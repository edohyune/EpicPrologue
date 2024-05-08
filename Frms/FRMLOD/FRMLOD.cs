using DevExpress.Mvvm.POCO;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using Frms.Repo;
using Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frms
{
    public partial class FRMLOD : UserControl
    {
        List<UserCtrl> userCtrls;

        public FRMLOD()
        {
            InitializeComponent();
            txtDllpath.btnVisiable = true;
        }

        private void txtDllpath_UCButtonClick(object Sender, Control control)
        {
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
            //strFilePath : D:\00_WorkSpace\EpicPrologue\Frms\FRMLOD\bin\Debug\net8.0-windows\FRMLOD.dll
            //strFile : FRMLOD
            //strExt : dll
            //strFileExt : FRMLOD.dll

            string strFilePath = openFileDialog1.FileName;
            string strFileExt = openFileDialog1.SafeFileName;
            //string strExt = strFileExt.Substring(strFileExt.Length - 3, 3);
            string strFile = strFileExt.Substring(0, strFileExt.Length - 4);

            GenFunc.SetIni("DLLPath", strFilePath);

            //선택한 파일 버전 정보읽기   
            UserControl ucform = null;
            try
            {
                Assembly assembly = AppDomain.CurrentDomain.Load(File.ReadAllBytes(strFilePath));
                //Assembly assembly = Assembly.LoadFile(strFile);
                string strVersion = assembly.GetName().Version.ToString();

                Common.gMsg = $"assembly.GetName().Name : {assembly.GetName().Name}";
                Common.gMsg = $"assembly.GetName().CultureName : {assembly.GetName().CultureName}";
                Common.gMsg = $"assembly.GetName().FullName : {assembly.GetName().FullName}";

                //Rule : Form NameSpace -> Frms.[strFile] 
                var ty = assembly.GetType($"Frms.{strFile}");
                ucform = (UserControl)Activator.CreateInstance(ty);

                var ctrlInForms = CtrlsIncludeinForm(ucform, strFileExt);

                using (var db = new Lib.GaiaHelper())
                {
                    var ctrlMsts = new CtrlClsRepo();

                    foreach (var item in ctrlInForms)
                    {
                        if (ctrlMsts.ChkByCtrlNm(Lib.GenFunc.GetLastSubstring(item.Val.ToString(), '.')))
                        {
                            ctrlMsts.Add(new CtrlCls
                            {
                                CtrlNm = Lib.GenFunc.GetLastSubstring(item.Val.ToString(), '.'),
                                CtrlGrpCd = null,
                                CtrlRegNm = item.Val.ToString(),
                                ContainYn = true,
                                CustomYn = true,
                                Rnd = null,
                                Memo = null,
                                PId = 0,
                                CId = 10010,
                                MId = 10010
                            });
                        }
                    }

                    //CTRLINC 테이블을 만들고 모델과  Repository를 만들고 모든 컨트롤러를 저장한다. 
                    //ATZ300에 해당하는 것으로 기억함.



                    //var ucInfo = db.GetUc(new { sys = SysCode, frm = FrmID, ctrl = FldID }).SingleOrDefault();
                    //if (ucInfo != null)
                    //{
                    //    this.Title = ucInfo.Title;
                    //    this.TitleWidth = ucInfo.TitleW;
                    //    this.labelCtrl.Visible = (ucInfo.Show_chk == "0" ? false : true);
                    //    this.textCtrl.Visible = (ucInfo.Show_chk == "0" ? false : true);
                    //    this.labelCtrl.Appearance.TextOptions.HAlignment = GenFunc.StrToAlign(ucInfo.TitleAlign);
                    //    this.Text = ucInfo.Txt;
                    //    this.textCtrl.Properties.Appearance.TextOptions.HAlignment = GenFunc.StrToAlign(ucInfo.TxtAlign);
                    //    this.textCtrl.ReadOnly = (ucInfo.Edit_chk == "1" ? false : true);
                    //}
                }


                
                txtDllpath.Text = strFilePath;
;
                var userCtrl = new Repo.UserCtrlRepo();

                userCtrls = userCtrl.GetAll();

                string lastPart = Lib.GenFunc.GetLastSubstring(input, '.');

                // 프로세서정리
                // CTRLMST 구성 Controller이름 저장
                // CTRLINC 구성 Controller에 포함된 컨트롤 저장    

                //GetChildControls(ucform, userCtrl);
            }
            catch (Exception ex)
            {
                Common.gMsg = $"Exception : {ex}";
            }
        }

        private void GetChildControls(Control ucform, UserCtrlRepo userCtrl)
        {
            foreach (Control item in ucform.Controls)
            {
                Common.gMsg = $"item : {item.GetType().Name}/{item.Name}";

                if (item is SplitContainer || item is SplitterPanel || item is GroupControl || item is Ctrls.UCPanel)
                {
                    GetChildControls(item, userCtrl); // 재귀적으로 내부 컨트롤 탐색
                }

                //if (item is Ctrls.UCGrid || item is Ctrls.UCField)
                //{
                //    Common.gMsg = $"{item.GetType().Name}/{item.Name}";
                //    //GetChildControls(item, userCtrl); // 재귀적으로 내부 컨트롤 탐색
                //}
                //else if (item is SplitContainer || item is SplitterPanel || item is GroupControl || item is Ctrls.UCPanel)
                //{
                //    Common.gMsg = $"Handled : {item.GetType().Name}/{item.Name}";
                //    GetChildControls(item, userCtrl); // 재귀적으로 내부 컨트롤 탐색
                //}
                //else if (item is OpenFileDialog)
                //{
                //    Console.WriteLine($"OpenFileDialog : {item.GetType().Name}/{item.Name}");
                //}
                //else if (item is TokenEdit)
                //{
                //    Console.WriteLine($"TokenEdit : {item.GetType().Name}/{item.Name}");
                //}
                //else
                //{
                //    Console.WriteLine($"ETC : {item.GetType().Name}/{item.Name}");
                //}
            }


            //Common.gMsg = $"GetChildControls";
            //foreach (dynamic item in ucform.Controls)
            //{
            //    Common.gMsg = $"item : {item.GetType().Name}/{item.Name}";

            //    if (userCtrl.CheckWorkSetType(item.GetType().Name))
            //    {
            //        Common.gMsg = $"Case1 : {item.GetType().Name}/{item.Name}";
            //        switch (item.GetType().Name)
            //        {
            //            case "UCGrid":
            //                Common.gMsg = $"UCGrid : {item.GetType().Name}/{item.Name}";
            //                //formUcList.Add(new T22
            //                //{
            //                //    Ctrl_id = item.Name,
            //                //    Ctrl_ty = item.GetType().Name,
            //                //    CtrlW = item.Width.ToString(),
            //                //    CtrlH = item.Height.ToString(),
            //                //    Title = item.Title,
            //                //    TitleAlign = DevExpress.Utils.HorzAlignment.Default,
            //                //    Show_chk = (item.Visible == true) ? "1" : "0",
            //                //    Edit_chk = (item.Enabled == true) ? "1" : "0",
            //                //    Wkset_id = item.Name,
            //                //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
            //                //});
            //                break;
            //            case "UCField":
            //                Common.gMsg = $"UCField : {item.GetType().Name}/{item.Name}";
            //                //formUcList.Add(new T22
            //                //{
            //                //    Ctrl_id = item.Name,
            //                //    Ctrl_ty = item.GetType().Name,
            //                //    CtrlW = item.Width.ToString(),
            //                //    CtrlH = item.Height.ToString(),
            //                //    Title = item.Name,
            //                //    TitleAlign = DevExpress.Utils.HorzAlignment.Default,
            //                //    Show_chk = (item.Visible == true) ? "1" : "0",
            //                //    Edit_chk = (item.Enabled == true) ? "1" : "0",
            //                //    Wkset_id = item.Name,
            //                //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
            //                //});
            //                break;
            //            case "UCGroup":
            //                Common.gMsg = $"UCGroup : {item.GetType().Name}/{item.Name}";
            //                //formUcList.Add(new T22
            //                //{
            //                //    Ctrl_id = item.Name,
            //                //    Ctrl_ty = item.GetType().Name,
            //                //    CtrlW = item.Width.ToString(),
            //                //    CtrlH = item.Height.ToString(),
            //                //    Title = item.Title,
            //                //    TitleAlign = DevExpress.Utils.HorzAlignment.Default,
            //                //    Show_chk = (item.Visible == true) ? "1" : "0",
            //                //    Edit_chk = (item.Enabled == true) ? "1" : "0",
            //                //    Wkset_id = repoCtrl.FindWorkSetType(item.GetType().Name),
            //                //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
            //                //});
            //                break;
            //            case "UCPanel":
            //                Common.gMsg = $"UCPanel : {item.GetType().Name}/{item.Name}";
            //                //formUcList.Add(new T22
            //                //{
            //                //    Ctrl_id = item.Name,
            //                //    Ctrl_ty = item.GetType().Name,
            //                //    CtrlW = item.Width.ToString(),
            //                //    CtrlH = item.Height.ToString(),
            //                //    Title = item.Title,
            //                //    TitleAlign = DevExpress.Utils.HorzAlignment.Default,
            //                //    Show_chk = (item.Visible == true) ? "1" : "0",
            //                //    Edit_chk = (item.Enabled == true) ? "1" : "0",
            //                //    Wkset_id = repoCtrl.FindWorkSetType(item.GetType().Name),
            //                //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
            //                //});
            //                GetChildControls(item, userCtrl);
            //                break;
            //            case "SplitContainer":
            //            case "SplitterPanel":
            //            case "GroupControl":
            //                GetChildControls(item, userCtrl);
            //                break;
            //            case "OpenFileDialog":
            //                Common.gMsg = $"ETC : {item.GetType().Name}/{item.Name}";
            //                break;
            //            default:
            //                Common.gMsg = $"ETC : {item.GetType().Name}/{item.Name}";
            //                //formUcList.Add(new T22
            //                //{
            //                //    Ctrl_id = item.Name,
            //                //    Ctrl_ty = item.GetType().Name,
            //                //    CtrlW = item.Width.ToString(),
            //                //    CtrlH = item.Height.ToString(),
            //                //    Title = item.Title,
            //                //    TitleAlign = item.TitleAlignment,
            //                //    Show_chk = (item.Visible == true) ? "1" : "0",
            //                //    Edit_chk = (item.Enabled == true) ? "1" : "0",
            //                //    Wkset_id = repoCtrl.FindWorkSetType(item.GetType().Name),
            //                //    Wkset_ty = repoCtrl.FindWorkSetType(item.GetType().Name)
            //                //});
            //                break;
            //        }
            //    }
            //    else
            //    {

            //        Common.gMsg = $"Case2 : {item.GetType().Name}/{item.Name}";
            //        GetChildControls(item, userCtrl);
            //    }
            //}
        }

        private  List<IdNm> CtrlsIncludeinForm(UserControl ucform, string strFileExt)
        {
            // UserControl의 모든 필드를 가져옵니다.
            FieldInfo[] fields = ucform.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            List<IdNm> idNms = new List<IdNm>();

            foreach (var field in fields)
            {
                if (field.Module.ToString() == strFileExt)
                {
                    idNms.Add(new IdNm { Txt = field.Name, Val = field.FieldType });
                }
            }
            return idNms;
        }
    }
}
