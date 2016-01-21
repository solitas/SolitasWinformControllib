using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
namespace Controllib.Controls
{
    [ToolboxBitmap(typeof(UserButton)), ToolboxItem(true), ToolboxItemFilter("System.Windows.Forms"), Description("Raises an event when the user clicks it.")]
    public class UserButton : Button
    {
        private Color _backGroundColor;
        private Color _backColor;
        private Color _innerBorderColor;
        private Color _outerBorderColor;
        private Color _shineColor;
        private Color _glowColor;

        private bool _isHovered;
        private bool _isFocused;
        private bool _isFocusedByKey;
        private bool _isKeyDown;
        private bool _isMouseDown;
        

        public UserButton()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, false);
        }

        public virtual new Color BackColor
        {
            get { return _backColor; }
            set
            {
                if (!_backColor.Equals(value))
                {
                    _backColor = value;
                    UseVisualStyleBackColor = false;
                    OnBackColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the control.
        /// </summary>
        /// <returns>The foreground <see cref="T:System.Drawing.Color" /> of the control.</returns>
        [DefaultValue(typeof(Color), "White")]
        public virtual new Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
            }
        }

        [DefaultValue(typeof(Color), "Black"), Category("Appearance"), Description("The inner border color of the control.")]
        public virtual Color InnerBorderColor
        {
            get { return _innerBorderColor; }
            set
            {
                if (_innerBorderColor != value)
                {
                    _innerBorderColor = value;
                    if (IsHandleCreated)
                    {
                        Invalidate();
                    }
                    OnInnerBorderColorChanged(EventArgs.Empty);
                }
            }
        }
        [DefaultValue(typeof(Color), "White"), Category("Appearance"), Description("The outer border color of the control.")]
        public virtual Color OuterBorderColor
        {
            get { return _outerBorderColor; }
            set
            {
                if (_outerBorderColor != value)
                {
                    _outerBorderColor = value;
                    if (IsHandleCreated)
                    {
                        Invalidate();
                    }
                    OnOuterBorderColorChanged(EventArgs.Empty);
                }
            }
        }
        [DefaultValue(typeof(Color), "White"), Category("Appearance"), Description("The shine color of the control.")]
        public virtual Color ShineColor
        {
            get { return _shineColor; }
            set
            {
                if (_shineColor != value)
                {
                    _shineColor = value;
                    if (IsHandleCreated)
                    {
                        Invalidate();
                    }
                    OnShineColorChanged(EventArgs.Empty);
                }
            }
        }
        [DefaultValue(typeof(Color), "255,141,189,255"), Category("Appearance"), Description("The glow color of the control.")]
        public virtual Color GlowColor
        {
            get { return _glowColor; }
            set
            {
                if (_glowColor != value)
                {
                    _glowColor = value;
                    if (IsHandleCreated)
                    {
                        Invalidate();
                    }
                    OnGlowColorChanged(EventArgs.Empty);
                }
            }
        }

        private bool _fadeOnFocus;
        /// <summary>
        /// Gets or sets a value indicating whether the button should fade in and fade out when it's getting and loosing the focus.
        /// </summary>
        /// <value><c>true</c> if fading with changing the focus; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Category("Appearance"), Description("Indicates whether the button should fade in and fade out when it is getting and loosing the focus.")]
        public virtual bool FadeOnFocus
        {
            get { return _fadeOnFocus; }
            set
            {
                if (_fadeOnFocus != value)
                {
                    _fadeOnFocus = value;
                }
            }
        }
        private bool IsPressed { get { return _isKeyDown || (_isMouseDown && _isHovered); } }

        #region event 
        /// <summary>Occurs when the value of the <see cref="P:Glass.GlassButton.InnerBorderColor" /> property changes.</summary>
        [Description("Event raised when the value of the InnerBorderColor property is changed."), Category("Property Changed")]
        public event EventHandler InnerBorderColorChanged;
        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.InnerBorderColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnInnerBorderColorChanged(EventArgs e)
        {
            if (InnerBorderColorChanged != null)
            {
                InnerBorderColorChanged(this, e);
            }
        }
        /// <summary>Occurs when the value of the <see cref="P:Glass.GlassButton.OuterBorderColor" /> property changes.</summary>
        [Description("Event raised when the value of the OuterBorderColor property is changed."), Category("Property Changed")]
        public event EventHandler OuterBorderColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.OuterBorderColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnOuterBorderColorChanged(EventArgs e)
        {
            if (OuterBorderColorChanged != null)
            {
                OuterBorderColorChanged(this, e);
            }
        }

        /// <summary>Occurs when the value of the <see cref="P:Glass.GlassButton.ShineColor" /> property changes.</summary>
        [Description("Event raised when the value of the ShineColor property is changed."), Category("Property Changed")]
        public event EventHandler ShineColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.ShineColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnShineColorChanged(EventArgs e)
        {
            if (ShineColorChanged != null)
            {
                ShineColorChanged(this, e);
            }
        }

        /// <summary>Occurs when the value of the <see cref="P:Glass.GlassButton.GlowColor" /> property changes.</summary>
        [Description("Event raised when the value of the GlowColor property is changed."), Category("Property Changed")]
        public event EventHandler GlowColorChanged;

        /// <summary>
        /// Raises the <see cref="E:Glass.GlassButton.GlowColorChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected virtual void OnGlowColorChanged(EventArgs e)
        {
            if (GlowColorChanged != null)
            {
                GlowColorChanged(this, e);
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
        }

        #region " Overrided Methods "

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            _isKeyDown = _isMouseDown = false;
            base.OnClick(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Enter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnEnter(EventArgs e)
        {
            _isFocused = _isFocusedByKey = true;
            base.OnEnter(e);
            if (_fadeOnFocus)
            {
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Leave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            _isFocused = _isFocusedByKey = _isKeyDown = _isMouseDown = false;
            Invalidate();
            if (_fadeOnFocus)
            {
            }
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnKeyUp(System.Windows.Forms.KeyEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _isKeyDown = true;
                Invalidate();
            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.ButtonBase.OnKeyUp(System.Windows.Forms.KeyEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs" /> that contains the event data.</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (_isKeyDown && e.KeyCode == Keys.Space)
            {
                _isKeyDown = false;
                Invalidate();
            }
            base.OnKeyUp(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!_isMouseDown && e.Button == MouseButtons.Left)
            {
                _isMouseDown = true;
                _isFocusedByKey = false;
                Invalidate();
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseUp" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                _isMouseDown = false;
                Invalidate();
            }
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.OnMouseMove(System.Windows.Forms.MouseEventArgs)" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs" /> that contains the event data.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button != MouseButtons.None)
            {
                if (!ClientRectangle.Contains(e.X, e.Y))
                {
                    if (_isHovered)
                    {
                        _isHovered = false;
                        Invalidate();
                    }
                }
                else if (!_isHovered)
                {
                    _isHovered = true;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            //FadeIn();
            Invalidate();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            if (!(FadeOnFocus && _isFocusedByKey))
            {
                //FadeOut();
            }
                
            Invalidate();
            base.OnMouseLeave(e);
        }

        #endregion


        #region Code related to Paint

        private void PaintButtonBackground(Graphics g)
        {

        }

        #endregion
    }
}
