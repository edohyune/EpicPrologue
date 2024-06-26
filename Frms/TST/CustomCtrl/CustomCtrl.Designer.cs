namespace Frms
{
    partial class CustomCtrl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ucCheckBox1 = new EpicV003.Ctrls.UCCheckBox();
            ((System.ComponentModel.ISupportInitialize)ucCheckBox1.Properties).BeginInit();
            SuspendLayout();
            // 
            // ucCheckBox1
            // 
            ucCheckBox1.BindValue = false;
            ucCheckBox1.Location = new Point(179, 198);
            ucCheckBox1.Name = "ucCheckBox1";
            ucCheckBox1.Properties.Caption = "ucCheckBox1";
            ucCheckBox1.Size = new Size(75, 20);
            ucCheckBox1.TabIndex = 0;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucCheckBox1);
            Name = "UserControl1";
            Size = new Size(433, 396);
            ((System.ComponentModel.ISupportInitialize)ucCheckBox1.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private EpicV003.Ctrls.UCCheckBox ucCheckBox1;
    }
}
