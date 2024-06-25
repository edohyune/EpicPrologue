using Lib.Repo;
using Lib;
using DevExpress.XtraGrid.Views.Base;
using System.ComponentModel;

namespace Frms
{
    public partial class FRWCDE : UserControl
    {
        public FRWCDE()
        {
            InitializeComponent();
        }
        private void grdCde_UCFocusedRowChanged(object sender, int preIndex, int rowIndex, FocusedRowChangedEventArgs e)
        {
            grdRef.Open<CdeRef>();
            grdDtl.Open<FrwCde>();
        }

        private void pnlCode_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Save")
            {
                grdCde.Save<FrwCde>();
            }
            else if (e.Button.Properties.Caption == "New")
            {
                grdCde.AddNewDoc();
            }
            else if (e.Button.Properties.Caption == "Open")
            {
                grdCde.Open<FrwCde>();
            }
        }
        private void pnlReference_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            grdRef.Save<CdeRef>();
        }
        private void pnlCodeDetail_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Save")
            {
                grdDtl.Save<FrwCde>();
            }
            else if (e.Button.Properties.Caption == "New")
            {
                grdDtl.AddNewDoc();
            }
            else if (e.Button.Properties.Caption == "Open")
            {
                grdDtl.Open<FrwCde>();
            }
        }
    }
}
