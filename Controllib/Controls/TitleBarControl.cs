using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

using Controllib.Graphic;

namespace Controllib.Controls
{
    public class TitleBarControl : Control
    {
        private Color _backgroundColor;

        [Browsable(true), Category("apperance")]
        public Color BackgroundColor
        {
            set
            {
                _backgroundColor = value;
                Invalidate();
            }
            get { return _backgroundColor; }
        }

        public TitleBarControl()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw,
                true);
        }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            using (Brush brush = new SolidBrush(Parent.BackColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            PaintBackground(e.Graphics);
            PaintTitleText(e.Graphics);
        }

        private void PaintBackground(Graphics g)
        {
            const float outterMargin = 0;
            const float innerMargin = outterMargin + 0.5f;
            var borderColor = ControlPaint.Dark(BackgroundColor);

            using (Pen pen = new Pen(borderColor, 0.5f))
            {
                g.DrawRoundRect(pen, outterMargin, outterMargin, Width - outterMargin * 2, Height - outterMargin * 2, 2);
            }

            using (Brush brush = new SolidBrush(BackgroundColor))
            {
                g.FillRoundRect(brush, innerMargin, innerMargin, Width - innerMargin * 2, Height - innerMargin * 2, 2);
            }
        }

        private void PaintTitleText(Graphics g)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            float rectHeight = 30.0f;
            float rectWidth = 100.0f;

            if (rectWidth > Width)
            {
                rectWidth = Width * 0.4f;
            }

            if (rectHeight > Height)
            {
                rectHeight = Height * 0.5f;
            }

            Rectangle titleRect = new Rectangle((int)(Width * 0.01), (int)(Height * 0.2), (int)rectWidth, (int)rectHeight);

            Color fontColor = ControlPaint.LightLight(BackgroundColor);

            using (Brush brush = new SolidBrush(fontColor))
            {
                g.DrawStringWithGraphicsPath(Text, Font, brush, titleRect, StringFormat.GenericDefault);
            }
        }
    }
}
