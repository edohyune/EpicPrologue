using Lib.Repo;
using System.ComponentModel;

namespace Ctrls
{
    public class UCPanel : DevExpress.XtraEditors.GroupControl
    {
        [Browsable(false)]
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string ctrlNm { get; set; }

        [Category("ACE UC Property"), Description("Title")]
        public string Title
        {
            get { return this.panelCtrl.Text; }
            set { this.panelCtrl.Text = value; }
        }

        [Category("A UserController Property"), Description("Title Alignment")]
        public DevExpress.Utils.HorzAlignment TitleAlignment
        {
            get
            {
                return this.panelCtrl.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.panelCtrl.Appearance.TextOptions.HAlignment = value;
            }
        }

        [Category("A UserController Property"), Description("Editable=Enable=Not ReadOnly")]
        public bool EditYn
        {
            get
            { 
                return this.panelCtrl.Enabled;
            }
            set
            {
                this.panelCtrl.Enabled = value;
            }
        }

        [Category("A UserController Property"), Description("Visiable")]
        public bool ShowYn
        {
            get
            {
                return this.Visible;
            }
            set
            {
                this.Visible = value;
            }
        }
        public DevExpress.XtraEditors.GroupControl panelCtrl { get; set; }
        public UCPanel()
        {
            panelCtrl = new DevExpress.XtraEditors.GroupControl();
            panelCtrl.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            panelCtrl.Text = "UCPanel";
            HandleCreated += UCPanel_HandleCreated;
        }

        private void UCPanel_HandleCreated(object? sender, EventArgs e)
        {
            frwId = Lib.Common.gFrameWorkId;

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
                    this.Title = wrkFld.FldTitle;
                    this.EditYn = wrkFld.EditYn;
                    this.ShowYn = wrkFld.ShowYn;
                }
            }
            catch (Exception ex) 
            { 
                Lib.Common.gMsg = $"UCPanel_HandleCreated>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }
    }
}
