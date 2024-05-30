using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class WrkSql : MdlBase
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
    public interface IWrkSqlRepo
    {
        //WrkSql GetSql(string frwId, string frmId, string wrkId, string crudm); GenFunc로 전환
        List<WrkSql> GetSqls(string frwId, string frmId, string wrkId);
        void Add(WrkSql wrkSql);
        void Save(WrkSql wrkSql);
        void Update(WrkSql wrkSql);
        void Delete(WrkSql wrkSql);
    }
    public class WrkSqlRepo : IWrkSqlRepo
    {
//        public WrkSql GetSql(string frwId, string frmId, string wrkId)
//        {
//            string sql = @"
//select a.FrwId, a.FrmId, a.WrkId, a.CRUDM, a.Query,
//       a.Memo, a.Id, a.PId, a.CId, a.CDt,
//       a.MId, a.MDt
//  from WRKSQL a
// where 1=1
//   and a.FrwId = @FrwId
//   and a.FrmId = @FrmId
//   and a.WrkId = @WrkId
//";
//            using (var db = new Lib.GaiaHelper())
//            {
//                var result = db.Query<WrkSql>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = wrkId }).FirstOrDefault();

//                if (result != null)
//                {
//                    result.ChangedFlag = MdlState.None;
//                    return result;
//                }
//            }
//        }

        public List<WrkSql> GetSqls(string frwId, string frmId, string wrkId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CRUDM, a.Query,
       a.Memo, a.Id, a.PId, a.CId, a.CDt,
       a.MId, a.MDt
  from WRKSQL a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.WrkId = @WrkId
   and a.CRUDM = @CRUDM
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<WrkSql>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = wrkId }).ToList();

                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {frwId},{frmId},{wrkId} was not found.");
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
        public void Add(WrkSql wrkSql)
        {
            string sql = @"
insert into WRKSQL
      (FrwId, FrmId, WrkId, CRUDM, Query,
       Memo, PId, CId, CDt,
       MId, MDt)
select @FrwId, @FrmId, @WrkId, @CRUDM, @Query,
       @Memo, @PId, 
       @CId, getdate(), @MId, getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkSql);
            }
        }
        public void Delete(WrkSql wrkSql)
        {
            string sql = @"
delete
  from WRKSQL
 where 1=1
   and FrmId = @FrmId
   and FrwId = @FrwId
   and WrkId = @WrkId
   and CRUDM = @CRUDM
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkSql);
            }
        }
        public void Update(WrkSql wrkSql)
        {
            string sql = @"
update a
   set Query= @Query,
       Memo= @Memo,
       PId= @PId,
       MId= @MId,
       MDt= getdate()
  from WRKSQL a
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkSql);
            }
        }

        public void Save(WrkSql wrkSql)
        {
            string sql = @"
if exists(select 1 from WRKSQL where FrwId=@FrwId and FrmId=@FrmId and WrkId=@WrkId and CRUDM=@CRUDM)
begin 
    update a
       set Query= @Query,
           Memo= @Memo,
           PId= @PId,
           MId= @MId,
           MDt= getdate()
      from WRKSQL a
     where 1=1
       and FrwId = @FrwId
       and FrmId = @FrmId
       and WrkId = @WrkId
       and CRUDM = @CRUDM
end else begin 
    insert into WRKSQL
          (FrwId, FrmId, WrkId, CRUDM, Query,
           Memo, PId, CId, CDt,
           MId, MDt)
    select @FrwId, @FrmId, @WrkId, @CRUDM, @Query,
           @Memo, @PId, 
           @CId, getdate(), @MId, getdate()
end 
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkSql);
            }
        }
    }

}
