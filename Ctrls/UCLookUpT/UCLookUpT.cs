using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Controls;
using System.Reflection;
using System.Data;
using Ctrls;
using Lib;
using Lib.Repo;

namespace Ctrls
{
    public class UCLookUpT<T> : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged
    {
        #region Properties Browseable(false) ----------------------------------------------->>
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string thisNm { get; set; }
        public string BindText
        {
            get
            {
                string str = (this.lookupCtrl.Text == null) ? string.Empty : this.lookupCtrl.Text;
                return str;
            }
            set
            {
                this.lookupCtrl.Text = value;
                OnPropertyChanged("BindText");
                UCEditValueChanged?.Invoke(this, lookupCtrl);
            }
        }
        #endregion
        #region Properties Browseable(true) ------------------------------------------------>>
        [Category("A UserController Property"), Description("Bind Text"), Browsable(true)]
        public override string Text
        {
            get
            {
                string str = (this.lookupCtrl.Text == null) ? string.Empty : this.lookupCtrl.Text;
                return str;
            }
            set
            {
                this.lookupCtrl.Text = value;
                this.BindText = value;  // Text가 업데이트 될 때 BindText도 업데이트
            }
        }
        #endregion

        #region Methods - Document(Get, Set, Create, Update, Delete) ----------------------->>
        #endregion

        #region Methods - Value (Get, Set) ------------------------------------------------->>
        #endregion

        #region Event ---------------------------------------------------------------------->>
        #endregion

        private List<T> _dataList;

        public DevExpress.XtraEditors.LookUpEdit lookupCtrl;
        public DevExpress.XtraEditors.LabelControl labelCtrl;
        public SplitContainer splitCtrl;

        public UCLookUpT(List<T> dataList)
        {
            this.Width = 180;
            this.Height = 21;

            InitializeComponent();
            _dataList = dataList;

            //생성이 될때 실행되는 이벤트 생성
            this.Load += UCLookUp_Load;

        }

        private void UCLookUp_Load(object? sender, EventArgs e)
        {
            frwId = Common.GetValue("gFrameWorkId");

            Form ? form = this.FindForm();
            frmId = form != null ? form.Name : "Unknown";
            thisNm = this.Name;

            if (!string.IsNullOrEmpty(frwId))
            {
                ResetCtrl();
            }
        }

        private void ResetCtrl()
        {
            // DataSource 설정
            lookupCtrl.Properties.DataSource = _dataList;

            // 기존 컬럼 초기화
            lookupCtrl.Properties.Columns.Clear();

            // 데이터 타입의 프로퍼티를 반영하여 컬럼 추가
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                lookupCtrl.Properties.Columns.Add(new LookUpColumnInfo(property.Name, property.Name));
            }

            // 기본 DisplayMember와 ValueMember 설정 (필요에 따라 변경)
            lookupCtrl.Properties.DisplayMember = properties.Length > 0 ? properties[0].Name : string.Empty;
            lookupCtrl.Properties.ValueMember = properties.Length > 0 ? properties[0].Name : string.Empty;
        }

        private void InitializeComponent()
        {
            splitCtrl = new SplitContainer();
            lookupCtrl = new LookUpEdit();
            labelCtrl = new LabelControl();

            splitCtrl.Dock = DockStyle.Fill;
            splitCtrl.Orientation = Orientation.Vertical;
            splitCtrl.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitCtrl.IsSplitterFixed = true;

            this.Controls.Add(splitCtrl);

            labelCtrl = new DevExpress.XtraEditors.LabelControl();
            labelCtrl.AutoSizeMode = LabelAutoSizeMode.None;
            labelCtrl.Dock = DockStyle.Fill;
            labelCtrl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            labelCtrl.Appearance.Font = new System.Drawing.Font("Tahoma", 9);
            labelCtrl.Appearance.Options.UseFont = true;
            labelCtrl.Text = "UCLookUpEdit";

            splitCtrl.Panel1.Controls.Add(labelCtrl);

            lookupCtrl = new DevExpress.XtraEditors.LookUpEdit();
            lookupCtrl.Dock = DockStyle.Fill;
            lookupCtrl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lookupCtrl.Properties.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lookupCtrl.Properties.Appearance.Options.UseFont = true;
            lookupCtrl.Properties.Buttons[0].Visible = false;
            lookupCtrl.Properties.NullText = "";
            //lookupCtrl에 changed 이벤트와 changeing 이벤트를 추가한다.

            lookupCtrl.EditValueChanged += lookupCtrl_EditValueChanged;
            lookupCtrl.TextChanged += lookupCtrl_TextChanged;

            splitCtrl.Panel2.Controls.Add(lookupCtrl);
        }

