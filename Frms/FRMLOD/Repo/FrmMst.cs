using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class FrmMst : MdlBase
    {
        private string _FrmId;
        public string FrmId
        {
            get => _FrmId;
            set => Set(ref _FrmId, value);
        }

        private string _FrmNm;
        public string FrmNm
        {
            get => _FrmNm;
            set => Set(ref _FrmNm, value);
        }

        private int _OwnId;
        public int OwnId
        {
            get => _OwnId;
            set => Set(ref _OwnId, value);
        }

        private string _FrwId;
        public string FrwId
        {
            get => _FrwId;
            set => Set(ref _FrwId, value);
        }

        private string _FilePath;
        public string FilePath
        {
            get => _FilePath;
            set => Set(ref _FilePath, value);
        }

        private string _FileNm;
        public string FileNm
        {
            get => _FileNm;
            set => Set(ref _FileNm, value);
        }

        private string _NmSpace;
        public string NmSpace
        {
            get => _NmSpace;
            set => Set(ref _NmSpace, value);
        }

        private bool _FldYn;
        public bool FldYn
        {
            get => _FldYn;
            set => Set(ref _FldYn, value);
        }

        private string _PId;
        public string PId
        {
            get => _PId;
            set => Set(ref _PId, value);
        }

        private string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }
    }
    public interface IFrmMstRepo
    {
        bool ChkByFrm(string frmId);
        FrmMst GetByFrmId(string frmId);
        List<FrmMst> GetAll();
        void Add(FrmMst frmMst);
        void Update(FrmMst frmMst);
        void Delete(string frmId);

    }
    public class FrmMstRepo : IFrmMstRepo
    {
        public bool ChkByFrm(string frmId)
        {
            string sql = @"
select a.FrmId, a.FrmNm, a.OwnId, a.FrwId, a.FilePath,
       a.FileNm, a.NmSpace, a.FldYn, a.PId, a.Memo,
       a.CId, a.CDt, a.MId, a.MDt
  from FRMMST a
 where 1=1
   and a.FrmId = @FrmId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmMst>(sql, new { FrmId = frmId }).FirstOrDefault();
                return result == null;
            }
        }
       
        public FrmMst GetByFrmId(string frmId)
        {
            string sql = @"
select a.FrmId, a.FrmNm, a.OwnId, a.FrwId, a.FilePath,
       a.FileNm, a.NmSpace, a.FldYn, a.PId, a.Memo,
       a.CId, a.CDt, a.MId, a.MDt
  from FRMMST a
 where 1=1
   and a.FrmId = @FrmId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmMst>(sql, new { FrmId = frmId }).FirstOrDefault();
                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {frmId} was not found.");
                }
                else 
                {
                    result.ChangedFlag = MdlState.None;  // 객체 상태를 None으로 설정
                    return result;
                }


            }
        }
        public List<FrmMst> GetAll()
        {
            string sql = @"
select a.FrmId, a.FrmNm, a.OwnId, a.FrwId, a.FilePath,
       a.FileNm, a.NmSpace, a.FldYn, a.PId, a.Memo,
       a.CId, a.CDt, a.MId, a.MDt
  from FRMMST a
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmMst>(sql).ToList();

                foreach (var item in result)
                {
                    item.ChangedFlag = MdlState.None;  // 객체 상태를 None으로 설정
                }
                return result;
            }
        }

        public void Add(FrmMst frmMst)
        {
            string sql = @"
insert into FRMMST
      (FrmId, FrmNm, OwnId, FrwId, FilePath,
       FileNm, NmSpace, FldYn, PId, Memo,
       CId, CDt, MId, MDt)
select @FrmId, @FrmNm, @OwnId, @FrwId, @FilePath,
       @FileNm, @NmSpace, @FldYn, @PId, @Memo,
       @CId, getdate(), @MId, getdate()
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frmMst);
            }
        }

        public void Update(FrmMst frmMst)
        {
            string sql = @"
update a
   set FrmId= @FrmId,
       FrmNm= @FrmNm,
       OwnId= @OwnId,
       FrwId= @FrwId,
       FilePath= @FilePath,
       FileNm= @FileNm,
       NmSpace= @NmSpace,
       FldYn= @FldYn,
       PId= @PId,
       Memo= @Memo,
       MId= @MId,
       MDt= getdate()
  from FRMMST a
 where 1=1
   and FrmId = @FrmId
";
            Common.gMsg = sql;
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frmMst);
            }
        }

        public void Delete(string frmId)
        {
            string sql = @"
delete
  from FRMMST
 where 1=1
   and FrmId = @FrmId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { FrmId = frmId });
            }
        }
    }
}
