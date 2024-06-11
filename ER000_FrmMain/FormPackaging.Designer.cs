namespace ER000
{
    partial class FormPackaging
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
            barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            memoLog = new DevExpress.XtraEditors.MemoEdit();
            Contents = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)memoLog.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Contents).BeginInit();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barCheckItem1, barButtonItem1, barButtonItem2, barButtonItem3, barButtonItem4, barButtonItem5 });
            barManager1.MaxItemId = 6;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barCheckItem1), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem1, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem2, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem3, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem4, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem5, true) });
            bar1.Text = "Tools";
            // 
            // barCheckItem1
            // 
            barCheckItem1.Caption = "Log";
            barCheckItem1.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            barCheckItem1.Id = 0;
            barCheckItem1.Name = "barCheckItem1";
            barCheckItem1.CheckedChanged += barCheckItem1_CheckedChanged;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 1;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "barButtonItem2";
            barButtonItem2.Id = 2;
            barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "barButtonItem3";
            barButtonItem3.Id = 3;
            barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "barButtonItem4";
            barButtonItem4.Id = 4;
            barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            barButtonItem5.Caption = "barButtonItem5";
            barButtonItem5.Id = 5;
            barButtonItem5.Name = "barButtonItem5";
            barButtonItem5.ItemClick += barButtonItem5_ItemClick;
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(1072, 0);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 505);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(1072, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 505);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1072, 0);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 505);
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(memoLog);
            groupControl1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Clear", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Copy", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Log Capture", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, true, true, null, -1) });
            groupControl1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            groupControl1.Location = new System.Drawing.Point(0, 0);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(329, 505);
            groupControl1.TabIndex = 11;
            groupControl1.Text = "Log";
            groupControl1.CustomButtonClick += groupControl1_CustomButtonClick;
            groupControl1.CustomButtonChecked += groupControl1_CustomButtonChecked;
            // 
            // memoLog
            // 
            memoLog.Dock = System.Windows.Forms.DockStyle.Fill;
            memoLog.EditValue = "";
            memoLog.Location = new System.Drawing.Point(2, 23);
            memoLog.MenuManager = barManager1;
            memoLog.Name = "memoLog";
            // 
            // 
            // 
            memoLog.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            memoLog.Size = new System.Drawing.Size(325, 480);
            memoLog.TabIndex = 6;
            // 
            // Contents
            // 
            Contents.Dock = System.Windows.Forms.DockStyle.Fill;
            Contents.Location = new System.Drawing.Point(329, 0);
            Contents.Name = "Contents";
            Contents.Size = new System.Drawing.Size(743, 505);
            Contents.TabIndex = 16;
            Contents.Text = "groupControl2";
            // 
            // FormPackaging
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1072, 505);
            Controls.Add(Contents);
            Controls.Add(groupControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "FormPackaging";
            Text = "FormPackaging";
            Load += FormPackaging_Load;
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)memoLog.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Contents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit memoLog;
        private DevExpress.XtraEditors.GroupControl Contents;
    }
}