using DevExpress.XtraEditors;
using System.ComponentModel;

namespace EL010.Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    [System.ComponentModel.DefaultEvent("UCTextChanged")]
    public class UCLookUp : DevExpress.XtraEditors.XtraUserControl
    {
        private string SysCd { get; }
        private string FrmID { get; set; }
        private string FldID { get; set; }

        [Category("UserController Property"), Description("ReadOnly")]
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
            //get
            //{
            //    return this.labelCtrl.Width;
            //}
            //set
            //{
            //    this.labelCtrl.Width = value;
            //}
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
        [Category("UserController Property"), Description("Bind Text")]
        public string BindText
        {
            get
            {
                return this.lookupCtrl.Text;
            }
            set
            {
                this.lookupCtrl.Text = value;
            }
        }
        [Category("UserController Property"), Description("Bind Text")]
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
        [Category("UserController Property"), Description("Bind Text")]
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
        [Category("UserController Property"), Description("Bind Text")]
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

        public DevExpress.XtraEditors.LookUpEdit lookupCtrl;
        public DevExpress.XtraEditors.LabelControl labelCtrl;
        public SplitContainer splitCtrl;
        public UCLookUp()
        {
            this.Width = 150;
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
            labelCtrl.Text = "UCLookUpEdit";

            splitCtrl.Panel1.Controls.Add(labelCtrl);

            lookupCtrl = new DevExpress.XtraEditors.LookUpEdit();
            lookupCtrl.Dock = DockStyle.Fill;
            lookupCtrl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lookupCtrl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9);
            lookupCtrl.Properties.Buttons[0].Visible = false;
            lookupCtrl.Properties.NullText = "";

            splitCtrl.Panel2.Controls.Add(lookupCtrl);

            Load += UCLookUp_Load;
        }

        private void UCLookUp_Load(object? sender, EventArgs e)
        {
            try
            {
                FrmID = this.FindForm().Name;
                FldID = this.Name;

                //    using (var db = new ACE.Lib.DbHelper())
                //    {
                //        var ucInfo = db.GetUc(new { sys = SysCode, frm = FrmID, ctrl = FldID }).SingleOrDefault();
                //        if (ucInfo != null)
                //        {
                //            labelCtrl.Text = ucInfo.Title;
                //            if (ucInfo.Popup != "")
                //            {
                //                //콤보 종류 지정
                //                //code, combo, popup 등을 구분하여 사용
                //                //if (ucInfo.field_type=="Code")
                //                //......

                //                List<MdlIdName> lists = db.GetCodeNm(new { Grp = ucInfo.Popup }, "1");
                //                //List<UcCombo> lists = db.GetUcCombo(new { gcode = ucInfo.Pop }, "1");
                //                //var bindingLists = new BindingList<MdlIdName>(lists);
                //                this.comboCtrl.Properties.DataSource = lists;
                //                this.comboCtrl.Properties.ValueMember = "Id";
                //                this.comboCtrl.Properties.DisplayMember = "Nm";
                //                this.comboCtrl.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                //                //if (ucInfo.ShowCode != "1")
                //                if ("1" != "1")
                //                {
                //                    this.comboCtrl.Properties.PopulateColumns();
                //                    this.comboCtrl.Properties.Columns["Id"].Visible = false;
                //                }
                //            }
                //            this.TitleWidth = ucInfo.TitleW;
                //            this.labelCtrl.Visible = (ucInfo.Show_chk == "0" ? false : true);
                //            this.labelCtrl.Properties.Appearance.TextOptions.HAlignment = GenFunc.StrToAlign(ucInfo.TitleAlign);
                //            this.Text = ucInfo.Txt;
                //            this.comboCtrl.Visible = (ucInfo.Show_chk == "0" ? false : true);
                //            this.comboCtrl.Properties.Appearance.TextOptions.HAlignment = GenFunc.StrToAlign(ucInfo.TxtAlign);
                //            this.comboCtrl.ReadOnly = (ucInfo.Edit_chk == "1" ? false : true);
                //            this.comboCtrl.Properties.NullText = "";
                //        }
                //    }
            }
            catch (Exception)
            {
                string str = $"UCLookUp Exception {Environment.NewLine}";
                Lib.Common.gMsg = str;
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

    }
}
