using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lib;
using Lib.Repo;
using System.Data;
using Dapper;
using DevExpress.XtraEditors.Controls;
using System.Reflection;
using DevExpress.XtraPrinting.Native;

namespace Ctrls
{
    [System.ComponentModel.DefaultBindingProperty("BindText")]
    [System.ComponentModel.DefaultEvent("UCEditValueChanged")]
    public class UCLook01 : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged
    {
        #region Properties Browseable(false) ----------------------------------------------->>
        [Browsable(false)]
        private string frwId { get; set; }
        [Browsable(false)]
        private string frmId { get; set; }
        [Browsable(false)]
        private string thisNm { get; set; }

        private object OSearchParam;
        private DynamicParameters DSearchParam;


        [Category("A UserController Property"), Description("Bind Text")]
        public string BindText
        {
            get
            {
                string str = (this.lookUpCtrl.EditValue == null) ? string.Empty : this.lookUpCtrl.EditValue.ToString();
                return str;
            }
            set
            {
                this.lookUpCtrl.EditValue = value;
                OnPropertyChanged("BindText");
                UCEditValueChanged?.Invoke(this, lookUpCtrl);
            }
        }
        #endregion

        #region Properties Browseable(true) ------------------------------------------------>>
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
                string str = (this.lookUpCtrl.Text == null) ? string.Empty : this.lookUpCtrl.Text.ToString();
                return str;
            }
            set
            {
                this.lookUpCtrl.Text = value;
            }
        }
        //fontFace랑 fontSize 추가
        [Category("A UserController Property"), Description("Font Face")] //chk
        public string FontFace
        {
            get
            {
                return this.lookUpCtrl.Font.Name;
            }
            set
            {
                this.labelCtrl.Font = new Font(value, this.lookUpCtrl.Font.Size);
                this.lookUpCtrl.Font = new Font(value, this.lookUpCtrl.Font.Size);
            }
        }
        [Category("A UserController Property"), Description("Font Size")] //chk
        public float FontSize
        {
            get
            {
                return this.lookUpCtrl.Font.Size;
            }
            set
            {
                this.lookUpCtrl.Font = new Font(this.lookUpCtrl.Font.Name, value);
                this.labelCtrl.Font = new Font(this.labelCtrl.Font.Name, value);
            }
        }
        [Category("A UserController Property"), Description("Text Alignment")] //chk
        public DevExpress.Utils.HorzAlignment TextAlignment
        {
            get
            {
                return this.lookUpCtrl.Properties.Appearance.TextOptions.HAlignment;
            }
            set
            {
                this.lookUpCtrl.Properties.Appearance.TextOptions.HAlignment = value;
            }
        }
        [Category("A UserController Property"), Description("Necessary")] //chk
        private bool NeedYn { get; set; }
        [Category("A UserController Property"), Description("Editable=Enable=Not ReadOnly")] //chk
        public bool EditYn
        {
            get
            {
                return !(lookUpCtrl.Properties.ReadOnly);
            }
            set
            {
                lookUpCtrl.Properties.ReadOnly = !value;
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
                return this.lookUpCtrl.EditValue;
            }
            set
            {
                this.lookUpCtrl.EditValue = value;
            }
        }
        #endregion

        #region Event ---------------------------------------------------------------------->>
        #endregion

        public DevExpress.XtraEditors.LookUpEdit lookUpCtrl;
        public DevExpress.XtraEditors.LabelControl labelCtrl;
        public SplitContainer splitCtrl;

        public UCLook01()
        {
            this.Height = 21;

            splitCtrl = new SplitContainer();
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

            lookUpCtrl = new DevExpress.XtraEditors.LookUpEdit();
            lookUpCtrl.Dock = DockStyle.Fill;
            lookUpCtrl.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lookUpCtrl.Properties.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lookUpCtrl.Properties.Appearance.Options.UseFont = true;
            lookUpCtrl.Properties.Buttons[0].Visible = true;
            lookUpCtrl.Properties.NullText = "";
            lookUpCtrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboCtrl_KeyDown);
            lookUpCtrl.EditValueChanged += lookupCtrl_EditValueChanged;
            lookUpCtrl.TextChanged += lookupCtrl_TextChanged;

            splitCtrl.Panel2.Controls.Add(lookUpCtrl);
            
            // CloseUpKey 속성 설정
            lookUpCtrl.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(Keys.Enter);

            // EditValueChanged 이벤트 처리
            lookUpCtrl.Properties.EditValueChanged += (sender, e) => {
                if (lookUpCtrl.IsPopupOpen)
                {
                    lookUpCtrl.ClosePopup();
                }
            };

            Load += UCLookUp_Load;
        }

        private void UCLookUp_Load(object? sender, EventArgs e)
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
                if (wrkFld != null)
                {
                    //wrkFld.FldX와 wrkFld.FldY를 사용하여 위치 설정
                    this.Location = new Point(wrkFld.FldX, wrkFld.FldY);
                    this.ControlWidth = wrkFld.FldWidth;
                    this.TitleWidth = wrkFld.FldTitleWidth;
                    this.Title = wrkFld.FldTitle;
                    this.TitleAlignment = GenFunc.StrToAlign(wrkFld.TitleAlign);

                    if (!string.IsNullOrEmpty(wrkFld.Popup))
                    {
                        var columns = GetColumns(wrkFld.Popup);

                        FrwCdeRepo frwCdebs = new FrwCdeRepo();
                        List<FrwCde> frwCdes = frwCdebs.GetFrwCdes(frwId, wrkFld.Popup, wrkFld.FldTy);
                        var bindingLists = new BindingList<FrwCde>(frwCdes);

                        this.lookUpCtrl.Properties.DataSource = bindingLists;
                        this.lookUpCtrl.Properties.ValueMember = wrkFld.FldTy;
                        this.lookUpCtrl.Properties.DisplayMember = "Nm";
                        this.lookUpCtrl.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

                        //if (wrkFld.FldTy == "CdNm")
                        //{
                        //    FrwCdeRepo frwCdebs = new FrwCdeRepo();
                        //    List<FrwCde> frwCdes = frwCdebs.GetFrwCdes(frwId, wrkFld.Popup, wrkFld.FldTy);
                        //    var bindingLists = new BindingList<FrwCde>(frwCdes);

                        //    this.lookupCtrl.Properties.DataSource = bindingLists;
                        //    this.lookupCtrl.Properties.ValueMember = wrkFld.FldTy;
                        //    this.lookupCtrl.Properties.DisplayMember = "Nm";
                        //    this.lookupCtrl.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;

                        //    lookupCtrl.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", wrkFld.FldTy));
                        //    lookupCtrl.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Nm"));
                        //}
                        //else if (wrkFld.FldTy == "PopUp" && 1!=1)
                        //{
                        //    SetPopupDataSource(wrkFld.Popup);
                        //    // LookUpEdit 컬럼 설정
                        //    lookupCtrl.Properties.Columns.Clear();
                        //    if (_dataList != null && _dataList.Count > 0)
                        //    {
                        //        Type itemType = _dataList[0].GetType();
                        //        PropertyInfo[] properties = itemType.GetProperties();
                        //        foreach (PropertyInfo property in properties)
                        //        {
                        //            lookupCtrl.Properties.Columns.Add(new LookUpColumnInfo(property.Name, property.Name));
                        //        }

                        //        lookupCtrl.Properties.DisplayMember = properties.Length > 0 ? properties[0].Name : string.Empty;
                        //        lookupCtrl.Properties.ValueMember = properties.Length > 0 ? properties[0].Name : string.Empty;
                        //    }
                        //}
                        this.lookUpCtrl.Properties.NullText = "";
                    }

                    this.EditValue = wrkFld.DefaultText;
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
                Lib.Common.gMsg = $"UCLookUp_Load>>ResetCtrl{Environment.NewLine}Exception : {ex.Message}";
            }
        }

        private object GetColumns(string popup)
        {
            // UCGridSet의 ResetColumns와 유사하게 WrkFldRepo에서 컬럼 정보를 가져옵니다.
            PopFldRepo popFldRepo = new PopFldRepo();
            List<PopFld> colProperties = popFldRepo.GetPopColumnProperties(frwId, frmId, popup);

            foreach (var column in colProperties)
            {
                columns.Add(new FrwCde
                {
                    Cd = column.FldNm,
                    SubCd = column.FldTitle
                });
            }

            return columns;
        }

        private List<dynamic> _dataList;
        private void SetPopupDataSource(string popId)
        {
            //PopUp을 열기 위해 팝업에 필요한 파라미터를 가져온다. 
            PopGetRepo popGetRepo = new PopGetRepo();
            List<PopGet> popGets = popGetRepo.GetPullFlds(frwId, frmId, thisNm);
            DSearchParam = new DynamicParameters();

            foreach (var popGet in popGets)
            {
                //string tmp = GetParamValue(this.FindForm().Controls, wrkGet.GetFldNm, wrkGet.GetWrkId, wrkGet.FldNm);
                string tmp = GetParamValue(this.FindForm().Controls, popGet);
                DSearchParam.Add(popGet.FldNm, tmp);
                Common.gLog = $"Declare {popGet.FldNm} varchar ='{tmp}'";
            }

            //Lookup 쿼리 정보를 가져온다.
            var sql = GenFunc.GetPopSql(new { FrwId=frwId, FrmId=frmId, PopId=popId});
            using (var db = new GaiaHelper())
            {
                //var lists = db.Query<dynamic>(sql, DSearchParam).ToList();
                //lookupCtrl.Properties.DataSource = lists;
                var lists = db.Query<dynamic>(sql, DSearchParam).ToList();

                // 데이터 소스 설정
                lookUpCtrl.Properties.DataSource = lists;

                // LookUpEdit 컬럼 설정
                lookUpCtrl.Properties.Columns.Clear();
                if (lists.Count > 0)
                {
                    var firstRow = lists[0] as IDictionary<string, object>;
                    if (firstRow != null)
                    {
                        List<PopFld> popFlds = new PopFldRepo().GetPopColumnProperties(frwId, frmId, popId);

                        if (popFlds != null)
                        {
                            foreach (var popFld in popFlds)
                            {
                                if (firstRow.ContainsKey(popFld.FldNm))
                                {
                                    LookUpColumnInfo column = CreateLookUpColumn(popFld);
                                    lookUpCtrl.Properties.Columns.Add(column);
                                }
                            }

                        }
                        else
                        {
                            if (firstRow != null)
                            {
                                foreach (var key in firstRow.Keys)
                                {
                                    lookUpCtrl.Properties.Columns.Add(new LookUpColumnInfo(key, key));
                                }
                            }
                        }
                        lookUpCtrl.Properties.DisplayMember = firstRow.Keys.First();
                        lookUpCtrl.Properties.ValueMember = firstRow.Keys.First();
                    }
                }
            }
        }
        private LookUpColumnInfo CreateLookUpColumn(PopFld popFld)
        {
            LookUpColumnInfo column = new LookUpColumnInfo(popFld.FldNm, popFld.FldTitle);
            //column.FormatType = DevExpress.Utils.FormatType.Custom;
            //column.FormatString = popFld.FormatString;
            //column.Alignment = popFld.Alignment;
            column.Width = popFld.FldTitleWidth;
            column.Visible = popFld.ShowYn;
            column.Alignment = GenFunc.StrToAlign(popFld.TextAlign);
            //column.Caption Title의 alignment

            return column;
        }

        private string GetParamValue(ControlCollection frm, PopGet popGet)
        {
            string str = string.Empty;

            if (string.IsNullOrEmpty(popGet.GetWrkId))
            {
                if (string.IsNullOrEmpty(popGet.GetFldNm))
                {
                    str = popGet.GetDefalueValue;
                }
                else
                {
                    dynamic tbx = frm.Find(popGet.GetFldNm, true).FirstOrDefault();
                    str = tbx.Text;
                }
            }
            else
            {
                dynamic tbx = frm.Find(popGet.GetWrkId, true).FirstOrDefault();
                str = tbx.GetText(popGet.GetFldNm);
            }
            return str;
        }
        private void ComboCtrl_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Delete)
                lookUpCtrl.EditValue = "";
        }
        #region INotifyPropertyChanged
        
        public delegate void delEventEditValueChanged(object Sender, Control control);   // delegate 선언
        public event delEventEditValueChanged UCEditValueChanged;   // event 선언
        public event PropertyChangedEventHandler? PropertyChanged;
        private void lookupCtrl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpCtrl.EditValue != null)
                {
                    // 선택된 값의 DataRow를 가져옴
                    var selectedRow = lookUpCtrl.Properties.GetDataSourceRowByKeyValue(lookUpCtrl.EditValue) as DataRowView;
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
                    UCEditValueChanged(this, lookUpCtrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

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
                        UCLook01 uccombo = ctrl as UCLook01;
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

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void lookupCtrl_TextChanged(object sender, EventArgs e)
        {
            //Text<---->EditValue
            if (lookUpCtrl.EditValue != null)
            {
                BindText = lookUpCtrl.EditValue.ToString();
            }
            else
            {
                BindText = string.Empty; // Or any default value you see fit
            }
            //BindText = lookupCtrl.Text;
        }
        #endregion

    }
}
