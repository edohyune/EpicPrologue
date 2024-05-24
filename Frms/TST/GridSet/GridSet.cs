using DevExpress.Mvvm.POCO;
using DevExpress.XtraBars.Docking2010;
using Lib.Repo;
namespace Frms.TST
{
    public partial class GridSet : UserControl
    {
        public GridSet()
        {
            InitializeComponent();
        }

        private void GridSet_Load(object sender, EventArgs e)
        {

        }

        private void ucPanel1_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            g10.Open<Person>();
        }

        private void ucPanel2_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ucPanel3_CustomButtonClick(object sender, BaseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
