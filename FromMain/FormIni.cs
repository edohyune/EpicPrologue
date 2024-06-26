using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpicV003.Lib.Repo;
using EpicV003.Lib;
using DevExpress.XtraGrid;
using DevExpress.Data.ODataLinq;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace FormMain
{
    public partial class FormIni : UserControl
    {
        private LodIniRepo lodIniRepo;
        private List<LodIni> lodInis;
        //private RepositoryItemImageComboBox repoItemImageComboBox;
        public FormIni()
        {
            InitializeComponent();
            gvCtrl.CustomDrawRowIndicator += GvCtrl_CustomDrawRowIndicator;
            //repoItemImageComboBox = new RepositoryItemImageComboBox
            //{
            //    SmallImages = imageCollection1 // ImageCollection에 아이콘을 추가해야 합니다.
            //};

            //repoItemImageComboBox.Items.Add(new ImageComboBoxItem("", MdlState.Inserted, 0)); // 삽입된 경우의 아이콘 인덱스 0
            //repoItemImageComboBox.Items.Add(new ImageComboBoxItem("", MdlState.Updated, 1)); // 수정된 경우의 아이콘 인덱스 1
            //grdCtrl.RepositoryItems.Add(repoItemImageComboBox);
        }

        private void GvCtrl_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                GridView view = sender as GridView;
                MdlState mdlState = (MdlState)view.GetRowCellValue(e.RowHandle, "ChangedFlag");

                if (mdlState == MdlState.Inserted || mdlState == MdlState.Updated)
                {
                    e.Handled = true;
                    e.DefaultDraw();

                    Image image = mdlState == MdlState.Inserted ? imageCollection1.Images[1] : imageCollection1.Images[0];
                    Rectangle rect = e.Bounds;

                    int imageSize = 12; // 이미지 크기 설정
                    int x = rect.X + (rect.Width - imageSize) / 2;
                    int y = rect.Y + (rect.Height - imageSize) / 2;

                    e.Graphics.DrawImage(image, x, y, imageSize, imageSize);
                }
            }
        }

        private void pnlIni_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption.Trim())
            {
                case "Open":
                    string iniFilePath = Common.GetValue("gIniFilePath");
                    Common.gLog = iniFilePath;
                    if (string.IsNullOrEmpty(iniFilePath))
                    {
                        MessageBox.Show("환경설정 파일이 지정되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    lodIniRepo = new LodIniRepo(iniFilePath);
                    lodInis = lodIniRepo.LoadAll();
                    foreach (var lodIni in lodInis)
                    {
                        lodIni.ChangedFlag = MdlState.None;
                    }
                    grdCtrl.DataSource = new BindingList<LodIni>(lodInis);
                    break;
                case "Save":
                    if (gvCtrl.IsEditing)
                    {
                        gvCtrl.CloseEditor();
                    }
                    if (gvCtrl.FocusedRowModified)
                    {
                        gvCtrl.UpdateCurrentRow();
                    }
                    var dataSource = grdCtrl.DataSource as BindingList<LodIni>;
                    if (dataSource == null) return;

                    var dataList = dataSource.ToList();
                    lodIniRepo.SaveAll(dataList);

                    foreach (var lodIni in dataSource)
                    {
                        lodIni.ChangedFlag = MdlState.None;
                    }
                    grdCtrl.RefreshDataSource();
                    break;
                default:
                    break;
            }
        }

        private void gvCtrl_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gvCtrl.SetRowCellValue(e.RowHandle, "ChangedFlag", MdlState.Inserted);
        }
    }
}
