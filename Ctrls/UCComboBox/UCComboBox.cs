using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib;
using Lib.Repo;
using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraBars;

namespace Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    [System.ComponentModel.DefaultEvent("UCEditValueChanged")]
    public partial class UCComboBox : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged
    {
        #region Properties Browsable(false)
        [Browsable(false)]
        private string frwId { get; set; }
        [Browsable(false)]
        private string frmId { get; set; }
        [Browsable(false)]
        private string thisNm { get; set; }

        [Category("A UserController Property"), Description("Selected Text Type"), Browsable(false)]
        private string fldTy { get; set; }

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
                string str = (this.cmbCtrl.EditValue == null) ? string.Empty : this.cmbCtrl.EditValue.ToString();
                return str;
            }
            set
            {
                this.cmbCtrl.EditValue = value;
                OnPropertyChanged("BindText");
                UCEditValueChanged?.Invoke(this, cmbCtrl);
            }
        }
        #endregion
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
        [Category("A UserController Property"), Description("Default Text"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                string str = (this.EditValue == null) ? string.Empty : this.EditValue.ToString();
                return str;
            }
            set
            {
                this.EditValue = value;
            }
        }
        //fontFace랑 fontSize 추가
        [Category("A UserController Property"), Description("Font Face")] //chk
        public string FontFace
        {
            get
            {
                return this.cmbCtrl.Font.Name;
            }
            set
            {
                this.labelCtrl.Font = new Font(value, this.cmbCtrl.Font.Size);
                this.cmbCtrl.Font = new Font(value, this.cmbCtrl.Font.Size);
            }
        }
        [Category("A UserController Property"), Description("Font Size")] //chk
        public float FontSize
        {
            get
            {
                return this.cmbCtrl.Font.Size;
            }
            set
            {
                this.cmbCtrl.Font = new Font(this.cmbCtrl.Font.Name, value);
                this.labelCtrl.Font = new Font(this.labelCtrl.Font.Name, value);
            }
        }
        [Category("A UserController Property"), Description("Text Alignment")] //chk
        public DevExpress.Utils.HorzAlignment TextAlignment
        {
            get
            {
                return this.cmbCtrl.Properties.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.cmbCtrl.Properties.Appearance.TextOptions.HAlignment = value;
            }
        }
        [Category("A UserController Property"), Description("Necessary")] //chk
        private bool NeedYn { get; set; }
        [Category("A UserController Property"), Description("Editable=Enable=Not ReadOnly")] //chk
        public bool EditYn
        {
            get
            {
                return !(cmbCtrl.ReadOnly);
            }
            set
            {
                cmbCtrl.ReadOnly = !value;
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
        [Category("A UserController Property"), Description("EditValue")] //chk
        public object EditValue
        {
            get
            {
                return this.cmbCtrl.EditValue;
            }
            set
            {
                this.cmbCtrl.EditValue = value;
            }
        }
        #endregion


        [EditorBrowsable(EditorBrowsableState.Always)]
        public string GetText()
        {
            FrwCde frwCde = cmbCtrl.SelectedItem as FrwCde;

            string rtn;
            if (frwCde.Nm == null)
            {
                rtn = string.Empty;
            }
            else
            {
                rtn = (fldTy == "SubCdNm") ? frwCde.Cd : frwCde.SubCd;
            }
            return rtn;
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string GetText(string columnName)
        {
            FrwCde frwCde = cmbCtrl.SelectedItem as FrwCde;
            if (frwCde == null)
            {
                return string.Empty;
            }

            var property = typeof(FrwCde).GetProperty(columnName);
            if (property == null)
            {
                throw new ArgumentException($"Property {columnName} not found on FrwCde");
            }

            var value = property.GetValue(frwCde);
            return value?.ToString() ?? string.Empty;
        }

        public UCComboBox()
        {
            InitializeComponent();
        }
        private void UCComboBox_Load(object sender, EventArgs e)
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
                this.ControlHeight = 21;

                var wrkFldRepo = new WrkFldRepo();
                var wrkFld = wrkFldRepo.GetFldProperties(frwId, frmId, thisNm);
                if (wrkFld != null)
                {
                    //wrkFld.FldX와 wrkFld.FldY를 사용하여 위치 설정
                    this.Location = new Point(wrkFld.FldX, wrkFld.FldY);
                    this.ControlWidth = wrkFld.FldWidth;
                    this.TitleWidth = wrkFld.FldTitleWidth;
                    this.Title = wrkFld.FldTitle;
                    this.TitleAlignment = GenFunc.StrToAlign(wrkFld.TitleAlign);
                    this.Text = wrkFld.DefaultText;
                    this.TextAlignment = GenFunc.StrToAlign(wrkFld.TextAlign);
                    //this. = wrkFld.FixYn;
                    //this. = wrkFld.GroupYn;
                    this.ShowYn = wrkFld.ShowYn;
                    this.NeedYn = wrkFld.NeedYn;
                    this.EditYn = wrkFld.EditYn;
                    //this.ButtonVisiable = wrkFld.EditYn;
                    //this. = wrkFld.Band1;
                    //this. = wrkFld.Band2;
                    //this. = wrkFld.FuncStr;
                    //SetFuncStr(wrkFld.FuncStr);
                    //this. = wrkFld.FormatStr;
                    //SetFormatStr(wrkFld.FuncStr);
                    //this. = wrkFld.ColorFont;
                    //this. = wrkFld.ColorBg;
                    //this. = wrkFld.Seq;

                    if (wrkFld.Popup != "")
                    {
                        List<FrwCde> frwCdes = new FrwCdeRepo().GetFrwCdes(frwId, wrkFld.Popup);
                        foreach (FrwCde frwCde in frwCdes)
                        {
                            cmbCtrl.Properties.Items.Add(frwCde);
                        }
                        if (wrkFld.FldTy == "SubCdNm") { this.fldTy = "SubCd"; }
                        else if (wrkFld.FldTy == "CdNm") { this.fldTy = "Cd"; }
                        cmbCtrl.Properties.NullText = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCComboBox_Load>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }

        public void InitializeComboBox(List<FrwCde> dataSource, string initialTextType = "Cd", string initialText = null)
        {
            cmbCtrl.Properties.Items.Clear(); // 기존 아이템 초기화
            foreach (FrwCde item in dataSource)
            {
                cmbCtrl.Properties.Items.Add(item);
            }
            fldTy = initialTextType; // 초기 텍스트 타입 설정
            if (!string.IsNullOrEmpty(initialText))
            {
                Text = initialText; // 초기 텍스트 설정
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        public delegate void delEventEditValueChanged(object Sender, Control control);   // delegate 선언
        public event delEventEditValueChanged UCEditValueChanged;   // event 선언
        private void cmbCtrl_EditValueChanged(object sender, EventArgs e)
        {
            if (UCEditValueChanged != null)  // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
            {
                UCEditValueChanged(this, cmbCtrl);
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void cmbCtrl_TextChanged(object sender, EventArgs e)
        {
            BindText = cmbCtrl.Text;
        }
        #endregion

        public FrwCde cdZip { get;set;}

        public delegate void delEventSelectedIndexChanged(object sender, EventArgs e);   // delegate 선언
        public event delEventSelectedIndexChanged UCSelectedIndexChanged;
        private void cmbCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UCSelectedIndexChanged(sender, e);
        }

        public delegate void delEventSelectedValueChanged(object sender, EventArgs e);   // delegate 선언
        public event delEventSelectedValueChanged UCSelectedValueChanged;
        private void cmbCtrl_SelectedValueChanged(object sender, EventArgs e)
        {
             UCSelectedValueChanged(sender, e);
        }
    }
}
