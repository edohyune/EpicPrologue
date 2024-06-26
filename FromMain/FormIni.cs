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

namespace FormMain
{
    public partial class FormIni : UserControl
    {
        private LodIniRepo lodIniRepo;
        private List<LodIni> lodIniList;
        public FormIni()
        {
            InitializeComponent();
        }

        private void pnlIni_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption.Trim())
            {
                case "Open":
                    string iniFilePath = Common.GetValue("gIniFilePath");
                    if (string.IsNullOrEmpty(iniFilePath))
                    {
                        MessageBox.Show("환경설정 파일이 지정되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lodIniRepo = new LodIniRepo(iniFilePath);
                    lodIniList = lodIniRepo.LoadAll();
                    grdIni.Open<LodIni>(lodIniList);

                    break;
                case "Save":
                    grdIni.Save<LodIni>(lodIniRepo);
                    break;
                default:
                    break;
            }
        }
    }
}
