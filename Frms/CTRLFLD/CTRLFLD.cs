using Lib.Repo;
using System.ComponentModel;

namespace Frms
{
    public partial class CTRLFLD : UserControl
    {
        public CTRLFLD()
        {
            InitializeComponent();
        }

        private void pnlMain_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            grdFrmCtrl.Open<FrmCtrl>();
            grdWrkFld.Open<WrkFld>();
        }

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
            var data = e.Data.GetData(typeof(List<FrmCtrl>)) as List<FrmCtrl>;
            if (data != null && data.Count > 0)
            {
                var targetList = (grdWrkFld.DataSource as BindingList<WrkFld>);
                var sourceList = (grdFrmCtrl.DataSource as BindingList<FrmCtrl>);

                foreach (var item in data)
                {
                    targetList.Add(new WrkFld 
                    { 
                        CtrlNm = item.CtrlNm
                    });
                    sourceList.Remove(item);
                }

                grdWrkFld.RefreshDataSource();
                grdFrmCtrl.RefreshDataSource();
            }
        }
    }
}
