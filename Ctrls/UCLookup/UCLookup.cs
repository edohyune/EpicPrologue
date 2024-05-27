using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lib;
using Lib.Repo;

namespace Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    [System.ComponentModel.DefaultEvent("UCTextChanged")]
    public class UCLookUp : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged
    {
        #region Properties
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string ctrlNm { get; set; }

        [Category("A UserController Property"), Description("ReadOnly")]
        public bool Readonly
        {
            get
            {
                return this.lookupCtrl.ReadOnly;
            }
            set
            {
                this.lookupCtrl.ReadOnly = value;
            }
        }

        [Category("A UserController Property"), Description("Title")]
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

        [Category("A UserController Property"), Description("Width")]
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
        [Category("A UserController Property"), Description("Title Alignment")]
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
        [Category("A UserController Property"), Description("Text Alignment")] //chk
        public DevExpress.Utils.HorzAlignment TextAlignment
        {
            get
            {
                return this.lookupCtrl.Properties.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.lookupCtrl.Properties.Appearance.TextOptions.HAlignment = value;
            }
        }
        [Category("A UserController Property"), Description("Default Text")] //chk
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
        [Category("A UserController Property"), Description("Bind Text")]
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
        [Category("A UserController Property"), Description("Bind Text")]
        public string BindValue
        {
            get
            {
                return this.lookupCtrl.EditValue.ToString();
            }
            set
            {
                this.lookupCtrl.EditValue = value;
            }
        }
        [Category("A UserController Property"), Description("Bind Text")]
        public string BindDisplayMember
        {
            get
            {
                return this.lookupCtrl.Properties.DisplayMember;
            }
            set
            {
                this.lookupCtrl.Properties.DisplayMember = value;
            }
        }
        [Category("A UserController Property"), Description("Bind Text")]
        public string BindValueMember
        {
            get
            {
                return this.lookupCtrl.Properties.ValueMember;
            }
            set
            {
                this.lookupCtrl.Properties.ValueMember = value;
            }
        }
        #endregion

        public DevExpress.XtraEditors.LookUpEdit lookupCtrl;
        public DevExpress.XtraEditors.LabelControl labelCtrl;
        public SplitContainer splitCtrl;

        public UCLookUp()
        {
            this.Width = 180;
            this.Height = 21;

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
            lookupCtrl.EditValueChanged += lookupCtrl_EditValueChanged;
            lookupCtrl.TextChanged += lookupCtrl_TextChanged;

            splitCtrl.Panel2.Controls.Add(lookupCtrl);

            Load += UCLookUp_Load;
        }

        private void UCLookUp_Load(object? sender, EventArgs e)
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
                ResetCtrl();
            }
        }

        private void ResetCtrl()
        {
            try
            {
                var wrkFldRepo = new WrkFldRepo();
                var wrkFld = wrkFldRepo.GetFldProperties(frwId, frmId, ctrlNm);
                if (wrkFld != null)
                {
                    labelCtrl.Text = wrkFld.FldTitle;
                    this.Visible = wrkFld.ShowYn;
                    this.TitleWidth = wrkFld.FldTitleWidth;
                    //if (wrkFld.Popup != "")
                    //{
                    //    //콤보 종류 지정
                    //    //code, combo, popup 등을 구분하여 사용
                    //    //if (ucInfo.field_type=="Code")
                    //    //......

                    //    List<IdNm> lists = db.GetCodeNm(new { Grp = wrkFld.Popup }, "1");

                    //    //List<UcCombo> lists = db.GetUcCombo(new { gcode = ucInfo.Pop }, "1");
                    //    //var bindingLists = new BindingList<MdlIdName>(lists);
                    //    this.comboCtrl.Properties.DataSource = lists;
                    //    this.comboCtrl.Properties.ValueMember = "Id";
                    //    this.comboCtrl.Properties.DisplayMember = "Nm";
                    //    this.comboCtrl.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                    //    //if (ucInfo.ShowCode != "1")
                    //    if ("1" != "1")
                    //    {
                    //        this.comboCtrl.Properties.PopulateColumns();
                    //        this.comboCtrl.Properties.Columns["Id"].Visible = false;
                    //    }
                    //}
                    this.labelCtrl.Appearance.TextOptions.HAlignment = GenFunc.StrToAlign(wrkFld.TitleAlign);
                    this.Text = wrkFld.DefaultText;
                    this.lookupCtrl.Properties.Appearance.TextOptions.HAlignment = GenFunc.StrToAlign(wrkFld.TextAlign);
                    this.lookupCtrl.ReadOnly = wrkFld.EditYn;
                    this.lookupCtrl.Properties.NullText = "";
                }
                else
                { 

                }
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCLookUp_Load>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
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

        #region INotifyPropertyChanged
        public delegate void delEventEditValueChanged(object Sender, Control control);   // delegate 선언
        public event delEventEditValueChanged UCEditValueChanged;   // event 선언
        public event PropertyChangedEventHandler? PropertyChanged;

        private void lookupCtrl_EditValueChanged(object sender, EventArgs e)
        {
            string strDate = string.Empty;
            strDate = lookupCtrl.Text;
            if (UCEditValueChanged != null)  // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
            {
                UCEditValueChanged(this, lookupCtrl);
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
        #endregion

    }
}
