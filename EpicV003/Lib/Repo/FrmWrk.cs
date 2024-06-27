using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicV003.Lib.Repo
{
    public class FrmWrk : MdlBase
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

        private string _SelectMode;
        public string SelectMode
        {
            get => _SelectMode;
            set => Set(ref _SelectMode, value);
        }

        private bool _MultiSelect;
        public bool MultiSelect
        {
            get => _MultiSelect;
            set => Set(ref _MultiSelect, value);
        }

        private bool _UseYn;
        public bool UseYn
        {
            get => _UseYn;
            set => Set(ref _UseYn, value);
        }

        private bool _NavAdd;
        public bool NavAdd
        {
            get => _NavAdd;
            set => Set(ref _NavAdd, value);
        }

        private bool _NavDelete;
        public bool NavDelete
        {
            get => _NavDelete;
            set => Set(ref _NavDelete, value);
        }

        private bool _NavSave;
        public bool NavSave
        {
            get => _NavSave;
            set => Set(ref _NavSave, value);
        }

        private bool _NavCancel;
        public bool NavCancel
        {
            get => _NavCancel;
            set => Set(ref _NavCancel, value);
        }

        private int _SaveSq;
        public int SaveSq
        {
            get => _SaveSq;
            set => Set(ref _SaveSq, value);
        }

        private int _OpenSq;
        public int OpenSq
        {
            get => _OpenSq;
            set => Set(ref _OpenSq, value);
        }

        private string _OpenTrg;
        public string OpenTrg
        {
            get => _OpenTrg;
            set => Set(ref _OpenTrg, value);
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
        List<FrmWrk> GetByWorkSetsOrderby(string frwId, string frmId);
        List<FrmWrk> GetByWorkSetsSaveOrderby(string frwId, string frmId);
        List<FrmWrk> GetByWorkSets(string frwId, string frmId);
        List<FrmWrk> GetByDataSets(string frwId, string frmId);
        List<FrmWrk> GetByGridSets(string frwId, string frmId);
        FrmWrk GetByWorkSet(string frwId, string frmId, string ctrlNm);
        void Add(FrmWrk frmWrk);
        void Update(FrmWrk frmWrk);
        void Delete(string wrkId);
    }
    public class FrmWrkRepo : IFrmWrkRepo
    {
        public List<FrmWrk> GetByWorkSetsOrderby(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.SelectMode, a.MultiSelect, a.UseYn, a.NavAdd,
       a.NavDelete, a.NavSave, a.NavCancel, a.SaveSq, a.OpenSq,
       a.OpenTrg, a.StartYn, a.Memo, 
       a.CId, a.CDt, a.MId, a.MDt
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
                        item.ChangedFlag = MdlState.None;
                    }
                    return result;
                }
            }
        }
        public List<FrmWrk> GetByWorkSetsSaveOrderby(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.SelectMode, a.MultiSelect, a.UseYn, a.NavAdd,
       a.NavDelete, a.NavSave, a.NavCancel, a.SaveSq, a.OpenSq,
       a.OpenTrg, a.StartYn, a.Memo, 
       a.CId, a.CDt, a.MId, a.MDt
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
                        item.ChangedFlag = MdlState.None;
                    }
                    return result;
                }
            }
        }
        public List<FrmWrk> GetByOpenWrks(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.SelectMode, a.MultiSelect, a.UseYn, a.NavAdd,
       a.NavDelete, a.NavSave, a.NavCancel, a.SaveSq, a.OpenSq,
       a.OpenTrg, a.StartYn, a.Memo, 
       a.CId, a.CDt, a.MId, a.MDt
  from FRMWRK a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.StartYn = 1
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
                    return result;
                }
            }
        }

        public List<FrmWrk> GetByWorkSets(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.SelectMode, a.MultiSelect, a.UseYn, a.NavAdd,
       a.NavDelete, a.NavSave, a.NavCancel, a.SaveSq, a.OpenSq,
       a.OpenTrg, a.StartYn, a.Memo, 
       a.CId, a.CDt, a.MId, a.MDt
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
                    return result;
                }
            }
        }

        public List<FrmWrk> GetByDataSets(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.SelectMode, a.MultiSelect, a.UseYn, a.NavAdd,
       a.NavDelete, a.NavSave, a.NavCancel, a.SaveSq, a.OpenSq,
       a.OpenTrg, a.StartYn, a.Memo, 
       a.CId, a.CDt, a.MId, a.MDt
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
                        item.ChangedFlag = MdlState.None;
                    }
                    return result;
                }
            }
        }

        public List<FrmWrk> GetByGridSets(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.SelectMode, a.MultiSelect, a.UseYn, a.NavAdd,
       a.NavDelete, a.NavSave, a.NavCancel, a.SaveSq, a.OpenSq,
       a.OpenTrg, a.StartYn, a.Memo, 
       a.CId, a.CDt, a.MId, a.MDt
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
                        item.ChangedFlag = MdlState.None;
                    }
                    return result;
                }
            }
        }

        public FrmWrk GetByWorkSet(string frwId, string frmId, string wrkId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.WrkNm,
       a.WrkCd, a.SelectMode, a.MultiSelect, a.UseYn, a.NavAdd,
       a.NavDelete, a.NavSave, a.NavCancel, a.SaveSq, a.OpenSq,
       a.OpenTrg, a.StartYn, a.Memo, 
       a.CId, a.CDt, a.MId, a.MDt
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
   set FrwId= @FrwId,
       FrmId= @FrmId,
       WrkId= @WrkId,
       CtrlNm= @CtrlNm,
       WrkNm= @WrkNm,
       WrkCd= @WrkCd,
       SelectMode= @SelectMode,
       MultiSelect= @MultiSelect,
       UseYn= @UseYn,
       NavAdd= @NavAdd,
       NavDelete= @NavDelete,
       NavSave= @NavSave,
       NavCancel= @NavCancel,
       SaveSq= @SaveSq,
       OpenSq= @OpenSq,
       OpenTrg= @OpenTrg,
       StartYn= @StartYn,
       Memo= @Memo,
       MId= " + Common.GetValue("gRegId") + @",
       MDt= getdate()
  from FRMWRK a
 where 1=1
   and FrwId = @FrwId
   and FrmId = @FrmId
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
       WrkCd, SelectMode, MultiSelect, UseYn, NavAdd,
       NavDelete, NavSave, NavCancel, SaveSq, OpenSq,
       OpenTrg, StartYn, Memo, 
       CId, CDt, MId, MDt)
select @FrwId, @FrmId, @WrkId, @CtrlNm, @WrkNm,
       @WrkCd, @SelectMode, @MultiSelect, @UseYn, @NavAdd,
       @NavDelete, @NavSave, @NavCancel, @SaveSq, @OpenSq,
       @OpenTrg, @StartYn, @Memo, 
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
   and FrwId = @FrwId
   and FrmId = @FrmId
   and WrkId = @WrkId
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, new { WrkId = wrkId });
            }
        }
    }
}
