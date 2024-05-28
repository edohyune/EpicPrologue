using DevExpress.XtraRichEdit.Services;
using DevExpress.XtraRichEdit;
using Lib;
using DevExpress.Office.Utils;
using Lib.Repo;
using System.Runtime.Intrinsics.Arm;
using System.Data;
using Frms.Models.WrkRepo;
using DevExpress.XtraTreeList.Printing;
using DevExpress.Data.Filtering.Helpers;
using System.ComponentModel;
using DevExpress.Pdf.Native;
using DevExpress.XtraGrid.Views.Grid;

namespace Frms
{
    public partial class WRKREPO : UserControl
    {
        private DevExpress.XtraRichEdit.RichEditControl rtSelect;
        private DevExpress.XtraRichEdit.RichEditControl rtInsert;
        private DevExpress.XtraRichEdit.RichEditControl rtUpdate;
        private DevExpress.XtraRichEdit.RichEditControl rtDelete;
        private DevExpress.XtraRichEdit.RichEditControl rtModel;

        public FrwFrm frwFrm { get; set; }
        private FrmCtrlRepo frmCtrlRepo { get; set; }
        public BindingList<FrmCtrl> frmCtrls { get; set; }
        private FrmWrk selectedDoc { get; set; }
        private FrmWrkRepo frmWrkRepo { get; set; }
        private BindingList<FrmWrk> frmWrks { get; set; }
        public WrkFld wrkFld { get; set; }
        private WrkFldRepo wrkFldRepo { get; set; }
        private BindingList<WrkFld> wrkFldbs { get; set; }

        private WrkGetRepo wrkGetRepo { get; set; }
        private BindingList<WrkGet> wrkGetbs { get; set; }
        private WrkSetRepo wrkSetRepo { get; set; }
        private BindingList<WrkSet> wrkSetbs { get; set; }
        private WrkRefRepo wrkRefRepo { get; set; }
        private BindingList<WrkRef> wrkRefbs { get; set; }

        public WRKREPO()
        {
            InitializeComponent();

            List<FrwFrm> frwFrms = new FrwFrmRepo().GetAll();
            foreach (var frwFrm in frwFrms)
            {
                cmbForm.Properties.Items.Add(frwFrm);
            }

            InitializeRichTextEditor();
            ucTab1.SelectedTabPageIndex = 0;
            ucTab2.SelectedTabPageIndex = 0;
            ucTab3.SelectedTabPageIndex = 0;
            ucTab4.SelectedTabPageIndex = 0;
        }

        private void InitializeRichTextEditor()
        {
            rtSelect = new DevExpress.XtraRichEdit.RichEditControl();
            rtInsert = new DevExpress.XtraRichEdit.RichEditControl();
            rtUpdate = new DevExpress.XtraRichEdit.RichEditControl();
            rtDelete = new DevExpress.XtraRichEdit.RichEditControl();
            rtModel = new DevExpress.XtraRichEdit.RichEditControl();

            rtSelect.Dock = DockStyle.Fill;
            rtSelect.Name = "rtSelect";
            rtSelect.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtSelect.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtSelect.Modified = true;
            rtSelect.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtSelect.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtSelect.ReplaceService<ISyntaxHighlightService>(new SQL_Syntax(rtSelect.Document));
            rtSelect.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtSelect.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            rtInsert.Dock = DockStyle.Fill;
            rtInsert.Name = "rtInsert";
            rtInsert.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtInsert.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtInsert.Modified = true;
            rtInsert.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtInsert.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtInsert.ReplaceService<ISyntaxHighlightService>(new SQL_Syntax(rtInsert.Document));
            rtInsert.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtInsert.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            rtUpdate.Dock = DockStyle.Fill;
            rtUpdate.Name = "rtUpdate";
            rtUpdate.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtUpdate.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtUpdate.Modified = true;
            rtUpdate.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtUpdate.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtUpdate.ReplaceService<ISyntaxHighlightService>(new SQL_Syntax(rtUpdate.Document));
            rtUpdate.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtUpdate.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            rtDelete.Dock = DockStyle.Fill;
            rtDelete.Name = "rtDelete";
            rtDelete.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtDelete.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtDelete.Modified = true;
            rtDelete.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtDelete.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtDelete.ReplaceService<ISyntaxHighlightService>(new SQL_Syntax(rtDelete.Document));
            rtDelete.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtDelete.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            rtModel.Dock = DockStyle.Fill;
            rtModel.Name = "rtModel";
            rtModel.Options.DocumentSaveOptions.CurrentFormat = DevExpress.XtraRichEdit.DocumentFormat.PlainText;
            rtModel.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            rtModel.Modified = true;
            rtModel.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            rtModel.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            rtModel.ReplaceService<ISyntaxHighlightService>(new CS_Syntax(rtModel.Document));
            rtModel.Options.Search.RegExResultMaxGuaranteedLength = 500;
            rtModel.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(300f);

            pnlSelect.Controls.Add(rtSelect);
            pnlInsert.Controls.Add(rtInsert);
            pnlUpdate.Controls.Add(rtUpdate);
            pnlDelete.Controls.Add(rtDelete);
            pnlModel.Controls.Add(rtModel);
        }
        private void cmbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            frwFrm = cmbForm.SelectedItem as FrwFrm;

