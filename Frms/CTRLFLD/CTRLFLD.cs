using DevExpress.CodeParser;
using DevExpress.XtraSpreadsheet.Model;
using Lib.Repo;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Frms
{
    public partial class CTRLFLD : UserControl
    {
        public CTRLFLD()
        {
            InitializeComponent();
        }

        #region DrugDrop
        private void grdFrmCtrl_UCMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                List<FrmCtrl> selectedRows = new List<FrmCtrl>();
                foreach (int rowHandle in grdFrmCtrl.gvCtrl.GetSelectedRows())
                {
                    if (rowHandle >= 0)
                    {
                        selectedRows.Add(grdFrmCtrl.gvCtrl.GetRow(rowHandle) as FrmCtrl);
                    }
                }

                if (selectedRows.Count > 0)
                {
                    grdFrmCtrl.gvCtrl.GridControl.DoDragDrop(selectedRows, DragDropEffects.Move);
                }
            }
        }

        private void grdWrkFld_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void grdWrkFld_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var data = e.Data.GetData(typeof(List<FrmCtrl>)) as List<FrmCtrl>;
                if (data != null && data.Count > 0)
                {
                    var targetList = (grdWrkFld.DataSource as BindingList<WrkFld>);
                    var sourceList = (grdFrmCtrl.DataSource as BindingList<FrmCtrl>);

                    foreach (var item in data)
                    {
                        targetList.Add(new WrkFld
                        {
                            FrwId = item.FrwId,
                            FrmId = item.FrmId,
                            CtrlNm = item.CtrlNm,
                            FldNm = item.CtrlNm,
                            FldX = item.CtrlX,
                            FldY = item.CtrlY,
                            FldWidth = item.CtrlW,
                            FldTitleWidth = item.TitleWidth,
                            FldTitle = item.TitleText,
                            TitleAlign = item.TitleAlign,
                            DefaultText = item.DefaultText,
                            TextAlign = item.TextAlign,
                            ShowYn = item.ShowYn,
                            EditYn = item.EditYn,
                            ToolNm = item.ToolNm
                        });
                        sourceList.Remove(item);
                    }

                    grdWrkFld.RefreshDataSource();
                    grdFrmCtrl.RefreshDataSource();
                }
            }
            finally
            {
                e.Effect = DragDropEffects.None;
                Cursor.Current = Cursors.Default;
            }

        }
        #endregion

        private void pnlWrkFld_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption.Trim())
            {
                case "GET":
                    MessageBox.Show("GET");
                    break;
                case "Save":
                    grdWrkFld.Save<WrkFld>();
                    break;
                case "Delete":
                    grdWrkFld.Delete<WrkFld>();
                    break;
            }
        }

        private void grdFrmCtrl_UCFocusedRowChanged(object sender, int preIndex, int rowIndex, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            List<FrmCtrl> frmCtrlList = ((BindingList<FrmCtrl>)grdFrmCtrl.DataSource).ToList();
            List<WrkFld> wrkFldList = ((BindingList<WrkFld>)grdWrkFld.DataSource).ToList();

            if (frmCtrlList != null && wrkFldList != null)
            {
                // 현재 선택된 항목을 가져옴
                var selectedRows = grdFrmCtrl.gvCtrl.GetSelectedRows();
                var selectedFrmCtrl = selectedRows.Select(rowHandle => grdFrmCtrl.MainView.GetRow(rowHandle) as FrmCtrl).Where(row => row != null).ToList();

                if (selectedFrmCtrl.Any())
                {
                    // WrkFld 리스트에서 일치하는 항목을 찾음
                    var matchingRows = wrkFldList.Where(w => selectedFrmCtrl.Any(f => f.FrwId == w.FrwId && f.FrmId == w.FrmId && f.CtrlNm == w.CtrlNm)).ToList();

                    // 일치하는 행을 선택
                    foreach (var row in matchingRows)
                    {
                        int rowHandle = grdWrkFld.gvCtrl.FindRow(row);
                        if (rowHandle >= 0)
                        {
                            grdWrkFld.gvCtrl.SelectRow(rowHandle);
                        }
                    }
                }
            }
        }

        private void pnlFrmCtrl_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            grdFrmCtrl.Open<FrmCtrl>();
            grdWrkFld.Open<WrkFld>();
        }

        private void cmbFrm_UCSelectedIndexChanged(object sender, EventArgs e)
        {
            grdFrmCtrl.Open<FrmCtrl>();
            grdWrkFld.Open<WrkFld>();
        }
    }
}
