namespace Frms
{
    partial class CTRLMST
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            ucPanel1 = new EpicV001Ctrls.UCPanel();
            gridCtrls = new DevExpress.XtraGrid.GridControl();
            gvCtrls = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)ucPanel1).BeginInit();
            ucPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridCtrls).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCtrls).BeginInit();
            SuspendLayout();
            // 
            // ucPanel1
            // 
            ucPanel1.Controls.Add(gridCtrls);
            ucPanel1.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] { new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Open", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1) });
            ucPanel1.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            ucPanel1.Dock = DockStyle.Fill;
            ucPanel1.Location = new Point(0, 0);
            ucPanel1.Name = "ucPanel1";
            ucPanel1.Size = new Size(1040, 615);
            ucPanel1.TabIndex = 0;
            ucPanel1.Text = "Controller Registration - CtrlMst";
            ucPanel1.CustomButtonClick += ucPanel1_CustomButtonClick;
            // 
            // gridCtrls
            // 
            gridCtrls.Dock = DockStyle.Fill;
            gridCtrls.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridCtrls.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gridCtrls.EmbeddedNavigator.Buttons.First.Visible = false;
            gridCtrls.EmbeddedNavigator.Buttons.Last.Visible = false;
            gridCtrls.EmbeddedNavigator.Buttons.Next.Visible = false;
            gridCtrls.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            gridCtrls.EmbeddedNavigator.Buttons.Prev.Visible = false;
            gridCtrls.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            gridCtrls.EmbeddedNavigator.ButtonClick += gridCtrls_EmbeddedNavigator_ButtonClick;
            gridCtrls.Location = new Point(2, 23);
            gridCtrls.MainView = gvCtrls;
            gridCtrls.Name = "gridCtrls";
            gridCtrls.Size = new Size(1036, 590);
            gridCtrls.TabIndex = 0;
            gridCtrls.UseEmbeddedNavigator = true;
            gridCtrls.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvCtrls });
            // 
            // gvCtrls
            // 
            gvCtrls.GridControl = gridCtrls;
            gvCtrls.Name = "gvCtrls";
            // 
            // CTRLMST
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucPanel1);
            Name = "CTRLMST";
            Size = new Size(1040, 615);
            ((System.ComponentModel.ISupportInitialize)ucPanel1).EndInit();
            ucPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridCtrls).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCtrls).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private EpicV001Ctrls.UCPanel ucPanel1;
        private DevExpress.XtraGrid.GridControl gridCtrls;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCtrls;
    }
}
