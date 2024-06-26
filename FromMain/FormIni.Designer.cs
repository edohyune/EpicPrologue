namespace FormMain
{
    partial class FormIni
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
            pnlIni = new EpicV003.Ctrls.UCPanel();
            grdIni = new EpicV003.Ctrls.UCGridSet();
            ((System.ComponentModel.ISupportInitialize)pnlIni).BeginInit();
            pnlIni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdIni).BeginInit();
            SuspendLayout();
            // 
            // pnlIni
            // 
            pnlIni.Controls.Add(grdIni);
            pnlIni.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Open", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            pnlIni.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlIni.EditYn = true;
            pnlIni.Location = new System.Drawing.Point(0, 0);
            pnlIni.Name = "pnlIni";
            pnlIni.ShowYn = true;
            pnlIni.Size = new System.Drawing.Size(466, 469);
            pnlIni.TabIndex = 0;
            pnlIni.Text = "Configuration";
            pnlIni.CustomButtonClick += pnlIni_CustomButtonClick;
            // 
            // grdIni
            // 
            grdIni.ColumnAutoWidth = true;
            grdIni.Dock = System.Windows.Forms.DockStyle.Fill;
            grdIni.FocuseRowIndex = int.MinValue;
            grdIni.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            grdIni.frmId = "Unknown";
            grdIni.frwId = "";
            grdIni.Location = new System.Drawing.Point(2, 23);
            grdIni.MultiSelect = false;
            grdIni.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            grdIni.Name = "grdIni";
            grdIni.RowAutoHeigh = false;
            grdIni.ShowFindPanel = false;
            grdIni.ShowGroupPanel = true;
            grdIni.Size = new System.Drawing.Size(462, 444);
            grdIni.TabIndex = 0;
            grdIni.wrkId = "ucGridSet1";
            // 
            // FormIni
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pnlIni);
            Name = "FormIni";
            Size = new System.Drawing.Size(466, 469);
            ((System.ComponentModel.ISupportInitialize)pnlIni).EndInit();
            pnlIni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdIni).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private EpicV003.Ctrls.UCPanel pnlIni;
        private EpicV003.Ctrls.UCGridSet grdIni;
    }
}
