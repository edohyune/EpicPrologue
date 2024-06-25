namespace SplitPanelTab
{
    partial class SplitPanelTab
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            ucSplit1 = new EpicV001Ctrls.UCSplit();
            ucPanel1 = new EpicV001Ctrls.UCPanel();
            ucSplit2 = new EpicV001Ctrls.UCSplit();
            ucPanel2 = new EpicV001Ctrls.UCPanel();
            ucPanel3 = new EpicV001Ctrls.UCPanel();
            ucTab1 = new EpicV001Ctrls.UCTab();
            xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)ucSplit1).BeginInit();
            ucSplit1.Panel1.SuspendLayout();
            ucSplit1.Panel2.SuspendLayout();
            ucSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucSplit2).BeginInit();
            ucSplit2.Panel1.SuspendLayout();
            ucSplit2.Panel2.SuspendLayout();
            ucSplit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel3).BeginInit();
            ucPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucTab1).BeginInit();
            ucTab1.SuspendLayout();
            SuspendLayout();
            // 
            // ucSplit1
            // 
            ucSplit1.Dock = DockStyle.Fill;
            ucSplit1.Location = new Point(0, 0);
            ucSplit1.Name = "ucSplit1";
            ucSplit1.Orientation = Orientation.Horizontal;
            // 
            // ucSplit1.Panel1
            // 
            ucSplit1.Panel1.Controls.Add(ucPanel1);
            // 
            // ucSplit1.Panel2
            // 
            ucSplit1.Panel2.Controls.Add(ucSplit2);
            ucSplit1.Size = new Size(800, 450);
            ucSplit1.SplitterDistance = 149;
            ucSplit1.TabIndex = 0;
            // 
            // ucPanel1
            // 
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.EditYn = true;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.ShowYn = true;
            ucPanel1.Size = new Size(800, 149);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "ucPanel1";
            ucPanel1.DoubleClick += ucPanel1_DoubleClick;
            // 
            // ucSplit2
            // 
            ucSplit2.Dock = DockStyle.Fill;
            ucSplit2.Location = new Point(0, 0);
            ucSplit2.Name = "ucSplit2";
            // 
            // ucSplit2.Panel1
            // 
            ucSplit2.Panel1.Controls.Add(ucPanel2);
            // 
            // ucSplit2.Panel2
            // 
            ucSplit2.Panel2.Controls.Add(ucPanel3);
            ucSplit2.Size = new Size(800, 297);
            ucSplit2.SplitterDistance = 398;
            ucSplit2.TabIndex = 0;
            // 
            // ucPanel2
            // 
            ucPanel2.Dock = DockStyle.Fill;
            ucPanel2.EditYn = true;
            ucPanel2.Location = new Point(0, 0);
            ucPanel2.Name = "ucPanel2";
            ucPanel2.ShowYn = true;
            ucPanel2.Size = new Size(398, 297);
            ucPanel2.TabIndex = 1;
            ucPanel2.Text = "ucPanel2";
            ucPanel2.DoubleClick += ucPanel2_DoubleClick;
            // 
            // ucPanel3
            // 
            ucPanel3.Controls.Add(ucTab1);
            ucPanel3.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Tab1", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Tab2", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Tab3", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            ucPanel3.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            ucPanel3.Dock = DockStyle.Fill;
            ucPanel3.EditYn = true;
            ucPanel3.Location = new Point(0, 0);
            ucPanel3.Name = "ucPanel3";
            ucPanel3.ShowYn = true;
            ucPanel3.Size = new Size(398, 297);
            ucPanel3.TabIndex = 1;
            ucPanel3.Text = "ucPanel3";
            ucPanel3.CustomButtonClick += ucPanel3_CustomButtonClick;
            // 
            // ucTab1
            // 
            ucTab1.Dock = DockStyle.Fill;
            ucTab1.Location = new Point(2, 23);
            ucTab1.Name = "ucTab1";
            ucTab1.SelectedTabPage = xtraTabPage3;
            ucTab1.Size = new Size(394, 272);
            ucTab1.TabIndex = 0;
            ucTab1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2, xtraTabPage3 });
            // 
            // xtraTabPage3
            // 
            xtraTabPage3.Name = "xtraTabPage3";
            xtraTabPage3.Size = new Size(392, 247);
            xtraTabPage3.Text = "xtraTabPage3";
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new Size(392, 247);
            xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new Size(392, 247);
            xtraTabPage2.Text = "xtraTabPage2";
            // 
            // SplitPanelTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucSplit1);
            Name = "SplitPanelTab";
            Size = new Size(800, 450);
            ucSplit1.Panel1.ResumeLayout(false);
            ucSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit1).EndInit();
            ucSplit1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucSplit2.Panel1.ResumeLayout(false);
            ucSplit2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit2).EndInit();
            ucSplit2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel3).EndInit();
            ucPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucTab1).EndInit();
            ucTab1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private EpicV001Ctrls.UCSplit ucSplit1;
        private EpicV001Ctrls.UCPanel ucPanel1;
        private EpicV001Ctrls.UCSplit ucSplit2;
        private EpicV001Ctrls.UCPanel ucPanel2;
        private EpicV001Ctrls.UCPanel ucPanel3;
        private EpicV001Ctrls.UCTab ucTab1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    }
}
