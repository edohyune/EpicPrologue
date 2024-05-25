﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPrinting.Native;
using Lib;

namespace Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    public class UCMemo : DevExpress.XtraEditors.MemoEdit, INotifyPropertyChanged
    {
        [Browsable(false)]
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string ctrlNm { get; set; }

        [Category("A UserController Property"), Description("Default Text")] //chk
        public override string Text
        {
            get
            {
                string str = (this.memoCtrl.Text == null) ? string.Empty : this.memoCtrl.Text;
                return str;
            }
            set
            {
                this.memoCtrl.Text = value;
                this.BindText = value;  // Text가 업데이트 될 때 BindText도 업데이트
            }
        }
        [Category("A UserController Property"), Description("Bind Text"), Browsable(false)]
        public string BindText
        {
            get
            {
                string str = (this.memoCtrl.Text == null) ? string.Empty : this.memoCtrl.Text;
                return str;
            }
            set
            {
                this.memoCtrl.Text = value;
                OnPropertyChanged("BindText");
                UCEditValueChanged?.Invoke(this, memoCtrl);
            }
        }

        public DevExpress.XtraEditors.MemoEdit memoCtrl { get; set; }
        public UCMemo()
        {
            memoCtrl = new DevExpress.XtraEditors.MemoEdit();
            memoCtrl.Text = "UCMemo";
            memoCtrl.EditValueChanged += memoCtrl_EditValueChanged;
            memoCtrl.TextChanged += memoCtrl_TextChanged;

            HandleCreated += UCMemo_HandleCreated;
        }

        private void UCMemo_HandleCreated(object? sender, EventArgs e)
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

            //Design모드에서 DB에서 설정값을 가져오지 않기
            if (frwId != string.Empty)
            {
                ResetCtrl();
            }
        }

        private void ResetCtrl()
        {
            Common.gMsg = "UCMemo_HandleCreated";
            try
            {

            }
            catch (Exception ex)
            {
                Common.gMsg = $"UCMemo_HandleCreated>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }

        #region INotifyPropertyChanged
        public delegate void delEventEditValueChanged(object Sender, Control control);   // delegate 선언
        public event delEventEditValueChanged UCEditValueChanged;   // event 선언
        public event PropertyChangedEventHandler? PropertyChanged;

        private void memoCtrl_EditValueChanged(object sender, EventArgs e)
        {
            string strDate = string.Empty;
            strDate = memoCtrl.Text;
            if (UCEditValueChanged != null)  // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
            {
                UCEditValueChanged(this, memoCtrl);
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void memoCtrl_TextChanged(object sender, EventArgs e)
        {
            BindText = memoCtrl.Text;
        }
        #endregion

    }
}
