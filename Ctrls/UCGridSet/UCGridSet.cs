using Dapper;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.ComponentModel;
using Lib;
using Lib.Repo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Charts.Native;
using DevExpress.XtraRichEdit.Model;
using System.Windows.Documents;
using DevExpress.XtraVerticalGrid;
using System.Windows.Forms;
using DevExpress.XtraEditors.Senders;

namespace Ctrls
{
    public class UCGridSet : DevExpress.XtraGrid.GridControl
    {
        #region Properties Browseable(false) ----------------------------------------------------------
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public DevExpress.XtraGrid.Views.Grid.GridView gvCtrl { get; private set; }
        [Browsable(false)]
        private string frwId { get; set; }
        [Browsable(false)]
        private string frmId { get; set; }
        [Browsable(false)]
        private string thisNm { get; set; }
        [Browsable(false)]
        private object OSearchParam;
        [Browsable(false)]
        private DynamicParameters DSearchParam;

        #endregion
        #region Properties Browseable(true) -----------------------------------------------------------
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int RowCount { get => gvCtrl.RowCount; }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int FocuseRowIndex
        {
            get => gvCtrl.FocusedRowHandle;
            set => gvCtrl.FocusedRowHandle = value;
        }
        //[EditorBrowsable(EditorBrowsableState.Always)]
        //public DataRow GetForcuseDataRow 
        //{ 
        //    get 
        //    {
        //        return this.gvCtrl.GetFocusedDataRow(); 
        //    } 
        //}
        //[EditorBrowsable(EditorBrowsableState.Always)]
        //public DataRow GetDataRow(int rowHandle) 
        //{ 
        //    return this.gvCtrl.GetDataRow(rowHandle); 
        //}
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
        #region Methods Documentation -----------------------------------------------------------------
        [EditorBrowsable(EditorBrowsableState.Always)]
        public T GetDoc<T>(int rowIndex)
        {
            T doc = (T)gvCtrl.GetRow(rowIndex);
            return doc;
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public List<T> GetDocs<T>()
        {
            var list = (List<T>)this.DataSource;
            return list;
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public void AddNewDoc()
        {
            gvCtrl.AddNewRow();
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public void SetDataSource<T>(List<T> lists)
        {
            this.DataSource = new BindingList<T>(lists);
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public void Clear()
        {
            this.DataSource = null;
        }
        #endregion
        #region Methods Cell Value --------------------------------------------------------------------
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string GetText()
        {
            //focus된 Cell의 값을 가져온다.
            string rtn;
            if (gvCtrl.GetFocusedRowCellValue(gvCtrl.FocusedColumn.FieldName) == null)
            {
                rtn = string.Empty;
            }
            else
            {
                rtn = gvCtrl.GetFocusedRowCellValue(gvCtrl.FocusedColumn.FieldName).ToString();
            }
            return rtn;
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
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
        [EditorBrowsable(EditorBrowsableState.Always)]
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
        [EditorBrowsable(EditorBrowsableState.Always)]
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
        [EditorBrowsable(EditorBrowsableState.Always)]
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
        [EditorBrowsable(EditorBrowsableState.Always)]
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
        [EditorBrowsable(EditorBrowsableState.Always)]
        public void SetText(string columnName, dynamic value)
        {
            int rowIndex = gvCtrl.GetFocusedDataSourceRowIndex();
            gvCtrl.SetRowCellValue(rowIndex, columnName, value);
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public void SetText(int columnIndex, dynamic value)
        {
            int rowIndex = gvCtrl.GetFocusedDataSourceRowIndex();
            string columnName = GetColumnName(columnIndex);
            gvCtrl.SetRowCellValue(rowIndex, columnName, value);
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public void SetText(string columnName, int rowIndex, dynamic value)
        {
            gvCtrl.SetRowCellValue(rowIndex, columnName, value);
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        public void SetText(int columnIndex, int rowIndex, dynamic value)
        {
            string columnName = GetColumnName(columnIndex);
            gvCtrl.SetRowCellValue(rowIndex, columnName, value);
        }
        #endregion
        #region EVENT ---------------------------------------------------------------------------------
        public delegate void delEvent(object sender, EventArgs e);   // delegate 선언
        public event delEvent UCBeforeLeaveRow;
        private void gvCtrl_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            UCBeforeLeaveRow?.Invoke(sender, e);
        }
        public delegate void delEventSelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e);   // delegate 선언
        public event delEventSelectionChanged UCSelectionChanged;
        private void gvCtrl_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            UCSelectionChanged?.Invoke(sender, e);
        }
        /*
        gvCtrl.SelectionChanged += gvForms_SelectionChanged;
        private void gvForms_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }
         */
        public delegate void delEventInitNewRow(object sender, InitNewRowEventArgs e);   // delegate 선언
        public event delEventInitNewRow UCInitNewRow;
        private void gvCtrl_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            WrkFldRepo wrkFldRepo = new WrkFldRepo();
            var wrkFlds = wrkFldRepo.GetColumnProperties(frwId, frmId, thisNm);
            foreach (var wrkFld in wrkFlds)
            {
                if (wrkFld.DefaultText != null)
                {
                    string defaultTxt = wrkFld.DefaultText;
                    using (var db = new GaiaHelper())
                    {
                        defaultTxt = db.ReplaceGVariables(defaultTxt);
                        gvCtrl.SetRowCellValue(e.RowHandle, wrkFld.FldNm, defaultTxt);
                    }
                }
            }

            UCInitNewRow?.Invoke(sender, e);
        }
        public delegate void delEvent4(object sender, RowDeletingEventArgs e);
        public event delEvent4 UCRowDeleting;
        private void gvCtrl_RowDeleting(object sender, RowDeletingEventArgs e)
        {
            UCRowDeleting?.Invoke(sender, e);
        }

        public delegate void delEventFocusedRowChanged(object sender, int preIndex, int rowIndex, FocusedRowChangedEventArgs e);   // delegate 선언
        public event delEventFocusedRowChanged UCFocusedRowChanged;
        public void gvCtrl_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (UCFocusedRowChanged != null && e.FocusedRowHandle >= 0)
            {
                List<WrkSet> ctrls = new WrkSetRepo().SetPushFlds(frwId, frmId, thisNm);
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
                            // GetText 메서드를 사용하여 값을 가져옴
                            var fieldValue = this.GetText(columnName);
                            if (fieldValue != null)
                            {
                                Common.gMsg = $"Enter Value({fieldValue}) into Control({mapping[item.Key]})";
                                InitBinding(this.FindForm(), mapping[item.Key], item.Value, fieldValue);
                            }
                            else
                            {
                                Common.gMsg = $"Value for column {columnName} is null.";
                            }
                        }
                        else
                        {
                            Common.gMsg = $"Column name for key {item.Key} is null.";
                        }
                    }
                }
                UCFocusedRowChanged(sender, e.PrevFocusedRowHandle, e.FocusedRowHandle, e);
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

        public delegate void delEventCellValueChanged(object sender, CellValueChangedEventArgs e);
        public event delEventCellValueChanged UCCellValueChanged;
        private void gvCtrl_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            UCCellValueChanged?.Invoke(sender, e);
        }
        public delegate void delEventCellValueChanging(object sender, CellValueChangedEventArgs e);
        public event delEventCellValueChanging UCCellValueChanging;
        private void gvCtrl_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            UCCellValueChanging?.Invoke(sender, e);
        }
        #endregion

