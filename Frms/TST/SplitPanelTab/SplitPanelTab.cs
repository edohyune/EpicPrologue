namespace SplitPanelTab
{
    public partial class SplitPanelTab : UserControl
    {
        public SplitPanelTab()
        {
            InitializeComponent();
        }

        private void ucPanel2_DoubleClick(object sender, EventArgs e)
        {
            ucTab1.SelectedTabPageIndex = 1;
        }

        private void ucPanel1_DoubleClick(object sender, EventArgs e)
        {
            ucTab1.SelectedTabPageIndex = 2;
        }

        private void ucPanel3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Tab1":
                    ucTab1.SelectedTabPageIndex = 0;
                    break;
                case "Tab2":
                    ucTab1.SelectedTabPageIndex = 1;
                    break;
                case "Tab3":
                    ucTab1.SelectedTabPageIndex = 2;
                    break;
                default:
                    break;
            }
        }
    }
}
