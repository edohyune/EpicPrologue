
using DevExpress.XtraGrid.Views.Base;

namespace Frms
{
    partial class FRWCDE
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
            ucSplit1 = new Ctrls.UCSplit();
            ucSplit2 = new Ctrls.UCSplit();
            pnlCode = new Ctrls.UCPanel();
            grdCde = new Ctrls.UCGridSet();
            pnlReference = new Ctrls.UCPanel();
            grdRef = new Ctrls.UCGridSet();
            pnlCodeDetail = new Ctrls.UCPanel();
            grdDtl = new Ctrls.UCGridSet();
            ((System.ComponentModel.ISupportInitialize)ucSplit1).BeginInit();
            ucSplit1.Panel1.SuspendLayout();
            ucSplit1.Panel2.SuspendLayout();
            ucSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucSplit2).BeginInit();
            ucSplit2.Panel1.SuspendLayout();
            ucSplit2.Panel2.SuspendLayout();
            ucSplit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCode).BeginInit();
            pnlCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdCde).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlReference).BeginInit();
            pnlReference.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdRef).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlCodeDetail).BeginInit();
            pnlCodeDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdDtl).BeginInit();
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
            ucSplit1.Panel1.Controls.Add(ucSplit2);
            // 
            // ucSplit1.Panel2
            // 
            ucSplit1.Panel2.Controls.Add(pnlCodeDetail);
            ucSplit1.Size = new Size(800, 450);
            ucSplit1.SplitterDistance = 197;
            ucSplit1.TabIndex = 0;
            ucSplit1.TitleWidth = 50;
            // 
            // ucSplit2
            // 
            ucSplit2.Dock = DockStyle.Fill;
            ucSplit2.Location = new Point(0, 0);
            ucSplit2.Name = "ucSplit2";
            // 
            // ucSplit2.Panel1
            // 
            ucSplit2.Panel1.Controls.Add(pnlCode);
            // 
            // ucSplit2.Panel2
            // 
            ucSplit2.Panel2.Controls.Add(pnlReference);
            ucSplit2.Size = new Size(800, 197);
            ucSplit2.SplitterDistance = 544;
            ucSplit2.TabIndex = 0;
            ucSplit2.TitleWidth = 50;
            // 
            // pnlCode
            // 
            pnlCode.Controls.Add(grdCde);
            pnlCode.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Save", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("New", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Open", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            pnlCode.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            pnlCode.Dock = DockStyle.Fill;
            pnlCode.EditYn = true;
            pnlCode.Location = new Point(0, 0);
            pnlCode.Name = "pnlCode";
            pnlCode.ShowYn = true;
            pnlCode.Size = new Size(544, 197);
            pnlCode.TabIndex = 0;
            pnlCode.Text = "Code Master";
            pnlCode.CustomButtonClick += pnlCode_CustomButtonClick;
            // 
            // grdCde
            // 
            grdCde.ColumnAutoWidth = true;
            grdCde.Dock = DockStyle.Fill;
            grdCde.FocuseRowIndex = int.MinValue;
            grdCde.Location = new Point(2, 23);
            grdCde.MultiSelect = false;
            grdCde.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grdCde.Name = "grdCde";
            grdCde.openFld = null;
            grdCde.openFrm = null;
            grdCde.RowAutoHeigh = false;
            grdCde.ShowFindPanel = false;
            grdCde.ShowGroupPanel = true;
            grdCde.Size = new Size(540, 172);
            grdCde.TabIndex = 0;
            grdCde.UCInitNewRow += grdCde_UCInitNewRow;
            grdCde.UCFocusedRowChanged += grdCde_UCFocusedRowChanged;
            // 
            // pnlReference
            // 
            pnlReference.Controls.Add(grdRef);
            pnlReference.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Save", true, buttonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            pnlReference.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            pnlReference.Dock = DockStyle.Fill;
            pnlReference.EditYn = true;
            pnlReference.Location = new Point(0, 0);
            pnlReference.Name = "pnlReference";
            pnlReference.ShowYn = true;
            pnlReference.Size = new Size(252, 197);
            pnlReference.TabIndex = 1;
            pnlReference.Text = "Reference Field Config";
            pnlReference.CustomButtonClick += pnlReference_CustomButtonClick;
            // 
            // grdRef
            // 
            grdRef.ColumnAutoWidth = true;
            grdRef.Dock = DockStyle.Fill;
            grdRef.FocuseRowIndex = int.MinValue;
            grdRef.Location = new Point(2, 23);
            grdRef.MultiSelect = false;
            grdRef.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grdRef.Name = "grdRef";
            grdRef.openFld = null;
            grdRef.openFrm = null;
            grdRef.RowAutoHeigh = false;
            grdRef.ShowFindPanel = false;
            grdRef.ShowGroupPanel = true;
            grdRef.Size = new Size(248, 172);
            grdRef.TabIndex = 1;
            // 
            // pnlCodeDetail
            // 
            pnlCodeDetail.Controls.Add(grdDtl);
            pnlCodeDetail.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Save", true, buttonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            pnlCodeDetail.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            pnlCodeDetail.Dock = DockStyle.Fill;
            pnlCodeDetail.EditYn = true;
            pnlCodeDetail.Location = new Point(0, 0);
            pnlCodeDetail.Name = "pnlCodeDetail";
            pnlCodeDetail.ShowYn = true;
            pnlCodeDetail.Size = new Size(800, 249);
            pnlCodeDetail.TabIndex = 1;
            pnlCodeDetail.Text = "Code Detail";
            pnlCodeDetail.CustomButtonClick += pnlCodeDetail_CustomButtonClick;
            // 
            // grdDtl
            // 
            grdDtl.ColumnAutoWidth = true;
            grdDtl.Dock = DockStyle.Fill;
            grdDtl.FocuseRowIndex = int.MinValue;
            grdDtl.Location = new Point(2, 23);
            grdDtl.MultiSelect = false;
            grdDtl.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grdDtl.Name = "grdDtl";
            grdDtl.openFld = null;
            grdDtl.openFrm = null;
            grdDtl.RowAutoHeigh = false;
            grdDtl.ShowFindPanel = false;
            grdDtl.ShowGroupPanel = true;
            grdDtl.Size = new Size(796, 224);
            grdDtl.TabIndex = 1;
            // 
            // FRWCDE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucSplit1);
            Name = "FRWCDE";
            Size = new Size(800, 450);
            ucSplit1.Panel1.ResumeLayout(false);
            ucSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit1).EndInit();
            ucSplit1.ResumeLayout(false);
            ucSplit2.Panel1.ResumeLayout(false);
            ucSplit2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit2).EndInit();
            ucSplit2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlCode).EndInit();
            pnlCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdCde).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlReference).EndInit();
            pnlReference.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdRef).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCodeDetail).EndInit();
            pnlCodeDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdDtl).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private Ctrls.UCSplit ucSplit1;
        private Ctrls.UCSplit ucSplit2;
        private Ctrls.UCPanel pnlCode;
        private Ctrls.UCPanel pnlReference;
        private Ctrls.UCPanel pnlCodeDetail;
        private Ctrls.UCGridSet grdCde;
        private Ctrls.UCGridSet grdRef;
        private Ctrls.UCGridSet grdDtl;
    }
}
