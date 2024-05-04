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
        string _Id;
        public string Id
        {
            get => _Id;
            set => Set(ref _Id, value);
        }
        string _Nm;
        public string Nm
        {
            get => _Nm;
            set => Set(ref _Nm, value);
        }
        string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }
        string _FrmWrkId;
        public string FrmWrkId
        {
            get => _FrmWrkId;
            set => Set(ref _FrmWrkId, value);
        }
        FrmType _FrmTy;
        public FrmType FrmTy
        {
            get => _FrmTy;
            set => Set(ref _FrmTy, value);
        }
        string _FilePath;
        public string FilePath
        {
            get => _FilePath;
            set => Set(ref _FilePath, value);
        }
        string _FileNm;
        public string FileNm
        {
            get => _FileNm;
            set => Set(ref _FileNm, value);
        }
        string _NmSpace;
        public string NmSpace
        {
            get => _NmSpace;
            set => Set(ref _NmSpace, value);
        }
        string _UsrId;
        public string UsrId
        {
            get => _UsrId;
            set => Set(ref _UsrId, value);
        }
        public override string ToString()
        {
            return Nm;
        }
    }
    public interface IFrmRepo
    {
        List<FrmMst> GetByFrmWrkId(string frmWrkId);
        //List<FrmMst> GetByUsrId(int usrId);
        List<FrmMst> GetByFrmTy(FrmType frmTy);
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
      (Id, Nm, Memo, FrmWrkId, FilePath,
       FileNm, NmSpace, UsrId)
select @Id, @Nm, @Memo, @FrmWrkId, @FilePath,
       @FileNm, @NmSpace, @UsrId
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
   and Id = @Id
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { Id = id });
            }
        }

        public List<FrmMst> GetAll()
        {
            string sql = @"
select a.Id, a.Nm, a.Memo, a.FrmWrkId, a.FilePath,
       a.FileNm, a.NmSpace, a.UsrId
  from FRMMST a
 where 1=1
";
            using (var db = new GaiaHelper())
            {
                return db.Query<FrmMst>(sql).ToList();
            }
        }

        public List<FrmMst> GetByFrmTy(FrmType frmTy)
        {
            string sql = @"
select a.Id, a.Nm, a.Memo, a.FrmWrkId, a.FilePath,
       a.FileNm, a.NmSpace, a.UsrId
  from FRMMST a
 where 1=1
   and a.FrmTy = @frmTy
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmMst>(sql, new { FrmTy = frmTy.ToString() }).ToList();
                return result;
            }
        }

        public List<FrmMst> GetByFrmWrkId(string frmWrkId)
        {
            string sql = @"
select a.Id, a.Nm, a.Memo, a.FrmWrkId, a.FilePath,
       a.FileNm, a.NmSpace, a.UsrId
  from FRMMST a
 where 1=1
   and a.FrmWrkId = @FrmWrkId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmMst>(sql, new { FrmWrkId = frmWrkId }).ToList();
                return result;
            }
        }

        public FrmMst GetById(string id)
        {
            string sql = @"
select a.Id, a.Nm, a.Memo, a.FrmWrkId, a.FilePath,
       a.FileNm, a.NmSpace, a.UsrId
  from FRMMST a
 where 1=1
   and a.Id = @Id
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmMst>(sql, new { Id = id }).FirstOrDefault();
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
select a.Id, a.Nm, a.Memo, a.FrmWrkId, a.FilePath,
       a.FileNm, a.NmSpace, a.UsrId
  from FRMMST a
 where 1=1
   and a.UsrId = @UId
   and a.FrmTy = 'Development'
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<FrmMst>(sql, new { UId = usrId }).ToList();
                return result;
            }
        }

        public void Update(FrmMst frm)
        {
            string sql = @"
update a
   set Id= @Id,
       Nm= @Nm,
       Memo= @Memo,
       FrmWrkId= @FrmWrkId,
       FilePath= @FilePath,
       FileNm= @FileNm,
       NmSpace= @NmSpace,
       UsrId= @UsrId
  from FRMMST a
 where 1=1
   and Id = @Id_old
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, frm);
            }
        }
    }
}
