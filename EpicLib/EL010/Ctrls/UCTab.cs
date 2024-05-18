using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL010.Ctrls
{
    public class UCTab : DevExpress.XtraTab.XtraTabControl
    {
        private string sysCd { get; set; }
        private string frmId { get; set; }
        private string fldId { get; set; }

        public DevExpress.XtraTab.XtraTabControl tabCtrl { get; set; }
        public UCTab()
        {
            tabCtrl = new DevExpress.XtraTab.XtraTabControl();
            //tabCtrl 기본설정
            tabCtrl.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Top;
            tabCtrl.HeaderButtons = DevExpress.XtraTab.TabButtons.Default;

            HandleCreated += UCTab_HandleCreated;
        }

        private void UCTab_HandleCreated(object? sender, EventArgs e)
        {
            sysCd = Lib.Common.gSysCd;

            Form? form = this.FindForm();
            if (form != null)
            {
                frmId = form.Name;
            }
            else
            {
                frmId = "Unknown";
            }
            fldId = this.Name;

            //Design모드에서 DB에서 설정값을 가져오지 않기
            if (sysCd != string.Empty)
            {
                ResetCtrl();
            }
        }

        private void ResetCtrl()
        {
            try
            {
                Lib.Common.gMsg = $"UCPanel : {sysCd}.{frmId}.{fldId}";
                using (var db = new Lib.GaiaHelper())
                {
                    //var ucInfo = db.GetUc(new { sys = SysCode, frm = FrmID, ctrl = FldID }).SingleOrDefault();
                    //if (ucInfo != null)
                    //{
                    //    this.Title = ucInfo.Title;
                    //    this.TitleWidth = ucInfo.TitleW;
                    //    this.labelCtrl.Visible = (ucInfo.Show_chk == "0" ? false : true);
                    //    this.textCtrl.Visible = (ucInfo.Show_chk == "0" ? false : true);
                    //    this.labelCtrl.Appearance.TextOptions.HAlignment = GenFunc.StrToAlign(ucInfo.TitleAlign);
                    //    this.Text = ucInfo.Txt;
                    //    this.textCtrl.Properties.Appearance.TextOptions.HAlignment = GenFunc.StrToAlign(ucInfo.TxtAlign);
                    //    this.textCtrl.ReadOnly = (ucInfo.Edit_chk == "1" ? false : true);
                    //}
                }
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"Exception : {ex}";
            }
        }
    }
}
