using DevExpress.XtraEditors;

namespace EpicV003.Ctrls
{
    partial class UCTextBox
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            splitCtrl = new SplitContainer();
            labelCtrl = new LabelControl();
            textCtrl = new ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)splitCtrl).BeginInit();
            splitCtrl.Panel1.SuspendLayout();
            splitCtrl.Panel2.SuspendLayout();
            splitCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textCtrl.Properties).BeginInit();
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
            splitCtrl.Panel2.Controls.Add(textCtrl);
            splitCtrl.Size = new Size(180, 21);
            splitCtrl.SplitterDistance = 80;
            splitCtrl.SplitterWidth = 1;
            splitCtrl.TabIndex = 0;
            // 
            // labelCtrl
            // 
            labelCtrl.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCtrl.Appearance.Options.UseFont = true;
            labelCtrl.Appearance.Options.UseTextOptions = true;
            labelCtrl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelCtrl.AutoSizeMode = LabelAutoSizeMode.None;
            labelCtrl.Dock = DockStyle.Fill;
            labelCtrl.Location = new Point(0, 0);
            labelCtrl.Name = "labelCtrl";
            labelCtrl.Size = new Size(80, 21);
            labelCtrl.TabIndex = 0;
            labelCtrl.Text = "UCTextBox";
            // 
            // textCtrl
            // 
            textCtrl.Dock = DockStyle.Fill;
            textCtrl.Location = new Point(0, 0);
            textCtrl.Name = "textCtrl";
            textCtrl.Properties.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textCtrl.Properties.Appearance.Options.UseFont = true;
            textCtrl.Properties.Appearance.Options.UseTextOptions = true;
            textCtrl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            textCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default) });
            textCtrl.Size = new Size(99, 20);
            textCtrl.TabIndex = 0;
            textCtrl.ButtonClick += textCtrl_ButtonClick;
            textCtrl.EditValueChanged += textCtrl_EditValueChanged;
            textCtrl.TextChanged += textCtrl_TextChanged;
            // 
            // UCTextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitCtrl);
            Name = "UCTextBox";
            Size = new Size(180, 21);
            Load += UCTextBox_Load;
            splitCtrl.Panel1.ResumeLayout(false);
            splitCtrl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitCtrl).EndInit();
            splitCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)textCtrl.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitCtrl;
        private DevExpress.XtraEditors.LabelControl labelCtrl;
        private DevExpress.XtraEditors.ButtonEdit textCtrl;
    }
}
