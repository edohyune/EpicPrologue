using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lib;
using Lib.Repo;
using static DevExpress.Accessibility.LookupPopupAccessibleObject;

namespace EpicV001Ctrls
{
    public class UCCheckBox : DevExpress.XtraEditors.CheckEdit, INotifyPropertyChanged
    {
        [Browsable(false)]
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string ctrlNm { get; set; }

        [Category("A UserController Property"), Description("Default Value")]
        public override bool Checked
        {
            get
            {
                return this.checkCtrl.Checked;
            }
            set
            {
                this.checkCtrl.Checked = value;
                this.BindValue = value;
            }
        }
        [Category("A UserController Property"), Description("Bind Text")]
        public bool BindValue
        {
            get
            {
                return this.checkCtrl.Checked;
            }
            set
            {
                this.checkCtrl.Checked = value;
                OnPropertyChanged("BindValue");
                UCEditValueChanged?.Invoke(this, checkCtrl);
            }
        }

        public DevExpress.XtraEditors.CheckEdit checkCtrl { get; set; }
        public UCCheckBox()
        {
            checkCtrl = new DevExpress.XtraEditors.CheckEdit();
            checkCtrl.Text = "UCCheckBox";
            checkCtrl.EditValueChanged += checkCtrl_EditValueChanged;
            checkCtrl.TextChanged += checkCtrl_TextChanged;

            HandleCreated += UCCheckBox_HandleCreated;
        }

        private void UCCheckBox_HandleCreated(object? sender, EventArgs e)
        {
            frwId = Common.GetValue("gFrameWorkId");

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
            Common.gMsg = "UCCheckBox_HandleCreated";
            try
            {

            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCCheckBox_HandleCreated>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }

        #region INotifyPropertyChanged
        public delegate void delEventEditValueChanged(object Sender, Control control);   // delegate 선언
        public event delEventEditValueChanged UCEditValueChanged;   // event 선언
        public event PropertyChangedEventHandler? PropertyChanged;

        private void checkCtrl_EditValueChanged(object sender, EventArgs e)
        {
            bool boolCheck = false;
            boolCheck = checkCtrl.Checked;
            if (UCEditValueChanged != null)  // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
            {
                UCEditValueChanged(this, checkCtrl);
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void checkCtrl_TextChanged(object sender, EventArgs e)
        {
            BindValue = checkCtrl.Checked;
        }
        #endregion


    }
}
