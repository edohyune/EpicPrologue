using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frms.Models.FieldSetTEST;

namespace Frms.TST
{
    public partial class FieldSetTEST : GAIA.FrmBase
    {
        public FieldSetTEST()
        {
            InitializeComponent();
        }

        private void ucPanel3_UCCustomButtonClick(object Sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            grdWrkSql.Open();
        }
    }
}
