using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class WrkSet : MdlBase
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

        private string _SetWrkId;
        public string SetWrkId
        {
            get => _SetWrkId;
            set => Set(ref _SetWrkId, value);
        }

        private string _SetFldNm;
        public string SetFldNm
        {
            get => _SetFldNm;
            set => Set(ref _SetFldNm, value);
        }

        private string _SetDefaultValue;
        public string SetDefaultValue
        {
            get => _SetDefaultValue;
            set => Set(ref _SetDefaultValue, value);
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

        private long _Pid;
        public long Pid
        {
            get => _Pid;
            set => Set(ref _Pid, value);
        }
        //------------------------------
        //FRMCTRL, WRKFLD
        //------------------------------
        private string _ToolNm;
        public string ToolNm
        {
            get => _ToolNm;
            set => Set(ref _ToolNm, value);
        }
    }
    public interface IWrkSetRepo
    {
        List<WrkSet> SetPushFlds(string frwId, string frmId, string wrkId);
        void Add(WrkSet wrkSet);
        void Update(WrkSet wrkSet);
        void Delete(WrkSet wrkSet);
    }
    public class WrkSetRepo : IWrkSetRepo
    {
        public List<WrkSet> SetPushFlds(string frwId, string frmId, string wrkId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.FldNm, a.SetWrkId,
       a.SetFldNm, a.SetDefaultValue, a.SqlId, a.Id, a.Pid,
       a.CId, a.CDt, a.MId, a.MDt, 
       b.ToolNm
  from WRKSET a
  join WRKFLD b on a.FrwId=b.FrwId and a.FrmId=b.FrmId and a.FldNm=b.CtrlNm
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.WrkId = @WrkId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<WrkSet>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = wrkId }).ToList();

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
        public void Add(WrkSet wrkSet)
        {
            string sql = @"
insert into WRKSET
      (FrwId, FrmId, WrkId, FldNm, SetWrkId,
       SetFldNm, SetDefaultValue, SqlId, Pid,
       CId, CDt, MId, MDt)
select @FrwId, @FrmId, @WrkId, @FldNm, @SetWrkId,
       @SetFldNm, @SetDefaultValue, @SqlId, @Pid,
       @CId, getdate(), @MId, getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkSet);
            }
        }

        public void Delete(WrkSet wrkSet)
        {
            string sql = @"
delete
  from WRKSET
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkSet);
            }
        }


        public void Update(WrkSet wrkSet)
        {
            string sql = @"
update a
   set FldNm= @FldNm,
       SetWrkId= @SetWrkId,
       SetFldNm= @SetFldNm,
       SetDefaultValue= @SetDefaultValue,
       SqlId= @SqlId,
       Pid= @Pid,
       MId= @MId,
       MDt= getdate()
  from WRKSET a
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkSet);
            }
        }
    }
}
