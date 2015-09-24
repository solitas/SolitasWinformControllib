using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Controllib
{
    public class AdvencedLabel : Control
    {
        private string _text;

        public string Text
        {
            set
            {
                if (!value.Equals(_text))
                {
                    _text = value;
                }
                Invalidate();
            }
            get
            {
                return _text;
            }
        }

        public AdvencedLabel() :base()
        {
            _text = string.Empty;
        }

        protected override void WndProc(ref Message m)
        {
            
        }
    }
}
