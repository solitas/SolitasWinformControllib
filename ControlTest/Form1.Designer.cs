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
            this.designedPanel1 = new Controllib.DesignedPanel();
            this.SuspendLayout();
            // 
            // designedPanel1
            // 
            this.designedPanel1.BackColor = System.Drawing.Color.Snow;
            this.designedPanel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.designedPanel1.Location = new System.Drawing.Point(12, 27);
            this.designedPanel1.Name = "designedPanel1";
            this.designedPanel1.Size = new System.Drawing.Size(1020, 134);
            this.designedPanel1.TabIndex = 2;
            this.designedPanel1.Text = "Title";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 576);
            this.Controls.Add(this.designedPanel1);
            this.Name = "Form1";
            this.Text = "test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Controllib.DesignedPanel designedPanel1;
    }
}

