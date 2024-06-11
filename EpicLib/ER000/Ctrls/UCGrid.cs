using DevExpress.XtraGrid.Columns;
using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using Lib;
using Lib.Repo;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using DevExpress.Data;
using DevExpress.Utils.DirectXPaint;
using DevExpress.XtraGrid.Views.Base;

namespace Ctrls
{
    public class UCGrid : DevExpress.XtraGrid.GridControl
    {
        [Browsable(false)]
        private string frwId { get; set; }
        private string frmId { get; set; }
        private string fldId { get; set; }
        public string openFrm { get; set; }
        public string openFld { get; set; }
        public long RowCount { get { return gvCtrl.RowCount; } }
        public int FocuseRowIndex
        {
            get => gvCtrl.FocusedRowHandle;
            set => gvCtrl.FocusedRowHandle = value;
        }
        public DevExpress.XtraGrid.Views.Grid.GridView gvCtrl { get; set; }

        public DataRow GetForcuseDataRow { get { return gvCtrl.GetFocusedDataRow(); } }

        [Category("ACE UC Property"), Description("RowAutoHeigh")]
        public bool RowAutoHeigh
        {
            get => gvCtrl.OptionsView.RowAutoHeight;
            set => gvCtrl.OptionsView.RowAutoHeight = value;
        }
        [Category("ACE UC Property"), Description("ColumnAutoWidth")]
        public bool ColumnAutoWidth
        {
            get => gvCtrl.OptionsView.ColumnAutoWidth;
            set => gvCtrl.OptionsView.ColumnAutoWidth = value;
        }
        [Category("ACE UC Property"), Description("ShowGroupPanel")]
        public bool ShowGroupPanel
        {
            get => gvCtrl.OptionsView.ShowGroupPanel;
            set => gvCtrl.OptionsView.ShowGroupPanel = value;
        }
        [Category("ACE UC Property"), Description("ShowFindPanel")]
        public bool ShowFindPanel
        {
            get => gvCtrl.OptionsFind.AlwaysVisible;
            set => gvCtrl.OptionsFind.AlwaysVisible = value;
        }
        [Category("ACE UC Property"), Description("MultiSelect")]
        public bool MultiSelect
        {
            get => gvCtrl.OptionsSelection.MultiSelect;
            set => gvCtrl.OptionsSelection.MultiSelect = value;
        }
        [Category("ACE UC Property"), Description("MultiSelectMode")]
        public GridMultiSelectMode MultiSelectMode
        {
            get => gvCtrl.OptionsSelection.MultiSelectMode;
            set => gvCtrl.OptionsSelection.MultiSelectMode = value;
        }

