using System.Drawing;
using System.Windows.Forms;
using Controllib.Graphic;

namespace Controllib.Controls
{
    public class FlatTabRenderer : UserTabRenderer
    {
        public override DockStyle[] SupportedTabDockStyles
        {
            get
            {
                return new DockStyle[] { DockStyle.Bottom, DockStyle.Top, DockStyle.Left, DockStyle.Right };
            }
        }

        public override bool UsesHighlghts
        {
            get
            {
                return false;
            }
        }

        public override void DrawTab(Color foreColor, Color backColor, Color highlightColor, Color shadowColor, Color borderColor, bool active, bool mouseOver, DockStyle dock, Graphics graphics, SizeF tabSize)
        {
            RectangleF headerRect = new RectangleF(0, 0, tabSize.Width, tabSize.Height);
            Rectangle header = new Rectangle(0, 0, (int)tabSize.Width, (int)tabSize.Height);
            using (var path = ShapeRender.GetTopRoundRect(0, 0, tabSize.Width, tabSize.Height, 0.5f))
            {
                if (active)
                {
                    using (Brush brush = new SolidBrush(foreColor))
                    using (Pen pen = new Pen(shadowColor, 0.2f))
                    {
                        graphics.FillPath(brush, path);
                        graphics.DrawRectangle(pen, header);
                    }
                }
                else
                {
                    using (Brush brush = new SolidBrush(backColor))
                    using (Pen pen = new Pen(shadowColor))
                    {
                        graphics.FillPath(brush, path);
                    }
                }
            }
        }

        public override bool SupportsTabDockStyle(DockStyle dock)
        {
            return (dock != DockStyle.Fill && dock != DockStyle.None);
        }
    }
}