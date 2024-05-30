namespace Frms
{
    partial class CTRLFLD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTRLFLD));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            ucSplit1 = new Ctrls.UCSplit();
            pnlFrmCtrl = new Ctrls.UCPanel();
            grdFrmCtrl = new Ctrls.UCGridSet();
            pnlWrkFld = new Ctrls.UCPanel();
            grdWrkFld = new Ctrls.UCGridSet();
            pnlMain = new Ctrls.UCPanel();
            ((System.ComponentModel.ISupportInitialize)ucSplit1).BeginInit();
            ucSplit1.Panel1.SuspendLayout();
            ucSplit1.Panel2.SuspendLayout();
            ucSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFrmCtrl).BeginInit();
            pnlFrmCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdFrmCtrl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlWrkFld).BeginInit();
            pnlWrkFld.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdWrkFld).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlMain).BeginInit();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // ucSplit1
            // 
            ucSplit1.Dock = DockStyle.Fill;
            ucSplit1.Location = new Point(2, 23);
            ucSplit1.Name = "ucSplit1";
            ucSplit1.Orientation = Orientation.Horizontal;
            // 
            // ucSplit1.Panel1
            // 
            ucSplit1.Panel1.Controls.Add(pnlFrmCtrl);
            // 
            // ucSplit1.Panel2
            // 
            ucSplit1.Panel2.Controls.Add(pnlWrkFld);
            ucSplit1.Size = new Size(796, 425);
            ucSplit1.SplitterDistance = 212;
            ucSplit1.TabIndex = 0;
            ucSplit1.TitleWidth = 50;
            // 
            // pnlFrmCtrl
            // 
            pnlFrmCtrl.Controls.Add(grdFrmCtrl);
            pnlFrmCtrl.Dock = DockStyle.Fill;
            pnlFrmCtrl.EditYn = true;
            pnlFrmCtrl.Location = new Point(0, 0);
            pnlFrmCtrl.Name = "pnlFrmCtrl";
            pnlFrmCtrl.ShowYn = true;
            pnlFrmCtrl.Size = new Size(796, 212);
            pnlFrmCtrl.TabIndex = 2;
            pnlFrmCtrl.Text = "FRMCTRL";
            pnlFrmCtrl.Title = "FRMCTRL";
            // 
            // grdFrmCtrl
            // 
            grdFrmCtrl.AllowDrop = true;
            grdFrmCtrl.ColumnAutoWidth = true;
            grdFrmCtrl.Dock = DockStyle.Fill;
            grdFrmCtrl.FocuseRowIndex = int.MinValue;
            grdFrmCtrl.Location = new Point(2, 23);
            grdFrmCtrl.MultiSelect = false;
            grdFrmCtrl.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grdFrmCtrl.Name = "grdFrmCtrl";
            grdFrmCtrl.openFld = null;
            grdFrmCtrl.openFrm = null;
            grdFrmCtrl.RowAutoHeigh = false;
            grdFrmCtrl.ShowFindPanel = false;
            grdFrmCtrl.ShowGroupPanel = true;
            grdFrmCtrl.Size = new Size(792, 187);
            grdFrmCtrl.TabIndex = 0;
            grdFrmCtrl.UCMouseDown += grdFrmCtrl_UCMouseDown;
            // 
            // pnlWrkFld
            // 
            pnlWrkFld.Controls.Add(grdWrkFld);
            buttonImageOptions1.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("buttonImageOptions1.SvgImage");
            buttonImageOptions1.SvgImageSize = new Size(16, 16);
            pnlWrkFld.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("     GET     ", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            pnlWrkFld.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            pnlWrkFld.Dock = DockStyle.Fill;
            pnlWrkFld.EditYn = true;
            pnlWrkFld.Location = new Point(0, 0);
            pnlWrkFld.Name = "pnlWrkFld";
            pnlWrkFld.ShowYn = true;
            pnlWrkFld.Size = new Size(796, 209);
            pnlWrkFld.TabIndex = 1;
            pnlWrkFld.Text = "WRKFLD";
            pnlWrkFld.Title = "WRKFLD";
            // 
            // grdWrkFld
            // 
            grdWrkFld.AllowDrop = true;
            grdWrkFld.ColumnAutoWidth = true;
            grdWrkFld.Dock = DockStyle.Fill;
            grdWrkFld.FocuseRowIndex = int.MinValue;
            grdWrkFld.Location = new Point(2, 23);
            grdWrkFld.MultiSelect = false;
            grdWrkFld.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grdWrkFld.Name = "grdWrkFld";
            grdWrkFld.openFld = null;
            grdWrkFld.openFrm = null;
            grdWrkFld.RowAutoHeigh = false;
            grdWrkFld.ShowFindPanel = false;
            grdWrkFld.ShowGroupPanel = true;
            grdWrkFld.Size = new Size(792, 184);
            grdWrkFld.TabIndex = 0;
            grdWrkFld.DragDrop += grdWrkFld_DragDrop;
            grdWrkFld.DragOver += grdWrkFld_DragOver;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(ucSplit1);
            pnlMain.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Open", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.EditYn = true;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.ShowYn = true;
            pnlMain.Size = new Size(800, 450);
            pnlMain.TabIndex = 1;
            pnlMain.Title = null;
            pnlMain.CustomButtonClick += pnlMain_CustomButtonClick;
            // 
            // CTRLFLD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "CTRLFLD";
            Size = new Size(800, 450);
            ucSplit1.Panel1.ResumeLayout(false);
            ucSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit1).EndInit();
            ucSplit1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFrmCtrl).EndInit();
            pnlFrmCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdFrmCtrl).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlWrkFld).EndInit();
            pnlWrkFld.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdWrkFld).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlMain).EndInit();
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Ctrls.UCSplit ucSplit1;
        private Ctrls.UCGridSet grdWrkFld;
        private Ctrls.UCPanel pnlWrkFld;
        private Ctrls.UCPanel pnlMain;
        private Ctrls.UCPanel pnlFrmCtrl;
        private Ctrls.UCGridSet grdFrmCtrl;
    }
}
