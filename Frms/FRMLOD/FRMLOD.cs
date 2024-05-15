using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using Lib;
using Lib.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using static DevExpress.Accessibility.LookupPopupAccessibleObject;

namespace Frms
{
    [ToolboxItem(false)]
    public partial class FRMLOD : UserControl
    {
        private FrmMst selectedFrmMst { get; set; }
        private BindingList<FrmMst> frmMsts { get; set; }
        private FrmMstRepo frmMstRepo { get; set; }
        private BindingList<FrmCtrl> frmCtrls { get; set; }
        private FrmCtrlRepo frmCtrlRepo { get; set; }


        public FRMLOD()
        {
            InitializeComponent();
            txtFilePath.btnVisiable = true;
            cmbStatus.DataSource = Enum.GetValues(typeof(MdlState));
            //cmbStatus.DisplayMember = "Display";
            //cmbStatus.ValueMember = "Value";
            //chkFld의 caption이 checkbox 왼쪽에 오도록 한다
        }

        private void gvForms_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            selectedFrmMst = view.GetFocusedRow() as FrmMst;

            SetFrmMstFreeForm();
        }

        private void SetFrmMstFreeForm()
        {
            if (selectedFrmMst == null)
            {
                MessageBox.Show($"selectedFrmMst이 null입니다.");
            }
            else
            {
                // selectedFrmMst의 각 필드를 컨트롤에 바인딩
                AddBindingIfNotExists(txtFilePath, "Text", selectedFrmMst, "FilePath");
                AddBindingIfNotExists(txtFileNm, "Text", selectedFrmMst, "FileNm");
                AddBindingIfNotExists(txtFrmId, "Text", selectedFrmMst, "FrmId");
                AddBindingIfNotExists(txtFrmNm, "Text", selectedFrmMst, "FrmNm");
                AddBindingIfNotExists(txtOwnId, "Text", selectedFrmMst, "OwnId");
                AddBindingIfNotExists(txtFrwId, "Text", selectedFrmMst, "FrwId");
                AddBindingIfNotExists(txtNmSpace, "Text", selectedFrmMst, "NmSpace");
                AddBindingIfNotExists(chkFld, "Checked", selectedFrmMst, "FldYn");
                AddBindingIfNotExists(cmbStatus, "Text", selectedFrmMst, "ChangedFlag");
            }
        }

        private void AddBindingIfNotExists(Control control, string propertyName, object dataSource, string dataMember)
        {
            foreach (Binding binding in control.DataBindings)
            {
                if (binding.PropertyName == propertyName)
                {
                    return; // Skip adding the binding if it already exists
                }
            }

            control.DataBindings.Add(propertyName, dataSource, dataMember);
        }

        private void GetFrmMstFreeForm()
        {
            selectedFrmMst.FilePath = txtFilePath.Text;
            selectedFrmMst.FileNm = txtFileNm.Text;
            selectedFrmMst.FrmId = txtFrmId.Text;
            selectedFrmMst.FrmNm = txtFrmNm.Text;
            //txtOwnId의 Text를 int로 변환
            selectedFrmMst.OwnId = Convert.ToInt32(txtOwnId.Text);
            selectedFrmMst.FrwId = txtFrwId.Text;
            selectedFrmMst.NmSpace = txtNmSpace.Text;
            selectedFrmMst.FldYn = chkFld.Checked;
            //txtChange의 값을 MdlState로 변환
            selectedFrmMst.ChangedFlag = (MdlState)Enum.Parse(typeof(MdlState), cmbStatus.Text);
        }

        private void txtFrmId_EditValueChanged(object Sender, Control control)
        {
            OpengridControls();
        }

        private void OpengridControls()
        {
            frmCtrlRepo = new FrmCtrlRepo();
            frmCtrls = new BindingList<FrmCtrl>(frmCtrlRepo.GetByFrm(selectedFrmMst.FrmId));
            gridControls.DataSource = frmCtrls;
        }

