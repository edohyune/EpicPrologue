using DevExpress.ChartRangeControlClient.Core;
using DevExpress.Data.Helpers;
using DevExpress.Mvvm.POCO;
using DevExpress.RichEdit.Export;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet.Model;
using DevExpress.XtraTab;
using Lib;
using Lib.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static DevExpress.Accessibility.LookupPopupAccessibleObject;

namespace Frms
{
    [ToolboxItem(false)]
    public partial class FRMLOD : UserControl
    {
        private FrwFrm selectedFrwFrm { get; set; }
        private BindingList<FrwFrm> frmMstbs { get; set; }
        private FrwFrmRepo frmMstRepo { get; set; }


        private FrmCtrl frmCtrl { get; set; }
        private BindingList<FrmCtrl> frmCtrlbs { get; set; }
        private FrmCtrlRepo frmCtrlRepo { get; set; }


        private CtrlMst ctrlCls { get; set; }
        private List<CtrlMst> ctrlClss { get; set; }
        private BindingList<CtrlMst> ctrlClsbs { get; set; }
        private CtrlMstRepo ctrlClsRepo { get; set; }

        public FrmWrk frmWrk { get; set; }
        public List<FrmWrk> frmWrks { get; set; }
        public BindingList<FrmWrk> frmWrkbs { get; set; }
        public FrmWrkRepo frmWrkRepo { get; set; }

        public FRMLOD()
        {
            InitializeComponent();
            txtFilePath.ButtonVisiable = true;
            cmbStatus.DataSource = Enum.GetValues(typeof(MdlState));
        }

        private void gvForms_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            selectedFrwFrm = view.GetFocusedRow() as FrwFrm;

            if (selectedFrwFrm != null)
            {
                SetFrwFrmFreeForm();
            }

        }

        private void SetFrwFrmFreeForm()
        {
            AddBindingIfNotExists(txtFilePath, "BindText", selectedFrwFrm, "FilePath");
            AddBindingIfNotExists(txtFileNm, "BindText", selectedFrwFrm, "FileNm");
            AddBindingIfNotExists(txtFrmId, "BindText", selectedFrwFrm, "FrmId");
            AddBindingIfNotExists(txtFrmNm, "BindText", selectedFrwFrm, "FrmNm");
            AddBindingIfNotExists(txtUsrRegId, "BindText", selectedFrwFrm, "UsrRegId");
            AddBindingIfNotExists(txtFrwId, "BindText", selectedFrwFrm, "FrwId");
            AddBindingIfNotExists(txtNmSpace, "BindText", selectedFrwFrm, "NmSpace");
            AddBindingIfNotExists(chkFld, "EditValue", selectedFrwFrm, "FldYn");
            AddBindingIfNotExists(cmbStatus, "SelectedItem", selectedFrwFrm, "ChangedFlag");

        }
        private System.Windows.Forms.BindingSource bindingSource = new System.Windows.Forms.BindingSource();
        private void AddBindingIfNotExists(Control control, string propertyName, object dataSource, string dataMember)
        {
            bindingSource.DataSource = dataSource;
            control.DataBindings.Clear();
            control.DataBindings.Add(propertyName, bindingSource, dataMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void txtFrmId_EditValueChanged(object Sender, Control control)
        {
            OpengridControls();
        }

        private void OpengridControls()
        {
            if (selectedFrwFrm != null)
            {
                frmCtrl = new FrmCtrl();
                frmCtrlRepo = new FrmCtrlRepo();
                frmCtrlbs = new BindingList<FrmCtrl>(frmCtrlRepo.GetByFrwFrm(selectedFrwFrm.FrwId, selectedFrwFrm.FrmId));
                gridControls.DataSource = frmCtrlbs;

                frmWrk = new FrmWrk();
                frmWrkRepo = new FrmWrkRepo();
                frmWrkbs = new BindingList<FrmWrk>(frmWrkRepo.GetByWorkSetsOpenOrderby(selectedFrwFrm.FrwId, selectedFrwFrm.FrmId));
                gridWorkset.DataSource = frmWrkbs;
            }
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
            frmMstRepo = new FrwFrmRepo();
            frmMstbs = new BindingList<FrwFrm>(frmMstRepo.GetAll());
            gcForms.DataSource = frmMstbs;
        }

        private void ucPanel3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "New")
            {
                selectedFrwFrm = new FrwFrm();
                selectedFrwFrm.ChangedFlag = MdlState.Inserted;
                SetFrwFrmFreeForm();
            }
            else if (e.Button.Properties.Caption == "Save")
            {
                if (selectedFrwFrm.ChangedFlag == MdlState.Inserted)
                {
                    frmMstRepo.Add(selectedFrwFrm);
                }
                else
                {
                    frmMstRepo.Update(selectedFrwFrm);
                }

            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                if (selectedFrwFrm.ChangedFlag == MdlState.Inserted)
                {
                    selectedFrwFrm = new FrwFrm();
                    cmbStatus.Text = MdlState.Inserted.ToString();
                    SetFrwFrmFreeForm();
                }
                else
                {
                    frmMstRepo.Delete(selectedFrwFrm.FrmId);
                }
            }
        }

