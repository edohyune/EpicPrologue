namespace Frms
{
    partial class GridTest
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
            g10 = new Ctrls.UCGrid();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)g10).BeginInit();
            SuspendLayout();
            // 
            // g10
            // 
            g10.Dock = System.Windows.Forms.DockStyle.Right;
            g10.gvCtrl = null;
            g10.Location = new System.Drawing.Point(126, 0);
            g10.Name = "g10";
            g10.Readonly = false;
            g10.Size = new System.Drawing.Size(638, 478);
            g10.TabIndex = 0;
            g10.UseEmbeddedNavigator = true;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(27, 25);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(27, 54);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // GridTest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(g10);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GridTest";
            Size = new System.Drawing.Size(764, 478);
            ((System.ComponentModel.ISupportInitialize)g10).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Ctrls.UCGrid g10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