            frmWrkRepo = new FrmWrkRepo();
            frmWrks = new BindingList<FrmWrk>(frmWrkRepo.GetByFrwFrm(frwFrm.FrwId, frwFrm.FrmId));

            if (frwFrm != null)
            {
                g10OpenGrid();
            }
        }
        private void g10_UCFocusedRowChanged(object sender, int preIndex, int rowIndex, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Common.gMsg = "g10_UCFocusedRowChanged";
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            selectedDoc = view.GetFocusedRow() as FrmWrk;

            wrkFldRepo = new WrkFldRepo();
            wrkFldbs = new BindingList<WrkFld>(wrkFldRepo.GetColumnProperties(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId));

            frmCtrlRepo = new FrmCtrlRepo();
            frmCtrls = new BindingList<FrmCtrl>(frmCtrlRepo.GetByFrwFrm(selectedDoc.FrwId, selectedDoc.FrmId));

            wrkGetRepo = new WrkGetRepo();
            wrkGetbs = new BindingList<WrkGet>(wrkGetRepo.GetPullFlds(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId));

            wrkSetRepo = new WrkSetRepo();
            wrkSetbs = new BindingList<WrkSet>(wrkSetRepo.SetPushFlds(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId));

            wrkRefRepo = new WrkRefRepo();
            wrkRefbs = new BindingList<WrkRef>(wrkRefRepo.RefDataFlds(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId));

            if (selectedDoc != null)
            {
                g20OpenGrid();
                SetWrkForm();
                t10OpenGrid();
                grdGetParamGrid();
                grdSetparamGrid();
                grdRefDataGrid();
            }
        }

        private void g10OpenGrid()
        {
            Common.gMsg = "g10OpenGrid";
            //g10.Clear();
            g10.DataSource = frmWrks;
        }
        private void g20OpenGrid()
        {
            Common.gMsg = "g20OpenGrid";
            //g20.Clear();
            g20.DataSource = frmCtrls;
        }
        private void t10OpenGrid()
        {
            Common.gMsg = "t10OpenGrid";
            //t10.Clear();
            t10.DataSource = wrkFldbs;
        }
        private void grdGetParamGrid()
        {
            grdGetParam.DataSource = wrkGetbs;
        }

        private void grdSetparamGrid()
        {
            grdSetParam.DataSource = wrkSetbs;
        }
        private void grdRefDataGrid()
        {
            grdRefData.DataSource = wrkRefbs;
        }

