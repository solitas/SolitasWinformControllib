using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Controllib.Graphic;
using Controllib.utils;

namespace Controllib
{
    public class DesignedPanel : Panel
    {
        private const int WS_EX_TRANSPARENT = 0x00000020;

        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_TRANSPARENT; // WS_EX_TRANSPARENT

                return createParams;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)Msgs.WmPaint)
            {
                using (var graphics = CreateGraphics())
                {
                    base.WndProc(ref m);
                    RenderBackGraphics(graphics);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        #region rendering methods

        private void RenderBackGraphics(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;

            var backColor = Color.FromArgb(100, BackColor.R, BackColor.G, BackColor.B);

            var rect = new Rectangle(0, 0, Width, Height);

            using (Brush brush = new SolidBrush(backColor))
            {
                g.FillRoundRect(brush, rect.X, rect.Y, rect.Width, rect.Height, 10.0f);
            }
        }

        #endregion
    }
}