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

            float ratio = Math.Max((pathRect.Width / bounds.Width), (pathRect.Height / bounds.Height));

            g.DrawRectangle(Pens.Black, bounds);
            //g.TranslateTransform(-bounds.X, -bounds.Y);
            g.ScaleTransform(ratio + 1, ratio + 1);
            
            g.FillPath(brush, gPath);
            g.Restore(state);
        }
    }
}
