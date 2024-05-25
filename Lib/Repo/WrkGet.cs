using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class WrkGet : MdlBase
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
    public interface IWrkGetRepo
    {
        List<WrkGet> GetPullFlds(string frwId, string frmId, string wrkId);
        void Add(WrkGet wrkGet);
        void Update(WrkGet wrkGet);
        void Delete(WrkGet wrkGet);
    }
    public class WrkGetRepo : IWrkGetRepo
    {
        public List<WrkGet> GetPullFlds(string frwId, string frmId, string wrkId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.FldNm, a.GetWrkId,
       a.GetFldNm, a.GetDefalueValue, a.SqlId, a.Id, a.PId,
       a.CId, a.CDt, a.MId, a.MDt
  from WRKGET a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.WrkId = @WrkId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<WrkGet>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = wrkId }).ToList();

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
        public List<IdNm> GetPullFlds(object param)
        {
            string sql = @"
select Id = a.GetFldNm, 
       Nm = a.GetDefalueValue
  from WRKGET a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.WrkId = @WrkId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<IdNm>(sql, param).ToList();
                return result;
            }
        }

        public void Add(WrkGet wrkGet)
        {
            string sql = @"
insert into WRKGET
      (FrwId, FrmId, WrkId, FldNm, GetWrkId,
       GetFldNm, GetDefalueValue, SqlId, Id, PId,
       CId, CDt, MId, MDt)
select @FrwId, @FrmId, @WrkId, @FldNm, @GetWrkId,
       @GetFldNm, @GetDefalueValue, @SqlId, @Id, @PId,
       @CId, getdate(), @MId, getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkGet);
            }
        }

        public void Update(WrkGet wrkGet)
        {
            string sql = @"
update a
   set FldNm= @FldNm,
       GetWrkId= @GetWrkId,
       GetFldNm= @GetFldNm,
       GetDefalueValue= @GetDefalueValue,
       SqlId= @SqlId,
       Id= @Id,
       PId= @PId,
       CId= @CId,
       CDt= @CDt,
       MId= @MId,
       MDt= @MDt
  from WRKGET a
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkGet);
            }
        }

        public void Delete(WrkGet wrkGet)
        {
            string sql = @"
delete
  from WRKGET
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkGet);
            }
        }
    }
}
