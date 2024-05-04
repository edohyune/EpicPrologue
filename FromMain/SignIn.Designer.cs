namespace GAIA
{
    partial class SignIn
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
            btnSignInIDO = new DevExpress.XtraEditors.SimpleButton();
            btnSignInOthers = new DevExpress.XtraEditors.SimpleButton();
            txtId = new DevExpress.XtraEditors.TextEdit();
            txtPwd = new DevExpress.XtraEditors.TextEdit();
            lblResult = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)txtId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPwd.Properties).BeginInit();
            SuspendLayout();
            // 
            // btnSignInIDO
            // 
            btnSignInIDO.Location = new System.Drawing.Point(12, 130);
            btnSignInIDO.Name = "btnSignInIDO";
            btnSignInIDO.Size = new System.Drawing.Size(135, 109);
            btnSignInIDO.TabIndex = 0;
            btnSignInIDO.Text = "IDO";
            btnSignInIDO.Click += simpleButton1_Click;
            // 
            // btnSignInOthers
            // 
            btnSignInOthers.Location = new System.Drawing.Point(153, 130);
            btnSignInOthers.Name = "btnSignInOthers";
            btnSignInOthers.Size = new System.Drawing.Size(133, 109);
            btnSignInOthers.TabIndex = 1;
            btnSignInOthers.Text = "Others";
            btnSignInOthers.Click += simpleButton2_Click;
            // 
            // txtId
            // 
            txtId.EditValue = "ido@mupai.studio";
            txtId.Location = new System.Drawing.Point(47, 19);
            txtId.Name = "txtId";
            txtId.Size = new System.Drawing.Size(186, 20);
            txtId.TabIndex = 2;
            // 
            // txtPwd
            // 
            txtPwd.EditValue = "1";
            txtPwd.Location = new System.Drawing.Point(47, 45);
            txtPwd.Name = "txtPwd";
            txtPwd.Size = new System.Drawing.Size(186, 20);
            txtPwd.TabIndex = 3;
            // 
            // lblResult
            // 
            lblResult.Location = new System.Drawing.Point(47, 80);
            lblResult.Name = "lblResult";
            lblResult.Size = new System.Drawing.Size(0, 13);
            lblResult.TabIndex = 4;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(298, 268);
            Controls.Add(lblResult);
            Controls.Add(txtPwd);
            Controls.Add(txtId);
            Controls.Add(btnSignInOthers);
            Controls.Add(btnSignInIDO);
            Name = "SignIn";
            Text = "SignIn";
            ((System.ComponentModel.ISupportInitialize)txtId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPwd.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSignInIDO;
        private DevExpress.XtraEditors.SimpleButton btnSignInOthers;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.LabelControl lblResult;
    }
}