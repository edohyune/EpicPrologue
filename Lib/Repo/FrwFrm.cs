using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class FrwFrm : MdlBase
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

        private int _UsrRegId;
        public int UsrRegId
        {
            get => _UsrRegId;
            set => Set(ref _UsrRegId, value);
        }

        private string _FrwId;
        public string FrwId
        {
            get => _FrwId;
            set => Set(ref _FrwId, value);
        }

        // 이 부분은 사용되지 않는 코드입니다. 작업환경이 자주 달라지는 경우 DLL File Path가 달라져 문제가 발생할 수 있다.
        // D:\00_WorkSpace\EpicPrologue\Frms\CTRLMST\bin\Debug\net8.0-windows
        // WorkPath = D:\00_WorkSpace\
        // FilePath = EpicPrologue\Frms\CTRLMST\bin\Debug\net8.0-windows
        // 위와 같이 분리하면 사용자는 작업공간을 선택하여 쉽게 작업이 가능하다.
        //private string _WorkPath; 
        //public string WorkPath
        //{
        //    get => _WorkPath;
        //    set => Set(ref _WorkPath, value);
        //}

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
    public interface IFrwFrmRepo
    {
        bool ChkByFrm(string frmId);
        FrwFrm GetByFrmId(string frmId);
        List<FrwFrm> GetAll();
        void Add(FrwFrm frmMst);
        void Update(FrwFrm frmMst);
        void Delete(string frmId);

    }
    public class FrwFrmRepo : IFrwFrmRepo
    {
        public bool ChkByFrm(string frmId)
        {
            string sql = @"
select a.FrmId, a.FrmNm, a.UsrRegId, a.FrwId, a.FilePath,
       a.FileNm, a.NmSpace, a.FldYn, a.PId, a.Memo,
       a.CId, a.CDt, a.MId, a.MDt
  from FRWFRM a
 where 1=1
   and a.FrmId = @FrmId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrwFrm>(sql, new { FrmId = frmId }).FirstOrDefault();
                return result == null;
            }
        }
        public List<FrwFrm> GetByOwnFrw(int ownId, string frwId)
        {
            string sql = @"
select a.FrmId, a.FrmNm, a.UsrRegId, a.FrwId, a.FilePath,
       a.FileNm, a.NmSpace, a.FldYn, a.PId, a.Memo,
       a.CId, a.CDt, a.MId, a.MDt
  from FRWFRM a
 where 1=1
   and a.UsrRegId = @UsrRegId
   and a.FrwId = @FrwId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrwFrm>(sql, new { FrwId = frwId, UsrRegId = ownId }).ToList();
                foreach (var item in result)
                {
                    item.ChangedFlag = MdlState.None;  // 객체 상태를 None으로 설정
                }
                return result;
            }
        }

        public FrwFrm GetByFrmId(string frmId)
        {
            string sql = @"
select a.FrmId, a.FrmNm, a.UsrRegId, a.FrwId, a.FilePath,
       a.FileNm, a.NmSpace, a.FldYn, a.PId, a.Memo,
       a.CId, a.CDt, a.MId, a.MDt
  from FRWFRM a
 where 1=1
   and a.FrmId = @FrmId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrwFrm>(sql, new { FrmId = frmId }).FirstOrDefault();
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
        public List<FrwFrm> GetAll()
        {
            string sql = @"
select a.FrmId, a.FrmNm, a.UsrRegId, a.FrwId, a.FilePath,
       a.FileNm, a.NmSpace, a.FldYn, a.PId, a.Memo,
       a.CId, a.CDt, a.MId, a.MDt
  from FRWFRM a
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrwFrm>(sql).ToList();

                foreach (var item in result)
                {
                    item.ChangedFlag = MdlState.None;  // 객체 상태를 None으로 설정
                }
                return result;
            }
        }

        public void Add(FrwFrm frmMst)
        {
            string sql = @"
insert into FRWFRM
      (FrmId, FrmNm, UsrRegId, FrwId, FilePath,
       FileNm, NmSpace, FldYn, PId, Memo,
       CId, CDt, MId, MDt)
select @FrmId, @FrmNm, @UsrRegId, @FrwId, @FilePath,
       @FileNm, @NmSpace, @FldYn, @PId, @Memo,
       @CId, getdate(), @MId, getdate()
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frmMst);
            }
        }

        public void Update(FrwFrm frmMst)
        {
            string sql = @"
update a
   set FrmId= @FrmId,
       FrmNm= @FrmNm,
       UsrRegId= @UsrRegId,
       FrwId= @FrwId,
       FilePath= @FilePath,
       FileNm= @FileNm,
       NmSpace= @NmSpace,
       FldYn= @FldYn,
       PId= @PId,
       Memo= @Memo,
       MId= @MId,
       MDt= getdate()
  from FRWFRM a
 where 1=1
   and FrmId = @FrmId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frmMst);
            }
        }

        public void Delete(string frmId)
        {
            string sql = @"
delete
  from FRWFRM
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
