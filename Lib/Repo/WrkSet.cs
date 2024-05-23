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

        private string _CtrlNm;
        public string CtrlNm
        {
            get => _CtrlNm;
            set => Set(ref _CtrlNm, value);
        }

        private int _ParamWrk;
        public int ParamWrk
        {
            get => _ParamWrk;
            set => Set(ref _ParamWrk, value);
        }

        private int _ParamName;
        public int ParamName
        {
            get => _ParamName;
            set => Set(ref _ParamName, value);
        }

        private int _ParamValue;
        public int ParamValue
        {
            get => _ParamValue;
            set => Set(ref _ParamValue, value);
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
    }
    public interface IWrkSetRepo
    {
        List<WrkSet> GetPushFlds(string frwId, string frmId, string wrkId);
        void Add(WrkSet wrkSet);
        void Update(WrkSet wrkSet);
        void Delete(WrkSet wrkSet);
    }
    public class WrkSetRepo : IWrkSetRepo
    {
        //public List<MdlParam> PushParam(object param)
        //{
        //    string sql = @"
        //    select a.Id, a.Sys_cd, a.Frm_id, a.Wkset_id, 
        //           a.Ctrl_id, b.Ctrl_ty, 
        //           a.Param_wkset, a.Param_name, a.Param_value, a.Pid
        //      from ATZ31Push a
        //      join ATZ310 b on a.Sys_cd=b.Sys_cd and a.Frm_id=b.Frm_id and a.Ctrl_id=b.Ctrl_id
        //     where a.Sys_cd=@sys
        //       and a.Frm_id=@frm
        //       and a.Param_wkset=@wkset
        //    ";

        //    var result = SqlMapper.Query<MdlParam>(_conn, sql, param, _tran).ToList();
        //    return result;
        //}

        public List<WrkSet> GetPushFlds(string frwId, string frmId, string wrkId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.WrkId, a.CtrlNm, a.ParamWrk,
       a.ParamName, a.ParamValue, a.Id, a.Pid, a.CId,
       a.CDt, a.MId, a.MDt
  from WRKSET a
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
      (FrwId, FrmId, WrkId, CtrlNm, ParamWrk,
       ParamName, ParamValue, Id, Pid, CId,
       CDt, MId, MDt)
select @FrwId, @FrmId, @WrkId, @CtrlNm, @ParamWrk,
       @ParamName, @ParamValue, @Id, @Pid, 
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
   and FrmId = @FrmId
   and FrwId = @FrwId
   and WrkId = @WrkId
   and CtrlNm = @CtrlNm
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
   set CtrlNm= @CtrlNm,
       ParamWrk= @ParamWrk,
       ParamName= @ParamName,
       ParamValue= @ParamValue,
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
