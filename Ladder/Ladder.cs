using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ladder
{
    public class Ladder  : Control
    {
        private const int _linePanelWidth = 50;

        private int _numberOfLine = 0;

        public Ladder()
        {
            _numberOfLine = 0;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            DrawLineNumberArea(g);
        }

        private void DrawLineNumberArea(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, _numberOfLine, Height);
            using (Brush backBrush = new SolidBrush(Color.FromArgb(100, 100, 100)))
            {
                g.FillRectangle(backBrush, rect);
            }
        }
    }
}