        private void SetWrkForm()
        {
            rtDelete.Text = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "D").Query;
            rtInsert.Text = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "C").Query;
            rtSelect.Text = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "R").Query;
            rtModel.Text = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "M").Query;
            rtUpdate.Text = GenFunc.GetSql(selectedDoc.FrwId, selectedDoc.FrmId, selectedDoc.WrkId, "U").Query;
        }

        #region CustomButtonClick

        private void ucPanel1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Open")
            {
                if (selectedDoc != null)
                {
                    g20OpenGrid();
                    SetWrkForm();
                    t10OpenGrid();
                    grdGetParamGrid();
                    grdSetparamGrid();
                    grdRefDataGrid();
                }
            }
        }
        private void pnlSelect_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "R",
                    Query = rtSelect.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "R",
                    Query = rtSelect.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
            else if (e.Button.Properties.Caption == "Make Field")
            {
                using (var db = new GaiaHelper())
                {
                    DataSet dSet = db.GetGridColumns(new { FrwId = selectedDoc.FrwId, FrmId = selectedDoc.FrmId, WrkId = selectedDoc.WrkId, CRUDM = "R" });
                    //목적 Select 쿼리를 이용하여 컬럼을 생성한다.
                    if (dSet != null)
                    {
                        foreach (DataColumn cols in dSet.Tables[0].Columns)
                        {
                            var wrkFld = wrkFldbs.Where(x => x.CtrlNm == $"{selectedDoc.CtrlNm}.{cols.ColumnName}").FirstOrDefault();

                            if (wrkFld != null)
                            {
                                wrkFld.FrwId = selectedDoc.FrwId;
                                wrkFld.FrmId = selectedDoc.FrmId;
                                wrkFld.WrkId = selectedDoc.WrkId;
                                wrkFld.CtrlCls = "Column";
                                wrkFld.CtrlNm = $"{selectedDoc.CtrlNm}.{cols.ColumnName}";
                                wrkFld.FldNm = cols.ColumnName;
                                wrkFld.FldTy = GetFieldType(cols.DataType);
                                //wrkFld.FldTitle = cols.ColumnName;
                                wrkFld.ChangedFlag = MdlState.Updated;
                            }
                            else
                            {
                                wrkFldbs.Add(new WrkFld
                                {
                                    FrwId = selectedDoc.FrwId,
                                    FrmId = selectedDoc.FrmId,
                                    WrkId = selectedDoc.WrkId,
                                    CtrlCls = "Column",
                                    CtrlNm = $"{selectedDoc.CtrlNm}.{cols.ColumnName}",
                                    FldNm = cols.ColumnName,
                                    FldTy = GetFieldType(cols.DataType),
                                    FldTitle = cols.ColumnName,
                                    ChangedFlag = MdlState.Inserted
                                });
                            }
                        }
                        t10.DataSource = wrkFldbs;
                    }
                }
                ucTab1.SelectedTabPageIndex = 1;
                ucTab2.SelectedTabPageIndex = 1;
            }
        }

        private string GetFieldType(Type dataType)
        {
            return dataType.Name switch
            {
                "Int32" => "Int",
                "String" => "Text",
                "DateTime" => "DateTime",
                "Date" => "Date",
                "Decimal" => "Decimal",
                "Double" => "Decimal",
                "Boolean" => "bool",
                _ => "Text",
            };
        }

        private void pnlInsert_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "C",
                    Query = rtInsert.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "C",
                    Query = rtInsert.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
        }
        private void pnlUpdate_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "U",
                    Query = rtUpdate.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "U",
                    Query = rtUpdate.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
        }
        private void pnlDelete_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "D",
                    Query = rtDelete.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "D",
                    Query = rtDelete.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
        }
        private void pnlModel_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var WrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                WrkSqlRepo.Delete(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "M",
                    Query = rtModel.Text
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                WrkSqlRepo.Save(new WrkSql
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    CRUDM = "M",
                    Query = rtModel.Text
                });
            }
            else if (e.Button.Properties.Caption == "Generate")
            {

            }
        }
        private void ucPanel3_CustomButtonClick(object Sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Save")
            {
                foreach (var wrkFld in wrkFldbs)
                {
                    if (wrkFld.ChangedFlag == MdlState.Inserted)
                    {
                        wrkFldRepo.Add(wrkFld);
                    }
                    else if (wrkFld.ChangedFlag == MdlState.Updated)
                    {
                        wrkFldRepo.Update(wrkFld);
                    }
                    else if (wrkFld.ChangedFlag == MdlState.None)
                    {
                        continue;
                    }
                }
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                GridView view = t10.MainView as GridView;
                if (view != null)
                {
                    var selectedRows = view.GetFocusedRow() as WrkFld;
                    Common.gMsg = selectedRows.Id.ToString();

                    if (selectedRows != null)
                    {
                        wrkFldbs.Remove(selectedRows);
                        wrkFldRepo.Delete(selectedRows);
                    }
                }
            }
        }

        private void pnlGet_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "New")
            {
                wrkGetbs.Add(new WrkGet
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    ChangedFlag = MdlState.Inserted
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                foreach (var wrkGet in wrkGetbs)
                {
                    if (wrkGet.ChangedFlag == MdlState.Inserted)
                    {
                        wrkGetRepo.Add(wrkGet);
                    }
                    else if (wrkGet.ChangedFlag == MdlState.Updated)
                    {
                        wrkGetRepo.Update(wrkGet);
                    }
                    else if (wrkGet.ChangedFlag == MdlState.None)
                    {
                        continue;
                    }
                }
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                GridView view = grdGetParam.MainView as GridView;
                if (view != null)
                {
                    var selectedRows = view.GetFocusedRow() as WrkGet;
                    if (selectedRows != null)
                    {
                        wrkGetbs.Remove(selectedRows);
                        wrkGetRepo.Delete(selectedRows);
                    }
                }
            }
        }

        private void pnlSet_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "New")
            {
                wrkSetbs.Add(new WrkSet
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    ChangedFlag = MdlState.Inserted
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                foreach (var wrkSet in wrkSetbs)
                {
                    if (wrkSet.ChangedFlag == MdlState.Inserted)
                    {
                        wrkSetRepo.Add(wrkSet);
                    }
                    else if (wrkSet.ChangedFlag == MdlState.Updated)
                    {
                        wrkSetRepo.Update(wrkSet);
                    }
                    else if (wrkSet.ChangedFlag == MdlState.None)
                    {
                        continue;
                    }
                }
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                GridView view = grdSetParam.MainView as GridView;
                if (view != null)
                {
                    var selectedRows = view.GetFocusedRow() as WrkSet;
                    if (selectedRows != null)
                    {
                        wrkSetbs.Remove(selectedRows);
                        wrkSetRepo.Delete(selectedRows);
                    }
                }
            }
        }

        private void pnlRef_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "New")
            {
                wrkRefbs.Add(new WrkRef
                {
                    FrwId = selectedDoc.FrwId,
                    FrmId = selectedDoc.FrmId,
                    WrkId = selectedDoc.WrkId,
                    FldNm = "RefFldNm",
                    ChangedFlag = MdlState.Inserted
                });
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                foreach (var wrkRef in wrkRefbs)
                {
                    if (wrkRef.ChangedFlag == MdlState.Inserted)
                    {
                        wrkRefRepo.Add(wrkRef);
                    }
                    else if (wrkRef.ChangedFlag == MdlState.Updated)
                    {
                        wrkRefRepo.Update(wrkRef);
                    }
                    else if (wrkRef.ChangedFlag == MdlState.None)
                    {
                        continue;
                    }
                }
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                GridView view = grdRefData.MainView as GridView;
                if (view != null)
                {
                    var selectedRows = view.GetFocusedRow() as WrkRef;
                    if (selectedRows != null)
                    {
                        wrkRefbs.Remove(selectedRows);
                        wrkRefRepo.Delete(selectedRows);
                    }
                }
            }
        }


        #endregion
    }
}
namespace Frms.Models.WrkRepo
{
    public class wrkList
    {
        public string WrkId { get; set; }
        public string FrwId { get; set; }
        public string FrmId { get; set; }
    }
}
