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

        public override string ToString()
        {
            return FrmNm;
        }
    }
    public interface IFrmRepo
    {
        List<FrmMst> GetByFrmWrkId(string frmWrkId);
        //List<FrmMst> GetByUsrId(int usrId);
        //List<FrmMst> GetByFrmTy(FrmType frmTy);
        List<FrmMst> GetDevFrmByUsrId(int usrId);
        FrmMst GetById(string id);
        List<FrmMst> GetAll();
        void Add(FrmMst frm);
        void Update(FrmMst frm);
        void Delete(string id);
    }   
    public class FrmRepo : IFrmRepo
    {
        public void Add(FrmMst frm)
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
                db.OpenExecute(sql, frm);
            }
        }

        public void Delete(string id)
        {
            string sql = @"
delete
  from FRMMST
 where 1=1
   and FrmId = @FrmId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { FrmId = id });
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
                return db.Query<FrmMst>(sql).ToList();
            }
        }
        
//        public List<FrmMst> GetByFrmTy(FrmType frmTy)
//        {
//            string sql = @"
//select a.Id, a.Nm, a.Memo, a.FrmWrkId, a.FilePath,
//       a.FileNm, a.NmSpace, a.UsrId
//  from FRMMST a
// where 1=1
//   and a.FrmTy = @frmTy
//";
//            using (var db = new GaiaHelper())
//            {
//                var result = db.Query<FrmMst>(sql, new { FrmTy = frmTy.ToString() }).ToList();
//                return result;
//            }
//        }

        public List<FrmMst> GetByFrmWrkId(string frmWrkId)
        {
            string sql = @"
select a.FrmId, a.FrmNm, a.OwnId, a.FrwId, a.FilePath,
       a.FileNm, a.NmSpace, a.FldYn, a.PId, a.Memo,
       a.CId, a.CDt, a.MId, a.MDt
  from FRMMST a
 where 1=1
   and a.FrwId = @FrwId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmMst>(sql, new { FrwId = frmWrkId }).ToList();
                return result;
            }
        }

        public FrmMst GetById(string id)
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
                var result = db.Query<FrmMst>(sql, new { FrmId = id }).FirstOrDefault();
                return result;
            }
        }

        //        public List<FrmMst> GetByUsrId(int usrId)
        //        {
        //            string sql = @"
        //select a.Id, a.Nm, a.Memo, a.FrmWrkId, a.FilePath,
        //       a.FileNm, a.NmSpace, a.UsrId
        //  from FRMMST a
        // where 1=1
        //   and a.UsrId = @UId
        //";
        //            using (var db = new GaiaHelper())
        //            {
        //                var result = db.Query<FrmMst>(sql, new { UId = usrId }).ToList();
        //                return result;
        //            }
        //        }

        public List<FrmMst> GetDevFrmByUsrId(int usrId)
        {
            string sql = @"
select a.FrmId, a.FrmNm, a.OwnId, a.FrwId, a.FilePath,
       a.FileNm, a.NmSpace, a.FldYn, a.PId, a.Memo,
       a.CId, a.CDt, a.MId, a.MDt
  from FRMMST a
 where 1=1
   and a.OwnId = @OwnId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmMst>(sql, new { OwnId = usrId }).ToList();
                return result;
            }
        }

        public void Update(FrmMst frm)
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
       CId= @CId,
       CDt= @CDt,
       MId= @MId,
       MDt= @MDt
  from FRMMST a
 where 1=1
   and FrmId = @FrmId_old
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frm);
            }
        }
    }
}
