using DevExpress.XtraPrinting.Native;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    public partial class UCDateBox : UserControl, INotifyPropertyChanged
    {
        [Category("A UserController Property"), Description("Default Text")] //chk
        public override string Text
        {
            get
            {
                string str = (this.dateCtrl.Text == null) ? string.Empty : this.dateCtrl.Text;
                return str;
            }
            set
            {
                this.dateCtrl.Text = value;
                this.BindText = value;  // Text가 업데이트 될 때 BindText도 업데이트
            }
        }
        [Category("A UserController Property"), Description("Bind Text"), Browsable(false)]
        public string BindText
        {
            get
            {
                string str = (this.dateCtrl.Text == null) ? string.Empty : this.dateCtrl.Text;
                return str;
            }
            set
            {
                this.dateCtrl.Text = value;
                OnPropertyChanged("BindText");
                UCEditValueChanged?.Invoke(this, dateCtrl);
            }
        }

        public UCDateBox()
        {
            InitializeComponent();
        }


        #region INotifyPropertyChanged
        public delegate void delEventEditValueChanged(object Sender, Control control);   // delegate 선언
        public event delEventEditValueChanged UCEditValueChanged;   // event 선언
        public event PropertyChangedEventHandler? PropertyChanged;

        private void dateCtrl_EditValueChanged(object sender, EventArgs e)
        {
            string strDate = string.Empty;
            strDate = dateCtrl.Text;
            if (UCEditValueChanged != null)  // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
            {
                UCEditValueChanged(this, dateCtrl);
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void dateCtrl_TextChanged(object sender, EventArgs e)
        {
            BindText = dateCtrl.Text;
        }
        #endregion
    }
}
