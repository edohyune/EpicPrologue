using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class WrkRef : MdlBase
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

        private string _RefWrkId;
        public string RefWrkId
        {
            get => _RefWrkId;
            set => Set(ref _RefWrkId, value);
        }

        private string _RefFldNm;
        public string RefFldNm
        {
            get => _RefFldNm;
            set => Set(ref _RefFldNm, value);
        }

        private string _RefDefalueValue;
        public string RefDefalueValue
        {
            get => _RefDefalueValue;
            set => Set(ref _RefDefalueValue, value);
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
    public interface IWrkRefRepo
    {
        List<WrkRef> RefDataFlds(string frwId, string frmId, string wrkId);
        void Add(WrkRef wrkRef);
        void Update(WrkRef wrkRef);
        void Delete(WrkRef wrkRef);
    }
    public class WrkRefRepo : IWrkRefRepo
    {
        public List<WrkRef> RefDataFlds(string frwId, string frmId, string wrkId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.FldNm, a.RefWrkId,
       a.RefFldNm, a.RefDefalueValue, a.SqlId, a.Id, a.PId,
       a.CId, a.CDt, a.MId, a.MDt
  from WRKREF a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.WrkId = @WrkId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<WrkRef>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = wrkId }).ToList();

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
        public List<IdNm> RefFlds(object param)
        {
            string sql = @"
select Id = a.RefFldNm, 
       Nm = a.RefDefalueValue
  from WRKREF a
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

        public void Add(WrkRef wrkRef)
        {
            string sql = @"
insert into WRKREF
      (FrwId, FrmId, WrkId, FldNm, RefWrkId,
       RefFldNm, RefDefalueValue, SqlId, PId,
       CId, CDt, MId, MDt)
select @FrwId, @FrmId, @WrkId, @FldNm, @RefWrkId,
       @RefFldNm, @RefDefalueValue, @SqlId, @PId,
       @CId, getdate(), @MId, getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkRef);
            }
        }

        public void Update(WrkRef wrkRef)
        {
            string sql = @"
update a
   set FldNm= @FldNm,
       RefWrkId= @RefWrkId,
       RefFldNm= @RefFldNm,
       RefDefalueValue= @RefDefalueValue,
       SqlId= @SqlId,
       PId= @PId,
       MId= @MId,
       MDt= getdate()
  from WRKREF a
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkRef);
            }
        }

        public void Delete(WrkRef wrkRef)
        {
            string sql = @"
delete
  from WRKREF
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkRef);
            }
        }
    }
}
