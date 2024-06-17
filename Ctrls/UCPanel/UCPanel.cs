using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraPrinting.Native;
using Lib.Repo;
using System.ComponentModel;

namespace Ctrls
{
    [System.ComponentModel.DefaultEvent("UCCustomButtonClick")]
    public class UCPanel : DevExpress.XtraEditors.GroupControl
    {
        [Browsable(false)]
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string ctrlNm { get; set; }


        [Category("A UserController Property"), Description("Text")]
        public override string Text { get => base.Text; set => base.Text = value; }

        [Category("A UserController Property"), Description("Editable=Enable=Not ReadOnly")]
        public bool EditYn
        {
            get
            { 
                return panelCtrl.Enabled;
            }
            set
            {
                panelCtrl.Enabled = value;
            }
        }

        [Category("A UserController Property"), Description("Visiable")]
        public bool ShowYn
        {
            get
            {
                return panelCtrl.Visible;
            }
            set
            {
                panelCtrl.Visible = value;
            }
        }

        public delegate void delEventCustomButtonClick(object Sender, BaseButtonEventArgs e);   // delegate 선언
        public event delEventCustomButtonClick UCCustomButtonClick;   // event 선언
        private void UCPanel_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            if (UCCustomButtonClick != null)  // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
            {
                UCCustomButtonClick(this, e);
            }
        }

        public DevExpress.XtraEditors.GroupControl panelCtrl { get; set; }
        public UCPanel()
        {
            panelCtrl = new DevExpress.XtraEditors.GroupControl();
            panelCtrl.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            panelCtrl.Text = "UCPanel";
            HandleCreated += UCPanel_HandleCreated;
            CustomButtonClick += UCPanel_CustomButtonClick;
        }

        private void UCPanel_HandleCreated(object? sender, EventArgs e)
        {
            frwId = Lib.Common.GetValue("gFrameWorkId");

            Form? form = this.FindForm();
            if (form != null)
            {
                frmId = form.Name;
            }
            else
            {
                frmId = "Unknown";
            }
            ctrlNm = this.Name;

            //Design모드에서 DB에서 설정값을 가져오지 않기
            if (frwId != string.Empty)
            {
                ResetCtrl();
            }
        }

        private void ResetCtrl()
        {
            try
            {
                Lib.Common.gMsg = $"UCPanel : {frwId}.{frmId}.{ctrlNm}";
                var wrkFldRepo = new WrkFldRepo();
                var wrkFld = wrkFldRepo.GetFldProperties(frwId, frmId, ctrlNm);
                if (wrkFld != null)
                {
                    panelCtrl.Text = wrkFld.FldTitle;
                    panelCtrl.Enabled = wrkFld.EditYn;
                    panelCtrl.Visible = wrkFld.ShowYn;
                }
                else
                {
                    panelCtrl.Text = this.Name;
                    panelCtrl.Enabled = this.Enabled;
                    panelCtrl.Visible = this.Visible;
                }

            }
            catch (Exception ex) 
            { 
                Lib.Common.gMsg = $"UCPanel_HandleCreated>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }
    }
}
