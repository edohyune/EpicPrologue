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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            barBtnOpen = new DevExpress.XtraBars.BarButtonItem();
            barBtnNew = new DevExpress.XtraBars.BarButtonItem();
            barBtnSave = new DevExpress.XtraBars.BarButtonItem();
            barBtnDelete = new DevExpress.XtraBars.BarButtonItem();
            barBtnTemplate = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            barStaticItemMsg = new DevExpress.XtraBars.BarStaticItem();
            barStaticItemMessage = new DevExpress.XtraBars.BarStaticItem();
            barStaticItemForm = new DevExpress.XtraBars.BarStaticItem();
            barStaticItemUser = new DevExpress.XtraBars.BarStaticItem();
            barStaticItemSite = new DevExpress.XtraBars.BarStaticItem();
            barStaticItemTime = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            cmbForm = new DevExpress.XtraEditors.ComboBoxEdit();
            msgCtrl = new DevExpress.XtraEditors.MemoEdit();
            bar2 = new DevExpress.XtraBars.Bar();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            menuCtrl = new DevExpress.XtraEditors.ListBoxControl();
            xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(components);
            ucPanel1 = new EpicV001Ctrls.UCPanel();
            ucTab1 = new EpicV001Ctrls.UCTab();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barBtnOpen, barBtnNew, barMdiChildrenListItem1, barStaticItemMsg, barBtnSave, barSubItem1, barBtnTemplate, barBtnDelete, barButtonItem5, barStaticItemMessage, barStaticItemForm, barStaticItemUser, barStaticItemSite, barStaticItemTime });
            barManager1.MaxItemId = 15;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.FloatLocation = new System.Drawing.Point(537, 134);
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barBtnOpen, true), new DevExpress.XtraBars.LinkPersistInfo(barBtnNew, true), new DevExpress.XtraBars.LinkPersistInfo(barBtnSave, true), new DevExpress.XtraBars.LinkPersistInfo(barBtnDelete, true), new DevExpress.XtraBars.LinkPersistInfo(barBtnTemplate, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem5, true) });
            bar1.Offset = 273;
            bar1.Text = "Tools";
            // 
            // barBtnOpen
            // 
            barBtnOpen.Caption = "Open";
            barBtnOpen.Id = 0;
            barBtnOpen.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnOpen.ImageOptions.SvgImage");
            barBtnOpen.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q);
            barBtnOpen.Name = "barBtnOpen";
            barBtnOpen.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            barBtnOpen.ShortcutKeyDisplayString = "Q";
            barBtnOpen.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            barBtnOpen.ItemClick += barBtnOpen_ItemClick;
            // 
            // barBtnNew
            // 
            barBtnNew.Caption = "New";
            barBtnNew.Id = 1;
            barBtnNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnNew.ImageOptions.SvgImage");
            barBtnNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N);
            barBtnNew.Name = "barBtnNew";
            barBtnNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            barBtnNew.ShortcutKeyDisplayString = "N";
            barBtnNew.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            barBtnNew.ItemClick += barBtnNew_ItemClick;
            // 
            // barBtnSave
            // 
            barBtnSave.Caption = "Save";
            barBtnSave.Id = 4;
            barBtnSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnSave.ImageOptions.SvgImage");
            barBtnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S);
            barBtnSave.Name = "barBtnSave";
            barBtnSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            barBtnSave.ShortcutKeyDisplayString = "S";
            barBtnSave.ItemClick += barBtnSave_ItemClick;
            // 
            // barBtnDelete
            // 
            barBtnDelete.Caption = "Delete";
            barBtnDelete.Id = 7;
            barBtnDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnDelete.ImageOptions.SvgImage");
            barBtnDelete.Name = "barBtnDelete";
            barBtnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            barBtnDelete.ItemClick += barBtnDelete_ItemClick;
            // 
            // barBtnTemplate
            // 
            barBtnTemplate.Caption = "Show In Templet";
            barBtnTemplate.Id = 6;
            barBtnTemplate.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barBtnTemplate.ImageOptions.SvgImage");
            barBtnTemplate.Name = "barBtnTemplate";
            barBtnTemplate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            barBtnTemplate.ItemClick += barBtnTemplate_ItemClick;
            // 
            // barButtonItem5
            // 
            barButtonItem5.Id = 8;
            barButtonItem5.Name = "barButtonItem5";
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barMdiChildrenListItem1), new DevExpress.XtraBars.LinkPersistInfo(barStaticItemMsg), new DevExpress.XtraBars.LinkPersistInfo(barStaticItemMessage), new DevExpress.XtraBars.LinkPersistInfo(barStaticItemForm), new DevExpress.XtraBars.LinkPersistInfo(barStaticItemUser), new DevExpress.XtraBars.LinkPersistInfo(barStaticItemSite), new DevExpress.XtraBars.LinkPersistInfo(barStaticItemTime) });
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
            // barStaticItemMessage
            // 
            barStaticItemMessage.Caption = "barStaticItemMessage";
            barStaticItemMessage.Id = 10;
            barStaticItemMessage.Name = "barStaticItemMessage";
            // 
            // barStaticItemForm
            // 
            barStaticItemForm.Caption = "barStaticItemForm";
            barStaticItemForm.Id = 11;
            barStaticItemForm.Name = "barStaticItemForm";
            // 
            // barStaticItemUser
            // 
            barStaticItemUser.Caption = "barStaticItemUser";
            barStaticItemUser.Id = 12;
            barStaticItemUser.Name = "barStaticItemUser";
            // 
            // barStaticItemSite
            // 
            barStaticItemSite.Caption = "barStaticItemSite";
            barStaticItemSite.Id = 13;
            barStaticItemSite.Name = "barStaticItemSite";
            // 
            // barStaticItemTime
            // 
            barStaticItemTime.Caption = "barStaticItemTime";
            barStaticItemTime.Id = 14;
            barStaticItemTime.Name = "barStaticItemTime";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(1438, 25);
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
            barDockControlLeft.Location = new System.Drawing.Point(0, 25);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 820);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1438, 25);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 820);
            // 
            // barSubItem1
            // 
            barSubItem1.Id = 9;
            barSubItem1.Name = "barSubItem1";
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
            msgCtrl.Size = new System.Drawing.Size(264, 770);
            msgCtrl.TabIndex = 10;
            // 
            // bar2
            // 
            bar2.BarName = "Tools";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barBtnOpen), new DevExpress.XtraBars.LinkPersistInfo(barBtnNew), new DevExpress.XtraBars.LinkPersistInfo(barBtnSave) });
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
            menuCtrl.Size = new System.Drawing.Size(268, 795);
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
            ucPanel1.Size = new System.Drawing.Size(268, 795);
            ucPanel1.TabIndex = 31;
            ucPanel1.CustomButtonClick += ucPanel1_CustomButtonClick;
            ucPanel1.CustomButtonUnchecked += ucPanel1_CustomButtonUnchecked;
            ucPanel1.CustomButtonChecked += ucPanel1_CustomButtonChecked;
            // 
            // ucTab1
            // 
            ucTab1.Dock = System.Windows.Forms.DockStyle.Left;
            ucTab1.Location = new System.Drawing.Point(0, 25);
            ucTab1.Name = "ucTab1";
            ucTab1.SelectedTabPage = xtraTabPage1;
            ucTab1.Size = new System.Drawing.Size(270, 820);
            ucTab1.TabIndex = 32;
            ucTab1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2 });
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(menuCtrl);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new System.Drawing.Size(268, 795);
            xtraTabPage1.TabPageWidth = 120;
            xtraTabPage1.Text = "Menu";
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Controls.Add(ucPanel1);
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new System.Drawing.Size(268, 795);
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
            ClientSizeChanged += FormMain_ClientSizeChanged;
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
        private DevExpress.XtraEditors.ComboBoxEdit cmbForm;
        private DevExpress.XtraBars.BarButtonItem barBtnOpen;
        private DevExpress.XtraBars.BarButtonItem barBtnNew;
        private DevExpress.XtraBars.BarButtonItem barBtnSave;
        private DevExpress.XtraBars.BarButtonItem barBtnDelete;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barBtnTemplate;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItemMsg;
        private DevExpress.XtraEditors.MemoEdit msgCtrl;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ListBoxControl menuCtrl;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private EpicV001Ctrls.UCPanel ucPanel1;
        private EpicV001Ctrls.UCTab ucTab1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraBars.BarStaticItem barStaticItemMessage;
        private DevExpress.XtraBars.BarStaticItem barStaticItemForm;
        private DevExpress.XtraBars.BarStaticItem barStaticItemUser;
        private DevExpress.XtraBars.BarStaticItem barStaticItemSite;
        private DevExpress.XtraBars.BarStaticItem barStaticItemTime;
    }
}

