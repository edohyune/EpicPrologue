using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ER000.Lib;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace ER000
{
    public partial class FormPackaging : DevExpress.XtraEditors.XtraForm
    {
        public FormPackaging()
        {
            InitializeComponent();
            //groupControl1의 capture라는 CheckButton의 값은 gTrackLog의 값으로 초기화한다. 
            groupControl1.CustomHeaderButtons[2].Properties.Checked = Common.gTrackLog;
        }
        public string openFrm { get; set; }
        dynamic dyForm;
        public FormPackaging(string frm)
        {
            InitializeComponent();
            //groupControl1의 capture라는 CheckButton의 값은 gTrackLog의 값으로 초기화한다. 
            groupControl1.CustomHeaderButtons[2].Properties.Checked = Common.gTrackLog;

            openFrm = frm;

            //string frmPath = $"{Common.gDirRoot}{Common.gDirWork}\\{frm}.dll";
            string frmPath = $"F:\\20_EpicFrameWork\\Controller\\TestFromTextBox\\bin\\Debug\\net8.0-windows\\TestFromTextBox.dll";

            if (FileSystem.FileExists(frmPath))
            {
                Assembly assmbly = AppDomain.CurrentDomain.Load(File.ReadAllBytes(frmPath));
                //string tyStr = $"{Common.gSolution}.Frms.{frm}";
                string tyStr = $"Frms.TestFromTextBox";
                var ty = assmbly.GetType(tyStr);
                UserControl ucform = (UserControl)Activator.CreateInstance(ty);
                Contents.Controls.Add(ucform);
                ucform.Dock = System.Windows.Forms.DockStyle.Fill;
                dyForm = ucform;
            }
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            //Capture 라는 CheckButton을 누르면 Capture + Checked값을 출력되도록 수정하세요.
            if (e.Button.Properties.Caption == "Clear")
            {
                memoLog.Text = string.Empty;
            }
            else if (e.Button.Properties.Caption == "Copy")
            {
                if (!string.IsNullOrWhiteSpace(memoLog.Text))
                {
                    Clipboard.SetText(memoLog.Text);
                }
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Common.gLog = "1234";
        }

        private void groupControl1_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Log Capture")
            {
                if (e.Button.Properties.Checked)
                {
                    Common.gTrackLog = true;
                }
                else
                {
                    Common.gTrackLog = false;
                }
            }
        }

        private void barCheckItem1_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void FormPackaging_Load(object sender, EventArgs e)
        {

            Common.gLogChanged += new EventHandler(ShowLog);
        }

        private void ShowLog(object sender, EventArgs e)
        {
            if (Common.gTrackLog)
            {
                memoLog.Text += sender.ToString() + Environment.NewLine;
            }
        }
    }
}