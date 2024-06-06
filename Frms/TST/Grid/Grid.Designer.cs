namespace Grid
{
    partial class Grid
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
            ucPanel1 = new Ctrls.UCPanel();
            g10 = new DevExpress.XtraGrid.GridControl();
            gvCtrl = new DevExpress.XtraGrid.Views.Grid.GridView();
            g20 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ucPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)g10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCtrl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)g20).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // ucPanel1
            // 
            ucPanel1.Controls.Add(g20);
            ucPanel1.Controls.Add(g10);
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.EditYn = true;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.ShowYn = true;
            ucPanel1.Size = new Size(488, 432);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "ucPanel1";
            // 
            // g10
            // 
            g10.Location = new Point(2, 23);
            g10.MainView = gvCtrl;
            g10.Name = "g10";
            g10.Size = new Size(228, 409);
            g10.TabIndex = 0;
            g10.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCtrl });
            g10.DragDrop += g10_DragDrop;
            g10.DragOver += g10_DragOver;
            g10.MouseDown += g10_MouseDown;
            g10.MouseMove += g10_MouseMove;
            // 
            // gvCtrl
            // 
            gvCtrl.GridControl = g10;
            gvCtrl.Name = "gvCtrl";
            gvCtrl.DragObjectDrop += gvCtrl_DragObjectDrop;
            gvCtrl.DragObjectOver += gvCtrl_DragObjectOver;
            gvCtrl.MouseDown += gvCtrl_MouseDown;
            gvCtrl.MouseMove += gvCtrl_MouseMove;
            // 
            // g20
            // 
            g20.Location = new Point(255, 23);
            g20.MainView = gridView1;
            g20.Name = "g20";
            g20.Size = new Size(228, 409);
            g20.TabIndex = 1;
            g20.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = g20;
            gridView1.Name = "gridView1";
            // 
            // Grid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucPanel1);
            Name = "Grid";
            Size = new Size(488, 432);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)g10).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCtrl).EndInit();
            ((System.ComponentModel.ISupportInitialize)g20).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Ctrls.UCPanel ucPanel1;
        private DevExpress.XtraGrid.GridControl g10;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCtrl;
        private DevExpress.XtraGrid.GridControl g20;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
