namespace Frms
{
    partial class DLLLoad
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
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            ucPanel2 = new Ctrls.UCPanel();
            s_txt = new Ctrls.UCTextBox();
            ucPanel1 = new Ctrls.UCPanel();
            gridFromList = new Ctrls.UCGrid();
            splitContainer3 = new SplitContainer();
            ucPanel3 = new Ctrls.UCPanel();
            txtDllpath = new Ctrls.UCTextBox();
            txtFormTy = new Ctrls.UCTextBox();
            txtFormName = new Ctrls.UCTextBox();
            ucPanel4 = new Ctrls.UCPanel();
            grid = new Ctrls.UCGrid();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel2).BeginInit();
            ucPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ucPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFromList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel3).BeginInit();
            ucPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucPanel4).BeginInit();
            ucPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer3);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(ucPanel2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(ucPanel1);
            splitContainer2.Size = new Size(266, 450);
            splitContainer2.SplitterDistance = 55;
            splitContainer2.TabIndex = 1;
            // 
            // ucPanel2
            // 
            ucPanel2.Controls.Add(s_txt);
            ucPanel2.Dock = DockStyle.Fill;
            ucPanel2.Location = new Point(0, 0);
            ucPanel2.Name = "ucPanel2";
            ucPanel2.Size = new Size(266, 55);
            ucPanel2.TabIndex = 1;
            ucPanel2.Text = "Form Search";
            // 
            // s_txt
            // 
            s_txt.BindText = "";
            s_txt.btnVisiable = false;
            s_txt.ControlHeight = 20;
            s_txt.ControlWidth = 252;
            s_txt.Location = new Point(9, 28);
            s_txt.Name = "s_txt";
            s_txt.Size = new Size(252, 20);
            s_txt.TabIndex = 1;
            s_txt.Title = "Search";
            s_txt.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            s_txt.TitleWidth = 59;
            // 
            // ucPanel1
            // 
            ucPanel1.Controls.Add(gridFromList);
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.Size = new Size(266, 391);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "ucPanel1";
            // 
            // gridFromList
            // 
            gridFromList.Dock = DockStyle.Fill;
            gridFromList.gvCtrl = null;
            gridFromList.Location = new Point(2, 23);
            gridFromList.Name = "gridFromList";
            gridFromList.Size = new Size(262, 366);
            gridFromList.TabIndex = 0;
            gridFromList.UseEmbeddedNavigator = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.FixedPanel = FixedPanel.Panel1;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(ucPanel3);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(ucPanel4);
            splitContainer3.Size = new Size(530, 450);
            splitContainer3.SplitterDistance = 115;
            splitContainer3.TabIndex = 0;
            // 
            // ucPanel3
            // 
            ucPanel3.Controls.Add(txtDllpath);
            ucPanel3.Controls.Add(txtFormTy);
            ucPanel3.Controls.Add(txtFormName);
            ucPanel3.Dock = DockStyle.Fill;
            ucPanel3.Location = new Point(0, 0);
            ucPanel3.Name = "ucPanel3";
            ucPanel3.Size = new Size(530, 115);
            ucPanel3.TabIndex = 0;
            ucPanel3.Text = "ucPanel3";
            // 
            // txtDllpath
            // 
            txtDllpath.BindText = "";
            txtDllpath.btnVisiable = true;
            txtDllpath.ControlHeight = 21;
            txtDllpath.ControlWidth = 442;
            txtDllpath.Location = new Point(5, 80);
            txtDllpath.Name = "txtDllpath";
            txtDllpath.Size = new Size(442, 21);
            txtDllpath.TabIndex = 2;
            txtDllpath.Title = "DLL Path";
            txtDllpath.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtDllpath.TitleWidth = 80;
            // 
            // txtFormTy
            // 
            txtFormTy.BindText = "";
            txtFormTy.btnVisiable = false;
            txtFormTy.ControlHeight = 21;
            txtFormTy.ControlWidth = 252;
            txtFormTy.Location = new Point(5, 53);
            txtFormTy.Name = "txtFormTy";
            txtFormTy.Size = new Size(252, 21);
            txtFormTy.TabIndex = 1;
            txtFormTy.Title = "Form Type";
            txtFormTy.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtFormTy.TitleWidth = 80;
            // 
            // txtFormName
            // 
            txtFormName.BindText = "";
            txtFormName.btnVisiable = false;
            txtFormName.ControlHeight = 21;
            txtFormName.ControlWidth = 252;
            txtFormName.Location = new Point(5, 26);
            txtFormName.Name = "txtFormName";
            txtFormName.Size = new Size(252, 21);
            txtFormName.TabIndex = 0;
            txtFormName.Title = "Form Name";
            txtFormName.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            txtFormName.TitleWidth = 80;
            txtFormName.UCButtonClick += btnGetCtrl_UCButtonClick;
            // 
            // ucPanel4
            // 
            ucPanel4.Controls.Add(grid);
            ucPanel4.Dock = DockStyle.Fill;
            ucPanel4.Location = new Point(0, 0);
            ucPanel4.Name = "ucPanel4";
            ucPanel4.Size = new Size(530, 331);
            ucPanel4.TabIndex = 0;
            ucPanel4.Text = "ucPanel4";
            // 
            // grid
            // 
            grid.Dock = DockStyle.Fill;
            grid.gvCtrl = null;
            grid.Location = new Point(2, 23);
            grid.Name = "grid";
            grid.Size = new Size(526, 306);
            grid.TabIndex = 0;
            grid.UseEmbeddedNavigator = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // DLLLoad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "DLLLoad";
            Size = new Size(800, 450);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel2).EndInit();
            ucPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFromList).EndInit();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel3).EndInit();
            ucPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucPanel4).EndInit();
            ucPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Ctrls.UCTextBox txtFormTy;
        private Ctrls.UCTextBox txtFormName;
        private OpenFileDialog openFileDialog1;
        private Ctrls.UCPanel ucPanel2;
        private Ctrls.UCPanel ucPanel1;
        private Ctrls.UCTextBox s_txt;
        private SplitContainer splitContainer3;
        private Ctrls.UCPanel ucPanel3;
        private Ctrls.UCPanel ucPanel4;
        private Ctrls.UCGrid gridFromList;
        private Ctrls.UCGrid grid;
        private Ctrls.UCTextBox txtDllpath;


    }
}
