using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using System.Data;
using Lib;
using Lib.Repo;
using Ctrls;
using DevExpress.Map.Native;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.Ocsp;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using System.Reflection;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using Dapper;
using System.Windows.Forms;
using DevExpress.Data.Filtering.Helpers;

namespace Ctrls
{
    public class UCGridSet : DevExpress.XtraGrid.GridControl
    {
        [Browsable(false)]
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string thisNm { get; set; }
        public string openFrm { get; set; }
        public string openFld { get; set; }

        private object OSearchParam;
        private DynamicParameters DSearchParam;

        public long RowCount { get { return gvCtrl.RowCount; } }
        public int FocuseRowIndex
        {
            get => gvCtrl.FocusedRowHandle;
            set => gvCtrl.FocusedRowHandle = value;
        }
        public DevExpress.XtraGrid.Views.Grid.GridView gvCtrl { get; set; }

        public DataRow GetForcuseDataRow { get { return gvCtrl.GetFocusedDataRow(); } }
        public DataRow GetDataRow(int rowHandle) { return gvCtrl.GetDataRow(rowHandle); }

        #region Properties
        [Category("A UserController Property"), Description("RowAutoHeigh")]
        public bool RowAutoHeigh
        {
            get => gvCtrl.OptionsView.RowAutoHeight;
            set => gvCtrl.OptionsView.RowAutoHeight = value;
        }
        [Category("A UserController Property"), Description("ColumnAutoWidth")]
        public bool ColumnAutoWidth
        {
            get => gvCtrl.OptionsView.ColumnAutoWidth;
            set => gvCtrl.OptionsView.ColumnAutoWidth = value;
        }
        [Category("A UserController Property"), Description("ShowGroupPanel")]
        public bool ShowGroupPanel
        {
            get => gvCtrl.OptionsView.ShowGroupPanel;
            set => gvCtrl.OptionsView.ShowGroupPanel = value;
        }
        [Category("A UserController Property"), Description("ShowFindPanel")]
        public bool ShowFindPanel
        {
            get => gvCtrl.OptionsFind.AlwaysVisible;
            set => gvCtrl.OptionsFind.AlwaysVisible = value;
        }
        [Category("A UserController Property"), Description("MultiSelect")]
        public bool MultiSelect
        {
            get => gvCtrl.OptionsSelection.MultiSelect;
            set => gvCtrl.OptionsSelection.MultiSelect = value;
        }
        [Category("A UserController Property"), Description("MultiSelectMode")]
        public GridMultiSelectMode MultiSelectMode
        {
            get => gvCtrl.OptionsSelection.MultiSelectMode;
            set => gvCtrl.OptionsSelection.MultiSelectMode = value;
        }
        #endregion
        #region Methods - Document(Get, Create, Update, Delete)
        public T GetDocument<T>(int rowIndex)
        {
            T doc = (T)gvCtrl.GetRow(rowIndex);
            return doc;
        }
        public BindingList<T> GetDocuments<T>()
        {
            var list = (BindingList<T>)this.DataSource;
            return list;
        }
        public void AddNewDocument()
        {
            gvCtrl.AddNewRow();
        }
        public void SetGridData<T>(List<T> lists)
        {
            this.DataSource = new BindingList<T>(lists);
        }
        public void Clear()
        {
            this.DataSource = null;
        }
        public void FindRow(string col, string val)
        {
            int rowHandle = gvCtrl.LocateByValue(col, val);
            if (rowHandle != DevExpress.Data.DataController.OperationInProgress)
                gvCtrl.FocusedRowHandle = rowHandle;
        }
        #endregion
        #region Methods - Value Get Set
        public string GetText(string columnName)
        {
            string rtn;
            if (gvCtrl.GetFocusedRowCellValue(columnName) == null)
            {
                rtn = string.Empty;
            }
            else
            {
                rtn = gvCtrl.GetFocusedRowCellValue(columnName).ToString();
            }
            return rtn;
        }
        public string GetText(int columnIndex)
        {
            string columnName = GetColumnName(columnIndex);
            string rtn;
            if (gvCtrl.GetFocusedRowCellValue(columnName) == null)
            {
                rtn = string.Empty;
            }
            else
            {
                rtn = gvCtrl.GetFocusedRowCellValue(columnName).ToString();
            }
            return rtn;
        }
        public string GetText(string columnName, int rowIndex)
        {
            if (rowIndex < 0)
            {
                return string.Empty;
            }
            else
            {
                string rtn;
                if (gvCtrl.GetRowCellValue(rowIndex, columnName) == null)
                {
                    rtn = string.Empty;
                }
                else
                {
                    rtn = gvCtrl.GetRowCellValue(rowIndex, columnName).ToString();
                }
                return rtn;
            }
        }
        public string GetText(int columnIndex, int rowIndex)
        {
            if (rowIndex < 0)
            {
                return string.Empty;
            }
            else
            {
                string columnName = GetColumnName(columnIndex);
                string rtn;

                if (gvCtrl.GetRowCellValue(rowIndex, columnName) == null)
                {
                    rtn = string.Empty;
                }
                else
                {
                    rtn = gvCtrl.GetRowCellValue(rowIndex, columnName).ToString();
                }
                return rtn;
            }
        }
        private string GetColumnName(int columnIndex)
        {
            string columnName = null;
            foreach (GridColumn item in gvCtrl.Columns)
            {
                if (item.FieldName == gvCtrl.Columns[columnIndex].FieldName)
                {
                    columnName = item.FieldName;
                }
            }
            return columnName;
        }
        public void SetText(string columnName, dynamic value)
        {
            int rowIndex = gvCtrl.GetFocusedDataSourceRowIndex();
            gvCtrl.SetRowCellValue(rowIndex, columnName, value);
        }
        public void SetText(int columnIndex, dynamic value)
        {
            int rowIndex = gvCtrl.GetFocusedDataSourceRowIndex();
            string columnName = GetColumnName(columnIndex);
            gvCtrl.SetRowCellValue(rowIndex, columnName, value);
        }
        public void SetText(string columnName, int rowIndex, dynamic value)
        {
            gvCtrl.SetRowCellValue(rowIndex, columnName, value);
        }
        public void SetText(int columnIndex, int rowIndex, dynamic value)
        {
            string columnName = GetColumnName(columnIndex);
            gvCtrl.SetRowCellValue(rowIndex, columnName, value);
        }
        #endregion
        #region Events
        public delegate void delEvent(object sender, EventArgs e);   // delegate 선언
        public event delEvent UCBeforeLeaveRow;
        private void gvCtrl_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            UCBeforeLeaveRow?.Invoke(sender, e);
        }
        public delegate void delEventSelectionChanged(object sender, SelectionChangedEventArgs e);   // delegate 선언
        public event delEventSelectionChanged UCSelectionChanged;
        private void gvCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UCSelectionChanged?.Invoke(sender, e);
        }
        public delegate void delEventInitNewRow(object sender, InitNewRowEventArgs e);   // delegate 선언
        public event delEventInitNewRow UCInitNewRow;
        private void gvCtrl_InitNewRow(object sender, InitNewRowEventArgs e)
        {

            UCInitNewRow?.Invoke(sender, e);
        }
        public delegate void delEvent4(object sender, RowDeletingEventArgs e);
        public event delEvent4 UCRowDeleting;
        private void gvCtrl_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            UCRowDeleting?.Invoke(sender, e);
        }

        //ForcuseRow가 변경이 되면 발생하는 이벤트
        //컬럼과 특정 컨트롤러를 연결하여 해당 컨트롤러에 

        public delegate void delEventFocusedRowChanged(object sender, int preIndex, int rowIndex, FocusedRowChangedEventArgs e);   // delegate 선언
        public event delEventFocusedRowChanged UCFocusedRowChanged;
        public void gvCtrl_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if ((UCFocusedRowChanged != null) && (e.FocusedRowHandle >= 0))
            {
                List<WrkSet> ctrls = new WrkSetRepo().SetPushFlds(frwId, frmId, thisNm);
                if (ctrls != null)
                {
                    foreach (var ctrl in ctrls)
                    {
                        var fieldInfo = ctrls.ToDictionary(x => x.FldNm, x => x.ToolNm);
                        var mapping = ctrls.ToDictionary(x => x.FldNm, x => x.SetFldNm);
                        dynamic rtn = null;

                        foreach (var item in fieldInfo)
                        {
                            if (gvCtrl.GetFocusedRowCellValue(mapping[item.Key]) != null)
                            {
                                rtn = gvCtrl.GetFocusedRowCellValue(mapping[item.Key]);
                            }
                            Common.gLog = $"Enter Value({rtn}) into Control({item.Key})";
                            InitBinding(this.FindForm(), item.Key, item.Value, rtn);
                        }
                    }
                }
                UCFocusedRowChanged(sender, e.PrevFocusedRowHandle, e.FocusedRowHandle, e);
            }
        }
        private void InitBinding(Form uc, string ctrlID, string ctrlTY, dynamic map)
        {
            switch (ctrlTY.ToLower())
            {
                case "uctext":
                    UCTextBox uctext = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCTextBox;
                    uctext.BindText = map.ToString();
                    break;
                case "ucdate":
                    UCDateBox ucdate = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCDateBox;
                    ucdate.BindText = map.ToString();
                    break;
                case "uccombo":
                    UCLookUp uccombo = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCLookUp;
                    uccombo.BindText = map.ToString();
                    break;
                case "uccheckbox":
                    UCCheckBox uccheckbox = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCCheckBox;
                    uccheckbox.BindValue = map;
                    break;
                case "ucmemo":
                    UCMemo ucmemo = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCMemo;
                    ucmemo.BindText = map.ToString();
                    break;
                default:
                    break;
            }
        }

        public delegate void delEventCellValueChanged(object sender, CellValueChangedEventArgs e);
        public event delEventCellValueChanged CellValueChanged;
        private void gvCtrl_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            CellValueChanged?.Invoke(sender, e);
        }
        public delegate void delEventCellValueChanging(object sender, CellValueChangedEventArgs e);
        public event delEventCellValueChanging CellValueChanging;
        private void gvCtrl_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            CellValueChanging?.Invoke(sender, e);
        }
        public delegate void delEventMouseDown(object sender, MouseEventArgs e);
        public event delEventMouseDown UCMouseDown;
        private void gvCtrl_MouseDown(object? sender, MouseEventArgs e)
        {
            UCMouseDown?.Invoke(sender, e);
        }
        public delegate void delEventMouseMove(object sender, MouseEventArgs e);
        public event delEventMouseMove UCMouseMove;
        private void gvCtrl_MouseMove(object? sender, MouseEventArgs e)
        {
            UCMouseMove?.Invoke(sender, e);
        }

        #endregion

        public UCGridSet()
        {
            gvCtrl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MainView = gvCtrl;
            this.ViewCollection.Add(gvCtrl);
            Load += ucGridSet_Load;
            //HandleCreated += ucGridSet_HandleCreated;
            gvCtrl.FocusedRowChanged += gvCtrl_FocusedRowChanged;
            gvCtrl.BeforeLeaveRow += gvCtrl_BeforeLeaveRow;
            gvCtrl.SelectionChanged += gvCtrl_SelectionChanged;
            gvCtrl.InitNewRow += gvCtrl_InitNewRow;
            gvCtrl.RowDeleting += gvCtrl_RowDeleting;
            gvCtrl.CellValueChanged += gvCtrl_CellValueChanged;
            gvCtrl.CellValueChanging += gvCtrl_CellValueChanging;
            gvCtrl.MouseDown += gvCtrl_MouseDown;
            gvCtrl.MouseMove += gvCtrl_MouseMove;
        }

        private void ucGridSet_Load(object? sender, EventArgs e)
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

            thisNm = this.Name;

            if (frwId != string.Empty)
            {
                ResetColumns();
            }
        }
        //최초의 Grid 컬럼을 데이터 없이 보여준다. 
        #region Grid Column Setting
        private void ResetColumns()
        {
            try
            {
                WrkFldRepo wrkFldRepo = new WrkFldRepo();
                List<WrkFld> colProperties = wrkFldRepo.GetColumnProperties(frwId, frmId, thisNm);
                gvCtrl.Columns.Clear();
                if (colProperties!=null)
                {
                    foreach (var colproperty in colProperties)
                    {
                        GridColumn column = SetGridProperties(colproperty.FldNm,     // Column ID
                                                              colproperty.FldTy,     // Text, Int, Date, Decimal, Code(Lookup)
                                                              colproperty.FldTitle,       // Title
                                                              colproperty.TitleAlign,  // Title Alignment DevExpress.Utils.HorzAlignment TitleAlign
                                                              colproperty.FldTitleWidth,      // Title Width
                                                              colproperty.Popup,       // Lookup
                                                              colproperty.DefaultText,         // Default Text
                                                              colproperty.TextAlign,    // Text Alignment DevExpress.Utils.HorzAlignment TxtAlign
                                                              colproperty.FixYn,     // Freeze Column
                                                              colproperty.GroupYn,   // Grouping
                                                              colproperty.ShowYn,    // Hide
                                                              colproperty.NeedYn,    // Necessary Field
                                                              colproperty.EditYn,    // ReadOnly
                                                              colproperty.Band1,       // Title Band 2nd
                                                              colproperty.Band2,       // Title Band 1st
                                                              colproperty.FuncStr,      // sum, avg, max, min
                                                              colproperty.FormatStr,   // #.##, #,##0.00
                                                              colproperty.ColorBg,    // Column Background Color
                                                              colproperty.ColorFont);// Text Color
                        AddGridColumn(gvCtrl, column);
                    }
                }
                gvCtrl.RefreshData();
            }
            catch (Exception ex)
            {
                Lib.Common.gMsg = $"ucGridSet_HandleCreated>>ResetColumns{Environment.NewLine}Exception : {ex.Message}";
            }
        }

        private void AddGridColumn(GridView gridV, GridColumn gridC)
        {
            if (gridC != null)
            {
                gridV.Columns.Add(gridC);
            }
            //====================================================================================
            //여기서 그리트 컬럼 컬렉션에 그리드 컬럼을 추가하면 다음번에는 컬럼을 다시 그리지 않아도 된다. 
            //====================================================================================
        }

        private GridColumn SetGridProperties(string fldNm, string fldTy, string fldTitle, string titleAlign, int fldTitleWidth, 
                                             string popup, string defaultText, string textAlign, bool fixYn, bool groupYn, 
                                             bool showYn, bool needYn, bool editYn, string band1, string band2, 
                                             string funcStr, string formatStr, string colorBg, string colorFont)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();

            // 실제 프로퍼티는 TGridProp의 속성에 맞게 설정해야 합니다.
            column.Name = fldNm;
            column.FieldName = fldNm;

            // 여기서부터는 컬럼 타입에 따른 ColumnEdit 설정 예시입니다.
            // 실제 ColumnEdit 설정은 컨트롤 타입에 따라 다양하게 구현될 수 있습니다.
            // 예를 들어 RepositoryItemTextEdit, RepositoryItemDateEdit, RepositoryItemCheckEdit 등이 있습니다.
            //column.ColumnEdit = null;  // Make Function fn(ctrl_ty) to set column.ColumnEdit
            switch (fldTy)
            {
                case "Text":
                    // 텍스트 편집 컨트롤 설정
                    column.ColumnEdit = new RepositoryItemTextEdit();
                    break;
                case "Date":
                    // 날짜 편집 컨트롤 설정
                    column.ColumnEdit = new RepositoryItemDateEdit();
                    break;
                case "Int":
                    // 정수 편집 컨트롤 설정
                    var edit = new RepositoryItemTextEdit();
                    edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    edit.Mask.EditMask = "d";
                    column.ColumnEdit = edit;
                    break;
                case "Decimal":
                    // 십진수 편집 컨트롤 설정
                    var editDecimal = new RepositoryItemTextEdit();
                    editDecimal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    editDecimal.Mask.EditMask = "n2";
                    column.ColumnEdit = editDecimal;
                    break;
                    // ... 기타 컨트롤 타입에 대한 설정
            }
            column.Caption = fldTitle;
            column.AppearanceHeader.TextOptions.HAlignment = GenFunc.StrToAlign(titleAlign);
            column.Width = fldTitleWidth;
            //pupup Controller Type에 따라 다른 설정이 필요합니다.
            //txt는 GridView의 AddNewRow 이벤트에서 설정합니다. 
            column.AppearanceCell.TextOptions.HAlignment = GenFunc.StrToAlign(textAlign);
            column.Fixed = fixYn ? FixedStyle.Left : FixedStyle.None;
            column.OptionsColumn.AllowGroup = groupYn ? DefaultBoolean.True : DefaultBoolean.False;
            column.Visible = showYn;
            //need_chk는 저장시 확인하는 로직에서 사용합니다.
            column.OptionsColumn.AllowEdit = editYn;
            if (!string.IsNullOrEmpty(band1))
            {
                // 밴드 설정은 그리드 뷰에 밴드가 있는 경우에만 유효합니다.
                // 이 부분은 그리드에 밴드가 구성되어 있을 때 추가적인 로직이 필요합니다.
                // 예: column.OwnerBand = gridView.Bands[band1];
            }
            // 밴드 2 설정은 동일한 방식으로 적용됩니다.
            if (!string.IsNullOrEmpty(band2))
            {
                // 예: column.OwnerBand = gridView.Bands[band2];
            }
            // 집계 함수 설정
            switch (funcStr)
            {
                case "sum":
                    column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    break;
                case "avg":
                    column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
                    break;
                case "max":
                    column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Max;
                    break;
                case "min":
                    column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Min;
                    break;
            }
            // 형식 설정
            if (!string.IsNullOrEmpty(formatStr))
            {
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                column.DisplayFormat.FormatString = formatStr;
            }
            // 배경색과 글자색 설정
            if (!string.IsNullOrEmpty(colorBg))
            {
                column.AppearanceCell.BackColor = ColorTranslator.FromHtml(colorBg);
            }
            if (!string.IsNullOrEmpty(colorFont))
            {
                column.AppearanceCell.ForeColor = ColorTranslator.FromHtml(colorFont);
            }

            //기타 기본값을 설정
            column.AppearanceHeader.Options.UseTextOptions = true;
            //DevExpress.Data.UnboundColumnType.String의 내용이 명확하지 않음 column.UnboundDataType = DevExpress.Data.UnboundColumnType.String;
            //colproperty.Format_ty의 내용이 명확하지 않음 column.DisplayFormat.FormatType = colproperty.Format_ty;
            //column.OptionsColumn.AllowFocus = edit_chk != "1";
            column.OptionsColumn.AllowEdit = true;

            // 컬럼을 반환합니다.
            return column;
        }
        #endregion

        #region BindingDataToGrid - Field에 데이터 바인딩 - field set에 데이터바인딩이 필요한지?
        private void BindingDataToGrid<T>()
        {
            this.DataSource = null; // 기존 데이터 소스를 클리어합니다.
            List<T> lists;
            using (var db = new Lib.SeleneHelper())
            {
                // 데이터베이스에서 데이터를 가져와서 그리드에 바인딩하는 로직입니다.
                //var sql = db.GetCRUDQuery(new { sys = SysCode, frm = FrmID, wkset = FldID, CRUD = "R" });
                var sql = @"
select a.SysCd, a.MenuId, a.MenuNm, a.FrmId, a.HideYn, a.CId, a.CDt
  from TST100 a
 where 1=1
";
                lists = db.Query<T>(sql);

                Common.gLog = sql;
                //if (DynamicParam != null)
                //{
                //    lists = db.Query<T>(sql, DynamicParam);
                //}
                //else if (SearchParam != null)
                //{
                //    lists = db.Query<T>(sql, SearchParam);
                //}
                //else
                //{
                //    lists = db.Query<T>(sql, new { sys = SysCode, frm = FrmID, wkset = FldID });
                //}
            }

            var bindingLists = new BindingList<T>(lists);
            foreach (dynamic item in bindingLists)
            {
                item.ChangedFlag = MdlState.None;
            }
            this.DataSource = bindingLists;
            Common.gLog = $"-- End Select{Environment.NewLine}";
            // 필요없음 MainView.RefreshData();
        }
        #endregion

        #region Grid Open
        // Open<T> Pull Param을 이용한 Open
        //public void Open<T>()
        //{
        //    OpenForm<T>();
        //}

        public void Open<T>()
        {
            Common.gLog = $"{Environment.NewLine}-- {thisNm} Open<T>()";

            WrkGetRepo wrkGetRepo = new WrkGetRepo();
            List<WrkGet> wrkGets = wrkGetRepo.GetPullFlds(frwId, frmId, thisNm);
            DSearchParam = new DynamicParameters();

            foreach (var wrkGet in wrkGets)
            {
                //string tmp = GetParamValue(this.FindForm().Controls, wrkGet.GetFldNm, wrkGet.GetWrkId, wrkGet.FldNm);
                string tmp = GetParamValue(this.FindForm().Controls, wrkGet);
                DSearchParam.Add(wrkGet.FldNm, tmp);
                Common.gLog = $"Declare {wrkGet.FldNm} varchar ='{tmp}'";
            }
            OpenForm<T>();
        }

        // Open<T> Push Param을 이용한 Open
        //public void Open<T>(object p1, object p2)
        //{
        //    Common.gLog = $"{Environment.NewLine}-- {FldID} Open<T>(object p1, object p2)";
        //    ThisObj = p1;
        //    OpenObj = p2;
        //    OpenForm<T>();
        //}

        // Open<T> Search Param을 이용한 Open
        //public void Open<T>(string containfrom, string wkset, object search)
        //{
        //    FrmID = containfrom;
        //    FldID = wkset;
        //    SearchParam = search;
        //    Common.gLog = $"{Environment.NewLine}-- {FldID} Open<T>(string containfrom, string wkset, object search)";
        //    OpenForm<T>();
        //}

        private void OpenForm<T>()
        {
            this.DataSource = null;
            gvCtrl.Columns.Clear();
            GridDefine();
            try
            {
                WrkFldRepo wrkFldRepo = new WrkFldRepo();
                List<WrkFld> colProperties = wrkFldRepo.GetColumnProperties(frwId, frmId, thisNm);
                gvCtrl.Columns.Clear();
                if (colProperties != null)
                {

                    foreach (var column in colProperties)
                    {
                        AddGridColumn(gvCtrl, GetGridColumn(column.FldNm,     // Column ID
                                                            column.FldTy,     // Text, Int, Date, Decimal, Code(Lookup)
                                                            column.FldTitle,       // Title
                                                            column.TitleAlign,  // Title Alignment DevExpress.Utils.HorzAlignment TitleAlign
                                                            column.FldTitleWidth,      // Title Width
                                                            column.Popup,       // Lookup
                                                            column.DefaultText,         // Default Text
                                                            column.TextAlign,    // Text Alignment DevExpress.Utils.HorzAlignment TxtAlign
                                                            column.FixYn,     // Freeze Column
                                                            column.GroupYn,   // Grouping
                                                            column.ShowYn,    // Hide
                                                            column.NeedYn,    // Necessary Field
                                                            column.EditYn,    // ReadOnly
                                                            column.Band1,       // Title Band 2nd
                                                            column.Band2,       // Title Band 1st
                                                            column.FuncStr,      // sum, avg, max, min
                                                            column.FormatStr,   // #.##, #,##0.00
                                                            column.ColorBg,    // Column Background Color
                                                            column.ColorFont));// Text Color
                    }
                    gvCtrl.RefreshData();


                    var sql = GenFunc.GetSql(new { FrwId = frwId, FrmId = frmId, WrkId = thisNm, CRUDM = "R" });
                    Common.gMsg = sql;

                    List<T> lists;
                    using (var db = new GaiaHelper())
                    {
                        if (DSearchParam != null)
                        {
                            lists = db.Query<T>(sql, DSearchParam);
                        }
                        else if (OSearchParam != null)
                        {
                            lists = db.Query<T>(sql, OSearchParam);
                        }
                        else
                        {
                            lists = db.Query<T>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = thisNm });
                        }
                    }

                    var bindingLists = new BindingList<T>(lists);

                    foreach (dynamic item in bindingLists)
                    {
                        item.ChangedFlag = MdlState.None;
                    }
                    this.DataSource = bindingLists;
                }
            }
            catch (Exception e)
            {
                Common.gMsg = $"UCGridSet_OpenForm<T>() : {Environment.NewLine}--frwId : {frwId}{Environment.NewLine}-- frmId : {frmId}{Environment.NewLine}-- GridSet : {thisNm}{Environment.NewLine}Exception : {e.Message}";
            }
        }

        #endregion
        #region Grid Save
        #endregion
        #region Grid New
        public void New<T>()
        { }
        #endregion
        #region Grid Delete
        public void Delete<T>()
        { }
        #endregion


        #region 1.  GridDefine() - DataSource, DataBinding
        #region 1-1. 그리드 뷰 구하기 GridDefine()
        private void GridDefine()
        {

            //using (var db = new ACE.Lib.DbHelper())
            //{
            //    var ucInfo = db.GetWorkSet(new { sys = SysCode, frm = FrmID, wkset = FldID }).FirstOrDefault();
            //}

            //public List<MdlWorkSet> GetWorkSet(object param)
            //{
            //    string sql = @"
            //select Id, Sys_cd, Frm_id, Wkset_id, Wkset_ty, Wkset_nm, 
            //       New_chk, Delete_chk, Update_chk, Use_chk, ShowFooter_chk, 
            //       ShowGroupPanel_chk, Edit_chk, OptionsFind_chk, ColumnAutoWidth_chk, 
            //       EvenRow_chk, Memo
            //  from ATZ200
            // where Sys_cd=@sys
            //   and Frm_id=@frm
            //   and Wkset_id like @wkset + '%'
            //";
            //    return SqlMapper.Query<MdlWorkSet>(_conn, sql, param, _tran).ToList();
            //}

            //FrmWrk에서 FrmWrkRepo에서 GetByWrk(frwId, frmId, ctrlNm)를 가져온다.
            FrmWrkRepo frmWrkRepo = new FrmWrkRepo();
            FrmWrk ucInfo = frmWrkRepo.GetByWrk(frwId, frmId, thisNm);

            if (ucInfo != null)
            {
                //gvCtrl.OptionsFind.AlwaysVisible = (ucInfo.OptionsFind_chk == "0" ? false : true);
                gvCtrl.OptionsFind.AlwaysVisible = true;
                gvCtrl.OptionsFind.AllowFindPanel = true;
                gvCtrl.OptionsFind.ShowCloseButton = true;
                gvCtrl.OptionsFind.ShowClearButton = true;
                gvCtrl.OptionsFind.ShowFindButton = true;

                //gvCtrl.OptionsView.ShowGroupPanel = (ucInfo.ShowGroupPanel_chk == "0" ? false : true);
                //gvCtrl.OptionsView.ShowFooter = (ucInfo.ShowFooter_chk == "0" ? false : true);
                //gvCtrl.OptionsView.ColumnAutoWidth = (ucInfo.ColumnAutoWidth_chk == "0" ? false : true);
                //gvCtrl.OptionsView.EnableAppearanceEvenRow = (ucInfo.EvenRow_chk == "0" ? false : true);
                gvCtrl.OptionsView.ShowGroupPanel = true;
                gvCtrl.OptionsView.ShowFooter = true;
                gvCtrl.OptionsView.ColumnAutoWidth = true;
                gvCtrl.OptionsView.EnableAppearanceEvenRow = true;
                gvCtrl.OptionsView.ShowIndicator = true;
                gvCtrl.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
                gvCtrl.OptionsView.RowAutoHeight = true;

                //gvCtrl.OptionsBehavior.Editable = (ucInfo.Edit_chk == "0" ? false : true);
                gvCtrl.OptionsBehavior.Editable = true;
                gvCtrl.OptionsBehavior.EditorShowMode = EditorShowMode.MouseDown;

                gvCtrl.OptionsCustomization.AllowColumnMoving = true;
                gvCtrl.OptionsCustomization.AllowColumnResizing = true;
                gvCtrl.OptionsCustomization.AllowFilter = true;
                gvCtrl.OptionsCustomization.AllowSort = true;

                gvCtrl.OptionsSelection.MultiSelect = true;
                gvCtrl.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CellSelect;
                gvCtrl.OptionsSelection.EnableAppearanceFocusedCell = true;
                gvCtrl.OptionsSelection.EnableAppearanceFocusedRow = true;

                gvCtrl.FocusRectStyle = DrawFocusRectStyle.RowFocus;

                gvCtrl.OptionsMenu.EnableColumnMenu = false;
                gvCtrl.OptionsMenu.EnableFooterMenu = false;
                gvCtrl.OptionsMenu.EnableGroupPanelMenu = false;
                gvCtrl.OptionsMenu.ShowAddNewSummaryItem = DefaultBoolean.True;
                gvCtrl.OptionsMenu.ShowAutoFilterRowItem = true;
                gvCtrl.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gvCtrl.OptionsMenu.ShowGroupSortSummaryItems = true;
                gvCtrl.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gvCtrl.OptionsMenu.ShowSplitItem = true;

                gvCtrl.OptionsNavigation.AutoFocusNewRow = true;
                gvCtrl.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 255, 192);
                gvCtrl.Appearance.SelectedRow.BackColor = Color.FromArgb(255, 255, 192);
                gvCtrl.Appearance.SelectedRow.Options.UseBackColor = true;

                ///아래 Default Setting
                gvCtrl.Appearance.FocusedRow.BackColor = System.Drawing.Color.Gold;
                gvCtrl.Appearance.HeaderPanel.Options.UseTextOptions = true;
                gvCtrl.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                gvCtrl.Appearance.SelectedRow.BackColor = System.Drawing.Color.Aquamarine;
                gvCtrl.Appearance.SelectedRow.Options.UseBackColor = true;
                gvCtrl.DetailHeight = 300;
                gvCtrl.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                gvCtrl.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
                gvCtrl.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
                gvCtrl.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
                gvCtrl.OptionsPrint.AllowMultilineHeaders = true;

                //GridNavigator(this, (ucInfo.NewYn == "0" ? false : true), (ucInfo.Delete_chk == "0" ? false : true), true);
                GridNavigator(this, true, true, true);
            }
        }
        #endregion
        #region 1-2. 그리드 뷰 구하기 GridNavigator
        private void GridNavigator(GridControl gc, bool chkAppend, bool chkRemove, bool chkShowNavigator)
        {
            ControlNavigator navigator = gc.EmbeddedNavigator;
            navigator.Buttons.BeginUpdate();
            try
            {
                navigator.Buttons.Append.Visible = chkAppend;
                navigator.Buttons.Remove.Visible = chkRemove;
                navigator.Buttons.Edit.Visible = false;
                navigator.Buttons.EndEdit.Visible = false;
                navigator.Buttons.CancelEdit.Visible = false;
            }
            finally
            {
                navigator.Buttons.EndUpdate();
            }
            gc.UseEmbeddedNavigator = chkShowNavigator;
        }
        #endregion
        #region 1-3. 그리드 컬럼 구하기 - GetGridColumn(caption, fieldName, unboundColumnType, width, horzAlignment, allowEdit, formatType, formatString)
        /// <summary>
        /// 그리드 컬럼 구하기
        /// </summary>
        /// <param name="caption">제목</param>
        /// <param name="fieldName">필드명</param>
        /// <param name="unboundColumnType">언바운드 컬럼 종류</param>
        /// <param name="width">너비</param>
        /// <param name="horzAlignment">수평 정렬</param>
        /// <param name="allowEdit">편집 허용 여부</param>
        /// <param name="formatType">형식 종류</param>
        /// <param name="formatString">형식 문자열</param>
        /// <returns>그리드 컬럼</returns>
        private GridColumn GetGridColumn(string fldNm, string fldTy, string fldTitle, string titleAlign, int fldTitleWidth, 
                                         string popup, string defaultText, string textAlign, bool fixYn, 
                                         bool groupYn, bool showYn, bool needYn, bool editYn, 
                                         string band1, string band2, string funcStr, string formatStr, 
                                         string colorBg, string colorFont)
        {
            GridColumn column = new GridColumn();

            column.Name = fldNm;
            column.FieldName = fldNm;
            column.Caption = fldTitle;
            column.Width = fldTitleWidth;
            column.Visible = showYn;
            column.OptionsColumn.AllowEdit = editYn;
            //column.Tag = new AceTool.Common.MyRowStyle(AceTool.Grid.SetColor(foreColor), AceTool.Grid.SetColor(backColor), popup);
            column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
            column.AppearanceHeader.Options.UseTextOptions = true;
            column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            column.Fixed = (fixYn? FixedStyle.None : FixedStyle.Left);
            column.UnboundType = DevExpress.Data.UnboundColumnType.String;

            switch (titleAlign)
            {
                case "Default": column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Default; break;
                case "Near": column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near; break;
                case "Center": column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center; break;
                case "Far": column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far; break;
            }

            switch (textAlign)
            {
                case "Default": column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default; break;
                case "Near": column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near; break;
                case "Center": column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center; break;
                case "Far": column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far; break;
            }

            if (formatStr == "")
                column.DisplayFormat.FormatType = FormatType.None;
            else
            {
                switch (fldTy)
                {
                    case "Decimal":
                        column.DisplayFormat.FormatType = FormatType.Numeric;
                        break;
                    case "Int":
                        column.DisplayFormat.FormatType = FormatType.Numeric;
                        break;
                    case "Date":
                        column.DisplayFormat.FormatType = FormatType.DateTime;
                        break;
                    case "DateTime":
                        column.DisplayFormat.FormatType = FormatType.DateTime;
                        break;
                    default:
                        column.DisplayFormat.FormatType = FormatType.Custom;
                        break;
                }

                column.DisplayFormat.FormatString = formatStr;

                //SummaryItem
                switch (funcStr)
                {
                    case "AVG":
                        GridColumnSummaryItem SummaryAvg = new GridColumnSummaryItem(SummaryItemType.Average, fldNm, "{0:" + formatStr + "}");
                        column.Summary.Add(SummaryAvg);
                        break;
                    case "Count":
                        GridColumnSummaryItem SummaryCnt = new GridColumnSummaryItem(SummaryItemType.Count, fldNm, "{0:" + formatStr + "}");
                        column.Summary.Add(SummaryCnt);
                        break;
                    case "Max":
                        GridColumnSummaryItem SummaryMax = new GridColumnSummaryItem(SummaryItemType.Max, fldNm, "{0:" + formatStr + "}");
                        column.Summary.Add(SummaryMax);
                        break;
                    case "Min":
                        GridColumnSummaryItem SummaryMin = new GridColumnSummaryItem(SummaryItemType.Min, fldNm, "{0:" + formatStr + "}");
                        column.Summary.Add(SummaryMin);
                        break;
                    case "Sum":
                        GridColumnSummaryItem SummarySum = new GridColumnSummaryItem(SummaryItemType.Sum, fldNm, "{0:" + formatStr + "}");
                        column.Summary.Add(SummarySum);
                        break;
                }
            }

            switch (fldTy.ToUpper())
            {
                case "CHECKBOX":
                    column.ColumnEdit = SetCheckBox();
                    break;
                case "CODE":
                    column.ColumnEdit = SetColumnLookup(popup);//SetLookupCode(popup, 1);
                    break;
                case "CODE2":
                    column.ColumnEdit = SetColumnLookup_Value(popup); //SetLookupCode(popup, 2);
                    break;
                case "COMBO":
                    column.ColumnEdit = SetLookupCombo(popup, 1);
                    break;
                case "COMBO2":
                    column.ColumnEdit = SetLookupCombo(popup, 2);
                    break;
                case "POPUP":
                    RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                    buttonEdit.Buttons[0].Kind = ButtonPredefines.Glyph;
                    buttonEdit.Buttons[0].Caption = "Select";
                    buttonEdit.ButtonClick += (s, e) => {
                        // 팝업 창을 열거나 원하는 동작을 수행
                        MessageBox.Show("팝업을 표시합니다.");
                    };
                    column.ColumnEdit = buttonEdit;
                    break;
                case "MEMO":
                    RepositoryItemMemoEdit MemoEdit = new RepositoryItemMemoEdit();
                    MemoEdit.AutoHeight = true;
                    MemoEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    MemoEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    MemoEdit.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
                    column.ColumnEdit = MemoEdit;
                    break;
            }
            return column;
        }
        private RepositoryItemCheckEdit SetCheckBox()
        {
            RepositoryItemCheckEdit chkbox = new RepositoryItemCheckEdit();
            chkbox.NullText = "0";
            chkbox.ValueChecked = "1";
            chkbox.ValueUnchecked = "0";
            chkbox.ValueGrayed = "0";
            chkbox.NullStyle = StyleIndeterminate.Unchecked;
            chkbox.CheckStyle = CheckStyles.Radio; // CheckStyles.Standard;
            return chkbox;
        }
        private RepositoryItem SetColumnLookup(string pcode)
        {
            RepositoryItemLookUpEdit lookUp = new RepositoryItemLookUpEdit();

            //using (var db = new ACE.Lib.DbHelper())
            //{
            //}
            //List<MdlIdName> lists = new List<MdlIdName>();
            //lists = db.GetCodeNm(new { Grp = pcode });

            //lookUp.DataSource = lists;
            //lookUp.ValueMember = "Id";
            //lookUp.DisplayMember = "Nm";

            //lookUp.ShowHeader = false;
            //lookUp.ForceInitialize();
            //lookUp.PopulateColumns();
            //lookUp.Columns["Id"].Visible = true;
            //lookUp.Columns["Nm"].Visible = true;
            //lookUp.DropDownRows = 15; //dsLook.Tables[0].Rows.Count;
            //lookUp.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //lookUp.AutoHeight = true;
            //lookUp.NullText = "";
            //lookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //lookUp.AutoSearchColumnIndex = 1;
            //lookUp.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //lookUp.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.AutoSearch;
            //lookUp.CaseSensitiveSearch = false;

            return lookUp;
        }
        private RepositoryItemLookUpEdit SetColumnLookup_Value(string pcode)
        {
            RepositoryItemLookUpEdit lookUp = new RepositoryItemLookUpEdit();

            //List<MdlIdName> lists = new List<MdlIdName>();
            //lists = db.GetNmNm(new { Grp = pcode });
            //lookUp.DataSource = lists;
            //lookUp.ValueMember = "Id";
            //lookUp.DisplayMember = "Nm";

            //lookUp.ShowHeader = false;
            //lookUp.ForceInitialize();
            //lookUp.PopulateColumns();
            //lookUp.Columns["Id"].Visible = false;
            //lookUp.Columns["Nm"].Visible = true;
            //lookUp.DropDownRows = 15; //dsLook.Tables[0].Rows.Count;
            //lookUp.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //lookUp.AutoHeight = true;
            //lookUp.NullText = "";
            //lookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //lookUp.AutoSearchColumnIndex = 1;
            //lookUp.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            //lookUp.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.AutoSearch;
            //lookUp.CaseSensitiveSearch = false;
            return lookUp;
        }
        private RepositoryItemLookUpEdit SetLookupCode(string grp, string opt)
        {
            RepositoryItemLookUpEdit lookup = new RepositoryItemLookUpEdit();
            //List<MdlIdName> lists;

            //if (opt == "0")
            //{
            //    lists = db.GetNmNm(new { Grp = grp }, "0"); //컬럼에서는 항상 ALL제외 
            //}
            //else
            //{
            //    lists = db.GetCodeNm(new { Grp = grp }, "0"); //컬럼에서는 항상 ALL제외 
            //}

            //lookup.DataSource = lists;
            //lookup.ValueMember = "Id";
            //lookup.DisplayMember = "Nm";
            //lookup.ShowHeader = false;
            //lookup.ForceInitialize();
            //lookup.PopulateColumns();
            //lookup.Columns["Id"].Visible = true;
            //lookup.Columns["Nm"].Visible = true;
            //lookup.DropDownRows = 10; //lookup.count
            //lookup.BestFitMode = BestFitMode.BestFitResizePopup;
            //lookup.AutoHeight = true;
            //lookup.NullText = "";
            //lookup.TextEditStyle = TextEditStyles.Standard;
            //lookup.AutoSearchColumnIndex = 1;
            //lookup.SearchMode = SearchMode.OnlyInPopup;
            //lookup.HeaderClickMode = HeaderClickMode.AutoSearch;
            //lookup.CaseSensitiveSearch = false;
            return lookup;
        }
        private RepositoryItemLookUpEdit SetLookupCombo(object pcode, int opt)
        {
            RepositoryItemLookUpEdit LookUp = new RepositoryItemLookUpEdit();

            LookUp.DataSource = null;
            LookUp.ValueMember = "Code";
            LookUp.DisplayMember = "Code";

            LookUp.ShowHeader = false;
            LookUp.ForceInitialize();
            LookUp.PopulateColumns();
            LookUp.Columns["Code"].Visible = false;

            LookUp.DropDownRows = 10;// dsLook.Tables[0].Rows.Count;
            LookUp.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            LookUp.AutoHeight = true;
            LookUp.NullText = "";
            LookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            LookUp.AutoSearchColumnIndex = 1;
            LookUp.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            LookUp.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.AutoSearch;
            LookUp.CaseSensitiveSearch = false;

            return LookUp;
        }

        #endregion
        #region 1-4. 그리드 컬럼 추가하기 - AddGridColumn(gridView, gridColumn)
        ///// <summary>
        ///// 그리드 컬럼 추가하기
        ///// </summary>
        ///// <param name="gridView">그리드 뷰</param>
        ///// <param name="gridColumn">그리드 컬럼</param>
        //private void AddGridColumn(GridView gridView, GridColumn gridColumn)
        //{
        //    gridView.Columns.Add(gridColumn);
        //}
        #endregion

        #endregion

        #region 기타 함수
        //private void gvCtrl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        //{
        //    //string tmp = "1";//gvCtrl.Tag.ToString();
        //    //if (tmp == "1")
        //    //{
        //    //    ACE.Common._gridPopupMenuShowing(sender, e, gcCtrl, gvCtrl).Show(Control.MousePosition);
        //    //}
        //    //else
        //    //{
        //    //    ACE.Common._gridPopupMenuShowing2(sender, e, gcCtrl, gvCtrl).Show(Control.MousePosition);
        //    //}
        //}
        //public string CallPopup()
        //{
        //    //GridColumn column = gvCtrl.FocusedColumn;
        //    //AceTool.Common.MyRowStyle cColor = (AceTool.Common.MyRowStyle)column.Tag;
        //    //string frmId = cColor.PopCode;
        //    //return frmId;
        //    return "";
        //}
        //public Form LoadPopup(string frmId)
        //{
        //    string dir = @"C:\ACE";
        //    string frmName = frmId;
        //    string frmPath = $"{dir}\\{frmName}.dll";

        //    Assembly assmbly = AppDomain.CurrentDomain.Load(File.ReadAllBytes(frmPath));
        //    //UserControl ucform = (UserControl)Activator.CreateInstance(assmbly.GetType($"ACE.{frmName}"));
        //    Form frm = (Form)Activator.CreateInstance(assmbly.GetType($"ACE.{frmName}"));
        //    return frm;
        //}
        #endregion

        private string GetParamValue(ControlCollection frm, WrkGet wrkGet)
        {
            string str = string.Empty;
            //아마도 이부분은 수정이 필요할듯 컨트롤러에 따라 BindText가 다르니까 처리방법을 고려할것 
            if (string.IsNullOrEmpty(wrkGet.GetWrkId))
            {
                if (string.IsNullOrEmpty(wrkGet.GetFldNm))
                {
                    str = wrkGet.GetDefalueValue;
                }
                else
                {
                    dynamic tbx = frm.Find(wrkGet.GetFldNm, true).FirstOrDefault();
                    str = tbx.Text;
                }
            }
            else
            {
                dynamic tbx = frm.Find(wrkGet.GetWrkId, true).FirstOrDefault();
                str = tbx.GetText(wrkGet.GetFldNm);
            }

            //if (string.IsNullOrEmpty(wrkGet.WrkId))
            //{
                
            //}

            return str;
        }
    }
}
