
using Dapper;

namespace Frms.TST
{
    public partial class OpenTrigger : GAIA.FrmBase
    {
        public OpenTrigger()
        {
            InitializeComponent();

            DynamicParameters p = new DynamicParameters();
            p.Add("@VAR1", "TEST1");
            p.Add("@VAR2", "TEST2");
            p.Add("@VAR3", "TEST3");
            OpenWorkSet("WorkSetName", p);
        }
    }
}
