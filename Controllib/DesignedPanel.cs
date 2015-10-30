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
    public class DesignedPanel : Panel
    {
        protected readonly int WS_EX_TRANSPARENT = 0x00000020;
        protected readonly int WS_EX_COMPOSITED = 0x02000000;
        public DesignedPanel()
        {
            //SetStyle( ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                //createParams.ExStyle |= WS_EX_COMPOSITED;
                createParams.ExStyle |= WS_EX_TRANSPARENT; // WS_EX_TRANSPARENT
                
                return createParams;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
           
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            Color backColor = Color.FromArgb(100, BackColor.R, BackColor.G, BackColor.B);
            Color shadowColor = Color.FromArgb(255, Color.Black);
            Rectangle rect = new Rectangle(0, 0, Width, Height);

            using (Brush brush = new SolidBrush(backColor))
            using (Brush shadowBrush = new SolidBrush(shadowColor))
            using (Pen pen = new Pen(Color.Black, 1.0f))
            {
                e.Graphics.FillRoundRect(brush, rect.X, rect.Y, rect.Width, rect.Height, 10.0f);
            }

            base.OnPaint(e);
        }
    }
}
