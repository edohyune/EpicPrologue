using Lib;
using System.Collections.Generic;
using System.Linq;

namespace Repo
{
    public class FrmWrk : MdlBase
    {
        string _FrwId;
        public string FrwId
        {
            get => _FrwId;
            set => Set(ref _FrwId, value);
        }
        string _FrwNm;
        public string FrwNm
        {
            get => _FrwNm;
            set => Set(ref _FrwNm, value);
        }
        string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }
        string _Ver;
        public string Ver
        {
            get => _Ver;
            set => Set(ref _Ver, value);
        }
        string _PId;
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
    public interface IFrmWrkRepo
    {
        FrmWrk GetById(string id);
        List<FrmWrk> GetAll();
        void Add(FrmWrk frmWrk);
        void Update(FrmWrk frmWrk);
        void Delete(string id);
    }
    public class FrmWrkRepo : IFrmWrkRepo
    {
        public void Add(FrmWrk frmWrk)
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

        public List<FrmWrk> GetAll()
        {
            string sql = @"
select a.FrwId, a.FrwNm, a.Memo, a.Ver, a.PId
  from FRWMST a
";
            using (var db = new GaiaHelper())
            {
                return db.Query<FrmWrk>(sql).ToList();
            }
        }

        public FrmWrk GetById(string id)
        {
            string sql = @"
select a.FrwId, a.FrwNm, a.Memo, a.Ver, a.PId
  from FRWMST a
 where 1=1
   and a.FrwId = @FrwId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmWrk>(sql, new { FrwId = id }).FirstOrDefault();
                return result;
            }
        }

        public void Update(FrmWrk frmWrk)
        {
            string sql = @"
update a
   set FrwId= @FrwId,
       FrwNm= @FrwNm,
       Memo= @Memo,
       Ver= @Ver,
       PId= @PId,
       MId= @MId,
       Mdt= getdate()
  from FRWMST a
 where 1=1
   and FrwId = @FrwId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frmWrk);
            }

        }
    }
}
