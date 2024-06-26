namespace GAIA
{
    partial class FormLog
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            pnlLog = new EpicV003.Ctrls.UCPanel();
            logCtrl = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)pnlLog).BeginInit();
            pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logCtrl.Properties).BeginInit();
            SuspendLayout();
            // 
            // pnlLog
            // 
            pnlLog.Controls.Add(logCtrl);
            pnlLog.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("  Stop Log Tracking  ", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, true, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("  Clear  ", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("  Copy  ", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            pnlLog.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLog.EditYn = true;
            pnlLog.Location = new System.Drawing.Point(0, 0);
            pnlLog.Name = "pnlLog";
            pnlLog.ShowYn = true;
            pnlLog.Size = new System.Drawing.Size(354, 565);
            pnlLog.TabIndex = 32;
            pnlLog.CustomButtonClick += pnlLog_CustomButtonClick;
            pnlLog.CustomButtonUnchecked += pnlLog_CustomButtonUnchecked;
            pnlLog.CustomButtonChecked += pnlLog_CustomButtonChecked;
            // 
            // logCtrl
            // 
            logCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            logCtrl.EditValue = "";
            logCtrl.Location = new System.Drawing.Point(2, 23);
            logCtrl.Name = "logCtrl";
            logCtrl.Size = new System.Drawing.Size(350, 540);
            logCtrl.TabIndex = 10;
            // 
            // FormLog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(354, 565);
            Controls.Add(pnlLog);
            Name = "FormLog";
            Text = "FormLog";
            ((System.ComponentModel.ISupportInitialize)pnlLog).EndInit();
            pnlLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logCtrl.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private EpicV003.Ctrls.UCPanel pnlLog;
        private DevExpress.XtraEditors.MemoEdit logCtrl;
    }
}