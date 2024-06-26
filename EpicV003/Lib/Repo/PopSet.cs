using DevExpress.Pdf.Native.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicV003.Lib.Repo
{
    public class PopSet : MdlBase
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

        private string _PopId;
        public string PopId
        {
            get => _PopId;
            set => Set(ref _PopId, value);
        }

        private string _FldNm;
        public string FldNm
        {
            get => _FldNm;
            set => Set(ref _FldNm, value);
        }

        private string _SetPopId;
        public string SetPopId
        {
            get => _SetPopId;
            set => Set(ref _SetPopId, value);
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
    public interface IPopSetRepo
    {
        List<PopSet> SetPushFlds(string frwId, string frmId, string popId);
        void Add(PopSet popSet);
        void Update(PopSet popSet);
        void Delete(PopSet popSet);
    }
    public class PopSetRepo : IPopSetRepo
    {
        public List<PopSet> SetPushFlds(string frwId, string frmId, string popId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.PopId, a.FldNm, a.SetPopId,
       a.SetFldNm, a.SetDefaultValue, a.SqlId, a.Id, a.Pid,
       a.CId, a.CDt, a.MId, a.MDt
  from POPSET a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.PopId = @PopId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<PopSet>(sql, new { FrwId = frwId, FrmId = frmId }).ToList();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        item.ChangedFlag = MdlState.None;
                    }
                    return result;
                }
                else { return null; }
            }
        }
        public void Add(PopSet popSet)
        {
            string sql = @"
insert into POPSET
      (FrwId, FrmId, PopId, FldNm, SetPopId,
       SetFldNm, SetDefaultValue, SqlId, Id, Pid,
       CId, CDt, MId, MDt)
select @FrwId, @FrmId, @PopId, @FldNm, @SetPopId,
       @SetFldNm, @SetDefaultValue, @SqlId, @Id, @Pid,
       " + Common.GetValue("gRegId") + @", getdate(), " + Common.GetValue("gRegId") + @", getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, popSet);
            }
        }
        public void Update(PopSet popSet)
        {
            string sql =@"
update a
   set FrwId= @FrwId,
       FrmId= @FrmId,
       PopId= @PopId,
       FldNm= @FldNm,
       SetPopId= @SetPopId,
       SetFldNm= @SetFldNm,
       SetDefaultValue= @SetDefaultValue,
       SqlId= @SqlId,
       Id= @Id,
       Pid= @Pid,
       MId= " + Common.GetValue("gRegId") + @",
       MDt= getdate()
  from POPSET a
 where 1=1
   and Id = @Id
";

            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, popSet);
            }
        }
        public void Delete(PopSet popSet)
        {
            string sql = @"
delete
  from POPSET
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, popSet);
            }
        }
    }

}
