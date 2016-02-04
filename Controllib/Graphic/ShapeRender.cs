using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Controllib.Graphic
{
    public static class ShapeRender
    {
        public static void DrawRoundRect(this Graphics g, Pen pen, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = GetRoundRect(x, y, width, height, radius);
            gp.CloseFigure();
            g.DrawPath(pen, gp);
            gp.Dispose();
        }

        public static void FillRoundRect(this Graphics g, Brush brush, float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = GetRoundRect(x, y, width, height, radius);
            gp.CloseFigure();
            g.FillPath(brush, gp);
            gp.Dispose();
        }

        public static void FillRoundRect(this Graphics g, Brush brush, RectangleF bounds, float radius)
        {
            g.FillRoundRect(brush, bounds.X, bounds.Y, bounds.Width, bounds.Height, radius);
        }
        public static void DrawRoundRect(this Graphics g, Pen pen, Rectangle rect, float radius)
        {
            DrawRoundRect(g, pen, rect.X, rect.Y, rect.Width, rect.Height, radius);
        }
        public static GraphicsPath GetTopRoundRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            //Upper-right arc:
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            ////Lower-right arc:
            gp.AddArc(x + width - (1 * 2), y + height - (1 * 2), 1 * 2, 1 * 2, 0, 90);
            ////Lower-left arc:
            gp.AddArc(x, y + height - (1 * 2), 1 * 2, 1 * 2, 90, 90);
            //Upper-left arc:
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);
            return gp;
        }

        private static GraphicsPath GetRoundRect(float x, float y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            //Upper-right arc:
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90);
            //Lower-right arc:
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            //Lower-left arc:
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            //Upper-left arc:
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            return gp;
        }


    }
}
