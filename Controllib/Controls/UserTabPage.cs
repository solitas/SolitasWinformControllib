using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Controllib.Controls
{
    [ToolboxItem(false)]
    [Designer(typeof(UserTabPageDesigner))]
    public class UserTabPage : ContainerControl
    {
        public UserTabPage()
        {
            Dock = DockStyle.Fill;
        }

        /// <summary>
		/// Gets or sets the index to the image displayed on this tab.
		/// </summary>
		/// <value>
		/// The zero-based index to the image in the <see cref="TabControl.ImageList"/>
		/// that appears on the tab. The default is -1, which signifies no image.
		/// </value>
		/// <exception cref="ArgumentException">
		/// The <see cref="ImageIndex"/> value is less than -1.
		/// </exception>
		public int ImageIndex
        {
            get
            {
                return imgIndex;
            }
            set
            {
                imgIndex = value;
            }
        }

        /// <summary>
        /// Overridden from <see cref="Panel"/>.
        /// </summary>
        /// <remarks>
        /// Since the <see cref="UserTabPage"/> exists only
        /// in the context of a <see cref="UserTabControl"/>,
        /// it makes sense to always have it fill the
        /// <see cref="UserTabControl"/>. Hence, this property
        /// will always return <see cref="DockStyle.Fill"/>
        /// regardless of how it is set.
        /// </remarks>
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }
            set
            {
                base.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Only here so that it shows up in the property panel.
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Overriden from <see cref="Control"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="UserTabPage.ControlCollection"/>.
        /// </returns>
        protected override System.Windows.Forms.Control.ControlCollection CreateControlsInstance()
        {
            return new UserTabPage.ControlCollection(this);
        }

        /// <summary>
        /// The index of the image to use for the tab that represents this
        /// <see cref="UserTabPage"/>.
        /// </summary>
        private int imgIndex;

        /// <summary>
        /// A <see cref="UserTabPage"/>-specific
        /// <see cref="Control.ControlCollection"/>.
        /// </summary>
        public new class ControlCollection : Control.ControlCollection
        {
            /// <summary>
            /// Creates a new instance of the
            /// <see cref="UserTabPage.ControlCollection"/> class with 
            /// the specified <i>owner</i>.
            /// </summary>
            /// <param name="owner">
            /// The <see cref="UserTabPage"/> that owns this collection.
            /// </param>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <i>owner</i> is <b>null</b>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <i>owner</i> is not a <see cref="UserTabPage"/>.
            /// </exception>
            public ControlCollection(Control owner) : base(owner)
            {
                if (owner == null)
                {
                    throw new ArgumentNullException("owner", "Tried to create a UserTabPage.ControlCollection with a null owner.");
                }
                UserTabPage c = owner as UserTabPage;
                if (c == null)
                {
                    throw new ArgumentException("Tried to create a UserTabPage.ControlCollection with a non-UserTabPage owner.", "owner");
                }
            }

            /// <summary>
            /// Overridden. Adds a <see cref="Control"/> to the
            /// <see cref="UserTabPage"/>.
            /// </summary>
            /// <param name="value">
            /// The <see cref="Control"/> to add, which must not be a
            /// <see cref="UserTabPage"/>.
            /// </param>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <i>value</i> is <b>null</b>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <i>value</i> is a <see cref="UserTabPage"/>.
            /// </exception>
            public override void Add(Control value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Tried to add a null value to the UserTabPage.ControlCollection.");
                }
                UserTabPage p = value as UserTabPage;
                if (p != null)
                {
                    throw new ArgumentException("Tried to add a UserTabPage control to the UserTabPage.ControlCollection.", "value");
                }
                base.Add(value);
            }
        }
    }
}
