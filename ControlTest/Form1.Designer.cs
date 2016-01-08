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
            this.stepControl1 = new Controllib.Controls.StepControl();
            this.ladder1 = new Ladder.Ladder();
            this.dataModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // stepControl1
            // 
            this.stepControl1.Location = new System.Drawing.Point(18, 16);
            this.stepControl1.Name = "stepControl1";
            this.stepControl1.Size = new System.Drawing.Size(309, 176);
            this.stepControl1.TabIndex = 0;
            this.stepControl1.Text = "stepControl1";
            // 
            // ladder1
            // 
            this.ladder1.Location = new System.Drawing.Point(244, 34);
            this.ladder1.Name = "ladder1";
            this.ladder1.Size = new System.Drawing.Size(257, 158);
            this.ladder1.TabIndex = 1;
            this.ladder1.Text = "ladder1";
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
            this.Controls.Add(this.ladder1);
            this.Controls.Add(this.stepControl1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource dataModelBindingSource;
        private Controllib.Controls.StepControl stepControl1;
        private Ladder.Ladder ladder1;
    }
}

