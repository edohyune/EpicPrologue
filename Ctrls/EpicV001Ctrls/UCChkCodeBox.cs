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
using static DevExpress.Accessibility.LookupPopupAccessibleObject;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Native;
using DevExpress.XtraEditors.Controls;

namespace EpicV001Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("Codes")]
    [System.ComponentModel.DefaultEvent("UCEditValueChanged")]
    public partial class UCChkCodeBox : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged
    {
        #region [Browsable(false)] --------------------------------------------------------->>
        [Browsable(false)]
        private string frwId { get; set; }
        [Browsable(false)]
        private string frmId { get; set; }
        [Browsable(false)]
        private string thisNm { get; set; }
        [Browsable(false)]
        private string FldTy { get; set; }
        [Browsable(false)]
        public List<FrwCde> CodeZip
        {
            get
            {
                return chkcmbCtrl.Properties.Items.Cast<CheckedListBoxItem>().Where(item => item.CheckState == CheckState.Checked).Select(item => (FrwCde)item.Value).ToList();
            }
        }
        [Browsable(false)]
        public string Code
        {
            get
            {
                if (this.FldTy == "Cd")
                {
                    return string.Join(",", chkcmbCtrl.Properties.Items.Cast<CheckedListBoxItem>().Where(item => item.CheckState == CheckState.Checked).Select(item => ((FrwCde)item.Value).Cd));
                }
                else
                {
                    return string.Join(",", chkcmbCtrl.Properties.Items.Cast<CheckedListBoxItem>().Where(item => item.CheckState == CheckState.Checked).Select(item => ((FrwCde)item.Value).SubCd));
                }
            }
            set
            {
                var values = value.Split(',').Select(v => v.Trim()).ToList();
                foreach (CheckedListBoxItem item in chkcmbCtrl.Properties.Items)
                {
                    if (this.FldTy == "Cd")
                    {
                        item.CheckState = values.Contains(((FrwCde)item.Value).Cd) ? CheckState.Checked : CheckState.Unchecked;
                    }
                    else
                    {
                        item.CheckState = values.Contains(((FrwCde)item.Value).SubCd) ? CheckState.Checked : CheckState.Unchecked;
                    }
                }
                OnPropertyChanged();
            }
        }
        #endregion
        #region Properties Browsable(true) ------------------------------------------------->>
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
                string str = (this.chkcmbCtrl.Text == null) ? string.Empty : this.chkcmbCtrl.Text.ToString();
                return str;
            }
            set
            {
                this.chkcmbCtrl.Text = value;
            }
        }
        //fontFace랑 fontSize 추가
        [Category("A UserController Property"), Description("Font Face")] //chk
        public string FontFace
        {
            get
            {
                return this.chkcmbCtrl.Font.Name;
            }
            set
            {
                this.labelCtrl.Font = new Font(value, this.chkcmbCtrl.Font.Size);
                this.chkcmbCtrl.Font = new Font(value, this.chkcmbCtrl.Font.Size);
            }
        }
        [Category("A UserController Property"), Description("Font Size")] //chk
        public float FontSize
        {
            get
            {
                return this.chkcmbCtrl.Font.Size;
            }
            set
            {
                this.chkcmbCtrl.Font = new Font(this.chkcmbCtrl.Font.Name, value);
                this.labelCtrl.Font = new Font(this.labelCtrl.Font.Name, value);
            }
        }
        [Category("A UserController Property"), Description("Text Alignment")] //chk
        public DevExpress.Utils.HorzAlignment TextAlignment
        {
            get
            {
                return this.chkcmbCtrl.Properties.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.chkcmbCtrl.Properties.Appearance.TextOptions.HAlignment = value;
            }
        }
        [Category("A UserController Property"), Description("Necessary")] //chk
        private bool NeedYn { get; set; }
        [Category("A UserController Property"), Description("Editable=Enable=Not ReadOnly")] //chk
        public bool EditYn
        {
            get
            {
                return !(chkcmbCtrl.ReadOnly);
            }
            set
            {
                chkcmbCtrl.ReadOnly = !value;
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
        //[Category("A UserController Property"), Description("EditValue")] //chk
        //public object EditValue
        //{
        //    get
        //    {
        //        return this.cmbCtrl.EditValue;
        //    }
        //    set
        //    {
        //        this.cmbCtrl.EditValue = value;
        //    }
        //}
        #endregion
        public UCChkCodeBox()
        {
            InitializeComponent();
        }
        private void UCChkCodeBox_Load(object sender, EventArgs e)
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
                    this.FldTy = wrkFld.FldTy;
                    if (wrkFld.Popup != "")
                    {
                        List<FrwCde> frwCdes = new FrwCdeRepo().GetFrwCdesForCodeBox(frwId, wrkFld.Popup);
                        foreach (FrwCde frwCde in frwCdes)
                        {
                            chkcmbCtrl.Properties.Items.Add(new CheckedListBoxItem(frwCde, false));
                        }
                    }

                    //wrkFld.FldX와 wrkFld.FldY를 사용하여 위치 설정
                    this.Location = new Point(wrkFld.FldX, wrkFld.FldY);
                    this.ControlWidth = wrkFld.FldWidth;
                    this.TitleWidth = wrkFld.FldTitleWidth;
                    this.Title = wrkFld.FldTitle;
                    this.TitleAlignment = GenFunc.StrToAlign(wrkFld.TitleAlign);

                    this.Code = wrkFld.DefaultText;
                    //var selectedValues = wrkFld.DefaultText.Split(',').Select(v => v.Trim()).ToList();
                    //foreach (CheckedListBoxItem item in chkcmbCtrl.Properties.Items)
                    //{
                    //    if (this.FldTy == "Cd")
                    //    {
                    //        item.CheckState = selectedValues.Contains(((FrwCde)item.Value).Cd) ? CheckState.Checked : CheckState.Unchecked;
                    //    }
                    //    else
                    //    {
                    //        item.CheckState = selectedValues.Contains(((FrwCde)item.Value).SubCd) ? CheckState.Checked : CheckState.Unchecked;
                    //    }
                    //}
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
                }
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCChkCodeBox_Load>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }

        #region Event ---------------------------------------------------------------->>
        public delegate void delEventEditValueChanged(object sender, EventArgs e);
        public event delEventEditValueChanged UCEditValueChanged;
        private void chkcmbCtrl_EditValueChanged(object sender, EventArgs e)
        {
            UCEditValueChanged?.Invoke(sender, e);
        }
        #endregion

        #region INotifyPropertyChanged ----------------------------------------------->>
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}