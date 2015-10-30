using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllib
{
    public class AdvencedTextBox :  RichTextBox
    {
        public AdvencedTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint 
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw 
                | ControlStyles.UserPaint,
                true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
        }
    }
}
