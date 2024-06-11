using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Lib;
using Lib.Repo;
using System.IO;
using Repo;
using DevExpress.XtraEditors.ButtonsPanelControl;

namespace GAIA
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        [STAThread]
        static void Main()
        {
            sign = new SignIn();
            Application.Run(sign);

            if (signin)
            {
                FormMain m = new FormMain();
                sign.Close();
                Application.Run(m);
            }
            else
            {
                Application.Exit();
            }
        }

        static SignIn sign = null;
        internal static bool signin = false;

        public FormMain()
        {
            InitializeComponent();

            //menuCtrl.VisibleChanged += new EventHandler(menuCtrl_VisibleChanged);
            //msgCtrl.VisibleChanged += new EventHandler(msgCtrl_VisibleChanged);
            ucTab1.VisibleChanged += new EventHandler(ucTab1_VisibleChanged);
            Common.gMsgChanged += new EventHandler(AddGAIAMsg);

            ucTab1.Visible = false;
            ucTab1.SelectedTabPageIndex = 0;

            //msgCtrl.Visible = false;
            //menuCtrl.Visible = false;

            //FrameWork List
            List<PrjFrw> frmwrks = new PrjFrwRepo().GetAll();
            foreach (var frmWrk in frmwrks)
            {
                cmbForm.Properties.Items.Add(frmWrk);
            }

            //Tab 설정
            xtraTabbedMdiManager.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.BlueViolet;
            xtraTabbedMdiManager.AppearancePage.HeaderActive.BorderColor = System.Drawing.Color.Black;
            xtraTabbedMdiManager.AppearancePage.HeaderActive.Font = new System.Drawing.Font(xtraTabbedMdiManager.AppearancePage.HeaderActive.Font, System.Drawing.FontStyle.Bold);
            xtraTabbedMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
        }

        private void ucTab1_VisibleChanged(object sender, EventArgs e)
        {
            simpleButton1.Text = ucTab1.Visible ? "Hide" : "Show";
        }

        private void xtraTabbedMdiManager_SelectedPageChanged(object sender, EventArgs e)
        {
            //마지막 Tab 삭제될때 이벤트가 삭제보다 먼저 수행되어 에러 발생
            //xtraTabbedMdiManager.Pages.Count 사용 못하여 예외처리함
            try
            {
                if (xtraTabbedMdiManager.Pages.Count > 1)
                {
                    Common.gMsg = $"{xtraTabbedMdiManager.SelectedPage.MdiChild.Text} ({xtraTabbedMdiManager.SelectedPage.MdiChild.Name})";
                }
                //this.barStaticItemForm.Caption = xtraTabbedMdiManager.SelectedPage.MdiChild.Text + "(" + xtraTabbedMdiManager.SelectedPage.MdiChild.Name + ")";
            }
            catch (Exception)
            {
                Common.gMsg = $"Error";
                //this.barStaticItemForm.Caption = "";
            }
        }

        dynamic dynamicForm;
        private void cmbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox cmbForm = sender as ComboBox;
            PrjFrw frmWrk = cmbForm.SelectedItem as PrjFrw;
            Common.SetValue("gFrameWorkId", frmWrk.FrwId.ToString());

            menuCtrl.Items.Clear();
            menuCtrl.Visible = true;
            //From List by FrmaeWork
            List<FrwFrm> frms = new FrwFrmRepo().GetByOwnFrw(Common.GetValue("gRegId").ToInt(), Common.GetValue("gFrameWorkId"));
            foreach (var frm in frms)
            {
                menuCtrl.Items.Add(new IdObject { Txt = frm.FrmNm, Obj = frm });
            }
            menuCtrl.DisplayMember = "Txt";
            menuCtrl.ValueMember = "Obj";
        }

        private void menuCtrl_DoubleClick(object sender, EventArgs e)
        {
            Common.gMsg = e.ToString();
            var mdi = (from c in MdiChildren
                       where c.Name.Contains(e.ToString())
                       select c).SingleOrDefault();

            if (mdi != null)
            {
                mdi.Activate();
            }
            else
            {
                if (menuCtrl.SelectedItem is IdObject selectedItem)
                {
                    FrwFrm frm = selectedItem.Obj as FrwFrm;
                    if (frm != null)
                    {
                        OpenFrm(frm);
                    }
                }

            }

            //if (HasChildren)
            //{
            //    foreach (Form frm in this.MdiChildren)
            //    {
            //        frm.Dispose();
            //    }
            //}

            //dynamicForm = null;

            //switch (cmbForm.SelectedItem.ToString())
            //{
            //    case "Grid Basic": dynamicForm = new Frm.UCForm01(); break;
            //    case "VB Form": dynamicForm = new UCVBForm(); break;
            //    case "TextBoxTEST": dynamicForm = new Frms.TestFromTextBox(); break;
            //    case "GAIA-DevTool": dynamicForm = new Frms.TestFromTextBox(); break;
            //    case "DLL Load":
            //        dynamicForm = new Frms.DLLLoad();
            //        break;
            //    default: break;
            //}

            //OpenForm(dynamicForm);
        }

        private void OpenFrm(FrwFrm frm)
        {
            //Form은 두가지 개념으로 분리

            //1. 개발자가 개발하고 있는 폼 (DevFrm)
            //   개발자가 등록한 폼을 실행

            //2. 메뉴에 등록되어 있는 폼 (Frm)
            //   Frm Version Check 후 다운로드 받아서 실행

            string frmFullPath = $"{frm.FilePath}\\{frm.FileNm}"; //@"C:\path\to\your\file.txt";

            if (File.Exists(frmFullPath))
            {
                Assembly assmbly = AppDomain.CurrentDomain.Load(File.ReadAllBytes(frmFullPath));

                string tyStr = $"{frm.NmSpace}";
                var ty = assmbly.GetType(tyStr);

                UserControl ucform = (UserControl)Activator.CreateInstance(ty);

                Form fb = new Form();
                fb.Controls.Add(ucform);
                ucform.Dock = System.Windows.Forms.DockStyle.Fill;
                fb.Name = frm.FrmId;
                fb.Text = frm.FrmNm;
                fb.MdiParent = this;

                fb.Show();
            }
            else
            {
                MessageBox.Show($"Form File not found.{frmFullPath}");
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ucTab1.Visible = !(ucTab1.Visible);
            //menuCtrl.Visible = !(menuCtrl.Visible);
        }
        //private void menuCtrl_VisibleChanged(object sender, EventArgs e)
        //{
        //    //simpleButton1.Text = menuCtrl.Visible ? "Hide Menu": "Show Menu";
        //    simpleButton1.Text = ucTab1.Visible ? "Hide" : "Show";
        //}
        //private void msgCtrl_VisibleChanged(object sender, EventArgs e)
        //{
        //    barButtonShowMsg.Caption = msgCtrl.Visible ? "Hide Message": "Show Message";
        //}
        //private void barButtonShowMsg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    msgCtrl.Visible = !(msgCtrl.Visible);
        //}
        private void AddGAIAMsg(object sender, EventArgs e)
        {
            if (Common.gTrackMsg)
            {
                msgCtrl.Text += sender.ToString() + Environment.NewLine;
            }
        }

        private void ucPanel1_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Common.gTrackMsg = true;
            (e.Button as GroupBoxButton).Caption = "Stop tracking";
        }

        private void ucPanel1_CustomButtonUnchecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Common.gTrackMsg = false;
            (e.Button as GroupBoxButton).Caption = "Tracking";
        }
        private void ucPanel1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption.Trim())
            {
                case "Clear":
                    msgCtrl.Text = string.Empty;
                    break;
                case "Copy":
                    Clipboard.SetText(msgCtrl.Text);
                    break;
                default:
                    break;
            }
        }

        public delegate void MyEventHandler(string frm, string action);
        public static event MyEventHandler BarButtonActive;

        public static void OnBarButtonActive(string frm, string action)
        {
            BarButtonActive?.Invoke(frm, action);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string selectedFormName = xtraTabbedMdiManager.SelectedPage.MdiChild.Name;
            string action = e.Item.Caption;
            OnBarButtonActive(selectedFormName, action);
        }


        private void barSubItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Common.gMsg = "SubItem1 Clicked";
        }

        private void barBtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barBtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barBtnTemplate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FormPackaging fb = new FormPackaging();
            FormPackaging fb = new FormPackaging(Common.GetValue("gOpenFrm"));
            ////Form Mapping 작업중인 폼을 템플릿 폼에 올려서 열기
            ////로그를 활성화하여 모든 로그를 본다. 
            //Panel pn = fb.Controls.Find("Contents", true).FirstOrDefault() as Panel;
            //pn.Controls.Add(dynamicForm);
            //dynamicForm.Dock = System.Windows.Forms.DockStyle.Fill;
            fb.Text = Common.GetValue("gOpenFrm");
            fb.Name = Common.GetValue("gOpenFrm");
            fb.Show();
        }
    }
}
