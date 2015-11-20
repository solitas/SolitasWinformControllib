namespace ControlTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.titleBarControl1 = new Controllib.Controls.TitleBarControl();
            this.userTabControl1 = new Controllib.Controls.UserTabControl();
            this.tabPage = new Controllib.Controls.UserTabPage();
            this.tabPage1 = new Controllib.Controls.UserTabPage();
            this.flatTabRenderer1 = new Controllib.Controls.FlatTabRenderer();
            this.userMenuStrip1 = new Controllib.Controls.UserMenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userTabControl1.SuspendLayout();
            this.userMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBarControl1
            // 
            this.titleBarControl1.BackColor = System.Drawing.Color.White;
            this.titleBarControl1.BackgroundColor = System.Drawing.Color.DimGray;
            this.titleBarControl1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBarControl1.Location = new System.Drawing.Point(6, 30);
            this.titleBarControl1.Name = "titleBarControl1";
            this.titleBarControl1.Size = new System.Drawing.Size(181, 27);
            this.titleBarControl1.TabIndex = 4;
            this.titleBarControl1.Text = "Project";
            // 
            // userTabControl1
            // 
            this.userTabControl1.ActiveColor = System.Drawing.Color.White;
            this.userTabControl1.BackColor = System.Drawing.Color.White;
            this.userTabControl1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.userTabControl1.Controls.Add(this.tabPage);
            this.userTabControl1.Controls.Add(this.tabPage1);
            this.userTabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.userTabControl1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userTabControl1.ForeColor = System.Drawing.Color.DimGray;
            this.userTabControl1.ImageIndex = -1;
            this.userTabControl1.ImageList = null;
            this.userTabControl1.InactiveColor = System.Drawing.Color.Gray;
            this.userTabControl1.Location = new System.Drawing.Point(762, 27);
            this.userTabControl1.Name = "userTabControl1";
            this.userTabControl1.OverIndex = -1;
            this.userTabControl1.Padding = new System.Windows.Forms.Padding(3);
            this.userTabControl1.ScrollButtonStyle = Controllib.Controls.UserTabScrollButtonStyle.Always;
            this.userTabControl1.SelectedIndex = 1;
            this.userTabControl1.SelectedTab = this.tabPage1;
            this.userTabControl1.Size = new System.Drawing.Size(279, 546);
            this.userTabControl1.TabDock = System.Windows.Forms.DockStyle.Top;
            this.userTabControl1.TabFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.userTabControl1.TabIndex = 1;
            this.userTabControl1.TabMargin = 3;
            this.userTabControl1.TabRenderer = this.flatTabRenderer1;
            this.userTabControl1.Text = "userTabControl1";
            // 
            // tabPage
            // 
            this.tabPage.BackColor = System.Drawing.Color.White;
            this.tabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage.ImageIndex = 0;
            this.tabPage.Location = new System.Drawing.Point(4, 33);
            this.tabPage.Name = "tabPage";
            this.tabPage.Size = new System.Drawing.Size(271, 509);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "데이터";
            // 
            // tabPage1
            // 
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(271, 509);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            // 
            // userMenuStrip1
            // 
            this.userMenuStrip1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.userMenuStrip1.ImageMarginGradientBegin = System.Drawing.Color.DimGray;
            this.userMenuStrip1.ImageMarginGradientEnd = System.Drawing.Color.WhiteSmoke;
            this.userMenuStrip1.ImageMarginGradientMiddle = System.Drawing.Color.WhiteSmoke;
            this.userMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.userMenuStrip1.Location = new System.Drawing.Point(3, 3);
            this.userMenuStrip1.MenuBorder = System.Drawing.Color.Black;
            this.userMenuStrip1.MenuItemBorder = System.Drawing.Color.Black;
            this.userMenuStrip1.MenuItemPressedGradientBegin = System.Drawing.Color.DimGray;
            this.userMenuStrip1.MenuItemPressedGradientEnd = System.Drawing.Color.DimGray;
            this.userMenuStrip1.MenuItemPressedGradientMiddle = System.Drawing.Color.DimGray;
            this.userMenuStrip1.MenuItemSelected = System.Drawing.Color.WhiteSmoke;
            this.userMenuStrip1.MenuItemSelectedGradientBegin = System.Drawing.Color.Black;
            this.userMenuStrip1.MenuItemSelectedGradientEnd = System.Drawing.Color.Black;
            this.userMenuStrip1.MenuStripForeColor = System.Drawing.Color.WhiteSmoke;
            this.userMenuStrip1.MenuStripGradientBegin = System.Drawing.Color.Black;
            this.userMenuStrip1.MenuStripGradientEnd = System.Drawing.Color.DimGray;
            this.userMenuStrip1.Name = "userMenuStrip1";
            this.userMenuStrip1.Size = new System.Drawing.Size(1038, 24);
            this.userMenuStrip1.TabIndex = 2;
            this.userMenuStrip1.Text = "userMenuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.openFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.newFileToolStripMenuItem.Text = "&New File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.openFileToolStripMenuItem.Text = "&Open File";
            // 
            // dataModelBindingSource
            // 
            this.dataModelBindingSource.DataSource = typeof(ControlTest.DataModel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1044, 576);
            this.Controls.Add(this.titleBarControl1);
            this.Controls.Add(this.userTabControl1);
            this.Controls.Add(this.userMenuStrip1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.userTabControl1.ResumeLayout(false);
            this.userMenuStrip1.ResumeLayout(false);
            this.userMenuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controllib.Controls.UserTabControl userTabControl1;
        private Controllib.Controls.UserTabPage tabPage;
        private Controllib.Controls.FlatTabRenderer flatTabRenderer1;
        private Controllib.Controls.UserTabPage tabPage1;
        private Controllib.Controls.UserMenuStrip userMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.BindingSource dataModelBindingSource;
        private Controllib.Controls.TitleBarControl titleBarControl1;
    }
}

