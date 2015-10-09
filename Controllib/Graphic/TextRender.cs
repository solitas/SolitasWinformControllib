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
        public static void DrawStringWithGraphicsPath(this Graphics g, string s, Brush brush, Font font, Rectangle bounds, StringFormat format)
        {
            if (bounds.Width == 0 || bounds.Height == 0)
                return;
            var state = g.Save();

            GraphicsPath gPath = new GraphicsPath();
            SizeF stringSize = g.MeasureString(s, font);
            float emSize = font.SizeInPoints * 96.0f / 72.0f;
            gPath.AddString(s, font.FontFamily, (int)font.Style, emSize, bounds, format);


            RectangleF pathRect = gPath.GetBounds();

            float ratio = Math.Min((bounds.Width / pathRect.Width), (bounds.Height / pathRect.Height));

            //g.TranslateTransform(-bounds.X, -bounds.Y);

            if (ratio > 1)
            {
                using (Matrix matrix = new Matrix())
                {
                    matrix.Scale(ratio, ratio);
                    gPath.Transform(matrix);
                    matrix.Translate(-pathRect.X, -pathRect.Y);
                    matrix.Reset();
                }
            }
            g.DrawRectangle(Pens.Black, bounds);
            g.FillPath(brush, gPath);
            g.Restore(state);
        }

        public static void DrawString()
        {

        }

        private static void debugGraphics(string text, SizeF size, float emSize, Rectangle rect)
        {
            Console.WriteLine(text);
            Console.WriteLine("String Size : {0}", size);
            Console.WriteLine("EMSIZE : {0}", emSize);
            Console.WriteLine("Bounds : {0}", rect);
        }
    }
}
