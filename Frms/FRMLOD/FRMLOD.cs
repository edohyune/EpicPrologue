using DevExpress.XtraEditors;
using Repo;
using Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Frms
{
    [ToolboxItem(false)]
    public partial class FRMLOD : UserControl
    {
        List<UserCtrl> userCtrls;

        public FRMLOD()
        {
            InitializeComponent();
            txtFilePath.btnVisiable = true;
            //chkFld의 caption이 checkbox 왼쪽에 오도록 한다
        }
        //gridForms의 Row선택이 바뀌는 이벤트
        private void gvForms_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            var row = view.GetFocusedRow() as FrmMst;
            if (row == null) return;

            txtFrmId.Text = row.FrmId;
            txtFrmNm.Text = row.FrmNm;
            txtOwnId.Text = row.OwnId.ToString();
            txtFrwId.Text = row.FrwId;
            txtFilePath.Text = row.FilePath;
            txtFileNm.Text = row.FileNm;
            txtNmSpace.Text = row.NmSpace;
            chkFld.Checked = row.FldYn;
            txtChange.Text = MdlState.Updated.ToString();
        }

        //txtFrmId의 값이 변경되면 txtFrmId을 openGridControl(txtFrmId)로 gridControl을 오픈한다
        private void txtFrmId_EditValueChanged(object Sender, Control control)
        {
            openGridControl(txtFrmId.Text);
        }

        BindingList<FrmCtrl> frmctrls;
        FrmCtrlRepo frmCtrlRepo;
        private void openGridControl(string frmId)
        {
            frmCtrlRepo = new FrmCtrlRepo();
            frmctrls = new BindingList<FrmCtrl>(frmCtrlRepo.GetByFrm(frmId));
            gridControls.DataSource = frmctrls;
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
                //Common.gMsg = $"assembly.GetName().CultureName : {assembly.GetName().CultureName}";
                Common.gMsg = $"assembly.GetName().FullName : {assembly.GetName().FullName}";

                //Rule : Form NameSpace -> Frms.[strFile] 
                var ty = assembly.GetType($"Frms.{strFile}");
                ucform = (UserControl)Activator.CreateInstance(ty);

                var ctrlInForms = CtrlsIncludeinForm(ucform, strFileExt);

                using (var db = new Lib.GaiaHelper())
                {
                    var ctrlMsts = new CtrlClsRepo();
                    string ctrlNm;
                    string toolNm;
                    //CtrlMsts에 저장하는 것은 Epic Prologue에서만 사용하는 것으로 한다.
                    foreach (var item in ctrlInForms)
                    {
                        ctrlNm = item.Txt;
                        toolNm = Lib.GenFunc.GetLastSubstring(item.Val.ToString(), '.');
                        if (ctrlMsts.ChkByCtrlNm(toolNm))
                        {
                            ctrlMsts.Add(new CtrlCls
                            {
                                CtrlNm = ctrlNm,
                                CtrlGrpCd = null,
                                CtrlRegNm = toolNm,
                                ContainYn = true,
                                CustomYn = true,
                                Rnd = null,
                                Memo = null,
                                CId = 10020,
                                MId = 10020
                            });
                        }

                        FrmCtrl frmCtrl = new FrmCtrl
                        {
                            CtrlNm = ctrlNm,
                            ToolNm = toolNm,
                            FrmId = txtFrmId.Text // FrmCtrl은 FrmMst의 FrmId와 연결된다.
                        };
                        //frmCtrl을 gridControls에 새로운 줄로 추가합니다. 
                        Common.gMsg = $"frmCtrl : {ctrlNm}/{toolNm}";


                        //frmCtrl = GetpropertiesController();
                        //frmCtrlRepo.Add(frmCtrl);
                    }
                    gvControls.RefreshData();
                }
            }
            catch (Exception ex)
            {
                Common.gMsg = $"Exception : {ex}";
            }
        }

        private FrmCtrl GetpropertiesController(UserControl ucform, FrmCtrl frmCtrl)
        {
            throw new NotImplementedException();
        }

        private List<IdNm> CtrlsIncludeinForm(UserControl ucform, string strFileExt)
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

        //List<FrmMst> frmmsts;
        BindingList<FrmMst> frmmsts;
        FrmMstRepo frmmstrepo;

        private void ucPenel2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Open")
            {
                gridForms_open();
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                gridForms_save();
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                Common.gMsg = ((FrmMst)gvForms.GetFocusedRow()).FrmNm.ToString();
            }
        }
        private void gridForms_open()
        {
            frmmstrepo = new FrmMstRepo();
            frmmsts = new BindingList<FrmMst>(frmmstrepo.GetAll());
            gcForms.DataSource = frmmsts;
        }
        private void gridForms_save()
        {
            MessageBox.Show("Save");
        }

        private void gdForms_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            var view = gvForms;
            var data = gcForms.DataSource as List<FrmMst>;

            switch (e.Button.ButtonType)
            {
                case NavigatorButtonType.Append:
                    break;
                case NavigatorButtonType.Remove:
                    var idToRemove = view.GetFocusedRowCellValue("FrmId");
                    if (idToRemove != null)
                    {
                        frmmstrepo.Delete((string)idToRemove);
                        data.Remove(data.Find(x => x.FrmId == (string)idToRemove));
                        view.RefreshData();
                    }
                    break;
                case NavigatorButtonType.Edit:
                    view.ShowEditor();
                    break;
                case NavigatorButtonType.EndEdit:
                    if (view.IsEditing)
                    {
                        view.CloseEditor();
                        view.UpdateCurrentRow();
                    }

                    var updatedRow = view.GetFocusedRow() as FrmMst;

                    if (updatedRow != null)
                    {
                        if (updatedRow.ChangedFlag == MdlState.Inserted)
                        {
                            // 새 행을 추가합니다.
                            frmmstrepo.Add(updatedRow);
                        }
                        else
                        {
                            // 기존 행을 업데이트합니다.
                            frmmstrepo.Update(updatedRow);
                        }
                        view.RefreshData();
                    }
                    break;
            }
        }

        private void ucPanel3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "New")
            {
                txtFrmId.Text = "";
                txtFrmNm.Text = "";
                txtOwnId.Text = "";
                txtFrwId.Text = "";
                txtFilePath.Text = "";
                txtFileNm.Text = "";
                txtNmSpace.Text = ""; 
                chkFld.Checked = false;
                txtChange.Text = MdlState.Inserted.ToString();
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                if (txtChange.Text == MdlState.Inserted.ToString())
                {
                    frmmstrepo.Add(new FrmMst
                    {
                        FrmId = txtFrmId.Text,
                        FrmNm = txtFrmNm.Text,
                        OwnId = Convert.ToInt32(txtOwnId.Text),
                        FrwId = txtFrwId.Text,
                        FilePath = txtFilePath.Text,
                        FileNm = txtFileNm.Text,
                        FldYn = chkFld.Checked,
                        NmSpace = txtNmSpace.Text
                    });
                }
                else
                {
                    frmmstrepo.Update(new FrmMst
                    {
                        FrmId = txtFrmId.Text,
                        FrmNm = txtFrmNm.Text,
                        OwnId = Convert.ToInt32(txtOwnId.Text),
                        FrwId = txtFrwId.Text,
                        FilePath = txtFilePath.Text,
                        FileNm = txtFileNm.Text,
                        NmSpace = txtNmSpace.Text,
                        FldYn = chkFld.Checked
                    });
                }

            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                if (txtChange.Text == MdlState.Inserted.ToString())
                {
                    txtFrmId.Text = "";
                    txtFrmNm.Text = "";
                    txtOwnId.Text = "";
                    txtFrwId.Text = "";
                    txtFilePath.Text = "";
                    txtFileNm.Text = "";
                    txtNmSpace.Text = "";
                    chkFld.Checked = false;
                    txtChange.Text = MdlState.Inserted.ToString();
                }
                else
                {
                    frmmstrepo.Delete(txtFrmId.Text);
                }
            }
        }
        //gridControls는 FrmCtrl을 이용한다.
        //gridControls의 EmbeddedNavigator의 버튼 클릭 이벤트를 처리한다.
        //gdForms_EmbeddedNavigator_ButtonClick의 기능을 참고하여 구현한다.

        private void gdControls_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            var view = gvControls;
            var data = gridControls.DataSource as List<FrmCtrl>;

            switch (e.Button.ButtonType)
            {
                case NavigatorButtonType.Append:
                    break;
                case NavigatorButtonType.Remove:
                    var idToRemove = view.GetFocusedRowCellValue("CtrlNm");
                    if (idToRemove != null)
                    {
                        frmCtrlRepo.Delete(txtFrmId.Text, (string)idToRemove);
                        data.Remove(data.Find(x => x.CtrlNm == (string)idToRemove));
                        view.RefreshData();
                    }
                    break;
                case NavigatorButtonType.Edit:
                    view.ShowEditor();
                    break;
                case NavigatorButtonType.EndEdit:
                    if (view.IsEditing)
                    {
                        view.CloseEditor();
                        view.UpdateCurrentRow();
                    }

                    var updatedRow = view.GetFocusedRow() as FrmCtrl;

                    if (updatedRow != null)
                    {
                        if (updatedRow.ChangedFlag == MdlState.Inserted)
                        {
                            // 새 행을 추가합니다.
                            frmCtrlRepo.Add(updatedRow);
                        }
                        else
                        {
                            // 기존 행을 업데이트합니다.
                            frmCtrlRepo.Update(updatedRow);
                        }
                        view.RefreshData();
                    }
                    break;
            }
        }
    }
}
