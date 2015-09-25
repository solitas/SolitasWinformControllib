using Controllib.utils;
using System.Drawing;
using System.Windows.Forms;

namespace Controllib
{
    public class AdvencedLabel : Control
    {
        public AdvencedLabel() : base()
        {
            Text = "AdvencedLabel";
            setStyles();
        }

        private void setStyles()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, true);
        }

        #region WndProc override methods

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)Msgs.WM_PAINT:
                    base.WndProc(ref m);

                    using (Graphics g = Graphics.FromHwnd(Handle))
                    {
                        drawString(g, Text);
                    }
                   
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        #endregion WndProc override methods

        private void drawString(Graphics g, string text)
        {
            Rectangle bounds = new Rectangle(0, 0, Width, Height);
            SizeF size = g.MeasureString(Text, Font);
            
            using (Brush backBrush = new SolidBrush(Parent.BackColor))
            using (Brush fontBrush = new SolidBrush(ForeColor))
            {
                g.FillRectangle(backBrush, bounds);
                g.DrawString("AdvencedLabel", Font, fontBrush, bounds);
            }
        }
    }
}