        private void txtDllpath_UCButtonClick(object Sender, Control control)
        {
            if (selectedFrwFrm == null) return;

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "DLL Files|*.dll|EXE Files|*.exe";

            if (string.IsNullOrEmpty(selectedFrwFrm.FilePath))
            {
                openFileDialog1.InitialDirectory = @"C:\";
            }
            else
            {
                openFileDialog1.InitialDirectory = selectedFrwFrm.FilePath;
            }
            openFileDialog1.ShowDialog();

            selectedFrwFrm.FilePath = Path.GetDirectoryName(openFileDialog1.FileName);
            selectedFrwFrm.FileNm = openFileDialog1.SafeFileName;
            selectedFrwFrm.FrmId = selectedFrwFrm.FileNm.Substring(0, selectedFrwFrm.FileNm.Length - 4);
            selectedFrwFrm.UsrRegId = Common.GetValue("gRegId").ToInt();
            selectedFrwFrm.FrwId = Common.GetValue("gFrameWorkId");
            selectedFrwFrm.NmSpace = $"Frms.{selectedFrwFrm.FrmId}";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (selectedFrwFrm == null) return;

            //frm.FilePath, frm.NmSpace의 값이 없으면 아무것도 하지 않는다.
            if (string.IsNullOrEmpty(selectedFrwFrm.FilePath) || string.IsNullOrEmpty(selectedFrwFrm.NmSpace))
            {
                return;
            }

            //UserControl정보를 넣는 변수 ucform을 선언한다.
            UserControl ucform = null;
            //추가 정보을 읽어 올 파일의 목록
            ctrlClsRepo = new CtrlMstRepo();
            ctrlClss = ctrlClsRepo.GetAll();
            //frmCtrlbs.Clear();

            Assembly assembly = AppDomain.CurrentDomain.Load(File.ReadAllBytes($"{selectedFrwFrm.FilePath}\\{selectedFrwFrm.FileNm}"));
            var ty = assembly.GetType(selectedFrwFrm.NmSpace);
            ucform = (UserControl)Activator.CreateInstance(ty);

            // 1. Non-Visual Components Tray Area 컨트롤 확인
            Common.gMsg = "1. Non-Visual Components Tray Area 컨트롤 확인";
            FieldInfo[] fields = ucform.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
                // BindingList, Repo, IContainer 타입 제외
                if (field.FieldType.FullName.Contains("BindingList") ||
                    field.FieldType.FullName.Contains("Repo") ||
                    field.FieldType.FullName.Contains("IContainer"))
                {
                    continue;
                }
                // UCField 또는 OpenFileDialog 타입인지 확인
                if (field.FieldType.FullName.Contains("Ctrls.UCField")) // 사용안함 field.FieldType.FullName.Contains("OpenFileDialog")
                {
                    // frmCtrls에 추가 (FrmCtrl 객체 생성 및 frmCtrlbs에 추가)
                    var ctrlNm = field.Name;
                    var toolNm = field.FieldType.Name;

                    // frmCtrlbs 에 데이터가 있으면 업데이트, 없으면 추가.
                    var frmCtrl = frmCtrlbs.FirstOrDefault(c => c.CtrlNm == ctrlNm);
                    if (frmCtrl != null)
                    {
                        frmCtrl.FrwId = Common.GetValue("gFrameWorkId");
                        frmCtrl.FrmId = selectedFrwFrm.FrmId;
                        frmCtrl.CtrlNm = ctrlNm;
                        frmCtrl.ToolNm = toolNm;
                        frmCtrl.ChangedFlag = MdlState.Updated;
                    }
                    else
                    {
                        frmCtrlbs.Add(new FrmCtrl
                        {
                            FrwId = Common.GetValue("gFrameWorkId"),
                            FrmId = selectedFrwFrm.FrmId,
                            CtrlNm = ctrlNm,
                            ToolNm = toolNm,
                            ChangedFlag = MdlState.Inserted
                            //사용하지 않는 데이터는 Null로 처리
                            //CtrlW = 0,CtrlH = 0,TitleText = "",TitleAlign = "",VisibleYn = false,ReadonlyYn = false
                        }); ;
                    }
                }
                else if (field.FieldType.FullName.Contains("UCGridSet"))
                {
                    var ctrlNm = field.Name;
                    var toolNm = field.FieldType.Name;
                    var frmCtrl = frmCtrlbs.FirstOrDefault(c => c.CtrlNm == ctrlNm);

                    if (frmCtrl != null)
                    {
                        frmCtrl.FrwId = Common.GetValue("gFrameWorkId");
                        frmCtrl.FrmId = selectedFrwFrm.FrmId;
                        frmCtrl.CtrlNm = ctrlNm;
                        frmCtrl.ToolNm = toolNm;
                        frmCtrl.ChangedFlag = MdlState.Updated;
                    }
                    else
                    {
                        frmCtrlbs.Add(new FrmCtrl
                        {
                            FrwId = Common.GetValue("gFrameWorkId"),
                            FrmId = selectedFrwFrm.FrmId,
                            CtrlNm = ctrlNm,
                            ToolNm = toolNm,
                            ChangedFlag = MdlState.Inserted
                        });
                    }
                }
            }

