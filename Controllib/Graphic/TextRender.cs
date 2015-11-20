using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Controllib.Graphic
{
    public static class TextRender
    {
        public static void DrawString(this Graphics g, string text, Font font, Brush brush, RectangleF rect, StringFormat format, bool allowNarrowSetWidth)
        {
            SizeF sz2 = g.MeasureString(text, font);
            float width = sz2.Width;

            // 글자 장평을 줄이는 방법
            if (width > rect.Width && allowNarrowSetWidth)
            {
                float mag = rect.Width / width;

                g.TranslateTransform(rect.Left, 0f);
                g.TranslateTransform(-rect.Width * mag * 0.5f, 0f);
                g.ScaleTransform(mag, 1f);
                g.TranslateTransform(rect.Width * 0.5f, 0f);
                g.TranslateTransform(-rect.Left, 0f);

                RectangleF rect2 = rect;
                rect2.Width = rect2.Width / mag;
                g.DrawString(text, font, brush, rect2, format);

                g.ResetTransform();
            }
            else
            {
                g.DrawString(text, font, brush, rect, format);
            }
        }

        public static void DrawStringWithGraphicsPath(this Graphics g, string text, Font font, Brush brush, RectangleF rect, StringFormat format, bool allowNarrowSetWidth = false)
        {
            var state = g.Save();

            SizeF sz2 = g.MeasureString(text, font);
            float width = sz2.Width;

            if (width > rect.Width && allowNarrowSetWidth)
            {
                float mag = rect.Width / width;

                g.TranslateTransform(rect.Left, 0f);
                g.TranslateTransform(-rect.Width * mag * 0.5f, 0f);
                g.ScaleTransform(mag, 1f);
                g.TranslateTransform(rect.Width * 0.5f, 0f);
                g.TranslateTransform(-rect.Left, 0f);

                rect.Width = rect.Width / mag;
            }

            float emSize = g.DpiY * font.Size / 72; // 다른의견 = font.Size + 4;
            GraphicsPath gp = new GraphicsPath();
            gp.AddString(text, font.FontFamily, (int)font.Style, emSize, rect, format);

            g.FillPath(brush, gp);
            g.Restore(state);
        }

    }

}
