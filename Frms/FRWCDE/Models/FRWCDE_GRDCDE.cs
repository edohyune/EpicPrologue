using EpicV003.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frms
{
    public class FRWCDE_GRDCDE : MdlBase
    {
        private string _FrwId;
        public string FrwId
        {
            get => _FrwId;
            set => Set(ref _FrwId, value);
        }

        private string _Cd;
        public string Cd
        {
            get => _Cd;
            set => Set(ref _Cd, value);
        }

        private string _PCd;
        public string PCd
        {
            get => _PCd;
            set => Set(ref _PCd, value);
        }

        private string _SubCd;
        public string SubCd
        {
            get => _SubCd;
            set => Set(ref _SubCd, value);
        }

        private string _Nm;
        public string Nm
        {
            get => _Nm;
            set => Set(ref _Nm, value);
        }

        private bool _UseYn;
        public bool UseYn
        {
            get => _UseYn;
            set => Set(ref _UseYn, value);
        }
        public override string ToString()
        {
            return Nm;
        }
    }
}
