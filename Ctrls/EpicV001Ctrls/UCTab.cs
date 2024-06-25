using DevExpress.XtraTab;
using Lib;
using Lib.Repo;

namespace EpicV001Ctrls
{
    public class UCTab : DevExpress.XtraTab.XtraTabControl
    {
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string ctrlNm { get; set; }

        public DevExpress.XtraTab.XtraTabControl tabCtrl { get; set; }
        public UCTab()
        {
            tabCtrl = new DevExpress.XtraTab.XtraTabControl();
            HandleCreated += UCTab_HandleCreated;
        }

        private void UCTab_HandleCreated(object? sender, EventArgs e)
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
                Common.gMsg = $"UCTab : {frwId}.{frmId}.{ctrlNm}";
                var wrkFldRepo = new WrkFldRepo();
                foreach (DevExpress.XtraTab.XtraTabPage tabPage in tabCtrl.TabPages)
                {
                    WrkFld wrkFld = wrkFldRepo.GetTabPageProperties(frwId, frmId, tabPage.Name);
                    if (wrkFld != null)
                    {
                        tabPage.Text = wrkFld.FldTitle;
                        tabPage.PageVisible = wrkFld.ShowYn;
                        //tabpage 배경색상
                        tabPage.Appearance.Header.BackColor = GenFunc.StrToColor(wrkFld.ColorBg);
                        //tabpage 글자색상
                        tabPage.Appearance.Header.ForeColor = GenFunc.StrToColor(wrkFld.ColorFont);
                        //tabpage 탭사이즈
                        tabPage.TabPageWidth = wrkFld.FldTitleWidth;

                        //아래 FldTab을 만들면 구현하도록 한다. 
                        //tabCtrl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Top;
                        //tabCtrl.HeaderButtons = DevExpress.XtraTab.TabButtons.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCTab_HandleCreated>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }
    }
}
