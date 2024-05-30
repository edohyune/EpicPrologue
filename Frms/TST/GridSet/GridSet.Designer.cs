using DevExpress.XtraBars.Docking2010;

namespace Frms.TST
{
    partial class GridSet
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions4 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions5 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions6 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions7 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            ucSplit1 = new Ctrls.UCSplit();
            ucPanel1 = new Ctrls.UCPanel();
            g10 = new Ctrls.UCGridSet();
            ucSplit2 = new Ctrls.UCSplit();
            ucPanel2 = new Ctrls.UCPanel();
            txtAge = new Ctrls.UCTextBox();
            txtNm = new Ctrls.UCTextBox();
            txtId = new Ctrls.UCTextBox();
            ucPanel3 = new Ctrls.UCPanel();
            g20 = new Ctrls.UCGridSet();
            ucSplit3 = new Ctrls.UCSplit();
            ucPanel4 = new Ctrls.UCPanel();
            sAge = new Ctrls.UCTextBox();
            sNm = new Ctrls.UCTextBox();
            sId = new Ctrls.UCTextBox();
            ((System.ComponentModel.ISupportInitialize)ucSplit1).BeginInit();
            ucSplit1.Panel1.SuspendLayout();
            ucSplit1.Panel2.SuspendLayout();
            ucSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ucPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)g10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucSplit2).BeginInit();
            ucSplit2.Panel1.SuspendLayout();
            ucSplit2.Panel2.SuspendLayout();
            ucSplit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel2).BeginInit();
            ucPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel3).BeginInit();
            ucPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)g20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucSplit3).BeginInit();
            ucSplit3.Panel1.SuspendLayout();
            ucSplit3.Panel2.SuspendLayout();
            ucSplit3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel4).BeginInit();
            ucPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // ucSplit1
            // 
            ucSplit1.Dock = DockStyle.Fill;
            ucSplit1.Location = new Point(0, 0);
            ucSplit1.Name = "ucSplit1";
            // 
            // ucSplit1.Panel1
            // 
            ucSplit1.Panel1.Controls.Add(ucSplit3);
            // 
            // ucSplit1.Panel2
            // 
            ucSplit1.Panel2.Controls.Add(ucSplit2);
            ucSplit1.Size = new Size(800, 450);
            ucSplit1.SplitterDistance = 266;
            ucSplit1.TabIndex = 0;
            ucSplit1.TitleWidth = 50;
            // 
            // ucPanel1
            // 
            ucPanel1.Controls.Add(g10);
            ucPanel1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Open", true, buttonImageOptions1, ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            ucPanel1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.EditYn = true;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.ShowYn = true;
            ucPanel1.Size = new Size(266, 338);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "People";
            ucPanel1.Title = "People";
            ucPanel1.CustomButtonClick += ucPanel1_CustomButtonClick;
            // 
            // g10
            // 
            g10.ColumnAutoWidth = true;
            g10.Dock = DockStyle.Fill;
            g10.FocuseRowIndex = int.MinValue;
            g10.Location = new Point(2, 23);
            g10.MultiSelect = false;
            g10.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            g10.Name = "g10";
            g10.openFld = null;
            g10.openFrm = null;
            g10.RowAutoHeigh = false;
            g10.ShowFindPanel = false;
            g10.ShowGroupPanel = true;
            g10.Size = new Size(262, 313);
            g10.TabIndex = 0;
            g10.UCFocusedRowChanged += g10_UCFocusedRowChanged;
            // 
            // ucSplit2
            // 
            ucSplit2.Dock = DockStyle.Fill;
            ucSplit2.Location = new Point(0, 0);
            ucSplit2.Name = "ucSplit2";
            ucSplit2.Orientation = Orientation.Horizontal;
            // 
            // ucSplit2.Panel1
            // 
            ucSplit2.Panel1.Controls.Add(ucPanel2);
            // 
            // ucSplit2.Panel2
            // 
            ucSplit2.Panel2.Controls.Add(ucPanel3);
            ucSplit2.Size = new Size(530, 450);
            ucSplit2.SplitterDistance = 110;
            ucSplit2.TabIndex = 1;
            ucSplit2.TitleWidth = 50;
            // 
            // ucPanel2
            // 
            ucPanel2.Controls.Add(txtAge);
            ucPanel2.Controls.Add(txtNm);
            ucPanel2.Controls.Add(txtId);
            ucPanel2.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("New", true, buttonImageOptions2, ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Save", true, buttonImageOptions3, ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Delete", true, buttonImageOptions4, ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            ucPanel2.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            ucPanel2.Dock = DockStyle.Fill;
            ucPanel2.EditYn = true;
            ucPanel2.Location = new Point(0, 0);
            ucPanel2.Name = "ucPanel2";
            ucPanel2.ShowYn = true;
            ucPanel2.Size = new Size(530, 110);
            ucPanel2.TabIndex = 0;
            ucPanel2.Text = "Person";
            ucPanel2.Title = "Person";
            ucPanel2.CustomButtonClick += ucPanel2_CustomButtonClick;
            // 
            // txtAge
            // 
            txtAge.BindText = "";
            txtAge.btnVisiable = false;
            txtAge.ControlWidth = 180;
            txtAge.EditYn = false;
            txtAge.Location = new Point(10, 83);
            txtAge.Name = "txtAge";
            txtAge.ShowYn = true;
            txtAge.Size = new Size(180, 20);
            txtAge.TabIndex = 2;
            txtAge.TextAlignment = DevExpress.Utils.HorzAlignment.Far;
            txtAge.Title = "AGE";
            txtAge.TitleAlignment = DevExpress.Utils.HorzAlignment.Far;
            txtAge.TitleWidth = 80;
            // 
            // txtNm
            // 
            txtNm.BindText = "";
            txtNm.btnVisiable = false;
            txtNm.ControlWidth = 180;
            txtNm.EditYn = false;
            txtNm.Location = new Point(10, 57);
            txtNm.Name = "txtNm";
            txtNm.ShowYn = true;
            txtNm.Size = new Size(180, 20);
            txtNm.TabIndex = 1;
            txtNm.TextAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtNm.Title = "Name";
            txtNm.TitleAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtNm.TitleWidth = 80;
            // 
            // txtId
            // 
            txtId.BindText = "";
            txtId.btnVisiable = false;
            txtId.ControlWidth = 180;
            txtId.EditYn = false;
            txtId.Location = new Point(10, 31);
            txtId.Name = "txtId";
            txtId.ShowYn = true;
            txtId.Size = new Size(180, 20);
            txtId.TabIndex = 0;
            txtId.TextAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtId.Title = "ID";
            txtId.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtId.TitleWidth = 80;
            // 
            // ucPanel3
            // 
            ucPanel3.Controls.Add(g20);
            ucPanel3.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("New", true, buttonImageOptions5, ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Save", true, buttonImageOptions6, ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Delete", true, buttonImageOptions7, ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            ucPanel3.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            ucPanel3.Dock = DockStyle.Fill;
            ucPanel3.EditYn = true;
            ucPanel3.Location = new Point(0, 0);
            ucPanel3.Name = "ucPanel3";
            ucPanel3.ShowYn = true;
            ucPanel3.Size = new Size(530, 336);
            ucPanel3.TabIndex = 1;
            ucPanel3.Text = "Detail";
            ucPanel3.Title = "Detail";
            ucPanel3.CustomButtonClick += ucPanel3_CustomButtonClick;
            // 
            // g20
            // 
            g20.ColumnAutoWidth = true;
            g20.Dock = DockStyle.Fill;
            g20.FocuseRowIndex = int.MinValue;
            g20.Location = new Point(2, 23);
            g20.MultiSelect = false;
            g20.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            g20.Name = "g20";
            g20.openFld = null;
            g20.openFrm = null;
            g20.RowAutoHeigh = false;
            g20.ShowFindPanel = false;
            g20.ShowGroupPanel = true;
            g20.Size = new Size(526, 311);
            g20.TabIndex = 0;
            // 
            // ucSplit3
            // 
            ucSplit3.Dock = DockStyle.Fill;
            ucSplit3.Location = new Point(0, 0);
            ucSplit3.Name = "ucSplit3";
            ucSplit3.Orientation = Orientation.Horizontal;
            // 
            // ucSplit3.Panel1
            // 
            ucSplit3.Panel1.Controls.Add(ucPanel4);
            // 
            // ucSplit3.Panel2
            // 
            ucSplit3.Panel2.Controls.Add(ucPanel1);
            ucSplit3.Size = new Size(266, 450);
            ucSplit3.SplitterDistance = 108;
            ucSplit3.TabIndex = 1;
            ucSplit3.TitleWidth = 50;
            // 
            // ucPanel4
            // 
            ucPanel4.Controls.Add(sAge);
            ucPanel4.Controls.Add(sNm);
            ucPanel4.Controls.Add(sId);
            ucPanel4.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            ucPanel4.Dock = DockStyle.Fill;
            ucPanel4.EditYn = true;
            ucPanel4.Location = new Point(0, 0);
            ucPanel4.Name = "ucPanel4";
            ucPanel4.ShowYn = true;
            ucPanel4.Size = new Size(266, 108);
            ucPanel4.TabIndex = 1;
            ucPanel4.Text = "Search";
            ucPanel4.Title = "Search";
            // 
            // sAge
            // 
            sAge.BindText = "";
            sAge.btnVisiable = false;
            sAge.ControlWidth = 180;
            sAge.EditYn = false;
            sAge.Location = new Point(10, 83);
            sAge.Name = "sAge";
            sAge.ShowYn = true;
            sAge.Size = new Size(180, 20);
            sAge.TabIndex = 2;
            sAge.TextAlignment = DevExpress.Utils.HorzAlignment.Far;
            sAge.Title = "AGE";
            sAge.TitleAlignment = DevExpress.Utils.HorzAlignment.Far;
            sAge.TitleWidth = 80;
            // 
            // sNm
            // 
            sNm.BindText = "";
            sNm.btnVisiable = false;
            sNm.ControlWidth = 180;
            sNm.EditYn = false;
            sNm.Location = new Point(10, 57);
            sNm.Name = "sNm";
            sNm.ShowYn = true;
            sNm.Size = new Size(180, 20);
            sNm.TabIndex = 1;
            sNm.TextAlignment = DevExpress.Utils.HorzAlignment.Center;
            sNm.Title = "Name";
            sNm.TitleAlignment = DevExpress.Utils.HorzAlignment.Center;
            sNm.TitleWidth = 80;
            // 
            // sId
            // 
            sId.BindText = "";
            sId.btnVisiable = false;
            sId.ControlWidth = 180;
            sId.EditYn = false;
            sId.Location = new Point(10, 31);
            sId.Name = "sId";
            sId.ShowYn = true;
            sId.Size = new Size(180, 20);
            sId.TabIndex = 0;
            sId.TextAlignment = DevExpress.Utils.HorzAlignment.Default;
            sId.Title = "ID";
            sId.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            sId.TitleWidth = 80;
            // 
            // GridSet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucSplit1);
            Name = "GridSet";
            Size = new Size(800, 450);
            Load += GridSet_Load;
            ucSplit1.Panel1.ResumeLayout(false);
            ucSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit1).EndInit();
            ucSplit1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)g10).EndInit();
            ucSplit2.Panel1.ResumeLayout(false);
            ucSplit2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit2).EndInit();
            ucSplit2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel2).EndInit();
            ucPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel3).EndInit();
            ucPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)g20).EndInit();
            ucSplit3.Panel1.ResumeLayout(false);
            ucSplit3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit3).EndInit();
            ucSplit3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel4).EndInit();
            ucPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private Ctrls.UCSplit ucSplit1;
        private Ctrls.UCPanel ucPanel1;
        private Ctrls.UCGridSet g10;
        private Ctrls.UCSplit ucSplit2;
        private Ctrls.UCPanel ucPanel2;
        private Ctrls.UCTextBox txtAge;
        private Ctrls.UCTextBox txtNm;
        private Ctrls.UCTextBox txtId;
        private Ctrls.UCPanel ucPanel3;
        private Ctrls.UCGridSet g20;
        private Ctrls.UCSplit ucSplit3;
        private Ctrls.UCPanel ucPanel4;
        private Ctrls.UCTextBox sAge;
        private Ctrls.UCTextBox sNm;
        private Ctrls.UCTextBox sId;
    }
}