        public UCGridSet()
        {
            this.gvCtrl = new DevExpress.XtraGrid.Views.Grid.GridView(this);
            this.MainView = this.gvCtrl;
            this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gvCtrl });
            this.gvCtrl.GridControl = this;
            this.gvCtrl.Name = "gvCtrl";


            this.Load += ucGridSet_Load;

            this.gvCtrl.FocusedRowChanged += gvCtrl_FocusedRowChanged;
            this.gvCtrl.BeforeLeaveRow += gvCtrl_BeforeLeaveRow;
            this.gvCtrl.SelectionChanged += gvCtrl_SelectionChanged;
            this.gvCtrl.InitNewRow += gvCtrl_InitNewRow;
            this.gvCtrl.RowDeleting += gvCtrl_RowDeleting;
            this.gvCtrl.CellValueChanged += gvCtrl_CellValueChanged;
            this.gvCtrl.CellValueChanging += gvCtrl_CellValueChanging;
            //this.gvCtrl.MouseDown += gvCtrl_MouseDown;
            //this.gvCtrl.MouseMove += gvCtrl_MouseMove;
            //this.DragDrop += gcGrid_DragDrop;
            //this.DragEnter += gcGrid_DragEnter;

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
        #region PreView<T>() - Preview Form -----------------------------------------------------------
        private void ResetColumns()
        {
            WrkFldRepo wrkFldRepo = new WrkFldRepo();
            List<WrkFld> colProperties = wrkFldRepo.GetColumnProperties(frwId, frmId, thisNm);
            gvCtrl.Columns.Clear();
            if (colProperties != null)
            {
                foreach (var column in colProperties)
                {
                    AddGridColumn(gvCtrl, GetTempColumn(column) as GridColumn);
                }
                gvCtrl.RefreshData();
            }
        }

