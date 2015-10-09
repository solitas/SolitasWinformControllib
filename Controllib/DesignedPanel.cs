using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

using Controllib.Graphic;
namespace Controllib
{
    public class DesignedPanel : Control
    {
        public DesignedPanel()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color backColor = Color.FromArgb(255, 100, 255);

            Rectangle bounds = new Rectangle(0, 0, Width, Height);

            using (Brush backBrush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(backBrush, bounds);
            }

            using (Brush foreBrush = new SolidBrush(Color.White))
            {
                int x = 20;
                int y = 20;
                int width = (int) (Width * 0.3f);
                int height = (int) (Height * 0.25f);

                Rectangle titleRect = new Rectangle(x, y, width, height);
                GraphicsPath graphicsPath = new GraphicsPath();

                e.Graphics.DrawStringWithGraphicsPath(Text, foreBrush, Font, titleRect, StringFormat.GenericDefault);
            }
        }
    }
}
