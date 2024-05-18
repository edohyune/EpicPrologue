namespace FieldSetTextBox
{
    partial class FieldSetTextBox
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            ucSplit1 = new Ctrls.UCSplit();
            ucSplit2 = new Ctrls.UCSplit();
            ucField1 = new Ctrls.UCField();
            ucPanel1 = new Ctrls.UCPanel();
            ucPanel2 = new Ctrls.UCPanel();
            ucPanel3 = new Ctrls.UCPanel();
            ((System.ComponentModel.ISupportInitialize)ucSplit1).BeginInit();
            ucSplit1.Panel1.SuspendLayout();
            ucSplit1.Panel2.SuspendLayout();
            ucSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucSplit2).BeginInit();
            ucSplit2.Panel1.SuspendLayout();
            ucSplit2.Panel2.SuspendLayout();
            ucSplit2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ucField1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel3).BeginInit();
            SuspendLayout();
            // 
            // ucSplit1
            // 
            ucSplit1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSplit1.Location = new System.Drawing.Point(0, 0);
            ucSplit1.Name = "ucSplit1";
            ucSplit1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ucSplit1.Panel1
            // 
            ucSplit1.Panel1.Controls.Add(ucPanel3);
            // 
            // ucSplit1.Panel2
            // 
            ucSplit1.Panel2.Controls.Add(ucSplit2);
            ucSplit1.Size = new System.Drawing.Size(1040, 623);
            ucSplit1.SplitterDistance = 106;
            ucSplit1.TabIndex = 0;
            ucSplit1.SplitterMoved += ucSplit1_SplitterMoved;
            // 
            // ucSplit2
            // 
            ucSplit2.Dock = System.Windows.Forms.DockStyle.Fill;
            ucSplit2.Location = new System.Drawing.Point(0, 0);
            ucSplit2.Name = "ucSplit2";
            // 
            // ucSplit2.Panel1
            // 
            ucSplit2.Panel1.Controls.Add(ucPanel1);
            // 
            // ucSplit2.Panel2
            // 
            ucSplit2.Panel2.Controls.Add(ucPanel2);
            ucSplit2.Size = new System.Drawing.Size(1040, 513);
            ucSplit2.SplitterDistance = 346;
            ucSplit2.TabIndex = 0;
            // 
            // ucField1
            // 
            ucField1.ChangedFlag = Lib.MdlState.Inserted;
            // 
            // ucPanel1
            // 
            ucPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPanel1.Location = new System.Drawing.Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.Readonly = false;
            ucPanel1.Size = new System.Drawing.Size(346, 513);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "ucPanel1";
            ucPanel1.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            // 
            // ucPanel2
            // 
            ucPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPanel2.Location = new System.Drawing.Point(0, 0);
            ucPanel2.Name = "ucPanel2";
            ucPanel2.Readonly = false;
            ucPanel2.Size = new System.Drawing.Size(690, 513);
            ucPanel2.TabIndex = 0;
            ucPanel2.Text = "ucPanel2";
            ucPanel2.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            // 
            // ucPanel3
            // 
            ucPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            ucPanel3.Location = new System.Drawing.Point(0, 0);
            ucPanel3.Name = "ucPanel3";
            ucPanel3.Readonly = false;
            ucPanel3.Size = new System.Drawing.Size(1040, 106);
            ucPanel3.TabIndex = 0;
            ucPanel3.Text = "ucPanel3";
            ucPanel3.TitleAlignment = DevExpress.Utils.HorzAlignment.Default;
            // 
            // FieldSetTextBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(ucSplit1);
            Name = "FieldSetTextBox";
            Size = new System.Drawing.Size(1040, 623);
            ucSplit1.Panel1.ResumeLayout(false);
            ucSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit1).EndInit();
            ucSplit1.ResumeLayout(false);
            ucSplit2.Panel1.ResumeLayout(false);
            ucSplit2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucSplit2).EndInit();
            ucSplit2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ucField1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ucPanel3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Ctrls.UCSplit ucSplit1;
        private Ctrls.UCSplit ucSplit2;
        private Ctrls.UCField ucField1;
        private Ctrls.UCPanel ucPanel3;
        private Ctrls.UCPanel ucPanel1;
        private Ctrls.UCPanel ucPanel2;
    }
}
