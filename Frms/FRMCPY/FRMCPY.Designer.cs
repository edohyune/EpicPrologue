
namespace Frms
{
    partial class FRMCPY
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
            txtSourcePath = new TextBox();
            btnSource = new Button();
            txtSourceClass = new TextBox();
            txtSourceNmSpace = new TextBox();
            btnDestination = new Button();
            btnCopy = new Button();
            txtDestinationPath = new TextBox();
            txtDestinationClass = new TextBox();
            txtDestinationNmSpace = new TextBox();
            SuspendLayout();
            // 
            // txtSourcePath
            // 
            txtSourcePath.Location = new Point(16, 18);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(312, 23);
            txtSourcePath.TabIndex = 0;
            // 
            // btnSource
            // 
            btnSource.Location = new Point(334, 17);
            btnSource.Name = "btnSource";
            btnSource.Size = new Size(75, 53);
            btnSource.TabIndex = 1;
            btnSource.Text = "Source";
            btnSource.UseVisualStyleBackColor = true;
            btnSource.Click += btnSource_Click;
            // 
            // txtSourceClass
            // 
            txtSourceClass.Location = new Point(16, 47);
            txtSourceClass.Name = "txtSourceClass";
            txtSourceClass.Size = new Size(85, 23);
            txtSourceClass.TabIndex = 2;
            // 
            // txtSourceNmSpace
            // 
            txtSourceNmSpace.Location = new Point(107, 47);
            txtSourceNmSpace.Name = "txtSourceNmSpace";
            txtSourceNmSpace.Size = new Size(221, 23);
            txtSourceNmSpace.TabIndex = 4;
            // 
            // btnDestination
            // 
            btnDestination.Location = new Point(334, 116);
            btnDestination.Name = "btnDestination";
            btnDestination.Size = new Size(75, 53);
            btnDestination.TabIndex = 6;
            btnDestination.Text = "Destination";
            btnDestination.UseVisualStyleBackColor = true;
            btnDestination.Click += btnDestination_Click;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(334, 221);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(75, 53);
            btnCopy.TabIndex = 9;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // txtDestinationPath
            // 
            txtDestinationPath.Location = new Point(16, 117);
            txtDestinationPath.Name = "txtDestinationPath";
            txtDestinationPath.Size = new Size(312, 23);
            txtDestinationPath.TabIndex = 5;
            // 
            // txtDestinationClass
            // 
            txtDestinationClass.Location = new Point(16, 146);
            txtDestinationClass.Name = "txtDestinationClass";
            txtDestinationClass.Size = new Size(85, 23);
            txtDestinationClass.TabIndex = 7;
            // 
            // txtDestinationNmSpace
            // 
            txtDestinationNmSpace.Location = new Point(107, 146);
            txtDestinationNmSpace.Name = "txtDestinationNmSpace";
            txtDestinationNmSpace.Size = new Size(221, 23);
            txtDestinationNmSpace.TabIndex = 8;
            // 
            // FRMCPY
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCopy);
            Controls.Add(txtDestinationNmSpace);
            Controls.Add(txtDestinationClass);
            Controls.Add(btnDestination);
            Controls.Add(txtDestinationPath);
            Controls.Add(txtSourceNmSpace);
            Controls.Add(txtSourceClass);
            Controls.Add(btnSource);
            Controls.Add(txtSourcePath);
            Name = "FRMCPY";
            Size = new Size(800, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtSourcePath;
        private Button btnSource;
        private TextBox txtSourceClass;
        private TextBox txtSourceNmSpace;
        private Button btnDestination;
        private Button btnCopy;
        private TextBox txtDestinationPath;
        private TextBox txtDestinationClass;
        private TextBox txtDestinationNmSpace;
    }
}
