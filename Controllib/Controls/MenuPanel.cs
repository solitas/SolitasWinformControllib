using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllib.Graphic;

namespace Controllib.Controls
{
    public class MenuPanel : Panel
    {
        public MenuPanel()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw|
                ControlStyles.SupportsTransparentBackColor,
                true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle clientRect = ClientRectangle;
            int x = 0;
            int y = 0;
            int width = Width;
            int height = Height;

            using (Brush background = new LinearGradientBrush(clientRect, Color.FromArgb(85,85,85), Color.FromArgb(65,65,65), 90f))
            {
                Rectangle backRect = new Rectangle(x, y, width, height);
                g.FillRectangle(background, backRect);
            }

            using (Pen topBorder = new Pen(Color.FromArgb(150, 150, 150), 1.2f))
            {
                Point left = new Point(0, 0);
                Point right = new Point(Width, 0);
                g.DrawLine(topBorder, left, right);
            }

            using (Pen topBorder = new Pen(Color.FromArgb(25, 25, 25), 1.5f))
            {
                Point left = new Point(0, Height-1);
                Point right = new Point(Width, Height-1);
                g.DrawLine(topBorder, left, right);
            }
        }
    }
}
