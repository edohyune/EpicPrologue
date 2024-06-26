namespace Frms.TST
{
    partial class DynamicGrid
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
            g10 = new EpicV003.Ctrls.UCGridSet();
            SuspendLayout();
            // 
            // g10
            // 
            g10.Dock = DockStyle.Fill;
            g10.Location = new Point(0, 0);
            g10.Margin = new Padding(4, 3, 4, 3);
            g10.Name = "g10";
            g10.Size = new Size(400, 300);
            g10.TabIndex = 0;
            // 
            // DynamicGrid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(g10);
            Margin = new Padding(4, 3, 4, 3);
            Name = "DynamicGrid";
            Size = new Size(400, 300);
            ResumeLayout(false);
        }

        #endregion

        private EpicV003.Ctrls.UCGridSet g10;
    }
}
