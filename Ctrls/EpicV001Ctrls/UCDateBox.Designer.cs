namespace EpicV001Ctrls
{
    partial class UCDateBox
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
            dateCtrl = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)splitCtrl).BeginInit();
            splitCtrl.Panel1.SuspendLayout();
            splitCtrl.Panel2.SuspendLayout();
            splitCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dateCtrl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateCtrl.Properties.CalendarTimeProperties).BeginInit();
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
            splitCtrl.Panel2.Controls.Add(dateCtrl);
            splitCtrl.Size = new Size(180, 21);
            splitCtrl.SplitterDistance = 80;
            splitCtrl.SplitterWidth = 1;
            splitCtrl.TabIndex = 1;
            // 
            // labelCtrl
            // 
            labelCtrl.Appearance.Options.UseFont = true;
            labelCtrl.Appearance.Options.UseTextOptions = true;
            labelCtrl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelCtrl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelCtrl.Dock = DockStyle.Fill;
            labelCtrl.Location = new Point(0, 0);
            labelCtrl.Name = "labelCtrl";
            labelCtrl.Size = new Size(80, 21);
            labelCtrl.TabIndex = 1;
            labelCtrl.Text = "UCDateBox";
            // 
            // dateCtrl
            // 
            dateCtrl.Dock = DockStyle.Fill;
            dateCtrl.EditValue = null;
            dateCtrl.Location = new Point(0, 0);
            dateCtrl.Name = "dateCtrl";
            dateCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateCtrl.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateCtrl.Size = new Size(99, 20);
            dateCtrl.TabIndex = 0;
            dateCtrl.EditValueChanged += dateCtrl_EditValueChanged;
            dateCtrl.TextChanged += dateCtrl_TextChanged;
            // 
            // UCDateBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitCtrl);
            Name = "UCDateBox";
            Size = new Size(180, 21);
            splitCtrl.Panel1.ResumeLayout(false);
            splitCtrl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitCtrl).EndInit();
            splitCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dateCtrl.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateCtrl.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitCtrl;
        private DevExpress.XtraEditors.LabelControl labelCtrl;
        private DevExpress.XtraEditors.DateEdit dateCtrl;
    }
}
