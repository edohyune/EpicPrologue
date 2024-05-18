using System.ComponentModel;

namespace EL010.Ctrls
{
    public class UCButton : DevExpress.XtraEditors.SimpleButton
    {
        private string sysCd { get; set; }
        private string frmId { get; set; }
        private string fldId { get; set; }

        [Category("UserController Property"), Description("Title Alignment")]
        public DevExpress.Utils.HorzAlignment TitleAlignment
        {
            get
            {
                return this.btnCtrl.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.btnCtrl.Appearance.TextOptions.HAlignment = value;
            }
        }

        [Category("UserController Property"), Description("ReadOnly - Not Enabled")]
        public bool Readonly
        {
            get
            {
                return !(this.btnCtrl.Enabled);
            }
            set
            {
                this.btnCtrl.Enabled = !(value);
            }
        }

        public DevExpress.XtraEditors.SimpleButton btnCtrl { get; set; }

        public UCButton()
        {
            btnCtrl = new DevExpress.XtraEditors.SimpleButton();

            btnCtrl.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnCtrl.Appearance.Options.UseFont = true;
            btnCtrl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            btnCtrl.Text = "UCButton";
            HandleCreated += UCButton_HandleCreated;
        }

        private void UCButton_HandleCreated(object? sender, EventArgs e)
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
                Lib.Common.gMsg = $"UCButton : {sysCd}.{frmId}.{fldId}";
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