        private GridColumn GetTempColumn(WrkFld column)
        {
            //column의 내용으로 GridColumn을 생성하여 반환, TitleWidth Caption, TitleAlign, TextAlign, ShowYn, FixYn의 내용만 이용하면 된다. 
            GridColumn gridColumn = new GridColumn();
            gridColumn.Name = column.FldNm;
            gridColumn.FieldName = column.FldNm;
            gridColumn.Caption = column.FldTitle;
            gridColumn.Width = column.FldTitleWidth;
            gridColumn.AppearanceHeader.TextOptions.HAlignment = GenFunc.StrToAlign(column.TitleAlign);
            gridColumn.Visible = column.ShowYn;
            gridColumn.Fixed = (column.FixYn ? DevExpress.XtraGrid.Columns.FixedStyle.None : DevExpress.XtraGrid.Columns.FixedStyle.Left);
            if (!string.IsNullOrEmpty(column.Band1))
            {
                // 밴드 설정은 그리드 뷰에 밴드가 있는 경우에만 유효합니다.
                // 이 부분은 그리드에 밴드가 구성되어 있을 때 추가적인 로직이 필요합니다.
                // 예: column.OwnerBand = gridView.Bands[band1];
            }
            if (!string.IsNullOrEmpty(column.Band2))
            {
                // 예: column.OwnerBand = gridView.Bands[band2];
            }
            return gridColumn;
        }
        #endregion
        #region Open<T>() - Open Form -----------------------------------------------------------------
        public void Open(DataTable dataTable)
        {
            if (dataTable != null)
            {
                this.DataSource = dataTable;
                this.MainView.PopulateColumns();
                Common.gMsg = $"Data bound with {dataTable.Rows.Count} rows.";
            }
            else
            {
                Common.gMsg = "Failed to bind data: DataTable is null.";
            }
        }

        public void Open<T>()
        {
            Common.gMsg = $"{Environment.NewLine}-- {thisNm}.Open<T>() ------------------------>>";

            WrkGetRepo wrkGetRepo = new WrkGetRepo();
            List<WrkGet> wrkGets = wrkGetRepo.GetPullFlds(frwId, frmId, thisNm);
            DSearchParam = new DynamicParameters();

            foreach (var wrkGet in wrkGets)
            {
                string tmp = GetParamValue(this.FindForm().Controls, wrkGet);
                DSearchParam.Add(wrkGet.FldNm, tmp);
                Common.gMsg = $"Declare {wrkGet.FldNm} varchar ='{tmp}'";
            }
            OpenForm<T>();
        }

