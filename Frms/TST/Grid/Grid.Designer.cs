namespace Grid
{
    partial class Grid
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
            ucPanel1 = new Ctrls.UCPanel();
            g10 = new Ctrls.UCGrid();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ucPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)g10).BeginInit();
            SuspendLayout();
            // 
            // ucPanel1
            // 
            ucPanel1.Controls.Add(g10);
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.Readonly = false;
            ucPanel1.Size = new Size(488, 432);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "ucPanel1";
            ucPanel1.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            // 
            // g10
            // 
            g10.Dock = DockStyle.Fill;
            g10.gvCtrl = null;
            g10.Location = new Point(2, 23);
            g10.Name = "g10";
            g10.Readonly = false;
            g10.Size = new Size(484, 407);
            g10.TabIndex = 0;
            g10.UseEmbeddedNavigator = true;
            // 
            // Grid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucPanel1);
            Name = "Grid";
            Size = new Size(488, 432);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)g10).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Ctrls.UCPanel ucPanel1;
        private Ctrls.UCGrid g10;
    }
}
