using DevExpress.Drawing.Printing.Internal;
using DevExpress.Utils.DirectXPaint;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EL010.Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    [System.ComponentModel.DefaultEvent("UCEditValueChanged")]
    public partial class UCTextBox : UserControl, INotifyPropertyChanged
    {
        private string SysCd { get; }
        private string FrmID { get; set; }
        private string FldID { get; set; }

        #region Properties  
        [Category("UserController Property"), Description("Title")]
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
        [Category("UserController Property"), Description("Height")]
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

        [Category("UserController Property"), Description("Width")]
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
        [Category("UserController Property"), Description("Title Width")]
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
        [Category("UserController Property"), Description("Title Alignment")]
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
        [Category("UserController Property"), Description("DefaultText")]
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
        [Category("UserController Property"), Description("BindText")]
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
        //private void textCtrl_TextChanged(object sender, EventArgs e)
        //{
        //    // This will also trigger UCEditValueChanged via the BindText setter
        //}


        [Category("UserController Property"), Description("Text Alignment")]
        public DevExpress.Utils.HorzAlignment TextAlignment
        {
            set
            {
                this.textCtrl.Properties.Appearance.TextOptions.HAlignment = value;
            }
        }
        [Category("UserController Property"), Description("Text Button Visiable")]
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

        [Category("UserController Property"), Description("ReadOnly")]
        public bool Readonly
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
        #endregion


        public UCTextBox()
        {
            InitializeComponent();
        }

        private void UCTextBox_Load(object sender, EventArgs e)
        {
            try
            {
                FrmID = this.FindForm().Name;
                FldID = this.Name;
                //default Setting
                this.ControlHeight = 21;
                this.btnVisiable = true;

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
            catch (Exception) { }
            //MessageBox.Show($"UCText : {SysCode}.{FrmID}.{FldID}");
        }
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


        #region Event Delegate
        // Control의 부모 쪽으로 전달할 Event Delegate 
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

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void textCtrl_TextChanged(object sender, EventArgs e)
        {
            BindText = textCtrl.Text;
        }
    }
}
