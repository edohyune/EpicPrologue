using DevExpress.XtraEditors;
using EpicV003.Lib;
using EpicV003.Lib.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace GAIA
{
    public partial class SignIn : DevExpress.XtraEditors.XtraForm
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new SignIn());
        }
        public SignIn()
        {
            InitializeComponent();
            Common.SetValue("gUserProfilePath", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            Common.SetValue("gIniFilePath", Path.Combine(Common.GetValue("gUserProfilePath"), "GAIA", "Setting.ini"));
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //IDO Login Process
            SignInProcess();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Others Login Process
            SignInProcess();
        }
        private void SignInProcess()
        {
            string id = txtId.Text;
            string pwd = txtPwd.Text;

            var repo = new UsrRepo();
            var usr = repo.CheckSignIn(id, pwd);

            if (usr == null)
            {
                lblResult.Text = $"A record with the code {id} was not found.";
            }
            else
            {
                Common.SetValue("gId", usr.UsrId);
                Common.SetValue("gRegId", usr.UsrRegId.ToString());
                Common.SetValue("gNm", usr.UsrNm);
                Common.SetValue("gCls", usr.Cls);

                FormMain.signin = true;
                this.Close();
            }
            //ini 파일 초기화 기본정보 셋팅하기 
            //기본정보는 사용자 아이디에 따른 프레임워크를 읽고 셋팅한다.

        }
    }
}