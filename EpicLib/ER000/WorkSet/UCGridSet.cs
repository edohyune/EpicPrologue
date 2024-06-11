using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ER000.Lib;
using ER000.Lib.Repo;
using ER000.Interface;
using Dapper;
using System.ComponentModel;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using System.Dynamic;

namespace ER000.WorkSet
{
    public partial class UCGridSet : UserControl, IGridSet
    {
        
        #region Properties Browseable(false) ----------------------------------------------------------
        //[EditorBrowsable(EditorBrowsableState.Always)]
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public DevExpress.XtraGrid.Views.Grid.GridView gvCtrl { get; private set; }
        //public DevExpress.XtraGrid.GridControl gcCtrl { get; set; }
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
        //[Browsable(false)]
        //private WrkFld wrkFld { get; set; }
        [Browsable(false)]
        private WrkFldRepo wrkFldRepo { get; set; }
        [Browsable(false)]
        private List<WrkFld> wrkFlds { get; set; }
        [Browsable(false)]
        public DynamicModel Model { get; set; }
        #endregion

        public UCGridSet()
        {
            InitializeComponent();
            Load += ucGridSet_Load;
        }
        private void ucGridSet_Load(object? sender, EventArgs e)
        {
            frwId = Common.GetValue("gFrameWorkId");

            Form? form = FindForm();
            if (form != null)
            {
                frmId = form.Name;
            }
            else
            {
                frmId = "Unknown";
            }

            thisNm = gcCtrl.Name;

            if (frwId != string.Empty)
            {
                InitializeColumns();
            }
        }
        #region InitializeColumns() - Preview Form ---------------------------------------------------
        public void InitializeColumns()
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
        public void Open()
        {
            wrkFldRepo = new WrkFldRepo();
            wrkFlds = wrkFldRepo.GetFldsProperties(frwId, frmId, thisNm);

            //동적 모델을 생성한다. 
            Model = new DynamicModel();
            foreach (WrkFld wrkFld in wrkFlds)
            {
                Model.SetDynamicProperty(wrkFld.FldNm, wrkFld.DefaultText);
            }

            WrkGetRepo wrkGetRepo = new WrkGetRepo();
            List<WrkGet> wrkGets = wrkGetRepo.GetPullFlds(frwId, frmId, thisNm);
            DSearchParam = new DynamicParameters();

            foreach (var wrkGet in wrkGets)
            {
                string tmp = GetParamValue(this.FindForm().Controls, wrkGet);
                DSearchParam.Add(wrkGet.FldNm, tmp);
                Common.gMsg = $"Declare {wrkGet.FldNm} varchar ='{tmp}'";
            }

            OpenWrk();
        }

        //public void Open(DataTable dataTable)
        //{
        //    if (dataTable != null)
        //    {
        //        this.DataSource = dataTable;
        //        this.MainView.PopulateColumns();
        //        Common.gMsg = $"Data bound with {dataTable.Rows.Count} rows.";
        //    }
        //    else
        //    {
        //        Common.gMsg = "Failed to bind data: DataTable is null.";
        //    }
        //}

        //public void Open<T>()
        //{
        //    Common.gMsg = $"{Environment.NewLine}-- {thisNm}.Open<T>() ------------------------>>";

        //    WrkGetRepo wrkGetRepo = new WrkGetRepo();
        //    List<WrkGet> wrkGets = wrkGetRepo.GetPullFlds(frwId, frmId, thisNm);
        //    DSearchParam = new DynamicParameters();

        //    foreach (var wrkGet in wrkGets)
        //    {
        //        string tmp = GetParamValue(this.FindForm().Controls, wrkGet);
        //        DSearchParam.Add(wrkGet.FldNm, tmp);
        //        Common.gMsg = $"Declare {wrkGet.FldNm} varchar ='{tmp}'";
        //    }
        //    OpenWrk<T>();
        //}

        private void OpenWrk()
        {
            gcCtrl.DataSource = null;
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
                    sql = GenFunc.ReplaceGPatternVariable(sql);
                    Common.gMsg = sql;
                    Common.gMsg = $"-- {thisNm}.End Select Query -------------------->>";

                    List<dynamic> lists = new List<dynamic>();

                    using (var db = new GaiaHelper())
                    {
                        if (DSearchParam != null)
                        {
                            lists = db.Query<dynamic>(sql, DSearchParam);
                        }
                        else if (OSearchParam != null)
                        {
                            lists = db.Query<dynamic>(sql, OSearchParam);
                        }
                        else
                        {
                            lists = db.Query<dynamic>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = thisNm });
                        }
                    }

                    foreach (dynamic item in lists)
                    {
                        dynamic model = new ExpandoObject();
                        var modelDict = model as IDictionary<string, object>;
                        foreach (WrkFld wrkFld in wrkFlds)
                        {
                            modelDict[wrkFld.FldNm] = item.GetType().GetProperty(wrkFld.FldNm)?.GetValue(item, null);
                        }
                        model.ChangedFlag = ModelState.None;
                    }

                    gcCtrl.DataSource = new BindingList<dynamic>(lists);
                    gcCtrl.MainView.PopulateColumns();
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
            FrmWrk ucInfo = frmWrkRepo.GetByWorkSet(frwId, frmId, thisNm);

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
                GridNavigator(gcCtrl, true, true, true);
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

        //public void InitializeColumns()
        //{
        //    throw new NotImplementedException();
        //}

        public void BindData()
        {
            throw new NotImplementedException();
        }

        //public void Open()
        //{
        //    throw new NotImplementedException();
        //}

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void New()
        {
            throw new NotImplementedException();
        }
    }
}