        #region UserController Event
        #endregion
        #region ACE UC Event
        public delegate void delEvent(object sender, EventArgs e);   // delegate 선언
        public event delEvent BeforeLeaveRow;
        private void gvCtrl_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            BeforeLeaveRow?.Invoke(sender, e);
        }
        public delegate void delEventSelectionChanged(object sender, SelectionChangedEventArgs e);   // delegate 선언
        public event delEventSelectionChanged SelectionChanged;
        private void gvCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChanged?.Invoke(sender, e);
        }
        public delegate void delEventInitNewRow(object sender, InitNewRowEventArgs e);   // delegate 선언
        public event delEventInitNewRow InitNewRow;
        private void gvCtrl_InitNewRow(object sender, InitNewRowEventArgs e)
        {

            InitNewRow?.Invoke(sender, e);
        }
        public delegate void delEvent4(object sender, RowDeletingEventArgs e);
        public event delEvent4 RowDeleting;
        private void gvCtrl_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            RowDeleting?.Invoke(sender, e);
        }

        //ForcuseRow가 변경이 되면 발생하는 이벤트
        //컬럼과 특정 컨트롤러를 연결하여 해당 컨트롤러에 

        //public delegate void delEventFocusedRowChanged(object sender, int preIndex, int rowIndex, FocusedRowChangedEventArgs e);   // delegate 선언
        //public event delEventFocusedRowChanged FocusedRowChanged;
        //public void gvCtrl_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        //{
        //    if ((FocusedRowChanged != null) && (e.FocusedRowHandle >= 0))
        //    {
        //        List<WrkGet> ctrls = new WrkGetRepo().GetPullFlds(frwId, frmId, fldId);
        //        if (ctrls != null)
        //        {
        //            foreach (var item in ctrls)
        //            {
        //                if (gvCtrl.GetFocusedRowCellValue(item.CtrlNm) != null)
        //                {
        //                    InitBinding(this.FindForm(), item.CtrlNm, item.CtrlTy, gvCtrl.GetFocusedRowCellValue(item.CtrlNm).ToString());
        //                }
        //            }
        //        }
        //        var ctrls = db.PushParam(new { sys = SysCode, frm = FrmID, wkset = FldID });
        //        if (ctrls != null)
        //        {
        //            Common.gLog = $"{Environment.NewLine}-- {FldID} Start Push";
        //            var fieldInfo = ctrls.ToDictionary(x => x.Ctrl_id, x => x.Ctrl_ty);
        //            var mapping = ctrls.ToDictionary(x => x.Ctrl_id, x => x.Param_name);
        //            string rtn = string.Empty;
        //            foreach (var item in fieldInfo)
        //            {
        //                if (gvCtrl.GetFocusedRowCellValue(mapping[item.Key]) != null)
        //                {
        //                    rtn = gvCtrl.GetFocusedRowCellValue(mapping[item.Key]).ToString();
        //                }

        //                InitBinding(this.FindForm(), item.Key, item.Value, rtn);
        //                Common.gLog = $"Enter Value({rtn}) into Control({item.Key})";
        //            }
        //        }

        //        FocusedRowChanged(sender, e.PrevFocusedRowHandle, e.FocusedRowHandle, e);
        //    }
        //}
        //private void InitBinding(Form uc, string ctrlID, string ctrlTY, string map)
        //{
        //    switch (ctrlTY.ToLower())
        //    {
        //        case "uctext":
        //            UCText uctext = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCText;
        //            uctext.BindText = map;
        //            break;
        //        case "ucdate":
        //            UCDate ucdate = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCDate;
        //            ucdate.BindText = map;
        //            break;
        //        case "uccombo":
        //            UCCombo uccombo = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCCombo;
        //            uccombo.BindText = map;
        //            break;
        //        case "uccheckbox":
        //            UCCheckBox uccheckbox = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCCheckBox;
        //            uccheckbox.BindText = map;
        //            break;
        //        case "ucmemo":
        //            UCMemo ucmemo = uc.Controls.Find(ctrlID, true).FirstOrDefault() as UCMemo;
        //            ucmemo.BindText = map;
        //            break;
        //        default:
        //            break;
        //    }
        //}

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
        #endregion

        #region 1. Text(Get, Set)
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

        #region 2. Document(Get, Create, Update, Delete)
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

        public UCGrid()
        {
            gvCtrl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MainView = gvCtrl;
            this.ViewCollection.Add(gvCtrl);
            this.UseEmbeddedNavigator = true;

            HandleCreated += ucGrid_HandleCreated;
        }

        private void ucGrid_HandleCreated(object? sender, EventArgs e)
        {
            frwId = Common.GetValue("gFrameWorkId");

            Form ? form = this.FindForm();
            if (form != null)
            {
                frmId = form.Name;
            }
            else
            {
                frmId = "Unknown";
            }
            fldId = this.Name;

            if (frwId != string.Empty)
            {
                ResetColumns();
            }
        }
        private void ResetColumns()
        {
            try
            {
                // GridPropRepo의 인스턴스를 생성합니다.
                WrkFldRepo wrkFldRepo = new WrkFldRepo();
                // 모든 컬럼 설정을 데이터베이스에서 가져옵니다.
                List<WrkFld> colProperties = wrkFldRepo.GetColumnProperties(frwId, frmId, fldId);

                //var repo = new Repo.TGridColumnPropRepo();
                //var colProperties = repo.GetTGridColumnProperties(sysCd, frmId, wkSetId);

                // MainView를 GridView 타입으로 캐스팅합니다.
                gvCtrl = this.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                // GridView에 설정된 기존의 컬럼들을 제거합니다.
                gvCtrl.Columns.Clear();

                if (colProperties!=null)
                {
                    foreach (var colproperty in colProperties)
                    {
                        AddGridColumn(gvCtrl, SetGridProperties(colproperty.FldNm,     // Column ID
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
                                                                colproperty.ColorFont));// Text Color
                    }
                }
                // GridView를 갱신합니다.
                gvCtrl.RefreshData();
            }
            catch (Exception ex)
            {
                // 예외 처리 로직, 예외 발생 시 사용자에게 알리기, 로깅 등
                MessageBox.Show($"Error setting default columns: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddGridColumn(DevExpress.XtraGrid.Views.Grid.GridView gvCtrl, DevExpress.XtraGrid.Columns.GridColumn gridColumn)
        {
            // GridView에 컬럼 추가
            gvCtrl.Columns.Add(gridColumn);
        }
        private DevExpress.XtraGrid.Columns.GridColumn SetGridProperties(string ctrl_id,     // Column ID
                                             string ctrl_ty,     // Text, Int, Date, Decimal, Code(Lookup), Form, Checkbox, Memo
                                             string title,       // Title
                                             string titleAlign,  // Title Alignment DevExpress.Utils.HorzAlignment TitleAlign
                                             int titleW,      // Title Width
                                             string popup,       // ctrl_ty에 따라 다른 값이 들어갑니다. (Lookup, Form, Checkbox, Memo)
                                             string txt,         // Default Text
                                             string txtAlign,    // Text Alignment DevExpress.Utils.HorzAlignment TxtAlign
                                             bool fix_chk,     // Freeze Column
                                             bool group_chk,   // Grouping
                                             bool show_chk,    // Hide
                                             bool need_chk,    // Necessary Field
                                             bool edit_chk,    // ReadOnly
                                             string band1,       // Title Band 2nd
                                             string band2,       // Title Band 1st
                                             string sum_ty,      // sum, avg, max, min
                                             string format_ty,   // #.##, #,##0.00
                                             string color_bg,    // Column Background Color
                                             string color_fore)  // Text Color
        {
            DevExpress.XtraGrid.Columns.GridColumn column = new DevExpress.XtraGrid.Columns.GridColumn();

            // 실제 프로퍼티는 TGridProp의 속성에 맞게 설정해야 합니다.
            column.Name = ctrl_id;
            column.FieldName = ctrl_id;

            // 여기서부터는 컬럼 타입에 따른 ColumnEdit 설정 예시입니다.
            // 실제 ColumnEdit 설정은 컨트롤 타입에 따라 다양하게 구현될 수 있습니다.
            // 예를 들어 RepositoryItemTextEdit, RepositoryItemDateEdit, RepositoryItemCheckEdit 등이 있습니다.
            column.ColumnEdit = null;  // Make Function fn(ctrl_ty) to set column.ColumnEdit
            switch (ctrl_ty)
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
            column.Caption = title;
            column.AppearanceHeader.TextOptions.HAlignment = GenFunc.StrToAlign(titleAlign);
            column.Width = titleW;
            //pupup Controller Type에 따라 다른 설정이 필요합니다.
            //txt는 GridView의 AddNewRow 이벤트에서 설정합니다. 
            column.AppearanceCell.TextOptions.HAlignment = GenFunc.StrToAlign(txtAlign);
            column.Fixed = fix_chk ? FixedStyle.Left : FixedStyle.None;
            column.OptionsColumn.AllowGroup = group_chk ? DefaultBoolean.True : DefaultBoolean.False;
            column.Visible = show_chk;
            //need_chk는 저장시 확인하는 로직에서 사용합니다.
            column.OptionsColumn.AllowEdit = edit_chk;
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
            switch (sum_ty)
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
            if (!string.IsNullOrEmpty(format_ty))
            {
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                column.DisplayFormat.FormatString = format_ty;
            }
            // 배경색과 글자색 설정
            if (!string.IsNullOrEmpty(color_bg))
            {
                column.AppearanceCell.BackColor = ColorTranslator.FromHtml(color_bg);
            }
            if (!string.IsNullOrEmpty(color_fore))
            {
                column.AppearanceCell.ForeColor = ColorTranslator.FromHtml(color_fore);
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

        // Open<T> Pull Param을 이용한 Open
        //public void Open<T>()
        //{
        //    Common.gLog = $"{Environment.NewLine}-- {FldID} Open<T>()";
        //    using (var db = new ACE.Lib.DbHelper())
        //    {
        //        var rows = db.PullParam(new { sys = SysCode, frm = FrmID, wkset = FldID });

        //        DynamicParam = new DynamicParameters();
        //        foreach (var item in rows)
        //        {
        //            string tmp = GetParamValue(this.FindForm().Controls, item.Param_name, item.Wkset_id, item.Ctrl_id);
        //            DynamicParam.Add(item.Param_name, tmp);
        //            Common.gLog = $"Declare @{item.Param_name} varchar(100) ='{tmp}'";
        //        }
        //    }
        //    OpenForm<T>();
        //}

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

        public void Open<T>()
        {
            BindingDataToGrid<T>();
        }


        // 모델없이 바인딩한후 저장하는 프로세서입니다. 
        public void Save<T>()
        {
            gvCtrl.CloseEditor();
            //gvCtrls.UpdateCurrentRow();

            var list = (BindingList<T>)this.DataSource;

            using (var db = new SeleneHelper())
            {
                //Parameter정보 가져오기 (SAVE SEE, Push, Pull)
                //List<MdlParam> rows = db.RefParam(new { sys = SysCode, frm = FrmID, wkset = FldID });

                string sql = string.Empty;

                foreach (dynamic item in list)
                {
                    switch (item.ChangedFlag)
                    {
                        case MdlState.None:
                            break;
                        case MdlState.Inserted:
                            //sql = db.GetCRUDQuery(new { sys = SysCode, frm = FrmID, wkset = FldID, CRUD = "C" });
                            //Lib.Common.gMsg = $"-- {FldID} Insert";
                            Lib.Common.gMsg = $"--Grid Save As Parameters";
                            //foreach (var row in rows)
                            //{
                            //    sql = sql.Replace($"@{row.Ctrl_id}", $"'{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'");
                            //    Common.gLog = $"@{row.Ctrl_id} : '{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'";
                            //}
                            Lib.Common.gMsg = sql;
                            db.OpenExecute(sql, item);
                            Lib.Common.gMsg = $"--END Insert{Environment.NewLine}";
                            break;
                        case MdlState.Updated:
                            //sql = db.GetCRUDQuery(new { sys = SysCode, frm = FrmID, wkset = FldID, CRUD = "U" });
                            //Lib.Common.gMsg = $"-- {FldID} Update";
                            Lib.Common.gMsg = $"--Grid Save As Parameters";
                            //foreach (var row in rows)
                            //{
                            //    sql = sql.Replace($"@{row.Ctrl_id}", $"'{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'");
                            //    Common.gLog = $"@{row.Ctrl_id} : '{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'";
                            //}
                            sql = "update TST100 set MenuNm = @MenuNm, HideYn = @HideYn, CId = @CId, CDt = @CDt where SysCd = @SysCd and MenuId = @MenuId";
                            Lib.Common.gMsg = sql;
                            db.OpenExecute(sql, item);
                            Lib.Common.gMsg = $"--END Update{Environment.NewLine}";
                            break;
                        case MdlState.Deleted:
                            //sql = db.GetCRUDQuery(new { sys = SysCode, frm = FrmID, wkset = FldID, CRUD = "D" });
                            //Lib.Common.gMsg = $"-- {FldID} Delete";
                            Lib.Common.gMsg = $"--Grid Save As Parameters";
                            //foreach (var row in rows)
                            //{
                            //    sql = sql.Replace($"@{row.Ctrl_id}", $"'{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'");
                            //    Common.gLog = $"@{row.Ctrl_id} : '{GetParamValue(this.FindForm().Controls, row.Param_name, row.Wkset_id, row.Ctrl_id)}'";
                            //}
                            Lib.Common.gMsg = sql;
                            db.OpenExecute(sql, item);
                            Lib.Common.gMsg = $"--END Delete{Environment.NewLine}";
                            break;
                    }
                }
            }
        }
        public void New<T>()
        { }
        public void Delete<T>()
        { }
        public void Check()
        {
            MessageBox.Show(gvCtrl.SelectedRowsCount.ToString());
        }
    }
}
