

namespace EpicV003.Ctrls
{
    partial class UCChkCodeBox
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
            splitCtrl = new SplitContainer();
            labelCtrl = new DevExpress.XtraEditors.LabelControl();
            chkcmbCtrl = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)splitCtrl).BeginInit();
            splitCtrl.Panel1.SuspendLayout();
            splitCtrl.Panel2.SuspendLayout();
            splitCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chkcmbCtrl.Properties).BeginInit();
            SuspendLayout();
            // 
            // splitCtrl
            // 
            splitCtrl.Dock = DockStyle.Fill;
            splitCtrl.FixedPanel = FixedPanel.Panel1;
            splitCtrl.IsSplitterFixed = true;
            splitCtrl.Location = new Point(0, 0);
            splitCtrl.Name = "splitCtrl";
            // 
            // splitCtrl.Panel1
            // 
            splitCtrl.Panel1.Controls.Add(labelCtrl);
            // 
            // splitCtrl.Panel2
            // 
            splitCtrl.Panel2.Controls.Add(chkcmbCtrl);
            splitCtrl.Size = new Size(154, 18);
            splitCtrl.SplitterDistance = 69;
            splitCtrl.SplitterWidth = 1;
            splitCtrl.TabIndex = 1;
            // 
            // labelCtrl
            // 
            labelCtrl.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCtrl.Appearance.Options.UseFont = true;
            labelCtrl.Appearance.Options.UseTextOptions = true;
            labelCtrl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelCtrl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelCtrl.Dock = DockStyle.Fill;
            labelCtrl.Location = new Point(0, 0);
            labelCtrl.Name = "labelCtrl";
            labelCtrl.Size = new Size(69, 18);
            labelCtrl.TabIndex = 0;
            labelCtrl.Text = "UCChkCodeBox";
            // 
            // chkcmbCtrl
            // 
            chkcmbCtrl.Dock = DockStyle.Fill;
            chkcmbCtrl.Location = new Point(0, 0);
            chkcmbCtrl.Name = "chkcmbCtrl";
            chkcmbCtrl.Properties.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkcmbCtrl.Properties.Appearance.Options.UseFont = true;
            chkcmbCtrl.Properties.Appearance.Options.UseTextOptions = true;
            chkcmbCtrl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            chkcmbCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            chkcmbCtrl.Size = new Size(84, 20);
            chkcmbCtrl.TabIndex = 0;
            chkcmbCtrl.EditValueChanged += chkcmbCtrl_EditValueChanged;
            // 
            // UCChkCodeBox
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitCtrl);
            Name = "UCChkCodeBox";
            Size = new Size(154, 18);
            Load += UCChkCodeBox_Load;
            splitCtrl.Panel1.ResumeLayout(false);
            splitCtrl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitCtrl).EndInit();
            splitCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chkcmbCtrl.Properties).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private SplitContainer splitCtrl;
        private DevExpress.XtraEditors.LabelControl labelCtrl;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkcmbCtrl;
    }
}
