using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ER000.Lib.Repo
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
        List<FrmWrk> GetByWorkSetsOpenOrderby(string frwId, string frmId);
        List<FrmWrk> GetByWorkSetsSaveOrderby(string frwId, string frmId);
        List<FrmWrk> GetByFieldSets(string frwId, string frmId);
        List<FrmWrk> GetByDataSets(string frwId, string frmId);
        List<FrmWrk> GetByGridSets(string frwId, string frmId);
        FrmWrk GetByWorkSet(string frwId, string frmId, string ctrlNm);
        void Add(FrmWrk frmWrk);
        void Update(FrmWrk frmWrk);
        void Delete(string wrkId);
    }
    public class FrmWrkRepo : IFrmWrkRepo
    {
        public List<FrmWrk> GetByWorkSetsOpenOrderby(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.UseYn, a.SaveSq, a.OpenSq, a.OpenTrg,
       a.Memo, a.CId, a.CDt, a.MId, a.MDt
  from FRMWRK a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
 order by a.OpenSq 
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<FrmWrk>(sql, new { FrwId = frwId, FrmId = frmId }).ToList();

                if (result == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in result)
                    {
                        item.ChangedFlag = ModelState.None;
                    }
                    return result;
                }
            }
        }
        public List<FrmWrk> GetByWorkSetsSaveOrderby(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.UseYn, a.SaveSq, a.OpenSq, a.OpenTrg,
       a.Memo, a.CId, a.CDt, a.MId, a.MDt
  from FRMWRK a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
 order by a.SaveSq 
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<FrmWrk>(sql, new { FrwId = frwId, FrmId = frmId }).ToList();

                if (result == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in result)
                    {
                        item.ChangedFlag = ModelState.None;
                    }
                    return result;
                }
            }
        }

        public List<FrmWrk> GetByFieldSets(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.UseYn, a.SaveSq, a.OpenSq, a.OpenTrg,
       a.Memo, a.CId, a.CDt, a.MId, a.MDt
  from FRMWRK a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.WrkCd = 'FieldSet'
 order by a.OpenSq 
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<FrmWrk>(sql, new { FrwId = frwId, FrmId = frmId }).ToList();

                if (result == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in result)
                    {
                        item.ChangedFlag = ModelState.None;
                    }
                    return result;
                }
            }
        }

        public List<FrmWrk> GetByDataSets(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.UseYn, a.SaveSq, a.OpenSq, a.OpenTrg,
       a.Memo, a.CId, a.CDt, a.MId, a.MDt
  from FRMWRK a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.WrkCd = 'DataSet'
 order by a.OpenSq 
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<FrmWrk>(sql, new { FrwId = frwId, FrmId = frmId }).ToList();

                if (result == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in result)
                    {
                        item.ChangedFlag = ModelState.None;
                    }
                    return result;
                }
            }
        }

        public List<FrmWrk> GetByGridSets(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.UseYn, a.SaveSq, a.OpenSq, a.OpenTrg,
       a.Memo, a.CId, a.CDt, a.MId, a.MDt
  from FRMWRK a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.WrkCd = 'GridSet'
 order by a.OpenSq 
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<FrmWrk>(sql, new { FrwId = frwId, FrmId = frmId }).ToList();

                if (result == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in result)
                    {
                        item.ChangedFlag = ModelState.None;
                    }
                    return result;
                }
            }
        }

        public FrmWrk GetByWorkSet(string frwId, string frmId, string wrkId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.UseYn, a.SaveSq, a.OpenSq, a.OpenTrg,
       a.Memo, a.CId, a.CDt, a.MId, a.MDt
  from FRMWRK a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.WrkId = @WrkId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmWrk>(sql, new {FrwId = frwId, FrmId = frmId, WrkId = wrkId }).FirstOrDefault();
                return result;
            }
        }

        public void Update(FrmWrk frmWrk)
        {
            string sql = @"
update a
   set CtrlNm= @CtrlNm,
       WrkNm= @WrkNm,
       WrkCd= @WrkCd,
       UseYn= @UseYn,
       SaveSq= @SaveSq,
       OpenSq= @OpenSq,
       OpenTrg= @OpenTrg,
       Memo= @Memo,
       MId= " + Common.GetValue("gRegId") + @",
       MDt= getdate()
  from FRMWRK a
 where 1=1
   and FrmId = @FrmId
   and FrwId = @FrwId
   and WrkId = @WrkId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frmWrk);
            }
        }
        public void Add(FrmWrk frmWrk)
        {
            string sql = @"
insert into FRMWRK
      (FrwId, FrmId, WrkId, CtrlNm, WrkNm,
       WrkCd, UseYn, SaveSq, OpenSq, OpenTrg,
       Memo, CId, CDt, MId, MDt)
select @FrwId, @FrmId, @WrkId, @CtrlNm, @WrkNm,
       @WrkCd, @UseYn, @SaveSq, @OpenSq, @OpenTrg,
       @Memo, 
       " + Common.GetValue("gRegId") + @", getdate(), " + Common.GetValue("gRegId") + @", getdate()
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
   and FrmId = @FrmId
   and FrwId = @FrwId
   and WrkId = @WrkId
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, new { WrkId = wrkId });
            }
        }
    }
}
