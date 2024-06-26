using EpicV003.Lib;
using System.Collections.Generic;
using System.Linq;

namespace EpicV003.Lib.Repo
{
    public class PrjFrw : MdlBase
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
    public interface IPrjFrwRepo
    {
        PrjFrw GetById(string id);
        List<PrjFrw> GetAll();
        void Add(PrjFrw frmWrk);
        void Update(PrjFrw frmWrk);
        void Delete(string id);
    }
    public class PrjFrwRepo : IPrjFrwRepo
    {
        public void Add(PrjFrw frmWrk)
        {
            string sql = @"
insert into PRJFRW
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
  from PRJFRW
 where 1=1
   and FrwId = @FrwId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { FrwId = id });
            }
        }

        public List<PrjFrw> GetAll()
        {
            string sql = @"
select a.FrwId, a.FrwNm, a.Memo, a.Ver, a.PId,
       a.CId, a.CDt, a.MId, a.Mdt
  from PRJFRW a
";
            using (var db = new GaiaHelper())
            {
                return db.Query<PrjFrw>(sql).ToList();
            }
        }

        public PrjFrw GetById(string id)
        {
            string sql = @"
select a.FrwId, a.FrwNm, a.Memo, a.Ver, a.PId,
       a.CId, a.CDt, a.MId, a.Mdt
  from PRJFRW a
 where 1=1
   and a.FrwId = @FrwId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<PrjFrw>(sql, new { FrwId = id }).FirstOrDefault();
                return result;
            }
        }

        public void Update(PrjFrw frmWrk)
        {
            string sql = @"
update a
   set FrwNm= @FrwNm,
       Memo= @Memo,
       Ver= @Ver,
       PId= @PId,
       MId= @MId,
       Mdt= getdate()
  from PRJFRW a
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
