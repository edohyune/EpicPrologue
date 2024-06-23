using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class MdlNmSpace
    {
        public string FrmId { get; set; }
        public string NmSpace { get; set; }

        public void DisplayInfo()
        {
            Common.gMsg = $"FrmId: {FrmId}, NmSpace: {NmSpace}";
        }
    }
    public class MdlNmSpaceRepo
    {
        private List<MdlNmSpace> models;

        public MdlNmSpaceRepo(string frwId)
        {
            // 예제 데이터를 초기화합니다.
            models = new List<MdlNmSpace>();
            models = new FrwFrmRepo().GetMdlNmSpace(frwId);
        }

        public MdlNmSpace FindModel(string frmId, string nmSpace)
        {
            // FrmId와 NmSpace를 기반으로 모델을 찾습니다.
            return models.FirstOrDefault(m => m.FrmId == frmId && m.NmSpace.Contains(nmSpace));
        }

        public List<MdlNmSpace> GetAllModels()
        {
            return models;
        }
    }
}
