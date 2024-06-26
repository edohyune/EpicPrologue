using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicV003.Lib.Repo
{
    public class PrjMst : MdlBase
    {
        private long _Id;
        public long Id
        {
            get => _Id;
            set => Set(ref _Id, value);
        }

        private string _Nm;
        public string Nm
        {
            get => _Nm;
            set => Set(ref _Nm, value);
        }

        private string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }

        private long _PId;
        public long PId
        {
            get => _PId;
            set => Set(ref _PId, value);
        }
    }
    public interface IPrjMstRepo
    {
        PrjMst GetByPrjId(long PrjId);
        List<PrjMst> GetAll();
        void Add(PrjMst prjMst);
        void Update(PrjMst prjMst);
        void Delete(PrjMst prjMst);
    }
    public class PrjMstRepo : IPrjMstRepo
    {
        public List<PrjMst> GetAll()
        {
            string sql = @"
select a.Id, a.Nm, a.Memo, a.PId, a.CId,
       a.CDt, a.MId, a.MDt
  from PRJMST a
 ";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<PrjMst>(sql).ToList();

                if (result == null)
                {
                    throw new KeyNotFoundException($"A record was not found.");
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

        public PrjMst GetByPrjId(long prjId)
        {
            string sql = @"
select a.Id, a.Nm, a.Memo, a.PId, a.CId,
       a.CDt, a.MId, a.MDt
  from PRJMST a
 where 1=1
   and a.Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<PrjMst>(sql, new { PrjId = prjId}).SingleOrDefault();

                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {prjId} was not found.");
                }
                else
                {
                    result.ChangedFlag = MdlState.None;
                    return result;
                }
            }
        }

        public void Add(PrjMst prjMst)
        {
            string sql = @"
insert into PRJMST
      (Id, Nm, Memo, PId, CId,
       CDt, MId, MDt)
select @Id, @Nm, @Memo, @PId,
       @CId, getdate(), @MId, getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, prjMst);
            }
        }

        public void Delete(PrjMst prjMst)
        {
            string sql = @"
delete
  from PRJMST
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, prjMst);
            }
        }

        public void Update(PrjMst prjMst)
        {
            string sql = @"
update a
   set Nm= @Nm,
       Memo= @Memo,
       PId= @PId,
       MId= @MId,
       MDt= getdate()
  from PRJMST a
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, prjMst);
            }
        }
    }
}
