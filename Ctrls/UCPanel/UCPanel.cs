using System.ComponentModel;

namespace Ctrls
{
    public class UCPanel : DevExpress.XtraEditors.GroupControl
    {
        private string sysCd { get; set; }
        private string frmId { get; set; }
        private string fldId { get; set; }

        [Category("UserController Property"), Description("Title Alignment")]
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

        [Category("UserController Property"), Description("ReadOnly - Not Enabled")]
        public bool Readonly
        {
            get
            {
                return !(this.panelCtrl.Enabled);
            }
            set
            {
                this.panelCtrl.Enabled = !(value);
            }
        }

        public DevExpress.XtraEditors.GroupControl panelCtrl { get; set; }
        public UCPanel()
        {
            panelCtrl = new DevExpress.XtraEditors.GroupControl();

            //panelCtrls.Appearance.BackColor = System.Drawing.Color.White;
            //panelCtrls.Appearance.Options.UseBackColor = true;
            //panelCtrls.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            //panelCtrls.AppearanceCaption.Options.UseFont = true;
            //panelCtrls.AppearanceCaption.Options.UseTextOptions = true;
            //panelCtrls.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //panelCtrls.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center

            panelCtrl.Text = "UCPanel";
            HandleCreated += UCPanel_HandleCreated;
        }

        private void UCPanel_HandleCreated(object? sender, EventArgs e)
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
