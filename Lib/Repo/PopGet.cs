using DevExpress.Pdf.Native.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class PopGet : MdlBase
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

        private string _PopId;
        public string PopId
        {
            get => _PopId;
            set => Set(ref _PopId, value);
        }

        private string _FldNm;
        public string FldNm
        {
            get => _FldNm;
            set => Set(ref _FldNm, value);
        }

        private string _GetWrkId;
        public string GetWrkId
        {
            get => _GetWrkId;
            set => Set(ref _GetWrkId, value);
        }

        private string _GetFldNm;
        public string GetFldNm
        {
            get => _GetFldNm;
            set => Set(ref _GetFldNm, value);
        }

        private string _GetDefalueValue;
        public string GetDefalueValue
        {
            get => _GetDefalueValue;
            set => Set(ref _GetDefalueValue, value);
        }

        private string _SqlId;
        public string SqlId
        {
            get => _SqlId;
            set => Set(ref _SqlId, value);
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
    public interface IPopGetRepo
    {
        List<PopGet> GetPullFlds(string frwId, string frmId, string popId);
        void Add(PopGet popGet);
        void Update(PopGet popGet);
        void Delete(PopGet popGet);
    }
    public class PopGetRepo : IPopGetRepo
    {
        public List<PopGet> GetPullFlds(string frwId, string frmId, string popId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.PopId, a.FldNm, a.GetWrkId,
       a.GetFldNm, a.GetDefalueValue, a.SqlId, a.Id, a.PId,
       a.CId, a.CDt, a.MId, a.MDt
  from POPGET a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.PopId = @PopId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<PopGet>(sql, new { FrwId = frwId, FrmId = frmId, PopId = popId }).ToList();

                if (result == null)
                {
                    return null;
                    //throw new KeyNotFoundException($"A record with the code {frwId},{frmId},{popId} was not found.");
                }
                else
                {
                    foreach (var item in result)
                    {
                        item.ChangedFlag = MdlState.None;
                    }
                    return result;
                }
            }
        }
        public void Add(PopGet popGet)
        {
            string sql = @"
insert into POPGET
      (FrwId, FrmId, PopId, FldNm, GetWrkId,
       GetFldNm, GetDefalueValue, SqlId, Id, PId,
       CId, CDt, MId, MDt)
select @FrwId, @FrmId, @PopId, @FldNm, @GetPopId,
       @GetFldNm, @GetDefalueValue, @SqlId, @Id, @PId,
       " + Common.gRegId + @", getdate(), " + Common.gRegId + @", getdate()
";

            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, popGet);
            }
        }
        public void Delete(PopGet popGet)
        {
            string sql = @"
update a
   set PopId= @PopId,
       FldNm= @FldNm,
       GetWrkId= @GetWrkId,
       GetFldNm= @GetFldNm,
       GetDefalueValue= @GetDefalueValue,
       SqlId= @SqlId,
       Id= @Id,
       PId= @PId,
       MId= " + Common.gRegId + @",
       MDt= getdate()
  from POPGET a
 where 1=1
   and Id = @Id
";

            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, popGet);
            }
        }
        public void Update(PopGet popGet)
        {
            string sql = @"
delete
  from POPGET
 where 1=1
   and Id = @Id
";

            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, popGet);
            }
        }
    }

}
