using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Controllib.Controls
{
    public class UserTabControlDesigner : ControlDesigner
    {
        private static int ControlNameNumber;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONDBCLICK = 0x0203;

        private UserTabControl _userTabControl;

        private DesignerVerbCollection _verbs;

        public UserTabControlDesigner()
        {

        }

        public override void Initialize(IComponent component)
        {
            _userTabControl = component as UserTabControl;

            if (_userTabControl == null)
            {
                DisplayError(new ArgumentException("Tried to use the UserTabControlDesigner with a class that does not inherit from UserTabControl.", "component"));
            }

            base.Initialize(component);

            IComponentChangeService compChangeServ = (IComponentChangeService)GetService(typeof(IComponentChangeService));

            if (compChangeServ != null)
            {
                compChangeServ.ComponentRemoved += new ComponentEventHandler(ComponentRemoved);
            } 
        }
        
        /// <summary>
		/// Overridden. Inherited from <see cref="ControlDesigner"/>.
		/// </summary>
		public override DesignerVerbCollection Verbs
        {
            get
            {
                if (_verbs == null)
                {
                    _verbs = new DesignerVerbCollection();
                    _verbs.Add(new DesignerVerb("Add Tab", new EventHandler(AddTab)));
                    _verbs.Add(new DesignerVerb("Remove Tab", new EventHandler(RemoveTab)));
                }
                return _verbs;
            }
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                int x = 0;
                int y = 0;
                if (_userTabControl.Created && m.HWnd == _userTabControl.Handle)
                {
                    switch (m.Msg)
                    {
                        case WM_LBUTTONDOWN:
                            x = (m.LParam.ToInt32() << 16) >> 16;
                            y = m.LParam.ToInt32() >> 16;
                            int oi = _userTabControl.SelectedIndex;
                            UserTabPage tabPage = _userTabControl.SelectedTab;
                            if (_userTabControl.ScrollButtonStyle == UserTabScrollButtonStyle.Always && _userTabControl.GetLeftScrollButtonRect().Contains(x, y))
                            {
                                _userTabControl.ScrollTabs(-10);
                            }
                            else if (_userTabControl.ScrollButtonStyle == UserTabScrollButtonStyle.Always && _userTabControl.GetRightScrollButtonRect().Contains(x, y))
                            {
                                _userTabControl.ScrollTabs(10);
                            }
                            else
                            {
                                for (int i = 0; i < _userTabControl.Controls.Count; i++)
                                {
                                    Rectangle r = _userTabControl.GetTabRect(i);
                                    if (r.Contains(x, y))
                                    {
                                        _userTabControl.SelectedIndex = i;
                                        RaiseComponentChanging(TypeDescriptor.GetProperties(Control)["SelectedIndex"]);
                                        RaiseComponentChanged(TypeDescriptor.GetProperties(Control)["SelectedIndex"], oi, i);
                                        break;
                                    }
                                }
                            }
                            break;
                        case WM_LBUTTONDBCLICK:
                            x = (m.LParam.ToInt32() << 16) >> 16;
                            y = m.LParam.ToInt32() >> 16;
                            if (_userTabControl.ScrollButtonStyle == UserTabScrollButtonStyle.Always && _userTabControl.GetLeftScrollButtonRect().Contains(x, y))
                            {
                                _userTabControl.ScrollTabs(-10);
                            }
                            else if (_userTabControl.ScrollButtonStyle == UserTabScrollButtonStyle.Always && _userTabControl.GetRightScrollButtonRect().Contains(x, y))
                            {
                                _userTabControl.ScrollTabs(10);
                            }
                            return;
                    }
                }
            }
            finally
            {
                base.WndProc(ref m);
            }
        }

        public override void DoDefaultAction() { }

        private void ComponentRemoved (object sender, ComponentEventArgs args)
        {
            if (args.Component == _userTabControl.TabRenderer)
            {
                _userTabControl.TabRenderer = null;
                RaiseComponentChanging(TypeDescriptor.GetProperties(Control)["TabDrawer"]);
                RaiseComponentChanged(TypeDescriptor.GetProperties(Control)["TabDrawer"], args.Component, null);
            }
        }


        private void AddTab(object sender, EventArgs args)
        {
            IDesignerHost desingnerHost = (IDesignerHost)GetService(typeof(IDesignerHost));

            if (desingnerHost != null)
            {
                int i = _userTabControl.SelectedIndex;
                while (true)
                {
                    try
                    {
                        string name = GetNewTabName();
                        UserTabPage userTabPage = desingnerHost.CreateComponent(typeof(UserTabPage), name) as UserTabPage;
                        userTabPage.Text = name;
                        _userTabControl.Controls.Add(userTabPage);
                        _userTabControl.SelectedTab = userTabPage;
                        RaiseComponentChanging(TypeDescriptor.GetProperties(Control)["SelectedIndex"]);
                        RaiseComponentChanged(TypeDescriptor.GetProperties(Control)["SelectedIndex"], i, _userTabControl.SelectedIndex);
                        break;
                    }
                    catch (Exception) { }
                }
            }
        }

        private void RemoveTab(object sender, EventArgs args)
        {
            IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));

            if (designerHost != null)
            {
                int i = _userTabControl.SelectedIndex;
                if (i > -1)
                {
                    UserTabPage userTabPage = _userTabControl.SelectedTab;
                    _userTabControl.Controls.Remove(userTabPage);
                    designerHost.DestroyComponent(userTabPage);
                    RaiseComponentChanging(TypeDescriptor.GetProperties(Control)["SelectedIndex"]);
                    RaiseComponentChanged(TypeDescriptor.GetProperties(Control)["SelectedIndex"], i, 0);
                }
            }
        }

        private string GetNewTabName()
        {
            ControlNameNumber += 1;
            return "tabPage" + ControlNameNumber;
        }


    }
}
