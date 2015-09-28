using Controllib.utils;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System;

namespace Controllib
{
    public class AdvencedLabel : Control
    {
        private string _text;

        public AdvencedLabel() : base()
        {
            setStyles();
            Text = "advencedLabel";
            Font = new Font("Consolas", 9.75f, FontStyle.Regular);
        }

        new public string Text
        {
            set
            {
                if (_text != null)
                {
                    if (!value.Equals(_text))
                    {
                        _text = value;
                        User32.Invalidate(Handle);
                    }
                }
                else
                {
                    _text = value;
                    User32.Invalidate(Handle);
                }
            }
            get
            {
                return _text;
            }
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
                        g.SmoothingMode = SmoothingMode.AntiAlias;
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
            if (Height <= 0 || Width <= 0)
                return;

            Rectangle bounds = new Rectangle(0, 0, Width, Height);
            SizeF size = g.MeasureString(Text, Font);

            using (Brush backBrush = new SolidBrush(Parent.BackColor))
            using (Brush fontBrush = new SolidBrush(ForeColor))
            {
                GraphicsPath fontPath = new GraphicsPath();
                fontPath.AddString(Text, Font.FontFamily , (int)Font.Style, Height, new Point(0, 0), new StringFormat());
                g.FillRectangle(backBrush, bounds);
                g.FillPath(fontBrush, fontPath);
                fontPath.Dispose();
            }
        }
    }
}