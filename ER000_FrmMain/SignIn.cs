using ER000.Lib;
using ER000.Lib.Repo;
using System;
using System.IO;
using System.Windows.Forms;

namespace ER000
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

            var repo = new B612Repo();
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

                FrmMain.signin = true;
                this.Close();
            }
        }
    }
}