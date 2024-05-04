using DevExpress.Mvvm.POCO;
using Repo;
using System.Reflection;
using Lib;
using System.Formats.Tar;
using System.IO;
namespace Frms
{
    public partial class DLLLoad : UserControl
    {

        public DLLLoad()
        {
            InitializeComponent();
        }

        List<UserCtrl> userCtrls;
        private void btnGetCtrl_UCButtonClick(object Sender, Control control)
        {

            //신규등록파일 열기
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "DLL Files|*.dll|EXE Files|*.exe";
            if (string.IsNullOrEmpty(GenFunc.GetIni("DLLPath")))
            {
                openFileDialog1.InitialDirectory = @"C:\"; 
            }
            else
            {
                openFileDialog1.InitialDirectory = GenFunc.GetIni("DLLPath");
            }
            openFileDialog1.ShowDialog();

            //선택한 파일 정보읽기   
            string strFile = openFileDialog1.FileName;
            Common.gMsg = strFile;
            string strPath = openFileDialog1.SafeFileName;
            Common.gMsg = strPath;
            string strExt = strPath.Substring(strPath.Length - 3, 3);
            Common.gMsg = strExt;

            GenFunc.SetIni("DLLPath", strFile);

            //선택한 파일의 이름
            string strFileName = strPath.Substring(0, strPath.Length - 4);
            Common.gMsg = strExt;


            //선택한 파일 버전 정보읽기   
            UserControl ucform = null;
            try
            {
                Assembly assembly = AppDomain.CurrentDomain.Load(File.ReadAllBytes(strFile));

                //Assembly assembly = Assembly.LoadFile(strFile);
                string strVersion = assembly.GetName().Version.ToString();



                Common.gMsg = assembly.GetName().Name;
                Common.gMsg = assembly.GetName().CultureName;
                Common.gMsg = assembly.GetName().FullName;

                Common.gMsg = "6";
                var ty = assembly.GetType($"Frms.{strFileName}");  //////////////////////////////////////////////////////// Namespace.ClassName
                //var ty = assembly.GetType("TestFromTextBox.TFTXT01");  //////////////////////////////////////////////////////// Namespace.ClassName
                Common.gMsg = "7";
                ucform = (UserControl)Activator.CreateInstance(ty);
                Common.gMsg = "8";

                txtDllpath.Text = strFile;
                //formUcList = new List<T22>();
                var userCtrl = new UserCtrlRepo();
                userCtrls = userCtrl.GetAll();

                GetChildControls(ucform, userCtrl);
            }
            catch (Exception ex)
            {
                Common.gMsg = $"Exception : {ex}";
            }
        }

        private void GetChildControls(Control ucform, UserCtrlRepo userCtrl)
        {
            Common.gMsg = $"GetChildControls";
            foreach (dynamic item in ucform.Controls)
            {
                Common.gMsg = $"item : {item.GetType().Name}/{item.Name}";

                if (userCtrl.CheckWorkSetType(item.GetType().Name))
                {
                    Common.gMsg = $"Case1 : {item.GetType().Name}/{item.Name}";
                    switch (item.GetType().Name)
                    {
                        case "UCGrid":
                            Common.gMsg = $"UCGrid : {item.GetType().Name}/{item.Name}";
                            //formUcList.Add(new T22
                            //{
                            //    Ctrl_id = item.Name,
                            //    Ctrl_ty = item.GetType().Name,
                            //    CtrlW = item.Width.ToString(),
                            //    CtrlH = item.Height.ToString(),
                            //    Title = item.Title,
                            //    TitleAlign = DevExpress.Utils.HorzAlignment.Default,
                            //    Show_chk = (item.Visible == true) ? "1" : "0",
                            //    Edit_chk = (item.Enabled == true) ? "1" : "0",
                            //    Wkset_id = item.Name,
                            //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
                            //});
                            break;
                        case "UCField":
                            Common.gMsg = $"UCField : {item.GetType().Name}/{item.Name}";
                            //formUcList.Add(new T22
                            //{
                            //    Ctrl_id = item.Name,
                            //    Ctrl_ty = item.GetType().Name,
                            //    CtrlW = item.Width.ToString(),
                            //    CtrlH = item.Height.ToString(),
                            //    Title = item.Name,
                            //    TitleAlign = DevExpress.Utils.HorzAlignment.Default,
                            //    Show_chk = (item.Visible == true) ? "1" : "0",
                            //    Edit_chk = (item.Enabled == true) ? "1" : "0",
                            //    Wkset_id = item.Name,
                            //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
                            //});
                            break;
                        case "UCGroup":
                            Common.gMsg = $"UCGroup : {item.GetType().Name}/{item.Name}";
                            //formUcList.Add(new T22
                            //{
                            //    Ctrl_id = item.Name,
                            //    Ctrl_ty = item.GetType().Name,
                            //    CtrlW = item.Width.ToString(),
                            //    CtrlH = item.Height.ToString(),
                            //    Title = item.Title,
                            //    TitleAlign = DevExpress.Utils.HorzAlignment.Default,
                            //    Show_chk = (item.Visible == true) ? "1" : "0",
                            //    Edit_chk = (item.Enabled == true) ? "1" : "0",
                            //    Wkset_id = repoCtrl.FindWorkSetType(item.GetType().Name),
                            //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
                            //});
                            break;
                        case "UCPanel":
                            Common.gMsg = $"UCPanel : {item.GetType().Name}/{item.Name}";
                            //formUcList.Add(new T22
                            //{
                            //    Ctrl_id = item.Name,
                            //    Ctrl_ty = item.GetType().Name,
                            //    CtrlW = item.Width.ToString(),
                            //    CtrlH = item.Height.ToString(),
                            //    Title = item.Title,
                            //    TitleAlign = DevExpress.Utils.HorzAlignment.Default,
                            //    Show_chk = (item.Visible == true) ? "1" : "0",
                            //    Edit_chk = (item.Enabled == true) ? "1" : "0",
                            //    Wkset_id = repoCtrl.FindWorkSetType(item.GetType().Name),
                            //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
                            //});
                            GetChildControls(item, userCtrl);
                            break;
                        case "SplitContainer":
                        case "SplitterPanel":
                        case "GroupControl":
                            GetChildControls(item, userCtrl);
                            break;
                        default:
                            Common.gMsg = $"ETC : {item.GetType().Name}/{item.Name}";
                            //formUcList.Add(new T22
                            //{
                            //    Ctrl_id = item.Name,
                            //    Ctrl_ty = item.GetType().Name,
                            //    CtrlW = item.Width.ToString(),
                            //    CtrlH = item.Height.ToString(),
                            //    Title = item.Title,
                            //    TitleAlign = item.TitleAlignment,
                            //    Show_chk = (item.Visible == true) ? "1" : "0",
                            //    Edit_chk = (item.Enabled == true) ? "1" : "0",
                            //    Wkset_id = repoCtrl.FindWorkSetType(item.GetType().Name),
                            //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
                            //});
                            break;
                    }
                }
                else
                {

                    Common.gMsg = $"Case2 : {item.GetType().Name}/{item.Name}";
                    GetChildControls(item,userCtrl);
                }
            }
        }
    }
}
