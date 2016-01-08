using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllib.Controls
{
    public class UserButton : Button
    {
        public UserButton()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor |
                      ControlStyles.Opaque |
                      ControlStyles.ResizeRedraw |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.CacheText, // We gain about 2% in painting by avoiding extra GetWindowText calls
                      true);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
            
        }

        
    }
}