            // 2. 폼에 등록된 컨트롤 확인 (ucform.Controls)
            Common.gMsg = "2. 폼에 등록된 컨트롤 확인 (ucform.Controls)";
            FindUCControlsRecursive(ucform);

            // 3. WorkSet 등록 (UCField, UCGrid)
            Common.gMsg = "3. WorkSet 등록 (UCField, UCGrid, UCGridSet)";
            foreach (var item in frmCtrlbs)
            {
                if (item.ToolNm == "UCField")
                {
                    //frmWrks에 데이터가 있으면 업데이트, 없으면 추가.
                    var frmWrk = frmWrkbs.FirstOrDefault(c => c.CtrlNm == item.CtrlNm);
                    if (frmWrk != null)
                    {
                        frmWrk.FrwId = item.FrwId;
                        frmWrk.FrmId = item.FrmId;
                        frmWrk.CtrlNm = item.CtrlNm;
                        frmWrk.WrkCd = "FieldSet";
                        frmWrk.UseYn = true;
                        frmWrk.ChangedFlag = MdlState.Updated;
                    }
                    else
                    {
                        frmWrkbs.Add(new FrmWrk
                        {
                            FrwId = item.FrwId,
                            FrmId = item.FrmId,
                            CtrlNm = item.CtrlNm,
                            WrkCd = "FieldSet",
                            UseYn = true,
                            ChangedFlag = MdlState.Inserted
                        });
                    }
                }
                else if (item.ToolNm == "UCGrid")
                {   //frmWrks에 데이터가 있으면 업데이트, 없으면 추가.
                    var frmWrk = frmWrkbs.FirstOrDefault(c => c.CtrlNm == item.CtrlNm);
                    if (frmWrk != null)
                    {
                        frmWrk.FrwId = item.FrwId;
                        frmWrk.FrmId = item.FrmId;
                        frmWrk.CtrlNm = item.CtrlNm;
                        frmWrk.WrkCd = "GridSet";
                        frmWrk.UseYn = true;
                        frmWrk.ChangedFlag = MdlState.Updated;
                    }
                    else
                    {
                        frmWrkbs.Add(new FrmWrk
                        {
                            FrwId = item.FrwId,
                            FrmId = item.FrmId,
                            CtrlNm = item.CtrlNm,
                            WrkCd = "GridSet",
                            UseYn = true,
                            ChangedFlag = MdlState.Inserted
                        });
                    }
                }
                else if (item.ToolNm == "UCGridSet")
                {   //frmWrks에 데이터가 있으면 업데이트, 없으면 추가.
                    var frmWrk = frmWrkbs.FirstOrDefault(c => c.CtrlNm == item.CtrlNm);
                    if (frmWrk != null)
                    {
                        frmWrk.FrwId = item.FrwId;
                        frmWrk.FrmId = item.FrmId;
                        frmWrk.CtrlNm = item.CtrlNm;
                        frmWrk.WrkCd = "GridSet";
                        frmWrk.UseYn = true;
                        frmWrk.ChangedFlag = MdlState.Updated;
                    }
                    else
                    {
                        frmWrkbs.Add(new FrmWrk
                        {
                            FrwId = item.FrwId,
                            FrmId = item.FrmId,
                            CtrlNm = item.CtrlNm,
                            WrkCd = "GridSet",
                            UseYn = true,
                            ChangedFlag = MdlState.Inserted
                        });
                    }
                }
            }

