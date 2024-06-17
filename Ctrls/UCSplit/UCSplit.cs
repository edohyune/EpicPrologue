using Lib.Repo;
using System.ComponentModel;

namespace Ctrls
{
    public class UCSplit : System.Windows.Forms.SplitContainer
    {
        [Browsable(false)]
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string ctrlNm { get; set; }

        [Category("A UserController Property"), Description("SplitterDistance Width")] //chk
        public int TitleWidth
        {
            get
            {
                return splitCtrl.SplitterDistance;
            }
            set
            {
                this.splitCtrl.SplitterDistance = value;
            }
        }
        public System.Windows.Forms.SplitContainer splitCtrl { get; set; }
        public UCSplit()
        {
            splitCtrl = new System.Windows.Forms.SplitContainer();
            HandleCreated += new EventHandler(UCSplit_HandleCreated);
        }

        private void UCSplit_HandleCreated(object? sender, EventArgs e)
        {
            frwId = Lib.Common.GetValue("gFrameWorkId") ;

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
                Lib.Common.gMsg = $"UCSplit : {frwId}.{frmId}.{ctrlNm}";
                var wrkFldRepo = new WrkFldRepo();
                var wrkFld = wrkFldRepo.GetFldProperties(frwId, frmId, ctrlNm);
                if (wrkFld != null)
                {
                    this.SplitterDistance = wrkFld.ShowYn == false ? 0 : wrkFld.FldTitleWidth;
                }
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCSplit_HandleCreated>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }
    }
}