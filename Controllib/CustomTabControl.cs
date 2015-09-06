using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Controllib
{
    public class CustomTabControl : TabControl
    {
        private Container components = null;
        
        public CustomTabControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void InitializeComponent()
        {
            components = new Container();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            drawControl(e.Graphics);
        }

        private void drawControl(Graphics g)
        {
            if (!Visible)
                return;

            Rectangle tabControlArea = ClientRectangle;
            Rectangle tabArea = DisplayRectangle;

            // fill client area
            using (Brush brush = new SolidBrush(Color.Transparent))
            {
                g.FillRectangle(brush, tabControlArea);
            }

            // draw border
            Rectangle borderArea = tabArea;
            borderArea.Inflate(1, 1);
            using (Pen pen = new Pen(Color.Red, 3))
            {
                //g.DrawRectangle(pen, borderArea);
            }
            // clip region for drawing tabs
            Rectangle tabRect = GetTabRect(0);

            for( int index = 0; index < TabPages.Count; index++)
            {
                drawTabHeader(g, TabPages[index], index);
            }

        }

        private void drawTabHeader(Graphics g, TabPage page, int index)
        {
            int selectedIndex = SelectedIndex;
            Rectangle tabHeaderRect = GetTabRect(index);

            if (index == selectedIndex)
            {
                using (StringFormat format = new StringFormat())
                using (Brush backgroundBrush = new SolidBrush(page.BackColor))
                using (Brush fontBrush = new SolidBrush(Color.Black))
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    g.FillRectangle(backgroundBrush, tabHeaderRect);
                    g.DrawString(page.Text, Font, fontBrush, tabHeaderRect, format);
                }
            }
            else
            {
                using (StringFormat format = new StringFormat())
                using (Brush fontBrush = new SolidBrush(Color.Black))
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    g.DrawString(page.Text, Font, fontBrush, tabHeaderRect, format);
                }
            }
        }
    }
}
