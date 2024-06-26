namespace Frms.TST
{
    partial class Syntax
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
            txtMemo = new DevExpress.XtraEditors.MemoEdit();
            btnTEST01 = new EpicV003.Ctrls.UCButton();
            btnTEST02 = new EpicV003.Ctrls.UCButton();
            btnTEST03 = new EpicV003.Ctrls.UCButton();
            ucSplit1 = new EpicV003.Ctrls.UCSplit();
            ucSplit2 = new EpicV003.Ctrls.UCSplit();
            txtUCMemo = new EpicV003.Ctrls.UCMemo();
            richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)txtMemo.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucSplit1).BeginInit();
            ucSplit1.Panel1.SuspendLayout();
            ucSplit1.Panel2.SuspendLayout();
            ucSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucSplit2).BeginInit();
            ucSplit2.Panel1.SuspendLayout();
            ucSplit2.Panel2.SuspendLayout();
            ucSplit2.SuspendLayout();
            SuspendLayout();
            // 
            // txtMemo
            // 
            txtMemo.Dock = DockStyle.Fill;
            txtMemo.EditValue = "declare @_Val varchar\r\n   set @_val='VALUE'\r\n\r\nselect *\r\n  from WRKSQL a\r\n where 1=1\r\n   and a.FrmId = @_val\r\n   and a.FrwId = @FrwId\r\n   and a.CID = <$reg_id>";
            txtMemo.Location = new Point(0, 0);
            txtMemo.Name = "txtMemo";
            txtMemo.Size = new Size(258, 532);
            txtMemo.TabIndex = 0;
            // 
            // btnTEST01
            // 
            btnTEST01.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnTEST01.EditYn = true;
            btnTEST01.Location = new Point(0, 0);
            btnTEST01.Name = "btnTEST01";
            btnTEST01.Size = new Size(170, 35);
            btnTEST01.TabIndex = 1;
            btnTEST01.Text = "ucButton1";
            btnTEST01.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            btnTEST01.Click += btnTEST01_Click;
            // 
            // btnTEST02
            // 
            btnTEST02.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnTEST02.EditYn = true;
            btnTEST02.Location = new Point(0, 35);
            btnTEST02.Name = "btnTEST02";
            btnTEST02.Size = new Size(170, 35);
            btnTEST02.TabIndex = 2;
            btnTEST02.Text = "ucButton2";
            btnTEST02.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            btnTEST02.Click += btnTEST02_Click;
            // 
            // btnTEST03
            // 
            btnTEST03.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnTEST03.EditYn = true;
            btnTEST03.Location = new Point(0, 70);
            btnTEST03.Name = "btnTEST03";
            btnTEST03.Size = new Size(170, 35);
            btnTEST03.TabIndex = 3;
            btnTEST03.Text = "ucButton3";
            btnTEST03.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            btnTEST03.Click += btnTEST03_Click;
            // 
            // ucSplit1
            // 
            ucSplit1.Dock = DockStyle.Fill;
            ucSplit1.Location = new Point(0, 0);
            ucSplit1.Name = "ucSplit1";
            // 
            // ucSplit1.Panel1
            // 
            ucSplit1.Panel1.Controls.Add(txtMemo);
            ucSplit1.Panel1MinSize = 0;
            // 
            // ucSplit1.Panel2
            // 
            ucSplit1.Panel2.Controls.Add(ucSplit2);
            ucSplit1.Size = new Size(774, 532);
            ucSplit1.SplitterDistance = 258;
            ucSplit1.TabIndex = 4;
            ucSplit1.TitleWidth = 50;
            // 
            // ucSplit2
            // 
            ucSplit2.Dock = DockStyle.Fill;
            ucSplit2.Location = new Point(0, 0);
            ucSplit2.Name = "ucSplit2";
            // 
            // ucSplit2.Panel1
            // 
            ucSplit2.Panel1.Controls.Add(richEditControl1);
            ucSplit2.Panel1.Controls.Add(btnTEST03);
            ucSplit2.Panel1.Controls.Add(btnTEST01);
            ucSplit2.Panel1.Controls.Add(btnTEST02);
            // 
            // ucSplit2.Panel2
            // 
            ucSplit2.Panel2.Controls.Add(txtUCMemo);
            ucSplit2.Size = new Size(512, 532);
            ucSplit2.SplitterDistance = 170;
            ucSplit2.TabIndex = 4;
            ucSplit2.TitleWidth = 50;
            // 
            // txtUCMemo
            // 
            txtUCMemo.BindText = "ucMemo1";
            txtUCMemo.ControlWidth = 338;
            txtUCMemo.Dock = DockStyle.Fill;
            txtUCMemo.EditYn = false;
            txtUCMemo.Location = new Point(0, 0);
            txtUCMemo.Name = "txtUCMemo";
            txtUCMemo.ShowYn = true;
            txtUCMemo.Size = new Size(338, 532);
            txtUCMemo.TabIndex = 0;
            txtUCMemo.TextAlignment = DevExpress.Utils.HorzAlignment.Near;
            txtUCMemo.Title = "UCMemo";
            txtUCMemo.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtUCMemo.TitleWidth = 0;
            // 
            // richEditControl1
            // 
            richEditControl1.Location = new Point(2, 123);
            richEditControl1.Name = "richEditControl1";
            richEditControl1.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            richEditControl1.Size = new Size(165, 398);
            richEditControl1.TabIndex = 4;
            richEditControl1.RtfTextChanged += richEditControl1_RtfTextChanged;
            richEditControl1.TextChanged += richEditControl1_TextChanged;
            // 
            // Syntax
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucSplit1);
            Name = "Syntax";
            Size = new Size(774, 532);
            ((System.ComponentModel.ISupportInitialize)txtMemo.Properties).EndInit();
            ucSplit1.Panel1.ResumeLayout(false);
            ucSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit1).EndInit();
            ucSplit1.ResumeLayout(false);
            ucSplit2.Panel1.ResumeLayout(false);
            ucSplit2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit2).EndInit();
            ucSplit2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtMemo;
        private EpicV003.Ctrls.UCButton btnTEST01;
        private EpicV003.Ctrls.UCButton btnTEST02;
        private EpicV003.Ctrls.UCButton btnTEST03;
        private EpicV003.Ctrls.UCSplit ucSplit1;
        private EpicV003.Ctrls.UCSplit ucSplit2;
        private EpicV003.Ctrls.UCMemo txtUCMemo;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
    }
}
