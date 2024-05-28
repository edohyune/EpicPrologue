using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class FrmWrk : MdlBase
    { 
        private string _WrkId;
        public string WrkId
        {
            get => _WrkId;
            set => Set(ref _WrkId, value);
        }

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

        private string _CtrlNm;
        public string CtrlNm
        {
            get => _CtrlNm;
            set => Set(ref _CtrlNm, value);
        }

        private string _WrkNm;
        public string WrkNm
        {
            get => _WrkNm;
            set => Set(ref _WrkNm, value);
        }

        private string _WrkCd;
        public string WrkCd
        {
            get => _WrkCd;
            set => Set(ref _WrkCd, value);
        }

        private bool _UseYn;
        public bool UseYn
        {
            get => _UseYn;
            set => Set(ref _UseYn, value);
        }

        private string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }
    }
    public interface IFrmWrkRepo
    {
        FrmWrk GetByWrk(string frwId, string frmId, string ctrlNm);
        List<FrmWrk> GetByFrwFrm(string frwId, string frmId);
        void Add(FrmWrk frmWrk);
        void Update(FrmWrk frmWrk);
        void Delete(string wrkId);
    }
    public class FrmWrkRepo : IFrmWrkRepo
    {
        public void Add(FrmWrk frmWrk)
        {
            string sql = @"
insert into FRMWRK
      (WrkId, FrwId, FrmId, CtrlNm, WrkNm,
       WrkCd, UseYn, Memo, 
       CId, CDt, MId, MDt)
select @CtrlNm, @FrwId, @FrmId, @CtrlNm, @WrkNm,
       @WrkCd, @UseYn, @Memo, 
       @CId, getdate(), @MId, getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, frmWrk);
            }
        }

        public void Delete(string wrkId)
        {
            string sql = @"
delete
  from FRMWRK
 where 1=1
   and WrkId = @WrkId
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, new { WrkId = wrkId});
            }
        }

        public List<FrmWrk> GetByFrwFrm(string frwId, string frmId)
        {
            string sql = @"
select a.WrkId, a.FrwId, a.FrmId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.UseYn, a.Memo, a.CId, a.CDt,
       a.MId, a.MDt
  from FRMWRK a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<FrmWrk>(sql, new { FrwId = frwId, FrmId = frmId }).ToList();

                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {frwId},{frmId} was not found.");
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

        public FrmWrk GetByWrk(string frwId, string frmId, string ctrlNm)
        {
            string sql = @"
select a.WrkId, a.FrwId, a.FrmId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.UseYn, a.Memo, a.CId, a.CDt,
       a.MId, a.MDt
  from FRMWRK a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.CtrlNm = @CtrlNm
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmWrk>(sql, new {FrwId = frwId, FrmId = frmId, CtrlNm = ctrlNm }).FirstOrDefault();
                return result;
            }
        }

        public void Update(FrmWrk frmWrk)
        {
            string sql = @"
update a
   set WrkId= @WrkId,
       FrwId= @FrwId,
       FrmId= @FrmId,
       CtrlNm= @CtrlNm,
       WrkNm= @WrkNm,
       WrkCd= @WrkCd,
       UseYn= @UseYn,
       Memo= @Memo,
       MId= @MId,
       MDt= getdate()
  from FRMWRK a
 where 1=1
   and frwId = @FrwId
   and WrkId = @WrkId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frmWrk);
            }
        }
    }

}
