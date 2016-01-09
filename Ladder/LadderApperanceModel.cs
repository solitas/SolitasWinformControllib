using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;

namespace Ladder
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class LadderApperanceModel
    {
        private Color _backColor;
        private Color _railColor;
        private Color _gridColor;
        private Color _lineNumAreaBackColor;

        public Color RailColor
        {
            set
            {
                _railColor = value;
            }
            get
            {
                return _railColor;
            }
        }
        public Color GridColor
        {
            set
            {
                _gridColor = value;
            }
            get
            {
                return _gridColor;
            }
        }
        public Color BackColor
        {
            get
            {
                return _backColor;
            }

            set
            {
                _backColor = value;
            }
        }
        public Color LineNumAreaBackColor
        {
            get
            {
                return _lineNumAreaBackColor;
            }

            set
            {
                _lineNumAreaBackColor = value;
            }
        }

        public LadderApperanceModel()
        {
            RailColor = Color.FromArgb(255, 0, 0);
            GridColor = Color.FromArgb(255, 0, 255);
            BackColor = Color.FromArgb(255, 255, 255);
            LineNumAreaBackColor = Color.FromArgb(100, 100, 100);
        }
    }
}