        #region INotifyPropertyChanged
        public delegate void delEventEditValueChanged(object Sender, Control control);   // delegate 선언
        public event delEventEditValueChanged UCEditValueChanged;   // event 선언
        public event PropertyChangedEventHandler? PropertyChanged;

        private void lookupCtrl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookupCtrl.EditValue != null)
                {
                    // 선택된 값의 DataRow를 가져옴
                    var selectedRow = lookupCtrl.Properties.GetDataSourceRowByKeyValue(lookupCtrl.EditValue) as DataRowView;
                    if (selectedRow != null)
                    {
                        List<PopSet> ctrls = new PopSetRepo().SetPushFlds(frwId, frmId, thisNm);
                        if (ctrls != null)
                        {
                            var fieldInfo = ctrls.ToDictionary(x => x.FldNm, x => x.ToolNm);
                            var mapping = ctrls.ToDictionary(x => x.FldNm, x => x.SetFldNm);

                            foreach (var item in fieldInfo)
                            {
                                // item.Key에 해당하는 매핑된 컬럼 이름을 가져옴

                                string columnName = mapping.ContainsKey(item.Key) ? item.Key : null;
                                if (columnName != null)
                                {
                                    // 선택된 Row의 특정 컬럼의 값을 가져옴
                                    var fieldValue = selectedRow[columnName];
                                    if (fieldValue != null)
                                    {
                                        Common.gLog = $"Enter Value({fieldValue}) into Control({mapping[item.Key]})";
                                        InitBinding(this.FindForm(), mapping[item.Key], item.Value, fieldValue);
                                    }
                                    else
                                    {
                                        Common.gLog = $"Value for column {columnName} is null.";
                                    }
                                }
                                else
                                {
                                    Common.gLog = $"Column name for key {item.Key} is null.";
                                }
                            }
                        }
                    }
                }
                if (UCEditValueChanged != null)  // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
                {
                    UCEditValueChanged(this, lookupCtrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void lookupCtrl_TextChanged(object sender, EventArgs e)
        {
            BindText = lookupCtrl.Text;
        }

        private void InitBinding(Form uc, string ctrlNm, string toolNm, dynamic value)
        {
            var ctrl = uc.Controls.Find(ctrlNm, true).FirstOrDefault();
            if (ctrl != null)
            {
                switch (toolNm.ToLower())
                {
                    case "uctextbox":
                    case "uctext":
                        UCTextBox uctxt = ctrl as UCTextBox;
                        if (uctxt != null)
                        {
                            uctxt.BindText = value.ToString();
                        }
                        break;
                    case "ucdatebox":
                    case "ucdate":
                        UCDateBox ucdate = ctrl as UCDateBox;
                        if (ucdate != null)
                        {
                            ucdate.BindText = value.ToString();
                        }
                        break;
                    case "uccombo":
                        UCLookUp uccombo = ctrl as UCLookUp;
                        if (uccombo != null)
                        {
                            uccombo.BindText = value.ToString();
                        }
                        break;
                    case "uccheckbox":
                        UCCheckBox uccheckbox = ctrl as UCCheckBox;
                        if (uccheckbox != null)
                        {
                            uccheckbox.BindValue = value;
                        }
                        break;
                    case "ucmemo":
                        UCMemo ucmemo = ctrl as UCMemo;
                        if (ucmemo != null)
                        {
                            ucmemo.BindText = value.ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
