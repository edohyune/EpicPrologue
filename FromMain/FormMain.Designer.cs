namespace GAIA
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barButtonShowMsg = new DevExpress.XtraBars.BarButtonItem();
            barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            barStaticItemMsg = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            cmbForm = new DevExpress.XtraEditors.ComboBoxEdit();
            msgCtrl = new DevExpress.XtraEditors.MemoEdit();
            bar2 = new DevExpress.XtraBars.Bar();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            menuCtrl = new DevExpress.XtraEditors.ListBoxControl();
            xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(components);
            ucPanel1 = new Ctrls.UCPanel();
            ucTab1 = new Ctrls.UCTab();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbForm.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)msgCtrl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuCtrl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabbedMdiManager).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ucPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucTab1).BeginInit();
            ucTab1.SuspendLayout();
            xtraTabPage1.SuspendLayout();
            xtraTabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1, barButtonItem2, barMdiChildrenListItem1, barStaticItemMsg, barButtonShowMsg, barSubItem1, barButtonItem3 });
            barManager1.MaxItemId = 7;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.FloatLocation = new System.Drawing.Point(537, 134);
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItem1), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem2), new DevExpress.XtraBars.LinkPersistInfo(barButtonShowMsg), new DevExpress.XtraBars.LinkPersistInfo(barSubItem1), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem3) });
            bar1.Offset = 273;
            bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Query";
            barButtonItem1.Id = 0;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Select System";
            barButtonItem2.Id = 1;
            barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonShowMsg
            // 
            barButtonShowMsg.Caption = "Show Message";
            barButtonShowMsg.Id = 4;
            barButtonShowMsg.Name = "barButtonShowMsg";
            // 
            // barSubItem1
            // 
            barSubItem1.Caption = "barSubItem1";
            barSubItem1.Id = 5;
            barSubItem1.Name = "barSubItem1";
            barSubItem1.ItemClick += barSubItem1_ItemClick;
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "Show In Templet";
            barButtonItem3.Id = 6;
            barButtonItem3.Name = "barButtonItem3";
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barMdiChildrenListItem1), new DevExpress.XtraBars.LinkPersistInfo(barStaticItemMsg) });
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barMdiChildrenListItem1
            // 
            barMdiChildrenListItem1.Id = 2;
            barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // barStaticItemMsg
            // 
            barStaticItemMsg.Id = 3;
            barStaticItemMsg.Name = "barStaticItemMsg";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(1438, 21);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 845);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(1438, 23);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 824);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1438, 21);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 824);
            // 
            // cmbForm
            // 
            cmbForm.EditValue = "Select";
            cmbForm.Location = new System.Drawing.Point(92, 0);
            cmbForm.MenuManager = barManager1;
            cmbForm.Name = "cmbForm";
            cmbForm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cmbForm.Properties.Appearance.Options.UseFont = true;
            cmbForm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbForm.Size = new System.Drawing.Size(178, 20);
            cmbForm.TabIndex = 4;
            cmbForm.SelectedIndexChanged += cmbForm_SelectedIndexChanged;
            // 
            // msgCtrl
            // 
            msgCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            msgCtrl.Location = new System.Drawing.Point(2, 23);
            msgCtrl.MenuManager = barManager1;
            msgCtrl.Name = "msgCtrl";
            msgCtrl.Size = new System.Drawing.Size(264, 774);
            msgCtrl.TabIndex = 10;
            // 
            // bar2
            // 
            bar2.BarName = "Tools";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItem1), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem2), new DevExpress.XtraBars.LinkPersistInfo(barButtonShowMsg) });
            bar2.Offset = 169;
            bar2.Text = "Tools";
            // 
            // simpleButton1
            // 
            simpleButton1.Location = new System.Drawing.Point(8, 0);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(80, 20);
            simpleButton1.TabIndex = 20;
            simpleButton1.Text = "ShowMenu";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // menuCtrl
            // 
            menuCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            menuCtrl.Location = new System.Drawing.Point(0, 0);
            menuCtrl.Name = "menuCtrl";
            menuCtrl.Size = new System.Drawing.Size(268, 799);
            menuCtrl.TabIndex = 26;
            menuCtrl.DoubleClick += menuCtrl_DoubleClick;
            // 
            // xtraTabbedMdiManager
            // 
            xtraTabbedMdiManager.MdiParent = this;
            xtraTabbedMdiManager.SelectedPageChanged += xtraTabbedMdiManager_SelectedPageChanged;
            // 
            // ucPanel1
            // 
            ucPanel1.Controls.Add(msgCtrl);
            ucPanel1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("    Tracking    ", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("  Clear  ", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("  Copy  ", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            ucPanel1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            ucPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPanel1.EditYn = true;
            ucPanel1.Location = new System.Drawing.Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.ShowYn = true;
            ucPanel1.Size = new System.Drawing.Size(268, 799);
            ucPanel1.TabIndex = 31;
            ucPanel1.Text = null;
            ucPanel1.CustomButtonClick += ucPanel1_CustomButtonClick;
            ucPanel1.CustomButtonUnchecked += ucPanel1_CustomButtonUnchecked;
            ucPanel1.CustomButtonChecked += ucPanel1_CustomButtonChecked;
            // 
            // ucTab1
            // 
            ucTab1.Dock = System.Windows.Forms.DockStyle.Left;
            ucTab1.Location = new System.Drawing.Point(0, 21);
            ucTab1.Name = "ucTab1";
            ucTab1.SelectedTabPage = xtraTabPage1;
            ucTab1.Size = new System.Drawing.Size(270, 824);
            ucTab1.TabIndex = 32;
            ucTab1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2 });
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(menuCtrl);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new System.Drawing.Size(268, 799);
            xtraTabPage1.TabPageWidth = 120;
            xtraTabPage1.Text = "Menu";
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Controls.Add(ucPanel1);
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new System.Drawing.Size(268, 799);
            xtraTabPage2.TabPageWidth = 120;
            xtraTabPage2.Text = "Message";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1438, 868);
            Controls.Add(ucTab1);
            Controls.Add(simpleButton1);
            Controls.Add(cmbForm);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            IsMdiContainer = true;
            Name = "FormMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Epic Prologue";
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbForm.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)msgCtrl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuCtrl).EndInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabbedMdiManager).EndInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucTab1).EndInit();
            ucTab1.ResumeLayout(false);
            xtraTabPage1.ResumeLayout(false);
            xtraTabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbForm;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemMsg;
        private DevExpress.XtraEditors.MemoEdit msgCtrl;
        private DevExpress.XtraBars.BarButtonItem barButtonShowMsg;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ListBoxControl menuCtrl;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private Ctrls.UCPanel ucPanel1;
        private Ctrls.UCTab ucTab1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    }
}

