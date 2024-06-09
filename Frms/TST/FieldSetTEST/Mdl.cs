using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frms.Models.FieldSetTEST
{
    public class GRDWRKSQL : Lib.MdlBase
    {
        private string _FrwId;
        public string FrwId
        {
            get => _FrwId;
            set => Set(ref _FrwId, value);
        }

        private string _FrmId;
        public string FrmId
        {
            get => _FrmId;
            set => Set(ref _FrmId, value);
        }

        private string _WrkId;
        public string WrkId
        {
            get => _WrkId;
            set => Set(ref _WrkId, value);
        }

        private string _CRUDM;
        public string CRUDM
        {
            get => _CRUDM;
            set => Set(ref _CRUDM, value);
        }

        private string _Query;
        public string Query
        {
            get => _Query;
            set => Set(ref _Query, value);
        }

        private string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }

        private long _Id;
        public long Id
        {
            get => _Id;
            set => Set(ref _Id, value);
        }

        private long _PId;
        public long PId
        {
            get => _PId;
            set => Set(ref _PId, value);
        }

    }
}
