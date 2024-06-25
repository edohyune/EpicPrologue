namespace Frms
{
    partial class FLDMAKE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLDMAKE));
            ucSplit1 = new Ctrls.UCSplit();
            pnlFrmCtrl = new Ctrls.UCPanel();
            grdFrmCtrl = new Ctrls.UCGridSet();
            pnlWrkFld = new Ctrls.UCPanel();
            grdWrkFld = new Ctrls.UCGridSet();
            ucSplit2 = new Ctrls.UCSplit();
            ucPanel1 = new Ctrls.UCPanel();
            ucButton1 = new Ctrls.UCButton();
            cmbFrm = new Ctrls.UCCodeBox();
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
            ((System.ComponentModel.ISupportInitialize)ucSplit2).BeginInit();
            ucSplit2.Panel1.SuspendLayout();
            ucSplit2.Panel2.SuspendLayout();
            ucSplit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ucPanel1.SuspendLayout();
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
            ucSplit1.Panel1.Controls.Add(pnlFrmCtrl);
            // 
            // ucSplit1.Panel2
            // 
            ucSplit1.Panel2.Controls.Add(pnlWrkFld);
            ucSplit1.Size = new Size(800, 393);
            ucSplit1.SplitterDistance = 195;
            ucSplit1.TabIndex = 0;
            ucSplit1.TitleWidth = 50;
            // 
            // pnlFrmCtrl
            // 
            pnlFrmCtrl.Controls.Add(grdFrmCtrl);
            pnlFrmCtrl.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Open", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            pnlFrmCtrl.Dock = DockStyle.Fill;
            pnlFrmCtrl.EditYn = true;
            pnlFrmCtrl.Location = new Point(0, 0);
            pnlFrmCtrl.Name = "pnlFrmCtrl";
            pnlFrmCtrl.ShowYn = true;
            pnlFrmCtrl.Size = new Size(800, 195);
            pnlFrmCtrl.TabIndex = 2;
            pnlFrmCtrl.Text = "FRMCTRL";
            // 
            // grdFrmCtrl
            // 
            grdFrmCtrl.ColumnAutoWidth = true;
            grdFrmCtrl.Dock = DockStyle.Fill;
            grdFrmCtrl.FocuseRowIndex = int.MinValue;
            grdFrmCtrl.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grdFrmCtrl.Location = new Point(2, 23);
            grdFrmCtrl.MultiSelect = false;
            grdFrmCtrl.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grdFrmCtrl.Name = "grdFrmCtrl";
            grdFrmCtrl.RowAutoHeigh = false;
            grdFrmCtrl.ShowFindPanel = false;
            grdFrmCtrl.ShowGroupPanel = true;
            grdFrmCtrl.Size = new Size(796, 170);
            grdFrmCtrl.TabIndex = 0;
            grdFrmCtrl.DoubleClick += grdFrmCtrl_DoubleClick;
            // 
            // pnlWrkFld
            // 
            pnlWrkFld.Controls.Add(grdWrkFld);
            buttonImageOptions4.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("buttonImageOptions4.SvgImage");
            buttonImageOptions4.SvgImageSize = new Size(16, 16);
            pnlWrkFld.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Save", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Delete", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("     GET     ", true, buttonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            pnlWrkFld.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            pnlWrkFld.Dock = DockStyle.Fill;
            pnlWrkFld.EditYn = true;
            pnlWrkFld.Location = new Point(0, 0);
            pnlWrkFld.Name = "pnlWrkFld";
            pnlWrkFld.ShowYn = true;
            pnlWrkFld.Size = new Size(800, 194);
            pnlWrkFld.TabIndex = 1;
            pnlWrkFld.Text = "WRKFLD";
            // 
            // grdWrkFld
            // 
            grdWrkFld.ColumnAutoWidth = true;
            grdWrkFld.Dock = DockStyle.Fill;
            grdWrkFld.FocuseRowIndex = int.MinValue;
            grdWrkFld.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grdWrkFld.Location = new Point(2, 23);
            grdWrkFld.MultiSelect = false;
            grdWrkFld.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grdWrkFld.Name = "grdWrkFld";
            grdWrkFld.RowAutoHeigh = false;
            grdWrkFld.ShowFindPanel = false;
            grdWrkFld.ShowGroupPanel = true;
            grdWrkFld.Size = new Size(796, 169);
            grdWrkFld.TabIndex = 0;
            // 
            // ucSplit2
            // 
            ucSplit2.Dock = DockStyle.Fill;
            ucSplit2.FixedPanel = FixedPanel.Panel1;
            ucSplit2.Location = new Point(0, 0);
            ucSplit2.Name = "ucSplit2";
            ucSplit2.Orientation = Orientation.Horizontal;
            // 
            // ucSplit2.Panel1
            // 
            ucSplit2.Panel1.Controls.Add(ucPanel1);
            // 
            // ucSplit2.Panel2
            // 
            ucSplit2.Panel2.Controls.Add(ucSplit1);
            ucSplit2.Size = new Size(800, 450);
            ucSplit2.SplitterDistance = 53;
            ucSplit2.TabIndex = 2;
            ucSplit2.TitleWidth = 50;
            // 
            // ucPanel1
            // 
            ucPanel1.Controls.Add(ucButton1);
            ucPanel1.Controls.Add(cmbFrm);
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.EditYn = true;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.ShowYn = true;
            ucPanel1.Size = new Size(800, 53);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "ucPanel1";
            // 
            // ucButton1
            // 
            ucButton1.Appearance.Font = new Font("Tahoma", 9F);
            ucButton1.Appearance.Options.UseFont = true;
            ucButton1.ControlHeight = 21;
            ucButton1.ControlWidth = 21;
            ucButton1.EditYn = true;
            ucButton1.FontBold = FontStyle.Regular;
            ucButton1.FontFace = "Tahoma";
            ucButton1.FontSize = 9F;
            ucButton1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("ucButton1.ImageOptions.SvgImage");
            ucButton1.ImageOptions.SvgImageSize = new Size(15, 15);
            ucButton1.Location = new Point(328, 27);
            ucButton1.Name = "ucButton1";
            ucButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            ucButton1.ShowYn = true;
            ucButton1.Size = new Size(21, 21);
            ucButton1.TabIndex = 1;
            ucButton1.Text = "UCButton";
            ucButton1.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            ucButton1.Click += ucButton1_Click;
            // 
            // cmbFrm
            // 
            cmbFrm.Code = null;
            cmbFrm.ControlHeight = 21;
            cmbFrm.ControlWidth = 309;
            cmbFrm.EditYn = true;
            cmbFrm.FontFace = "Tahoma";
            cmbFrm.FontSize = 9F;
            cmbFrm.Location = new Point(13, 27);
            cmbFrm.Name = "cmbFrm";
            cmbFrm.ShowYn = true;
            cmbFrm.Size = new Size(309, 21);
            cmbFrm.TabIndex = 0;
            cmbFrm.TextAlignment = DevExpress.Utils.HorzAlignment.Near;
            cmbFrm.Title = "UCCodeBox";
            cmbFrm.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            cmbFrm.TitleWidth = 100;
            cmbFrm.UCSelectedIndexChanged += cmbFrm_UCSelectedIndexChanged;
            // 
            // FLDMAKE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucSplit2);
            Name = "FLDMAKE";
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
            ucSplit2.Panel1.ResumeLayout(false);
            ucSplit2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit2).EndInit();
            ucSplit2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Ctrls.UCSplit ucSplit1;
        private Ctrls.UCPanel pnlWrkFld;
        private Ctrls.UCPanel pnlFrmCtrl;
        private Ctrls.UCSplit ucSplit2;
        private Ctrls.UCPanel ucPanel1;
        private Ctrls.UCCodeBox cmbFrm;
        private Ctrls.UCGridSet grdFrmCtrl;
        private Ctrls.UCGridSet grdWrkFld;
        private Ctrls.UCButton ucButton1;
    }
}
