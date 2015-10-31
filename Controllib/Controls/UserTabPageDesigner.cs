using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Controllib.Controls
{
    public class UserTabPageDesigner : ScrollableControlDesigner
    {
        public UserTabPageDesigner() { }

        /// <summary>
		/// Shadows the <see cref="UserTabPage.Text"/> property.
		/// </summary>
		public string Text
        {
            get
            {
                return userTabPage.Text;
            }
            set
            {
                string ot = userTabPage.Text;
                userTabPage.Text = value;
                IComponentChangeService iccs = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                if (iccs != null)
                {
                    UserTabControl userTabControl = userTabPage.Parent as UserTabControl;
                    if (userTabControl != null)
                    {
                        userTabControl.SelectedIndex = userTabControl.SelectedIndex;
                    }
                }
            }
        }

        /// <summary>
        /// Overridden. Inherited from
        /// <see cref="ControlDesigner.OnPaintAdornments(PaintEventArgs)"/>.
        /// </summary>
        /// <param name="pea">
        /// Some <see cref="PaintEventArgs"/>.
        /// </param>
        protected override void OnPaintAdornments(PaintEventArgs pea)
        {
            base.OnPaintAdornments(pea);

            // My thanks to bschurter (Bruce), CodeProject member #1255339 for this!
            using (Pen p = new Pen(SystemColors.ControlDark, 1))
            {
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                pea.Graphics.DrawRectangle(p, 0, 0, userTabPage.Width - 1, userTabPage.Height - 1);
            }
        }

        /// <summary>
        /// Overridden. Inherited from <see cref="ControlDesigner.Initialize( IComponent )"/>.
        /// </summary>
        /// <param name="component">
        /// The <see cref="IComponent"/> hosted by the designer.
        /// </param>
        public override void Initialize(IComponent component)
        {
            userTabPage = component as UserTabPage;
            if (userTabPage == null)
            {
                DisplayError(new Exception("You attempted to use a UserTabPageDesigner with a class that does not inherit from UserTabPage."));
            }
            base.Initialize(component);
        }

        /// <summary>
        /// Overridden. Inherited from <see cref="ControlDesigner.PreFilterProperties(IDictionary)"/>.
        /// </summary>
        /// <param name="properties"></param>
        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            properties["Text"] = TypeDescriptor.CreateProperty(typeof(UserTabPageDesigner), (PropertyDescriptor)properties["Text"], new Attribute[0]);
        }

        /// <summary>
        /// The <see cref="UserTabPage"/> hosted by the designer.
        /// </summary>
        private UserTabPage userTabPage;
    }
}
