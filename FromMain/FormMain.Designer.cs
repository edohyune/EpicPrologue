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
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbForm.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)msgCtrl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuCtrl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabbedMdiManager).BeginInit();
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
            bar1.Offset = 256;
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
            barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            // 
            // barButtonShowMsg
            // 
            barButtonShowMsg.Caption = "Hide Message";
            barButtonShowMsg.Id = 4;
            barButtonShowMsg.Name = "barButtonShowMsg";
            barButtonShowMsg.ItemClick += barButtonShowMsg_ItemClick;
            // 
            // barSubItem1
            // 
            barSubItem1.Caption = "barSubItem1";
            barSubItem1.Id = 5;
            barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "Show In Templet";
            barButtonItem3.Id = 6;
            barButtonItem3.Name = "barButtonItem3";
            barButtonItem3.ItemClick += barButtonItem3_ItemClick;
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
            barDockControlTop.Size = new System.Drawing.Size(964, 21);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 490);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(964, 23);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 21);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 469);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(964, 21);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 469);
            // 
            // cmbForm
            // 
            cmbForm.EditValue = "Select";
            cmbForm.Location = new System.Drawing.Point(92, 0);
            cmbForm.MenuManager = barManager1;
            cmbForm.Name = "cmbForm";
            cmbForm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbForm.Size = new System.Drawing.Size(160, 20);
            cmbForm.TabIndex = 4;
            cmbForm.SelectedIndexChanged += cmbForm_SelectedIndexChanged;
            // 
            // msgCtrl
            // 
            msgCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            msgCtrl.Location = new System.Drawing.Point(0, 21);
            msgCtrl.MenuManager = barManager1;
            msgCtrl.Name = "msgCtrl";
            msgCtrl.Size = new System.Drawing.Size(383, 469);
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
            simpleButton1.Text = "simpleButton1";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // menuCtrl
            // 
            menuCtrl.Dock = System.Windows.Forms.DockStyle.Left;
            menuCtrl.Location = new System.Drawing.Point(383, 21);
            menuCtrl.Name = "menuCtrl";
            menuCtrl.Size = new System.Drawing.Size(216, 469);
            menuCtrl.TabIndex = 26;
            menuCtrl.DoubleClick += menuCtrl_DoubleClick;
            // 
            // xtraTabbedMdiManager
            // 
            xtraTabbedMdiManager.MdiParent = this;
            xtraTabbedMdiManager.SelectedPageChanged += xtraTabbedMdiManager_SelectedPageChanged;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(964, 513);
            Controls.Add(menuCtrl);
            Controls.Add(simpleButton1);
            Controls.Add(msgCtrl);
            Controls.Add(cmbForm);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            IsMdiContainer = true;
            Name = "FormMain";
            Text = "FormMaker";
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbForm.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)msgCtrl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)menuCtrl).EndInit();
            ((System.ComponentModel.ISupportInitialize)xtraTabbedMdiManager).EndInit();
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
    }
}

