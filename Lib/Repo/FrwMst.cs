using Lib;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Repo
{
    public class FrwMst : MdlBase
    {
        private string _FrwId;
        public string FrwId
        {
            get => _FrwId;
            set => Set(ref _FrwId, value);
        }

        private string _FrwNm;
        public string FrwNm
        {
            get => _FrwNm;
            set => Set(ref _FrwNm, value);
        }

        private string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }

        private string _Ver;
        public string Ver
        {
            get => _Ver;
            set => Set(ref _Ver, value);
        }

        private string _PId;
        public string PId
        {
            get => _PId;
            set => Set(ref _PId, value);
        }

        public override string ToString()
        {
            return FrwNm;
        }
    }
    public interface IFrwMstRepo
    {
        FrwMst GetById(string id);
        List<FrwMst> GetAll();
        void Add(FrwMst frmWrk);
        void Update(FrwMst frmWrk);
        void Delete(string id);
    }
    public class FrwMstRepo : IFrwMstRepo
    {
        public void Add(FrwMst frmWrk)
        {
            string sql = @"
insert into FRWMST
      (FrwId, FrwNm, Memo, Ver, PId,
       CId, CDt, MId, Mdt)
select @FrwId, @FrwNm, @Memo, @Ver, @PId,
       @CId, getdate(), @MId, getdate()
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frmWrk);
            }
        }

        public void Delete(string id)
        {
            string sql = @"
delete
  from FRWMST
 where 1=1
   and FrwId = @FrwId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { FrwId = id });
            }
        }

        public List<FrwMst> GetAll()
        {
            string sql = @"
select a.FrwId, a.FrwNm, a.Memo, a.Ver, a.PId,
       a.CId, a.CDt, a.MId, a.Mdt
  from FRWMST a
";
            using (var db = new GaiaHelper())
            {
                return db.Query<FrwMst>(sql).ToList();
            }
        }

        public FrwMst GetById(string id)
        {
            string sql = @"
select a.FrwId, a.FrwNm, a.Memo, a.Ver, a.PId,
       a.CId, a.CDt, a.MId, a.Mdt
  from FRWMST a
 where 1=1
   and a.FrwId = @FrwId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrwMst>(sql, new { FrwId = id }).FirstOrDefault();
                return result;
            }
        }

        public void Update(FrwMst frmWrk)
        {
            string sql = @"
update a
   set FrwNm= @FrwNm,
       Memo= @Memo,
       Ver= @Ver,
       PId= @PId,
       MId= @MId,
       Mdt= getdate()
  from FRWMST a
 where 1=1
   and FrwId = @FrwId_old
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frmWrk);
            }

        }
    }
}
