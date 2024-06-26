using DevExpress.XtraGrid.Columns;

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
            components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIni));
            pnlIni = new EpicV003.Ctrls.UCPanel();
            grdCtrl = new DevExpress.XtraGrid.GridControl();
            gvCtrl = new DevExpress.XtraGrid.Views.Grid.GridView();
            Section = new GridColumn();
            Key = new GridColumn();
            Value = new GridColumn();
            ChangedFlag = new GridColumn();
            CId = new GridColumn();
            CDt = new GridColumn();
            MId = new GridColumn();
            MDt = new GridColumn();
            imageCollection1 = new DevExpress.Utils.ImageCollection(components);
            ((System.ComponentModel.ISupportInitialize)pnlIni).BeginInit();
            pnlIni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdCtrl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCtrl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).BeginInit();
            SuspendLayout();
            // 
            // pnlIni
            // 
            pnlIni.Controls.Add(grdCtrl);
            pnlIni.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Open", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1), new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Save", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
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
            // grdCtrl
            // 
            grdCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            grdCtrl.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            grdCtrl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            grdCtrl.EmbeddedNavigator.Buttons.First.Enabled = false;
            grdCtrl.EmbeddedNavigator.Buttons.First.Visible = false;
            grdCtrl.EmbeddedNavigator.Buttons.Last.Enabled = false;
            grdCtrl.EmbeddedNavigator.Buttons.Last.Visible = false;
            grdCtrl.EmbeddedNavigator.Buttons.Next.Enabled = false;
            grdCtrl.EmbeddedNavigator.Buttons.Next.Visible = false;
            grdCtrl.EmbeddedNavigator.Buttons.NextPage.Enabled = false;
            grdCtrl.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            grdCtrl.EmbeddedNavigator.Buttons.Prev.Enabled = false;
            grdCtrl.EmbeddedNavigator.Buttons.Prev.Visible = false;
            grdCtrl.EmbeddedNavigator.Buttons.PrevPage.Enabled = false;
            grdCtrl.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            grdCtrl.Location = new System.Drawing.Point(2, 23);
            grdCtrl.MainView = gvCtrl;
            grdCtrl.Name = "grdCtrl";
            grdCtrl.Size = new System.Drawing.Size(462, 444);
            grdCtrl.TabIndex = 0;
            grdCtrl.UseEmbeddedNavigator = true;
            grdCtrl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCtrl });
            // 
            // gvCtrl
            // 
            gvCtrl.Columns.AddRange(new GridColumn[] { Section, Key, Value, ChangedFlag, CId, CDt, MId, MDt });
            gvCtrl.GridControl = grdCtrl;
            gvCtrl.Name = "gvCtrl";
            gvCtrl.OptionsNavigation.AutoFocusNewRow = true;
            gvCtrl.InitNewRow += gvCtrl_InitNewRow;
            // 
            // Section
            // 
            Section.Caption = "Section";
            Section.FieldName = "Section";
            Section.Name = "Section";
            Section.Visible = true;
            Section.VisibleIndex = 0;
            // 
            // Key
            // 
            Key.Caption = "Key";
            Key.FieldName = "Key";
            Key.Name = "Key";
            Key.Visible = true;
            Key.VisibleIndex = 1;
            // 
            // Value
            // 
            Value.Caption = "Value";
            Value.FieldName = "Value";
            Value.Name = "Value";
            Value.Visible = true;
            Value.VisibleIndex = 2;
            // 
            // ChangedFlag
            // 
            ChangedFlag.Caption = "ChangedFlag";
            ChangedFlag.FieldName = "ChangedFlag";
            ChangedFlag.Name = "ChangedFlag";
            ChangedFlag.Visible = true;
            ChangedFlag.VisibleIndex = 3;
            // 
            // CId
            // 
            CId.Caption = "CId";
            CId.FieldName = "CId";
            CId.Name = "CId";
            // 
            // CDt
            // 
            CDt.Caption = "CDt";
            CDt.FieldName = "CDt";
            CDt.Name = "CDt";
            // 
            // MId
            // 
            MId.Caption = "MId";
            MId.FieldName = "MId";
            MId.Name = "MId";
            // 
            // MDt
            // 
            MDt.Caption = "MDt";
            MDt.FieldName = "MDt";
            MDt.Name = "MDt";
            // 
            // imageCollection1
            // 
            imageCollection1.ImageStream = (DevExpress.Utils.ImageCollectionStreamer)resources.GetObject("imageCollection1.ImageStream");
            imageCollection1.InsertGalleryImage("saveandnew_16x16.png", "grayscaleimages/save/saveandnew_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/save/saveandnew_16x16.png"), 0);
            imageCollection1.Images.SetKeyName(0, "saveandnew_16x16.png");
            imageCollection1.InsertGalleryImage("saveas_16x16.png", "grayscaleimages/save/saveas_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("grayscaleimages/save/saveas_16x16.png"), 1);
            imageCollection1.Images.SetKeyName(1, "saveas_16x16.png");
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
            ((System.ComponentModel.ISupportInitialize)grdCtrl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCtrl).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageCollection1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private EpicV003.Ctrls.UCPanel pnlIni;
        private DevExpress.XtraGrid.GridControl grdCtrl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCtrl;
        private DevExpress.XtraGrid.Columns.GridColumn Section;
        private DevExpress.XtraGrid.Columns.GridColumn Key;
        private DevExpress.XtraGrid.Columns.GridColumn Value;
        private DevExpress.XtraGrid.Columns.GridColumn ChangedFlag;
        private DevExpress.XtraGrid.Columns.GridColumn CId;
        private DevExpress.XtraGrid.Columns.GridColumn CDt;
        private DevExpress.XtraGrid.Columns.GridColumn MId;
        private DevExpress.XtraGrid.Columns.GridColumn MDt;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}
