namespace Frms.TST
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
            gPaste = new Ctrls.UCGridNav();
            gCopy = new Ctrls.UCGridNav();
            ucSplit1 = new Ctrls.UCSplit();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ucPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gPaste).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gCopy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucSplit1).BeginInit();
            ucSplit1.Panel1.SuspendLayout();
            ucSplit1.Panel2.SuspendLayout();
            ucSplit1.SuspendLayout();
            SuspendLayout();
            // 
            // ucPanel1
            // 
            ucPanel1.Controls.Add(ucSplit1);
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.EditYn = true;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.ShowYn = true;
            ucPanel1.Size = new Size(859, 538);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "ucPanel1";
            // 
            // gPaste
            // 
            gPaste.ColumnAutoWidth = true;
            gPaste.Dock = DockStyle.Fill;
            gPaste.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] { new DevExpress.XtraEditors.NavigatorCustomButton(-1, 11, true, true, "", "Query") });
            gPaste.FocuseRowIndex = int.MinValue;
            gPaste.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gPaste.Location = new Point(0, 0);
            gPaste.MultiSelect = false;
            gPaste.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            gPaste.Name = "gPaste";
            gPaste.RowAutoHeigh = false;
            gPaste.ShowFindPanel = false;
            gPaste.ShowGroupPanel = true;
            gPaste.Size = new Size(433, 513);
            gPaste.TabIndex = 3;
            gPaste.UseEmbeddedNavigator = true;
            // 
            // gCopy
            // 
            gCopy.ColumnAutoWidth = true;
            gCopy.Dock = DockStyle.Fill;
            gCopy.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] { new DevExpress.XtraEditors.NavigatorCustomButton(-1, 11, true, true, "", "Query") });
            gCopy.FocuseRowIndex = int.MinValue;
            gCopy.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gCopy.Location = new Point(0, 0);
            gCopy.MultiSelect = false;
            gCopy.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            gCopy.Name = "gCopy";
            gCopy.RowAutoHeigh = false;
            gCopy.ShowFindPanel = false;
            gCopy.ShowGroupPanel = true;
            gCopy.Size = new Size(418, 513);
            gCopy.TabIndex = 2;
            gCopy.UseEmbeddedNavigator = true;
            // 
            // ucSplit1
            // 
            ucSplit1.Dock = DockStyle.Fill;
            ucSplit1.Location = new Point(2, 23);
            ucSplit1.Name = "ucSplit1";
            // 
            // ucSplit1.Panel1
            // 
            ucSplit1.Panel1.Controls.Add(gCopy);
            // 
            // ucSplit1.Panel2
            // 
            ucSplit1.Panel2.Controls.Add(gPaste);
            ucSplit1.Size = new Size(855, 513);
            ucSplit1.SplitterDistance = 418;
            ucSplit1.TabIndex = 4;
            ucSplit1.TitleWidth = 50;
            // 
            // Grid
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucPanel1);
            Name = "Grid";
            Size = new Size(859, 538);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gPaste).EndInit();
            ((System.ComponentModel.ISupportInitialize)gCopy).EndInit();
            ucSplit1.Panel1.ResumeLayout(false);
            ucSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit1).EndInit();
            ucSplit1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Ctrls.UCPanel ucPanel1;
        private Ctrls.UCGridNav gCopy;
        private Ctrls.UCGridNav gPaste;
        private Ctrls.UCSplit ucSplit1;
    }
}
