using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllib.Controls
{
    /// <summary>
	/// Contains styles used to control the scroll buttons
	/// for a <see cref="YaTabControl"/>.
	/// </summary>
	public enum UserTabScrollButtonStyle
    {
        /// <summary>
        /// Indicates that the scroll buttons should get drawn
        /// regardless of whether the tabs extend beyond the
        /// visual tab area.
        /// </summary>
        Always,

        /// <summary>
        /// Indicates that the scroll buttons should get drawn
        /// only when the tabs extend beyond the visible span
        /// of the tab rectangle.
        /// </summary>
        Auto,

        /// <summary>
        /// Indicates that the scroll buttons should never get
        /// drawn.
        /// </summary>
        Never
    }
}
