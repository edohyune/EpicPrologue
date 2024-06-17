using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using Lib;
using Lib.Repo;
using static DevExpress.Accessibility.LookupPopupAccessibleObject;

namespace Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    [System.ComponentModel.DefaultEvent("UCEditValueChanged")]
    public class UCMemo : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged
    {
        #region Properties Browsable(flase) -------------------------------------------------------->>
        [Browsable(false)]
        private string frwId { get; set; }
        [Browsable(false)]
        private string frmId { get; set; }
        [Browsable(false)]
        private string thisNm { get; set; }
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
        #endregion

        #region Properties Browsable(true) --------------------------------------------------------->>
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

        [Category("A UserController Property"), Description("Title Width")]
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
                string str = (this.memoCtrl.Text == null) ? string.Empty : this.memoCtrl.Text;
                return str;
            }
            set
            {
                this.memoCtrl.Text = value;
                this.BindText = value;  // Text가 업데이트 될 때 BindText도 업데이트
            }
        }
        [Category("A UserController Property"), Description("Text Alignment")] //chk
        public DevExpress.Utils.HorzAlignment TextAlignment
        {
            get
            {
                return this.memoCtrl.Properties.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.memoCtrl.Properties.Appearance.TextOptions.HAlignment = value;
            }
        }
        [Category("A UserController Property"), Description("Necessary")] //chk
        private bool NeedYn { get; set; }
        [Category("A UserController Property"), Description("Editable=Enable=Not ReadOnly")] //chk
        public bool EditYn
        {
            get
            {
                return memoCtrl.ReadOnly;
            }
            set
            {
                memoCtrl.ReadOnly = value;
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

        public DevExpress.XtraEditors.MemoEdit memoCtrl;
        private DevExpress.XtraEditors.LabelControl labelCtrl;
        private SplitContainer splitCtrl;
                
        public UCMemo()
        {
            this.Width = 210;
            this.Height = 40;
            
            splitCtrl = new SplitContainer();
            splitCtrl.Dock = DockStyle.Fill;
            splitCtrl.Orientation = Orientation.Vertical;
            splitCtrl.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitCtrl.IsSplitterFixed = true;
            splitCtrl.Panel1MinSize = 0;

            this.Controls.Add(splitCtrl);

            labelCtrl = new DevExpress.XtraEditors.LabelControl();
            labelCtrl.AutoSizeMode = LabelAutoSizeMode.None;
            labelCtrl.Dock = DockStyle.Fill;
            labelCtrl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelCtrl.Appearance.Font = new System.Drawing.Font("Tahoma", 9);
            labelCtrl.Appearance.Options.UseFont = true;
            labelCtrl.Text = "UCMemo";

            splitCtrl.Panel1.Controls.Add(labelCtrl);

            memoCtrl = new DevExpress.XtraEditors.MemoEdit();
            memoCtrl.Dock = DockStyle.Fill;
            memoCtrl.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            memoCtrl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            memoCtrl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9);
            memoCtrl.Properties.Appearance.Options.UseFont = true;

            memoCtrl.EditValueChanged += memoCtrl_EditValueChanged;
            memoCtrl.TextChanged += memoCtrl_TextChanged;

            splitCtrl.Panel2.Controls.Add(memoCtrl);

            HandleCreated += UCMemo_HandleCreated;
        }

        private void UCMemo_HandleCreated(object? sender, EventArgs e)
        {
            frwId = Common.GetValue("gFrameWorkId");

            Form? form = this.FindForm();
            frmId = form != null ? form.Name : "Unknown";
            thisNm = this.Name;

            if (!string.IsNullOrEmpty(frwId))
            {
                ResetCtrl();
            }
        }

        private void ResetCtrl()
        {
            try
            {
                var wrkFldRepo = new WrkFldRepo();
                var wrkFld = wrkFldRepo.GetFldProperties(frwId, frmId, thisNm);
                if (wrkFld!=null)
                {
                    this.labelCtrl.Text = wrkFld.FldNm;
                    this.Visible = wrkFld.ShowYn;
                    this.Width = wrkFld.FldWidth;
                    this.Height = wrkFld.FldHeight;
                    this.TitleWidth = wrkFld.FldTitleWidth;
                    this.Title = wrkFld.FldTitle;
                    this.TitleAlignment = GenFunc.StrToAlign(wrkFld.TitleAlign);
                    this.ShowYn = wrkFld.ShowYn;
                    this.NeedYn = wrkFld.NeedYn;
                    this.EditYn = wrkFld.EditYn ? false : true;
                }
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
