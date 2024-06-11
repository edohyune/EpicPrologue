using DevExpress.Mvvm.POCO;
using DevExpress.XtraBars.Docking2010;
using Lib.Repo;
using Frms.Models.GridSet;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using Ctrls;
using DevExpress.Data.Helpers;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.X509;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Frms.TST
{
    public partial class GridSet : UserControl
    {
        public GridSet()
        {
            InitializeComponent();


            //// Create dummy data
            //DataTable dataTable = new DataTable();
            //dataTable.Columns.Add("ID", typeof(int));
            //dataTable.Columns.Add("Name", typeof(string));
            //dataTable.Columns.Add("Age", typeof(int));
            //dataTable.Columns.Add("PID", typeof(int));
            //dataTable.Rows.Add(1, "John", 11, 0);
            //dataTable.Rows.Add(2, "Jane", 12, 0);
            //dataTable.Rows.Add(3, "Sam", 42, 0);

            //// Bind data to g10
            //g10.Open(dataTable);

            //// Bind data to g20 (if needed)
            //g20.Open(dataTable);



        }

        private void GridSet_Load(object sender, EventArgs e)
        {
        }
        private void ucPanel1_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            g10.Open();
        }

        private Point _mouseDownLocation;
        private bool _isDragging = false;
        private int _draggedRowHandle;


        private void gvCtrl_MouseDown(object? sender, MouseEventArgs e)
        {
            _mouseDownLocation = e.Location;
            _isDragging = false;

            if (g10.gvCtrl != null)
            {
                int rowHandle = g10.gvCtrl.CalcHitInfo(e.Location).RowHandle;
                _draggedRowHandle = rowHandle;
                //Common.gMsg = $"MouseDown: {e.Location}, RowHandle: {rowHandle}";
            }
        }

        private void gvCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!_isDragging && (Math.Abs(e.X - _mouseDownLocation.X) > SystemInformation.DragSize.Width ||
                                     Math.Abs(e.Y - _mouseDownLocation.Y) > SystemInformation.DragSize.Height))
                {
                    _isDragging = true;
                    //Common.gMsg = "MouseMove Start";

                    if (_draggedRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                    {
                        //Common.gMsg = "Starting drag with the focused row.";
                        this.DoDragDrop(_draggedRowHandle, DragDropEffects.Copy);
                    }
                }
            }
        }

        private void gcGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(int)))
            {
                e.Effect = DragDropEffects.Copy;
                Lib.Common.gMsg = "DragEnter: Data is present.";
            }
            else
            {
                e.Effect = DragDropEffects.None;
                Lib.Common.gMsg = "DragEnter: Data is not present.";
            }
        }

        private void gcGrid_DragDrop(object sender, DragEventArgs e)
        {
           
            if (g20.gvCtrl != null)
            {
                int sourceRowHandle = (int)e.Data.GetData(typeof(int));
                if (sourceRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                {
                    Lib.Common.gMsg = $"drop start";
                    Point pt = g20.PointToClient(new Point(e.X, e.Y));
                    GridHitInfo hitInfo = g20.gvCtrl.CalcHitInfo(pt);
                    if (hitInfo.InRow)
                    {
                        int targetRowHandle = hitInfo.RowHandle;

                        Lib.Common.gMsg = $"targetRowHandle : {targetRowHandle}.";

                        if (targetRowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                        {
                            g20.SetText("PID", targetRowHandle, g10.GetText("ID", sourceRowHandle));
                            g20.SetText("Name", targetRowHandle, g10.GetText("Name", sourceRowHandle));
                        }
                    }
                }
            }
        }

        private void g10_RowDropped(object sender, RowsDropEventArgs e)
        {
            Lib.Common.gMsg = "g10_RowsDropped called";

            Lib.Common.gMsg = $"{e.TargetRowHandle}/{e.SourceRowHandle}";
            Lib.Common.gMsg = $"{g10.GetText("ID", e.SourceRowHandle)}";

            g20.SetText("PID", e.TargetRowHandle, g10.GetText("ID", e.SourceRowHandle));
        }

        //private void g10_RowsDropped(object sender, int source, int target, RowsDropEventArgs e)
        //{
        //    g20.SetText(g10.GetText(target, "ID"), "PID");
        //}

        //private void g10_RowsDropped(object sender, RowsDropEventArgs e)
        //{
        //    e.TargetRow.PID = e.SourceRow.ID;
        //    e.TargetRow.PNAME = e.SourceRow.Name;

        //    //foreach (var sourceRow in e.SourceRows)
        //    //{
        //    //    // Update target row with source row values
        //    //    e.TargetRow["PID"] = sourceRow["ID"];
        //    //    e.TargetRow["PNAME"] = sourceRow["Name"];
        //    //    Lib.Common.gMsg = "RowsDropped: Updated target row with ID = " + sourceRow["ID"] + " and Name = " + sourceRow["Name"];
        //    //}
        //}
    }
}
