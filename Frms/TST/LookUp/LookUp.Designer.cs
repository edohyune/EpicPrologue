namespace Frms.TST
{
    partial class LookUp
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
            ucLookUp1 = new Ctrls.UCLookUp();
            ucLookUp2 = new Ctrls.UCLookUp();
            ucLookUp3 = new Ctrls.UCLookUp();
            lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)lookUpEdit1.Properties).BeginInit();
            SuspendLayout();
            // 
            // ucLookUp1
            // 
            ucLookUp1.BindText = "";
            ucLookUp1.ControlHeight = 21;
            ucLookUp1.ControlWidth = 723;
            ucLookUp1.Location = new Point(30, 34);
            ucLookUp1.Name = "ucLookUp1";
            ucLookUp1.Readonly = false;
            ucLookUp1.Size = new Size(723, 21);
            ucLookUp1.TabIndex = 0;
            ucLookUp1.TextAlignment = DevExpress.Utils.HorzAlignment.Near;
            ucLookUp1.Title = "UCLookUpEdit";
            ucLookUp1.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            ucLookUp1.TitleWidth = 50;
            // 
            // ucLookUp2
            // 
            ucLookUp2.BindText = "";
            ucLookUp2.ControlHeight = 21;
            ucLookUp2.ControlWidth = 723;
            ucLookUp2.Location = new Point(30, 143);
            ucLookUp2.Name = "ucLookUp2";
            ucLookUp2.Readonly = false;
            ucLookUp2.Size = new Size(723, 21);
            ucLookUp2.TabIndex = 1;
            ucLookUp2.TextAlignment = DevExpress.Utils.HorzAlignment.Near;
            ucLookUp2.Title = "UCLookUpEdit";
            ucLookUp2.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            ucLookUp2.TitleWidth = 50;
            // 
            // ucLookUp3
            // 
            ucLookUp3.BindText = "";
            ucLookUp3.ControlHeight = 21;
            ucLookUp3.ControlWidth = 723;
            ucLookUp3.Location = new Point(30, 258);
            ucLookUp3.Name = "ucLookUp3";
            ucLookUp3.Readonly = false;
            ucLookUp3.Size = new Size(723, 21);
            ucLookUp3.TabIndex = 2;
            ucLookUp3.TextAlignment = DevExpress.Utils.HorzAlignment.Near;
            ucLookUp3.Title = "UCLookUpEdit";
            ucLookUp3.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            ucLookUp3.TitleWidth = 50;
            // 
            // lookUpEdit1
            // 
            lookUpEdit1.Location = new Point(278, 366);
            lookUpEdit1.Name = "lookUpEdit1";
            lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown) });
            lookUpEdit1.Size = new Size(100, 20);
            lookUpEdit1.TabIndex = 3;
            // 
            // LookUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lookUpEdit1);
            Controls.Add(ucLookUp3);
            Controls.Add(ucLookUp2);
            Controls.Add(ucLookUp1);
            Name = "LookUp";
            Size = new Size(800, 450);
            ((System.ComponentModel.ISupportInitialize)lookUpEdit1.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Ctrls.UCLookUp ucLookUp1;
        private Ctrls.UCLookUp ucLookUp2;
        private Ctrls.UCLookUp ucLookUp3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
    }
}
