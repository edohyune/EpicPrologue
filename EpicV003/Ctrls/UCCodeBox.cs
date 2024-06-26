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
using EpicV003.Lib;
using EpicV003.Lib.Repo;
using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraBars;
using static DevExpress.Accessibility.LookupPopupAccessibleObject;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Native;

namespace EpicV003.Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("Code")]
    [System.ComponentModel.DefaultEvent("UCSelectedIndexChanged")]
    public partial class UCCodeBox : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged
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
        public FrwCde CodeZip
        {
            get
            {
                if (cmbCtrl.SelectedItem is FrwCde selectedItem)
                {
                    return selectedItem;
                }
                return null;
            }
        }
        [Browsable(false)]
        public string Code
        {
            get
            {
                if (cmbCtrl.SelectedItem is FrwCde selectedItem)
                {
                    if (this.FldTy == "SubCd")
                    {
                        return selectedItem.SubCd;
                    }
                    else
                    { 
                        return selectedItem.Cd;
                    }
                }
                return null;
            }
            set
            {
                foreach (FrwCde item in cmbCtrl.Properties.Items)
                {
                    if (this.FldTy == "SubCd")
                    {
                        if (item.SubCd == value)
                        {
                            cmbCtrl.SelectedItem = item;
                            break;
                        }
                    }
                    else
                    {
                        if (item.Cd == value)
                        {
                            cmbCtrl.SelectedItem = item;
                            break;
                        }
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
                string str = (this.cmbCtrl.Text == null) ? string.Empty : this.cmbCtrl.Text.ToString();
                return str;
            }
            set
            {
                this.cmbCtrl.Text = value;
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
        public UCCodeBox()
        {
            InitializeComponent();
        }
        private void UCCodeBox_Load(object sender, EventArgs e)
        {
            frwId = Common.GetValue("gFrameWorkId");

            Form? form = this.FindForm();
            frmId = form != null ? form.Name : "Unknown";
            thisNm = this.Name;

            if (!string.IsNullOrEmpty(frwId))
            {
                ResetCtrl();
            }
            else
            {
                this.ControlHeight = 21;
                this.Title = this.Name;
                this.Text = "";
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
                    //wrkFld.FldX와 wrkFld.FldY를 사용하여 위치 설정
                    this.Location = new Point(wrkFld.FldX, wrkFld.FldY);
                    this.ControlWidth = wrkFld.FldWidth;
                    this.TitleWidth = wrkFld.FldTitleWidth;
                    this.Title = wrkFld.FldTitle;
                    this.TitleAlignment = GenFunc.StrToAlign(wrkFld.TitleAlign);
                    this.Code = wrkFld.DefaultText;
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
                        List<FrwCde> frwCdes = new FrwCdeRepo().GetFrwCdesForCodeBox(frwId, wrkFld.Popup);
                        foreach (FrwCde frwCde in frwCdes)
                        {
                            cmbCtrl.Properties.Items.Add(frwCde);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"UCCodeBox_Load>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }

        #region Event ---------------------------------------------------------------->>
        public delegate void delEventSelectedIndexChanged(object sender, EventArgs e);
        public event delEventSelectedIndexChanged UCSelectedIndexChanged;
        private void cmbCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UCSelectedIndexChanged?.Invoke(sender, e);
        }
        public delegate void delEventSelectedValueChanged(object sender, EventArgs e);
        public event delEventSelectedValueChanged UCSelectedValueChanged;
        private void cmbCtrl_SelectedValueChanged(object sender, EventArgs e)
        {
            UCSelectedValueChanged?.Invoke(sender, e);
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