            gridControls.DataSource = frmCtrlbs;
            gridWorkset.DataSource = frmWrkbs;
        }

        private void FindUCControlsRecursive(Control parentControl)
        {
            foreach (Control ctrl in parentControl.Controls)
            {
                if (!ctrlClss.Any(c => c.CtrlRegNm == ctrl.GetType().FullName))
                {
                    ctrlCls = new CtrlMst
                    {
                        CtrlNm = ctrl.GetType().Name,
                        CtrlRegNm = ctrl.GetType().FullName,
                        Memo = ctrl.HasChildren ? "HasChildren" : "NoChildren"
                    };
                    ctrlClsRepo.Add(ctrlCls);
                }
                else
                {
                    ctrlCls = new CtrlMst
                    {
                        CtrlNm = ctrl.GetType().Name,
                        CtrlRegNm = ctrl.GetType().FullName,
                        Memo = ctrl.HasChildren ? "HasChildren" : "NoChildren"
                    };
                    ctrlClsRepo.Update(ctrlCls);
                }

                //수정 ctrlClss.Any(c => c.CtrlRegNm == ctrl.GetType().FullName) 이면서 UseYn = true 인 경우만 frmCtrlbs에 추가
                if (ctrlClss.Any(c => c.CtrlRegNm == ctrl.GetType().FullName && c.UseYn))
                {
                    if (ctrlClss.Any(c => c.CtrlRegNm == ctrl.GetType().FullName && c.CustomYn))
                    {
                        //frmCtrlbs에 데이터가 있으면 업데이트, 없으면 추가.
                        var frmCtrl = frmCtrlbs.FirstOrDefault(c => c.CtrlNm == ctrl.Name);
                        if (frmCtrl != null)
                        {
                            frmCtrl.FrwId = Common.GetValue("gFrameWorkId");
                            frmCtrl.FrmId = selectedFrwFrm.FrmId;
                            frmCtrl.CtrlNm = ctrl.Name;
                            frmCtrl.ToolNm = ctrl.GetType().Name;
                            frmCtrl.CtrlW = GetWidth(ctrl);
                            frmCtrl.CtrlH = GetHeight(ctrl);
                            frmCtrl.CtrlX = ctrl.Location.X;
                            frmCtrl.CtrlY = ctrl.Location.Y;
                            frmCtrl.TitleText = GetTitleText(ctrl);
                            frmCtrl.TitleWidth = GetTitleWidth(ctrl);
                            frmCtrl.TitleAlign = GetTitleAlign(ctrl);
                            frmCtrl.DefaultText = GetText(ctrl);
                            frmCtrl.TextAlign = GetTextAlign(ctrl);
                            frmCtrl.ShowYn = ctrl.Visible;
                            frmCtrl.EditYn = GetEditYn(ctrl);
                            frmCtrl.ChangedFlag = MdlState.Updated;
                        }
                        else
                        {
                            frmCtrlbs.Add(new FrmCtrl
                            {
                                FrwId = Common.GetValue("gFrameWorkId"),
                                FrmId = selectedFrwFrm.FrmId,
                                CtrlNm = ctrl.Name,
                                ToolNm = ctrl.GetType().Name,
                                CtrlW = GetWidth(ctrl),
                                CtrlH = GetHeight(ctrl),
                                CtrlX = ctrl.Location.X,
                                CtrlY = ctrl.Location.Y,
                                TitleText = GetTitleText(ctrl),
                                TitleWidth = GetTitleWidth(ctrl),
                                TitleAlign = GetTitleAlign(ctrl),
                                DefaultText = GetText(ctrl),
                                TextAlign = GetTextAlign(ctrl),
                                ShowYn = ctrl.Visible,
                                EditYn = GetEditYn(ctrl),
                                ChangedFlag = MdlState.Inserted
                            });
                        }
                    }

                    if (ctrlClss.Any(c => c.CtrlRegNm == ctrl.GetType().FullName && c.ContainYn))
                    {
                        FindUCControlsRecursive(ctrl); // 재귀 호출
                    }
                }
            }
        }

        #region Get Control Properties
        private string GetTextAlign(Control ctrl)
        {
            if (ctrl is Ctrls.UCLookUp ucLookUp)
                return ucLookUp.TextAlignment.ToString();
            //else if (ctrl is Ctrls.UCField ucField)
            //else if (ctrl is Ctrls.UCGrid ucGrid)
            //else if (ctrl is Ctrls.UCLookUp ucLookUp)
            //    return ucLookUp.TextAlignment.ToString();
            //else if (ctrl is Ctrls.UCPanel ucPanel)
            //else if (ctrl is Ctrls.UCSplit ucSplit)
            //else if (ctrl is Ctrls.UCDateBox ucDateBox)
            //    return ucLookUp.TextAlignment.ToString();
            else if (ctrl is Ctrls.UCTextBox ucTextBox)
                return ucTextBox.TextAlignment.ToString();
            //else if (ctrl is Ctrls.UCTab ucTab)
            else
                return string.Empty;
        }

        private string GetText(Control ctrl)
        {
            if (ctrl is Ctrls.UCTextBox ucTextBox)
                return ucTextBox.Text;
            else if (ctrl is Ctrls.UCLookUp ucLookUp)
                return ucLookUp.Text;
            //else if (ctrl is Ctrls.UCMemo ucMemo)
            //    return ucLookUp.TitleWidth;
            //else if (ctrl is Ctrls.UCDateBox ucDateBox)
            //    return ucLookUp.TitleWidth;
            //else if (ctrl is Ctrls.UCCheckBox ucCheckBox)
            //    return ucLookUp.TitleWidth;
            else
                return "";
        }

        private int GetTitleWidth(Control ctrl)
        {
            if (ctrl is Ctrls.UCTextBox ucTextBox)
                return ucTextBox.TitleWidth;
            else if (ctrl is Ctrls.UCLookUp ucLookUp)
                return ucLookUp.TitleWidth;
            //else if (ctrl is Ctrls.UCMemo ucMemo)
            //    return ucLookUp.TitleWidth;
            //else if (ctrl is Ctrls.UCDateBox ucDateBox)
            //    return ucLookUp.TitleWidth;
            //else if (ctrl is Ctrls.UCCheckBox ucCheckBox)
            //    return ucLookUp.TitleWidth;
            else
                return 0;
        }

        private int GetWidth(Control ctrl)
        {
            if (ctrl is DevExpress.XtraTab.XtraTabPage tabPage)
                return tabPage.TabPageWidth;
            //else if (ctrl is Ctrls.UCButton ucButton)
            //else if (ctrl is Ctrls.UCField ucField)
            //else if (ctrl is Ctrls.UCGrid ucGrid)
            //else if (ctrl is Ctrls.UCLookUp ucLookUp)
            //else if (ctrl is Ctrls.UCPanel ucPanel)
            //else if (ctrl is Ctrls.UCSplit ucSplit)
            //else if (ctrl is Ctrls.UCTextBox ucTextBox)
            //else if (ctrl is Ctrls.UCTab ucTab)
            else
                return ctrl.Width;
        }
        private int GetHeight(Control ctrl)
        {
            if (ctrl is DevExpress.XtraTab.XtraTabPage tabPage)
                return ctrl.TabIndex;
            //else if (ctrl is Ctrls.UCButton ucButton)
            //else if (ctrl is Ctrls.UCField ucField)
            //else if (ctrl is Ctrls.UCGrid ucGrid)
            //else if (ctrl is Ctrls.UCLookUp ucLookUp)
            //else if (ctrl is Ctrls.UCPanel ucPanel)
            //else if (ctrl is Ctrls.UCSplit ucSplit)
            //else if (ctrl is Ctrls.UCTextBox ucTextBox)
            //else if (ctrl is Ctrls.UCTab ucTab)
            else
                return ctrl.Height;
        }

        private string GetTitleText(Control ctrl)
        {
            if (ctrl is Ctrls.UCButton ucButton)
                return ucButton.Text;
            //else if (ctrl is Ctrls.UCField ucField)
            //else if (ctrl is Ctrls.UCGrid ucGrid)
            else if (ctrl is Ctrls.UCLookUp ucLookUp)
                return ucLookUp.Title;
            else if (ctrl is Ctrls.UCPanel ucPanel)
                return ucPanel.Text;
            else if (ctrl is Ctrls.UCSplit ucSplit)
                return ucSplit.Text;
            else if (ctrl is Ctrls.UCTextBox ucTextBox)
                return ucTextBox.Title;
            //else if (ctrl is Ctrls.UCTab ucTab)
            else if (ctrl is DevExpress.XtraTab.XtraTabPage tabPage)
                return tabPage.Text;
            else
                return string.Empty;
        }

        private string GetTitleAlign(Control ctrl)
        {
            if (ctrl is Ctrls.UCButton ucButton)
                return ucButton.TitleAlignment.ToString();
            //else if (ctrl is Ctrls.UCField ucField)
            //else if (ctrl is Ctrls.UCGrid ucGrid)
            else if (ctrl is Ctrls.UCLookUp ucLookUp)
                return ucLookUp.TitleAlignment.ToString();
            //else if (ctrl is Ctrls.UCPanel ucPanel)
            //else if (ctrl is Ctrls.UCSplit ucSplit)
            else if (ctrl is Ctrls.UCTextBox ucTextBox)
                return ucTextBox.TitleAlignment.ToString();
            //else if (ctrl is Ctrls.UCTab ucTab)
            else
                return string.Empty;
        }

        private bool GetEditYn(Control ctrl)
        {
            if (ctrl is Ctrls.UCButton ucButton)
                return ucButton.EditYn;
            //else if (ctrl is Ctrls.UCField ucField)
            else if (ctrl is Ctrls.UCGrid ucGrid)
                if (ucGrid.gvCtrl != null)
                    return ucGrid.gvCtrl.Editable;
                else
                    return false; // or throw new Exception("gvCtrl is not initialized");
            else if (ctrl is Ctrls.UCLookUp ucLookUp)
                return ucLookUp.EditYn;
            else if (ctrl is Ctrls.UCPanel ucPanel)
                return ucPanel.EditYn;
            //else if (ctrl is Ctrls.UCSplit ucSplit)
            else if (ctrl is Ctrls.UCTextBox ucTextBox)
                return ucTextBox.EditYn;
            //else if (ctrl is Ctrls.UCTab ucTab)
            else
                return false;
        }
        #endregion

        private void ucPanel4_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Save")
            {
                foreach (var frmCtrl in frmCtrlbs)
                {
                    if (frmCtrl.ChangedFlag == MdlState.Inserted)
                    {
                        frmCtrlRepo.Add(frmCtrl);
                    }
                    else if (frmCtrl.ChangedFlag == MdlState.Updated)
                    {
                        frmCtrlRepo.Update(frmCtrl);
                    }
                    else if (frmCtrl.ChangedFlag == MdlState.None)
                    {
                        continue;
                    }
                }
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                var frmCtrl = gvControls.GetFocusedRow() as FrmCtrl;
                if (frmCtrl != null)
                {
                    frmCtrlbs.Remove(frmCtrl);
                    frmCtrlRepo.Delete(frmCtrl.FrwId, frmCtrl.FrmId, frmCtrl.CtrlNm);
                }
            }
        }
        private void ucPanel5_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Save")
            {
                foreach (var frmWrk in frmWrkbs)
                {
                    if (frmWrk.ChangedFlag == MdlState.None)
                    {
                        continue;
                    }
                    else if (frmWrk.ChangedFlag == MdlState.Inserted)
                    {
                        frmWrkRepo.Add(frmWrk);
                    }
                    else if (frmWrk.ChangedFlag == MdlState.Updated)
                    {
                        frmWrkRepo.Update(frmWrk);
                    }
                }
            }
            else if (e.Button.Properties.Caption == "Delete")
            {
                var frmWrk = gvWorkset.GetFocusedRow() as FrmWrk;
                if (frmWrk != null)
                {
                    frmWrkbs.Remove(frmWrk);
                    frmWrkRepo.Delete(frmWrk.WrkId);
                }
            }
            else if (e.Button.Properties.Caption == "New")
            {
                //입력을 위한 새로운 line을 준비한다. 저장은 Save 버튼을 눌러야 한다.
                frmWrkbs.Add(new FrmWrk
                {
                    FrwId = Common.GetValue("gFrameWorkId"),
                    FrmId = selectedFrwFrm.FrmId,
                    CtrlNm = "",
                    WrkCd = "",
                    UseYn = true,
                    ChangedFlag = MdlState.Inserted
                });
            }
        }

        private void btnFTPUpload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FTP Upload");
        }
    }
}