        private void OpenForm<T>()
        {
            this.DataSource = null;
            gvCtrl.Columns.Clear();
            //1. GridControl Configuration
            GridDefine();
            //2. Grid Column Configuration
            try
            {
                WrkFldRepo wrkFldRepo = new WrkFldRepo();
                List<WrkFld> colProperties = wrkFldRepo.GetColumnProperties(frwId, frmId, thisNm);
                gvCtrl.Columns.Clear();
                if (colProperties != null)
                {
                    foreach (var column in colProperties)
                    {
                        AddGridColumn(gvCtrl, GetGridColumn(column) as GridColumn);// Text Color
                        Common.gMsg = $"Added column: {column.FldNm}";
                    }
                    gvCtrl.RefreshData();
                    Common.gMsg = "Columns refreshed.";

                    //3. Data Source Binding
                    Common.gMsg = $"-- {thisNm}.Select Query ------------------------>>";
                    var sql = GenFunc.GetSql(new { FrwId = frwId, FrmId = frmId, WrkId = thisNm, CRUDM = "R" });
                    Common.gMsg = sql;
                    Common.gMsg = $"-- {thisNm}.End Select Query -------------------->>";

                    List<T> lists = new List<T>();

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

                    foreach (dynamic item in lists)
                    {
                        item.ChangedFlag = MdlState.None;
                    }

                    this.DataSource = new BindingList<T>(lists);


                    //var bindingLists = new BindingList<T>(lists);

                    //foreach (dynamic item in bindingLists)
                    //{
                    //    item.ChangedFlag = MdlState.None;
                    //}
                    //this.DataSource = bindingLists;
                    this.MainView.PopulateColumns();
                }
            }
            catch (Exception e)
            {
                Common.gMsg = $"-- {thisNm}. Exception ----------------------------->>";
                Common.gMsg = $"UCGridCode_OpenForm<T>() : {Environment.NewLine}--frwId : {frwId}{Environment.NewLine}-- frmId : {frmId}{Environment.NewLine}-- WorkSet : {thisNm}{Environment.NewLine}Exception :";
                Common.gMsg = $"{e.Message}";
                Common.gMsg = $"-- {thisNm}.End Exception -------------------------->>";
            }
        }
        #endregion
        #region Grid Column Configuration -------------------------------------------------------------
        private GridColumn GetGridColumn(WrkFld wrkFld)
        {
            GridColumn column = new GridColumn();

            column.Name = wrkFld.FldNm;
            column.FieldName = wrkFld.FldNm;
            column.Caption = wrkFld.FldTitle;
            column.Width = wrkFld.FldTitleWidth;
            column.Visible = wrkFld.ShowYn;
            column.OptionsColumn.AllowEdit = wrkFld.EditYn;
            column.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
            column.AppearanceHeader.Options.UseTextOptions = true;
            column.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            column.Fixed = (wrkFld.FixYn ? DevExpress.XtraGrid.Columns.FixedStyle.None : DevExpress.XtraGrid.Columns.FixedStyle.Left);
            column.UnboundType = DevExpress.Data.UnboundColumnType.String;

            switch (wrkFld.TitleAlign)
            {
                case "Default": column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Default; break;
                case "Near": column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near; break;
                case "Center": column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center; break;
                case "Far": column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far; break;
            }

            switch (wrkFld.TextAlign)
            {
                case "Default": column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default; break;
                case "Near": column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near; break;
                case "Center": column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center; break;
                case "Far": column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far; break;
            }

            if (wrkFld.FormatStr == "")
                column.DisplayFormat.FormatType = FormatType.None;
            else
            {
                switch (wrkFld.FldTy)
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
                column.DisplayFormat.FormatString = wrkFld.FormatStr;
            }

            switch (wrkFld.FldTy.ToUpper())
            {
                case "CHECKBOX":
                    column.ColumnEdit = SetCheckBox();
                    break;
                case "CODE":
                    column.ColumnEdit = SetColumnLookup(wrkFld.Popup);//SetLookupCode(popup, 1);
                    break;
                case "CODE2":
                    column.ColumnEdit = SetColumnLookup_Value(wrkFld.Popup); //SetLookupCode(popup, 2);
                    break;
                case "COMBO":
                    column.ColumnEdit = SetLookupCombo(wrkFld.Popup, 1);
                    break;
                case "COMBO2":
                    column.ColumnEdit = SetLookupCombo(wrkFld.Popup, 2);
                    break;
                case "POPUP":
                    RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                    buttonEdit.Buttons[0].Kind = ButtonPredefines.Glyph;
                    buttonEdit.Buttons[0].Caption = "Select";
                    buttonEdit.ButtonClick += (s, e) =>
                    {
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
                default:
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

        private void AddGridColumn(DevExpress.XtraGrid.Views.Grid.GridView gridV, GridColumn gridC)
        {
            if (gridC != null)
            {
                gridV.Columns.Add(gridC);
            }
        }
        #endregion
        #region GridDefine() - Grid Control Configuration (Options, Navigator, etc.) ------------------
        private void GridDefine()
        {
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
        #region Save<T>() - Save Data -----------------------------------------------------------------
        public void Save<T>()
        {
            if (gvCtrl.IsEditing)
            {
                gvCtrl.CloseEditor();
            }
            if (gvCtrl.FocusedRowModified)
            {
                gvCtrl.UpdateCurrentRow();
            }

            var list = (BindingList<T>)this.DataSource;

            if (list != null)
            {
                using (var db = new GaiaHelper())
                {
                    var changedItems = list.Where(item => IsChanged(item)).ToList();

                    foreach (dynamic item in changedItems)
                    {
                        WrkRefRepo wrkRefRepo = new WrkRefRepo();
                        List<WrkRef> wrkRefs = wrkRefRepo.RefDataFlds(frwId, frmId, thisNm);

                        string sql = string.Empty;
                        int ii = 0;

                        string operation = GetOperation(GetChangedFlag(item));

                        if (!string.IsNullOrEmpty(operation))
                        {
                            sql = GenFunc.GetSql(new { FrwId = frwId, FrmId = frmId, WrkId = thisNm, CRUDM = operation });
                            foreach (var wrkRef in wrkRefs)
                            {
                                Common.gMsg = $"--[{thisNm}] {operation}-------------------->>";
                                Common.gMsg = $"--Grid Save As Parameters------------------->>";
                                sql = sql.Replace($"{wrkRef.FldNm}", $"'{RefParamValue(this.FindForm().Controls, wrkRef)}'");
                            }
                            Common.gMsg = sql;
                            ii = db.OpenExecute(sql, item);
                            Common.gMsg = $"--[{thisNm}] END {operation}---------------->>";
                        }
                    }
                }
                OnSaveCompleted();
            }
        }

        private void OnSaveCompleted()
        {
            //OpenForm<T>();
            Common.gMsg = $"--[{thisNm}] END Delete--------------------{Environment.NewLine}";
        }

        private string GetOperation(MdlState state)
        {
            switch (state)
            {
                case MdlState.Inserted:
                    return "C";
                case MdlState.Updated:
                    return "U";
                case MdlState.Deleted:
                    return "D";
                default:
                    return string.Empty;
            }
        }

        private bool IsChanged<T>(T item)
        {
            var prop = typeof(T).GetProperty("ChangedFlag");
            if (prop != null)
            {
                var value = (MdlState)prop.GetValue(item);
                return value != MdlState.None;
            }
            return false;
        }

        private MdlState GetChangedFlag<T>(T item)
        {
            var prop = typeof(T).GetProperty("ChangedFlag");
            if (prop != null)
            {
                return (MdlState)prop.GetValue(item);
            }
            return MdlState.None;
        }

        #endregion
        #region Delete<T>() - Temporarily Delete Data -------------------------------------------------
        public void Delete<T>(RowDeletingEventArgs e)
        {
            var list = (BindingList<T>)this.DataSource;
            if (list != null)
            {
                list.Remove((T)e.Row); // 그리드에서만 항목 제거
            }
        }

        public void Delete<T>()
        {
            var list = (BindingList<T>)this.DataSource;
            if (list != null && FocuseRowIndex >= 0 && FocuseRowIndex < list.Count)
            {
                list.RemoveAt(FocuseRowIndex); // 그리드에서만 항목 제거
            }
        }

        #endregion
        #region Grid Control Get/Reference Parmameters ------------------------------------------------
        private string GetParamValue(ControlCollection frm, WrkGet wrkGet)
        {
            string str = string.Empty;

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
            return str;
        }
        private string RefParamValue(ControlCollection frm, WrkRef wrkRef)
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(wrkRef.RefWrkId))
            {
                if (string.IsNullOrEmpty(wrkRef.RefFldNm))
                {
                    str = wrkRef.RefDefalueValue;
                }
                else
                {
                    dynamic tbx = frm.Find(wrkRef.RefFldNm, true).FirstOrDefault();
                    str = tbx.Text;
                }
            }
            else
            {
                dynamic tbx = frm.Find(wrkRef.RefWrkId, true).FirstOrDefault();
                str = tbx.GetText(wrkRef.RefFldNm);
            }
            return str;
        }
        #endregion
    }

    public class RowsDropEventArgs : EventArgs
    {
        public int SourceRowHandle { get; }
        public int TargetRowHandle { get; }

        public RowsDropEventArgs(int sourceRowHandle, int targetRowHandle)
        {
            SourceRowHandle = sourceRowHandle;
            TargetRowHandle = targetRowHandle;
        }
    }
}
