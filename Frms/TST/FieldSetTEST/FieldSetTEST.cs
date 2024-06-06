namespace Frms.TST
{
    public partial class FieldSetTEST : UserControl
    {
        public FieldSetTEST()
        {
            InitializeComponent();
            ucField.frwId = Lib.Common.gFrameWorkId;
            ucField.frmId = this.Name;
            ucField.thisNm = "ucField";
        }
    }
}
