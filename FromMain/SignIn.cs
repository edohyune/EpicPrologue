using DevExpress.XtraEditors;
using Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Common.gUserProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Common.gIniFilePath = Path.Combine(Common.gUserProfilePath, "GAIA", "Setting.ini");
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

            var repo = new Repo.UsrRepo();
            var usr = repo.CheckSignIn(id, pwd);

            if (usr == null)
            {
                lblResult.Text = $"A record with the code {id} was not found.";
            }
            else
            {
                Common.gId = usr.UsrId;
                Common.gNm = usr.UsrNm;
                Common.gCls = usr.Cls;

                FormMain.signin = true;
                this.Close();
            }
        }
    }
}