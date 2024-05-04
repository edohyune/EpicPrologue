namespace Frms
{
    partial class GAIADEV
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
            xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ucSplit1 = new Ctrl.UCSplit();
            ucSplit2 = new Ctrl.UCSplit();
            ucPanel1 = new Ctrl.UCPanel();
            ucPanel2 = new Ctrl.UCPanel();
            g110 = new Ctrl.UCGrid();
            ucPanel3 = new Ctrl.UCPanel();
            ucGrid1 = new Ctrl.UCGrid();
            xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).BeginInit();
            xtraTabControl1.SuspendLayout();
            xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucSplit1).BeginInit();
            ucSplit1.Panel1.SuspendLayout();
            ucSplit1.Panel2.SuspendLayout();
            ucSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucSplit2).BeginInit();
            ucSplit2.Panel1.SuspendLayout();
            ucSplit2.Panel2.SuspendLayout();
            ucSplit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel2).BeginInit();
            ucPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)g110).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel3).BeginInit();
            ucPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucGrid1).BeginInit();
            SuspendLayout();
            // 
            // xtraTabControl1
            // 
            xtraTabControl1.Dock = DockStyle.Fill;
            xtraTabControl1.Location = new Point(0, 0);
            xtraTabControl1.Name = "xtraTabControl1";
            xtraTabControl1.SelectedTabPage = xtraTabPage5;
            xtraTabControl1.Size = new Size(1080, 550);
            xtraTabControl1.TabIndex = 0;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2, xtraTabPage3, xtraTabPage4, xtraTabPage5 });
            // 
            // xtraTabPage5
            // 
            xtraTabPage5.Name = "xtraTabPage5";
            xtraTabPage5.Size = new Size(1078, 525);
            xtraTabPage5.TabPageWidth = 100;
            xtraTabPage5.Text = "SQL Set";
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new Size(1078, 525);
            xtraTabPage1.TabPageWidth = 100;
            xtraTabPage1.Text = "Projects";
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Controls.Add(ucSplit1);
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new Size(1078, 525);
            xtraTabPage2.TabPageWidth = 100;
            xtraTabPage2.Text = "Forms";
            // 
            // ucSplit1
            // 
            ucSplit1.Dock = DockStyle.Fill;
            ucSplit1.FixedPanel = FixedPanel.Panel1;
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
            ucSplit1.Panel2.Controls.Add(ucPanel3);
            ucSplit1.Size = new Size(1078, 525);
            ucSplit1.SplitterDistance = 396;
            ucSplit1.SplitterWidth = 1;
            ucSplit1.TabIndex = 1;
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
            ucSplit2.Panel2.Controls.Add(ucPanel2);
            ucSplit2.Size = new Size(1078, 396);
            ucSplit2.SplitterDistance = 71;
            ucSplit2.SplitterWidth = 1;
            ucSplit2.TabIndex = 0;
            // 
            // ucPanel1
            // 
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.Size = new Size(1078, 71);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "Analyze";
            // 
            // ucPanel2
            // 
            ucPanel2.Controls.Add(g110);
            ucPanel2.Dock = DockStyle.Fill;
            ucPanel2.Location = new Point(0, 0);
            ucPanel2.Name = "ucPanel2";
            ucPanel2.Size = new Size(1078, 324);
            ucPanel2.TabIndex = 1;
            ucPanel2.Text = "Register";
            // 
            // g110
            // 
            g110.Dock = DockStyle.Fill;
            g110.gvCtrl = null;
            g110.Location = new Point(2, 23);
            g110.Name = "g110";
            g110.Size = new Size(1074, 299);
            g110.TabIndex = 0;
            g110.UseEmbeddedNavigator = true;
            // 
            // ucPanel3
            // 
            ucPanel3.Controls.Add(ucGrid1);
            ucPanel3.Dock = DockStyle.Fill;
            ucPanel3.Location = new Point(0, 0);
            ucPanel3.Name = "ucPanel3";
            ucPanel3.Size = new Size(1078, 128);
            ucPanel3.TabIndex = 1;
            ucPanel3.Text = "Controller";
            // 
            // ucGrid1
            // 
            ucGrid1.Dock = DockStyle.Fill;
            ucGrid1.gvCtrl = null;
            ucGrid1.Location = new Point(2, 23);
            ucGrid1.Name = "ucGrid1";
            ucGrid1.Size = new Size(1074, 103);
            ucGrid1.TabIndex = 0;
            ucGrid1.UseEmbeddedNavigator = true;
            // 
            // xtraTabPage3
            // 
            xtraTabPage3.Name = "xtraTabPage3";
            xtraTabPage3.Size = new Size(1078, 525);
            xtraTabPage3.TabPageWidth = 100;
            xtraTabPage3.Text = "Field Set";
            // 
            // xtraTabPage4
            // 
            xtraTabPage4.Name = "xtraTabPage4";
            xtraTabPage4.Size = new Size(1078, 525);
            xtraTabPage4.TabPageWidth = 100;
            xtraTabPage4.Text = "Grid Set";
            // 
            // GAIADEV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(xtraTabControl1);
            Name = "GAIADEV";
            Size = new Size(1080, 550);
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)xtraTabControl1).EndInit();
            xtraTabControl1.ResumeLayout(false);
            xtraTabPage2.ResumeLayout(false);
            ucSplit1.Panel1.ResumeLayout(false);
            ucSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit1).EndInit();
            ucSplit1.ResumeLayout(false);
            ucSplit2.Panel1.ResumeLayout(false);
            ucSplit2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit2).EndInit();
            ucSplit2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel2).EndInit();
            ucPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)g110).EndInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel3).EndInit();
            ucPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucGrid1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private Ctrl.UCSplit ucSplit1;
        private Ctrl.UCSplit ucSplit2;
        private Ctrl.UCPanel ucPanel1;
        private Ctrl.UCPanel ucPanel2;
        private Ctrl.UCPanel ucPanel3;
        private Ctrl.UCGrid g110;
        private Ctrl.UCGrid ucGrid1;
    }
}
