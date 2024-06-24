using DevExpress.Office.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraRichEdit.Services;
using Lib;
using Lib.Repo;
using Lib.Syntax;
using System.ComponentModel;
using System.Data;

namespace Frms
{
    public partial class WRKFLD : GAIA.FrmBase
    {
        public WRKFLD()
        {
            InitializeComponent();
        }
        private void cmbFrm_UCSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Open();
        }

        #region OPEN --------------------------------------------------------------->>
        #endregion

        #region CustomButtonClick -------------------------------------------------->>
        private void pnlWorkSet_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Open")
            {
                return;
            }
        }
        private void pnlSelect_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var wrkSqlRepo = new WrkSqlRepo();
            if (e.Button.Properties.Caption == "Delete")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Generate")
            {
                return;
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
            if (e.Button.Properties.Caption == "Delete")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                return;
            }
        }
        private void pnlUpdate_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Delete")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Make Reference Data")
            {
                return;
            }
        }
        private void pnlDelete_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Delete")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Generate")
            {
                return;
            }
        }
        private void pnlModel_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Delete")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Generate")
            {
                return;
            }
        }
        private void pnlColumn_CustomButtonClick(object Sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Save")
            {
                return;
                //foreach (var wrkFld in wrkFldbs)
                //{
                //    if (wrkFld.ChangedFlag == MdlState.Inserted)
                //    {
                //        wrkFldRepo.Add(wrkFld);
                //    }
                //    else if (wrkFld.ChangedFlag == MdlState.Updated)
                //    {
                //        wrkFldRepo.Update(wrkFld);
                //    }
                //    else if (wrkFld.ChangedFlag == MdlState.None)
                //    {
                //        continue;
                //    }
                //}
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                return;
                //GridView view = t10.MainView as GridView;
                //if (view != null)
                //{
                //    var selectedRows = view.GetFocusedRow() as WrkFld;
                //    Common.gMsg = selectedRows.Id.ToString();

                //    if (selectedRows != null)
                //    {
                //        wrkFldbs.Remove(selectedRows);
                //        wrkFldRepo.Delete(selectedRows);
                //    }
                //}
            }
            else if (e.Button.Properties.Caption == "Numbering")
            {
                return;
                //int i = 1;
                //foreach (var wrkFld in wrkFldbs)
                //{
                //    wrkFld.Seq = i * 10;
                //    i++;
                //}
            }
            else if (e.Button.Properties.Caption == "Make Columns")
            {
                return;
                //if (string.IsNullOrWhiteSpace(GenFunc.GetSql(new { FrwId = selectedDoc.FrwId, FrmId = selectedDoc.FrmId, WrkId = selectedDoc.WrkId, CRUDM = "R" })))
                //{
                //    MessageBox.Show("Select 쿼리를 먼저 입력하세요.");
                //    return;
                //}

                //using (var db = new GaiaHelper())
                //{
                //    DataSet dSet = db.GetGridColumns(new { FrwId = selectedDoc.FrwId, FrmId = selectedDoc.FrmId, WrkId = selectedDoc.WrkId, CRUDM = "R" });
                //    if (dSet != null)
                //    {
                //        foreach (DataColumn cols in dSet.Tables[0].Columns)
                //        {
                //            var wrkFld = wrkFldbs.Where(x => x.CtrlNm == $"{selectedDoc.CtrlNm}.{cols.ColumnName}").FirstOrDefault();

                //            if (wrkFld != null)
                //            {
                //                wrkFld.FrwId = selectedDoc.FrwId;
                //                wrkFld.FrmId = selectedDoc.FrmId;
                //                wrkFld.WrkId = selectedDoc.WrkId;
                //                wrkFld.CtrlCls = "Column";
                //                wrkFld.CtrlNm = $"{selectedDoc.CtrlNm}.{cols.ColumnName}";
                //                wrkFld.FldNm = cols.ColumnName;
                //                wrkFld.FldTy = GetFieldType(cols.DataType);
                //                //wrkFld.FldTitle = cols.ColumnName;
                //                wrkFld.ChangedFlag = MdlState.Updated;
                //            }
                //            else
                //            {
                //                wrkFldbs.Add(new WrkFld
                //                {
                //                    FrwId = selectedDoc.FrwId,
                //                    FrmId = selectedDoc.FrmId,
                //                    WrkId = selectedDoc.WrkId,
                //                    CtrlCls = "Column",
                //                    CtrlNm = $"{selectedDoc.CtrlNm}.{cols.ColumnName}",
                //                    FldNm = cols.ColumnName,
                //                    FldTy = GetFieldType(cols.DataType),
                //                    FldTitle = cols.ColumnName,
                //                    ShowYn = true,
                //                    EditYn = true,
                //                    ChangedFlag = MdlState.Inserted
                //                });
                //            }
                //        }
                //        t10.DataSource = wrkFldbs;
                //    }
                //}
            }
        }
        private void pnlGet_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "New")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Make GetParameters Data")
            {
                return;
                //SyntaxExtractor extractor = new SyntaxExtractor();
                //SyntaxMatch cvariables = extractor.ExtractVariables(rtSelect.Text);

                //foreach (var kvp in cvariables.OPatternMatch)
                //{
                //    //wrkGets에 있으면 update 없으면 insert
                //    var wrkGet = wrkGetbs.Where(x => x.FldNm == kvp.Key).FirstOrDefault();
                //    if (wrkGet == null)
                //    {
                //        wrkGet = wrkGetbs.Where(x => x.FldNm.ToLower() == kvp.Key.ToLower()).FirstOrDefault();
                //        if (wrkGet != null)
                //        {
                //            wrkGet.FldNm = kvp.Key;
                //            wrkGet.ChangedFlag = MdlState.Updated;
                //        }
                //        else
                //        {
                //            wrkGetbs.Add(new WrkGet
                //            {
                //                FrwId = selectedDoc.FrwId,
                //                FrmId = selectedDoc.FrmId,
                //                WrkId = selectedDoc.WrkId,
                //                FldNm = kvp.Key,
                //                ChangedFlag = MdlState.Inserted
                //            });
                //        }
                //    }
                //}
            }
        }
        private void pnlSet_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "New")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Import Target List")
            {
                return;
                //var addSetbs = new WrkSetRepo().GetTargetList(selectedDoc.FrwId, selectedDoc.FrmId);
                //foreach (var wrkSet in addSetbs)
                //{
                //    wrkSetbs.Add(new WrkSet
                //    {
                //        FrwId = wrkSet.FrwId,
                //        FrmId = wrkSet.FrmId,
                //        SetWrkId = wrkSet.SetWrkId,
                //        SetFldNm = wrkSet.SetFldNm,
                //        ChangedFlag = MdlState.Inserted
                //    });
                //}
            }
        }
        private void pnlRef_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "New")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Make Reference Data")
            {
                return;
                //SyntaxExtractor extractor = new SyntaxExtractor();
                //SyntaxMatch cvariables = extractor.ExtractVariables(rtUpdate.Text);

                //foreach (var kvp in cvariables.OPatternMatch)
                //{
                //    //wrkRefs에 있으면 update 없으면 insert
                //    var wrkRef = wrkRefbs.Where(x => x.FldNm == kvp.Key).FirstOrDefault();
                //    if (wrkRef == null)
                //    {
                //        wrkRef = wrkRefbs.Where(x => x.FldNm.ToLower() == kvp.Key.ToLower()).FirstOrDefault();
                //        if (wrkRef != null)
                //        {
                //            wrkRef.FldNm = kvp.Key;
                //            wrkRef.ChangedFlag = MdlState.Updated;
                //        }
                //        else
                //        {
                //            wrkRefbs.Add(new WrkRef
                //            {
                //                FrwId = selectedDoc.FrwId,
                //                FrmId = selectedDoc.FrmId,
                //                WrkId = selectedDoc.WrkId,
                //                FldNm = kvp.Key,
                //                ChangedFlag = MdlState.Inserted
                //            });
                //        }
                //    }
                //}

                //cvariables = extractor.ExtractVariables(rtInsert.Text);

                //foreach (var kvp in cvariables.OPatternMatch)
                //{
                //    var wrkRef = wrkRefbs.Where(x => x.FldNm == kvp.Key).FirstOrDefault();
                //    if (wrkRef == null)
                //    {
                //        wrkRef = wrkRefbs.Where(x => x.FldNm.ToLower() == kvp.Key.ToLower()).FirstOrDefault();
                //        if (wrkRef != null)
                //        {
                //            wrkRef.FldNm = kvp.Key;
                //            wrkRef.ChangedFlag = MdlState.Updated;
                //        }
                //        else
                //        {
                //            wrkRefbs.Add(new WrkRef
                //            {
                //                FrwId = selectedDoc.FrwId,
                //                FrmId = selectedDoc.FrmId,
                //                WrkId = selectedDoc.WrkId,
                //                FldNm = kvp.Key,
                //                ChangedFlag = MdlState.Inserted
                //            });
                //        }
                //    }
                //}
            }
        }
        #endregion
        #region Grid to Grid Drag and Drop ------------------------------------------>>

        private Point _mouseDownLocation;
        private bool _isDragging = false;
        private int _draggedRowHandle;

        private void sourceGrid_MouseDown(object? sender, MouseEventArgs e)
        {
            _mouseDownLocation = e.Location;
            _isDragging = false;

            if (grdFrmCtrl.gvCtrl != null)
            {
                int rowHandle = grdFrmCtrl.gvCtrl.CalcHitInfo(e.Location).RowHandle;
                _draggedRowHandle = rowHandle;
            }
        }

        private void sourceGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!_isDragging && (Math.Abs(e.X - _mouseDownLocation.X) > SystemInformation.DragSize.Width ||
                                     Math.Abs(e.Y - _mouseDownLocation.Y) > SystemInformation.DragSize.Height))
                {
                    _isDragging = true;
                    if (_draggedRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        this.DoDragDrop(_draggedRowHandle, DragDropEffects.Copy);
                    }
                }
            }
        }

        private void targetGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(int)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void targetGrid_DragDrop(object sender, DragEventArgs e)
        {

            if (grdWrkFld.gvCtrl != null)
            {
                int sourceRowHandle = (int)e.Data.GetData(typeof(int));
                if (sourceRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    Point pt = grdWrkFld.PointToClient(new Point(e.X, e.Y));
                    GridHitInfo hitInfo = grdWrkFld.gvCtrl.CalcHitInfo(pt);
                    if (hitInfo.InRow)
                    {
                        int targetRowHandle = hitInfo.RowHandle;

                        if (targetRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        {
                            grdWrkFld.SetText("PID", targetRowHandle, grdFrmCtrl.GetText("ID", sourceRowHandle));
                            grdWrkFld.SetText("Name", targetRowHandle, grdFrmCtrl.GetText("Name", sourceRowHandle));
                        }
                    }
                }
            }
        }
        #endregion

        private void ucPanel1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Expanding")
            {
                ucSplit2.SplitterDistance = ucSplit2.Parent.Width;
                //ExpandYn = true;
                e.Button.Properties.Caption = "Collapsing"; // 캡션 변경
            }
            else if (e.Button.Properties.Caption == "Collapsing")
            {
                ucSplit2.SplitterDistance = 250;
                //ExpandYn = false;
                e.Button.Properties.Caption = "Expanding"; // 캡션 변경
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                return;
            }
            else if (e.Button.Properties.Caption == "Open")
            {
                return;
            }
        }
    }
}
