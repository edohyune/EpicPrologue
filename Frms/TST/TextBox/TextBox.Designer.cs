namespace Frms.TST
{
    partial class TextBox
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
            custId = new Ctrls.UCTextBox();
            custNm = new Ctrls.UCTextBox();
            custAge = new Ctrls.UCTextBox();
            SuspendLayout();
            // 
            // custId
            // 
            custId.BindText = "";
            custId.ButtonVisiable = true;
            custId.ControlWidth = 180;
            custId.Location = new Point(51, 35);
            custId.Name = "custId";
            custId.EditYn = false;
            custId.ShowYn = true;
            custId.Size = new Size(180, 20);
            custId.TabIndex = 0;
            custId.Title = "ID";
            custId.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            custId.TitleWidth = 80;
            // 
            // custNm
            // 
            custNm.BindText = "";
            custNm.ButtonVisiable = true;
            custNm.ControlWidth = 180;
            custNm.Location = new Point(51, 61);
            custNm.Name = "custNm";
            custNm.EditYn = true;
            custNm.ShowYn = true;
            custNm.Size = new Size(180, 20);
            custNm.TabIndex = 1;
            custNm.Title = "Name";
            custNm.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            custNm.TitleWidth = 80;
            // 
            // custAge
            // 
            custAge.BindText = "";
            custAge.ButtonVisiable = true;
            custAge.ControlWidth = 180;
            custAge.Location = new Point(51, 87);
            custAge.Name = "custAge";
            custAge.EditYn = true;
            custAge.ShowYn = true;
            custAge.Size = new Size(180, 20);
            custAge.TabIndex = 2;
            custAge.Title = "Age";
            custAge.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            custAge.TitleWidth = 80;
            // 
            // TextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(custAge);
            Controls.Add(custNm);
            Controls.Add(custId);
            Name = "TextBox";
            Size = new Size(800, 450);
            ResumeLayout(false);
        }

        #endregion

        private Ctrls.UCTextBox custId;
        private Ctrls.UCTextBox custNm;
        private Ctrls.UCTextBox custAge;
    }
}
