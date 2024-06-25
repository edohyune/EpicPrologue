namespace Frms.TST
{
    partial class FieldSetTEST
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
            ucSplit1 = new EpicV001Ctrls.UCSplit();
            ucPanel3 = new EpicV001Ctrls.UCPanel();
            grdWrkSql =new EpicV001Ctrls.UCGridSet();
            ucSplit2 = new EpicV001Ctrls.UCSplit();
            ucPanel1 = new EpicV001Ctrls.UCPanel();
            rtxSQL =   new EpicV001Ctrls.UCRichText();
            ucPanel2 = new EpicV001Ctrls.UCPanel();
            txtFrwId = new EpicV001Ctrls.UCTextBox();
            txtWrkId = new EpicV001Ctrls.UCTextBox();
            txtFrmId = new EpicV001Ctrls.UCTextBox();
            txtCRUDM = new EpicV001Ctrls.UCTextBox();
            ((System.ComponentModel.ISupportInitialize)ucSplit1).BeginInit();
            ucSplit1.Panel1.SuspendLayout();
            ucSplit1.Panel2.SuspendLayout();
            ucSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel3).BeginInit();
            ucPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdWrkSql).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucSplit2).BeginInit();
            ucSplit2.Panel1.SuspendLayout();
            ucSplit2.Panel2.SuspendLayout();
            ucSplit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ucPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel2).BeginInit();
            ucPanel2.SuspendLayout();
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
            ucSplit1.Panel1.Controls.Add(ucPanel3);
            // 
            // ucSplit1.Panel2
            // 
            ucSplit1.Panel2.Controls.Add(ucSplit2);
            ucSplit1.Size = new Size(795, 517);
            ucSplit1.SplitterDistance = 265;
            ucSplit1.TabIndex = 0;
            ucSplit1.TitleWidth = 50;
            // 
            // ucPanel3
            // 
            ucPanel3.Controls.Add(grdWrkSql);
            ucPanel3.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Query", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            ucPanel3.Dock = DockStyle.Fill;
            ucPanel3.EditYn = true;
            ucPanel3.Location = new Point(0, 0);
            ucPanel3.Name = "ucPanel3";
            ucPanel3.ShowYn = true;
            ucPanel3.Size = new Size(265, 517);
            ucPanel3.TabIndex = 0;
            ucPanel3.Text = "ucPanel3";
            ucPanel3.UCCustomButtonClick += ucPanel3_UCCustomButtonClick;
            // 
            // grdWrkSql
            // 
            grdWrkSql.ColumnAutoWidth = true;
            grdWrkSql.Dock = DockStyle.Fill;
            grdWrkSql.FocuseRowIndex = int.MinValue;
            grdWrkSql.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grdWrkSql.Location = new Point(2, 23);
            grdWrkSql.MultiSelect = true;
            grdWrkSql.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            grdWrkSql.Name = "grdWrkSql";
            grdWrkSql.RowAutoHeigh = true;
            grdWrkSql.ShowFindPanel = true;
            grdWrkSql.ShowGroupPanel = false;
            grdWrkSql.Size = new Size(261, 492);
            grdWrkSql.TabIndex = 0;
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
            ucSplit2.Panel1.Controls.Add(ucPanel1);
            // 
            // ucSplit2.Panel2
            // 
            ucSplit2.Panel2.Controls.Add(ucPanel2);
            ucSplit2.Size = new Size(526, 517);
            ucSplit2.SplitterDistance = 223;
            ucSplit2.TabIndex = 0;
            ucSplit2.TitleWidth = 50;
            // 
            // ucPanel1
            // 
            ucPanel1.Controls.Add(rtxSQL);
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.EditYn = true;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.ShowYn = true;
            ucPanel1.Size = new Size(526, 223);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "ucPanel1";
            // 
            // rtxSQL
            // 
            rtxSQL.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtxSQL.BindText = "";
            rtxSQL.Dock = DockStyle.Fill;
            rtxSQL.EditYn = true;
            rtxSQL.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtxSQL.Location = new Point(2, 23);
            rtxSQL.Modified = true;
            rtxSQL.Name = "rtxSQL";
            rtxSQL.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtxSQL.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtxSQL.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtxSQL.ShowYn = true;
            rtxSQL.Size = new Size(522, 198);
            rtxSQL.TabIndex = 0;
            // 
            // ucPanel2
            // 
            ucPanel2.Controls.Add(txtCRUDM);
            ucPanel2.Controls.Add(txtFrmId);
            ucPanel2.Controls.Add(txtWrkId);
            ucPanel2.Controls.Add(txtFrwId);
            ucPanel2.Dock = DockStyle.Fill;
            ucPanel2.EditYn = true;
            ucPanel2.Location = new Point(0, 0);
            ucPanel2.Name = "ucPanel2";
            ucPanel2.ShowYn = true;
            ucPanel2.Size = new Size(526, 290);
            ucPanel2.TabIndex = 0;
            ucPanel2.Text = "ucPanel2";
            // 
            // txtFrwId
            // 
            txtFrwId.BindText = "2024FRW001";
            txtFrwId.ButtonVisiable = false;
            txtFrwId.ControlWidth = 180;
            txtFrwId.EditYn = true;
            txtFrwId.FontFace = "Tahoma";
            txtFrwId.FontSize = 9F;
            txtFrwId.Location = new Point(5, 27);
            txtFrwId.Name = "txtFrwId";
            txtFrwId.ShowYn = true;
            txtFrwId.Size = new Size(180, 21);
            txtFrwId.TabIndex = 0;
            txtFrwId.Text = "2024FRW001";
            txtFrwId.TextAlignment = DevExpress.Utils.HorzAlignment.Near;
            txtFrwId.Title = "FrwId";
            txtFrwId.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtFrwId.TitleWidth = 80;
            // 
            // txtWrkId
            // 
            txtWrkId.BindText = "";
            txtWrkId.ButtonVisiable = false;
            txtWrkId.ControlWidth = 180;
            txtWrkId.EditYn = true;
            txtWrkId.FontFace = "Tahoma";
            txtWrkId.FontSize = 9F;
            txtWrkId.Location = new Point(5, 81);
            txtWrkId.Name = "txtWrkId";
            txtWrkId.ShowYn = true;
            txtWrkId.Size = new Size(180, 21);
            txtWrkId.TabIndex = 1;
            txtWrkId.TextAlignment = DevExpress.Utils.HorzAlignment.Near;
            txtWrkId.Title = "WrkId";
            txtWrkId.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtWrkId.TitleWidth = 80;
            // 
            // txtFrmId
            // 
            txtFrmId.BindText = "";
            txtFrmId.ButtonVisiable = false;
            txtFrmId.ControlWidth = 180;
            txtFrmId.EditYn = true;
            txtFrmId.FontFace = "Tahoma";
            txtFrmId.FontSize = 9F;
            txtFrmId.Location = new Point(5, 54);
            txtFrmId.Name = "txtFrmId";
            txtFrmId.ShowYn = true;
            txtFrmId.Size = new Size(180, 21);
            txtFrmId.TabIndex = 2;
            txtFrmId.TextAlignment = DevExpress.Utils.HorzAlignment.Near;
            txtFrmId.Title = "FrmId";
            txtFrmId.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtFrmId.TitleWidth = 80;
            // 
            // txtCRUDM
            // 
            txtCRUDM.BindText = "";
            txtCRUDM.ButtonVisiable = false;
            txtCRUDM.ControlWidth = 180;
            txtCRUDM.EditYn = true;
            txtCRUDM.FontFace = "Tahoma";
            txtCRUDM.FontSize = 9F;
            txtCRUDM.Location = new Point(5, 108);
            txtCRUDM.Name = "txtCRUDM";
            txtCRUDM.ShowYn = true;
            txtCRUDM.Size = new Size(180, 21);
            txtCRUDM.TabIndex = 3;
            txtCRUDM.TextAlignment = DevExpress.Utils.HorzAlignment.Near;
            txtCRUDM.Title = "CRUDM";
            txtCRUDM.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtCRUDM.TitleWidth = 80;
            // 
            // FieldSetTEST
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucSplit1);
            Name = "FieldSetTEST";
            Size = new Size(795, 517);
            ucSplit1.Panel1.ResumeLayout(false);
            ucSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit1).EndInit();
            ucSplit1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel3).EndInit();
            ucPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdWrkSql).EndInit();
            ucSplit2.Panel1.ResumeLayout(false);
            ucSplit2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit2).EndInit();
            ucSplit2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel2).EndInit();
            ucPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private EpicV001Ctrls.UCSplit ucSplit1;
        private EpicV001Ctrls.UCPanel ucPanel3;
        private EpicV001Ctrls.UCGridSet grdWrkSql;
        private EpicV001Ctrls.UCSplit ucSplit2;
        private EpicV001Ctrls.UCPanel ucPanel1;
        private EpicV001Ctrls.UCPanel ucPanel2;
        private EpicV001Ctrls.UCRichText rtxSQL;
        private EpicV001Ctrls.UCTextBox txtFrwId;
        private EpicV001Ctrls.UCTextBox txtCRUDM;
        private EpicV001Ctrls.UCTextBox txtFrmId;
        private EpicV001Ctrls.UCTextBox txtWrkId;
    }
}
