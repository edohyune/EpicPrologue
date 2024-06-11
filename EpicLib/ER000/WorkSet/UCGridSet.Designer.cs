using System.ComponentModel;

namespace ER000.WorkSet
{
    partial class UCGridSet
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
            gcCtrl = new DevExpress.XtraGrid.GridControl();
            gvCtrl = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)gcCtrl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCtrl).BeginInit();
            SuspendLayout();
            // 
            // gcCtrl
            // 
            gcCtrl.Dock = DockStyle.Fill;
            gcCtrl.EmbeddedNavigator.Margin = new Padding(4, 3, 4, 3);
            gcCtrl.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gcCtrl.Location = new Point(0, 0);
            gcCtrl.MainView = gvCtrl;
            gcCtrl.Margin = new Padding(4, 3, 4, 3);
            gcCtrl.Name = "gcCtrl";
            gcCtrl.Size = new Size(421, 195);
            gcCtrl.TabIndex = 0;
            gcCtrl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCtrl });
            // 
            // gvCtrl
            // 
            gvCtrl.DetailHeight = 404;
            gvCtrl.GridControl = gcCtrl;
            gvCtrl.Name = "gvCtrl";
            gvCtrl.OptionsEditForm.PopupEditFormWidth = 933;
            // 
            // UCGridSet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gcCtrl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UCGridSet";
            Size = new Size(421, 195);
            ((System.ComponentModel.ISupportInitialize)gcCtrl).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCtrl).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcCtrl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCtrl;
    }
}
