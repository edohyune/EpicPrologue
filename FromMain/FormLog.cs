using DevExpress.XtraEditors.ButtonsPanelControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpicV003.Lib;
using DevExpress.XtraScheduler.Drawing;
using System.ServiceModel.Channels;
namespace GAIA
{
    public partial class FormLog : Form
    {
        public FormLog()
        {
            InitializeComponent();
            Common.gTrackLog = true;
        }

        private void pnlLog_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Common.gTrackLog = true;
            (e.Button as GroupBoxButton).Caption = "Stop Log tracking";
        }

        private void pnlLog_CustomButtonUnchecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            Common.gTrackLog = false;
            (e.Button as GroupBoxButton).Caption = "Log Tracking";
        }
        public void AddLog(string log)
        {
            if (Common.gTrackLog)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.logCtrl.AppendText(DateTime.Now.ToLongTimeString() + Environment.NewLine);
                        this.logCtrl.AppendText(log + Environment.NewLine);
                    });
                }
                else
                {
                    return;
                    // Handle the case where the control's handle is not created yet
                    // Maybe queue the log or handle differently
                }
            }
        }

        private void pnlLog_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption.Trim())
            {
                case "Clear":
                    logCtrl.Text = string.Empty;
                    break;
                case "Copy":
                    Clipboard.SetText(logCtrl.Text);
                    break;
                default:
                    break;
            }
        }
    }
}
