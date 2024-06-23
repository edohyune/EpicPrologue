using System.ComponentModel;
using Lib.Repo;
using Lib;

namespace Ctrls
{
    public class UCButton : DevExpress.XtraEditors.SimpleButton
    {
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string thisNm { get; set; }

        [Category("A UserController Property"), Description("Title Alignment")]
        public DevExpress.Utils.HorzAlignment TitleAlignment
        {
            get
            {
                return this.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.Appearance.TextOptions.HAlignment = value;
            }
        }
        [Category("A UserController Property"), Description("Visiable")] //chk
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
        [Category("A UserController Property"), Description("Font Face")] //chk
        public string FontFace
        {
            get
            {
                return this.Font.Name;
            }
            set
            {
                this.Font = new Font(value, this.Font.Size, this.Font.Style);
            }
        }
        [Category("A UserController Property"), Description("Font Size")] //chk
        public float FontSize
        {
            get
            {
                return this.Font.Size;
            }
            set
            {
                this.Font = new Font(this.Font.Name, value, this.Font.Style);
            }
        }
        [Category("A UserController Property"), Description("Font Size")] //chk
        public System.Drawing.FontStyle FontBold
        {
            get
            {
                return this.Font.Style;
            }
            set
            {
                this.Font = new Font(this.Font.Name, this.Font.Size, value);
            }
        }
        [Category("A UserController Property"), Description("Height")]
        public int ControlHeight
        {
            get
            {
                return this.Height;
            }
            set
            {
                this.Height = value;
            }
        }
        [Category("A UserController Property"), Description("Width")] //chk
        public int ControlWidth
        {
            get
            {
                return this.Width;
            }
            set
            {
                this.Width = value;
            }
        }
        [Category("A UserController Property"), Description("Editable=Enable=Not ReadOnly")] //chk
        public bool EditYn
        {
            get
            {
                return this.Enabled;
            }
            set
            {
                this.Enabled = value;
            }
        }

        public UCButton()
        {
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.Text = "UCButton";

            HandleCreated += UCButton_HandleCreated;
        }

        private void UCButton_HandleCreated(object? sender, EventArgs e)
        {
            frmId = Lib.Common.GetValue("gFrameWorkId");

            Form ? form = this.FindForm();

            if (form != null) frmId = form.Name;
            else frmId = "Unknown";

            thisNm = this.Name;

            if (thisNm != string.Empty) ResetCtrl();
        }

        private void ResetCtrl()
        {
            try
            {
                var wrkFld = new WrkFldRepo().GetFldProperties(frwId, frmId, thisNm);
                if (wrkFld != null)
                {
                    this.Text = wrkFld.FldTitle;
                    this.ControlWidth = wrkFld.FldWidth;
                    this.ControlHeight = wrkFld.FldHeight;
                    this.ShowYn = wrkFld.ShowYn;
                    this.Appearance.TextOptions.HAlignment = GenFunc.StrToAlign(wrkFld.TextAlign);
                    this.Enabled = wrkFld.EditYn;
                }
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCButton_HandleCreated>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }



        }
    }
}
