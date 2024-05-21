using DevExpress.Drawing.Internal.Fonts.Interop;
using DevExpress.Drawing.Printing.Internal;
using DevExpress.Pdf.Native.BouncyCastle.Ocsp;
using DevExpress.Utils.DirectXPaint;
using Lib;
using Lib.Repo;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Windows.Controls.Primitives;

namespace Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    [System.ComponentModel.DefaultEvent("UCEditValueChanged")]
    public partial class UCTextBox : UserControl, INotifyPropertyChanged
    {
        [Browsable(false)]
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string ctrlNm { get; set; }

        #region Properties Browsable(true)
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
        [Category("A UserController Property"), Description("Title Width")] //chk
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
        [Category("A UserController Property"), Description("Title")] //CHK
        public string Title
        {
            get
            {
                return this.labelCtrl.Text;
            }
            set
            {
                this.labelCtrl.Text = value;
            }
        }
        [Category("A UserController Property"), Description("Title Alignment")] //chk
        public DevExpress.Utils.HorzAlignment TitleAlignment
        {
            get
            {
                return this.labelCtrl.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.labelCtrl.Appearance.TextOptions.HAlignment = value;
            }
        }
        [Category("A UserController Property"), Description("Default Text")] //chk
        public override string Text
        {
            get
            {
                string str = (this.textCtrl.Text == null) ? string.Empty : this.textCtrl.Text;
                return str;
            }
            set
            {
                this.textCtrl.Text = value;
                this.BindText = value;  // Text가 업데이트 될 때 BindText도 업데이트
            }
        }
        [Category("A UserController Property"), Description("Text Alignment")] //chk
        public DevExpress.Utils.HorzAlignment TextAlignment
        {
            get
            {
                return this.textCtrl.Properties.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.textCtrl.Properties.Appearance.TextOptions.HAlignment = value;
            }
        }
        [Category("A UserController Property"), Description("Necessary")] //chk
        private bool Necessary { get; set; }
        [Category("A UserController Property"), Description("Editable=Enable=Not ReadOnly")] //chk
        public bool EditYn
        {
            get
            {
                return textCtrl.ReadOnly;
            }
            set
            {
                textCtrl.ReadOnly = value;
            }
        }
        [Category("A UserController Property"), Description("Text Button Visiable")]
        public bool btnVisiable
        {
            get
            {
                bool result = textCtrl.Properties.Buttons[0].Visible;
                return result;
            }
            set
            {
                textCtrl.Properties.Buttons[0].Visible = value;
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
        #endregion
        #region Properties Browsable(false)
        [Category("A UserController Property"), Description("Height"), Browsable(false)]
        public int ControlHeight
        {
            set
            {
                this.Height = value;
            }
        }
        [Category("A UserController Property"), Description("Bind Text"), Browsable(false)]
        public string BindText
        {
            get
            {
                string str = (this.textCtrl.Text == null) ? string.Empty : this.textCtrl.Text;
                return str;
            }
            set
            {
                this.textCtrl.Text = value;
                OnPropertyChanged("BindText");
                UCEditValueChanged?.Invoke(this, textCtrl);
            }
        }
        #endregion

        #region Event Delegate
        public delegate void delEventButtonClick(object Sender, Control control);
        public event delEventButtonClick UCButtonClick;
        public event PropertyChangedEventHandler? PropertyChanged;
        private void textCtrl_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string strText = string.Empty;
                strText = textCtrl.Text;
                if (UCButtonClick != null)
                {
                    UCButtonClick(this, textCtrl);
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        public UCTextBox()
        {
            InitializeComponent();
        }

        private void UCTextBox_Load(object sender, EventArgs e)
        {
            frwId = Common.gFrameWorkId;

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

            if (frwId != string.Empty)
            {
                //ResetCtrl();
            }
        }

        private void ResetCtrl()
        {
            try
            {
                this.ControlHeight = 21;

                var wrkFldRepo = new WrkFldRepo();
                var wrkFld = wrkFldRepo.GetFldProperties(frwId, frmId, ctrlNm);
                if (wrkFld != null)
                {
                    //this. = wrkFld.FldX;
                    //this. = wrkFld.FldY;
                    this.ControlWidth = wrkFld.FldWidth;
                    this.TitleWidth = wrkFld.FldWidth;
                    this.Title = wrkFld.FldTitle;
                    this.TitleAlignment = GenFunc.StrToAlign(wrkFld.TitleAlign);
                    //this. = wrkFld.Popup;
                    this.Text = wrkFld.DefaultText;
                    this.TextAlignment = GenFunc.StrToAlign(wrkFld.TextAlign);
                    //this. = wrkFld.FixYn;
                    //this. = wrkFld.GroupYn;
                    this.Visible = wrkFld.ShowYn;
                    this.Necessary = wrkFld.NeedYn;
                    this.EditYn = wrkFld.EditYn == true ? false : false;
                    //this. = wrkFld.Band1;
                    //this. = wrkFld.Band2;
                    //this. = wrkFld.FuncStr;
                    //this. = wrkFld.FormatStr;
                    //this. = wrkFld.ColorFont;
                    //this. = wrkFld.ColorBg;
                    //this. = wrkFld.Seq;

                    //추가설정
                    if (wrkFld.FldTy == "TextButton")
                    {
                        this.btnVisiable = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCTextBox_Load>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }

        #region FrameWork Value 전달을 위한 함수
        public string GetParamValue(ControlCollection frm, string param_name, string wkset, string field)
        {
            string str = string.Empty;
            if (wkset != "Field")
            {
                dynamic tbx = frm.Find(wkset, true).FirstOrDefault();
                str = tbx.GetText(field);
            }
            else
            {
                dynamic tbx = frm.Find(field, true).FirstOrDefault();
                str = tbx.BindText;
            }
            return str;
        }
        #endregion

        #region INotifyPropertyChanged
        public delegate void delEventEditValueChanged(object Sender, Control control);   // delegate 선언
        public event delEventEditValueChanged UCEditValueChanged;   // event 선언
        private void textCtrl_EditValueChanged(object sender, EventArgs e)
        {
            string strText = string.Empty;
            strText = textCtrl.Text;
            if (UCEditValueChanged != null)  // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
            {
                UCEditValueChanged(this, textCtrl);
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void textCtrl_TextChanged(object sender, EventArgs e)
        {
            BindText = textCtrl.Text;
        }
        #endregion
    }
}