        private void ucPenel2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Open")
            {
                OpengridFrms();
            }

        }
        private void OpengridFrms()
        {
            frmMstRepo = new FrmMstRepo();
            frmMsts = new BindingList<FrmMst>(frmMstRepo.GetAll());
            gcForms.DataSource = frmMsts;
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

            selectedFrmMst.FilePath = Path.GetDirectoryName(openFileDialog1.FileName);
            selectedFrmMst.FileNm = openFileDialog1.SafeFileName;
            selectedFrmMst.FrmId = selectedFrmMst.FileNm.Substring(0, selectedFrmMst.FileNm.Length - 4);
            selectedFrmMst.OwnId = (int)Common.gRegId;
            selectedFrmMst.FrwId = Common.gFrameWorkId;
            selectedFrmMst.NmSpace = $"Frms.{selectedFrmMst.FrmId}";

            SetFrmMstFreeForm();

            GenFunc.SetIni("DLLPath", txtFilePath.Text);

            LoadDll(selectedFrmMst);
        }

        private void LoadDll(FrmMst frm)
        {
            //frm.FilePath, frm.NmSpace의 값이 없으면 아무것도 하지 않는다.
            if (string.IsNullOrEmpty(frm.FilePath) || string.IsNullOrEmpty(frm.NmSpace))
            {
                return;
            }
            //선택한 파일 버전 정보읽기   
            UserControl ucform = null;
            try
            {
                Assembly assembly = AppDomain.CurrentDomain.Load(File.ReadAllBytes(frm.FilePath));
                //string strVersion = assembly.GetName().Version.ToString();

                var ty = assembly.GetType(frm.NmSpace);
                ucform = (UserControl)Activator.CreateInstance(ty);

                var ctrlInForms = CtrlsIncludeinForm(ucform, frm.FileNm);
                var ctrlMsts = new CtrlClsRepo();

                foreach (var item in ctrlInForms)
                {
                    string ctrlNm = item.Txt;
                    string toolNm = Lib.GenFunc.GetLastSubstring(item.Val.ToString(), '.');
                    string toolNs = item.Val.ToString();

                    if (ctrlMsts.ChkByCtrlNm(toolNm))
                    {
                        if (toolNs.Contains("BindingList") || toolNs.Contains("Repo") || toolNs.Contains("IContainer"))
                        {
                            continue;
                        }
                        else
                        {
                            ctrlMsts.Add(new CtrlCls
                            {
                                CtrlNm = toolNm,
                                CtrlRegNm = toolNs,
                                Memo = $"{frm.FrmId}작업 중 시스템이 추가"
                            });
                        }
                    }

                    FrmCtrl frmCtrl = new FrmCtrl
                    {
                        CtrlNm = ctrlNm,
                        ToolNm = toolNm,
                        FrmId = frm.FrmId // FrmCtrl은 FrmMst의 FrmId와 연결된다.
                    };
                    frmCtrls.Add(frmCtrl);

                    //frmCtrl을 gridControls에 새로운 줄로 추가합니다. 
                    Common.gMsg = $"frmCtrl : {ctrlNm}/{toolNm}";


                    //frmCtrl = GetpropertiesController();
                    //frmCtrlRepo.Add(frmCtrl);
                }
                gvControls.RefreshData();
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

        private void GetChildControls(Control ucform, CtrlClsRepo userCtrl)
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
                        frmMstRepo.Delete((string)idToRemove);
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
                            frmMstRepo.Add(updatedRow);
                        }
                        else
                        {
                            // 기존 행을 업데이트합니다.
                            frmMstRepo.Update(updatedRow);
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
                cmbStatus.Text = MdlState.Inserted.ToString();
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                if (selectedFrmMst.ChangedFlag == MdlState.Inserted)
                {
                    frmMstRepo.Add(selectedFrmMst);
                    //frmMstRepo.Add(new FrmMst
                    //{
                    //    FrmId = txtFrmId.Text,
                    //    FrmNm = txtFrmNm.Text,
                    //    OwnId = Convert.ToInt32(txtOwnId.Text),
                    //    FrwId = txtFrwId.Text,
                    //    FilePath = txtFilePath.Text,
                    //    FileNm = txtFileNm.Text,
                    //    FldYn = chkFld.Checked,
                    //    NmSpace = txtNmSpace.Text
                    //});
                }
                else
                {
                    frmMstRepo.Update(selectedFrmMst);
                    //frmMstRepo.Update(new FrmMst
                    //{
                    //    FrmId = txtFrmId.Text,
                    //    FrmNm = txtFrmNm.Text,
                    //    OwnId = Convert.ToInt32(txtOwnId.Text),
                    //    FrwId = txtFrwId.Text,
                    //    FilePath = txtFilePath.Text,
                    //    FileNm = txtFileNm.Text,
                    //    NmSpace = txtNmSpace.Text,
                    //    FldYn = chkFld.Checked
                    //});
                }

            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                if (cmbStatus.Text == MdlState.Inserted.ToString())
                {
                    txtFrmId.Text = "";
                    txtFrmNm.Text = "";
                    txtOwnId.Text = "";
                    txtFrwId.Text = "";
                    txtFilePath.Text = "";
                    txtFileNm.Text = "";
                    txtNmSpace.Text = "";
                    chkFld.Checked = false;
                    cmbStatus.Text = MdlState.Inserted.ToString();
                }
                else
                {
                    frmMstRepo.Delete(selectedFrmMst.FrmId);
                }
            }
        }

        private void ucPanel4_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Save")
            {
                if (cmbStatus.Text == MdlState.Inserted.ToString())
                {
                    Common.gMsg = "Insert";
                }
                else
                {
                    Common.gMsg = "Update";
                }
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                Common.gMsg = "Delete";
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
                case NavigatorButtonType.Remove:
                    var idToRemove = view.GetFocusedRowCellValue("CtrlNm");
                    if (idToRemove != null)
                    {
                        frmCtrlRepo.Delete(txtFrmId.Text, (string)idToRemove);
                        data.Remove(data.Find(x => x.CtrlNm == (string)idToRemove));
                        view.RefreshData();
                    }
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

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

    }
}
