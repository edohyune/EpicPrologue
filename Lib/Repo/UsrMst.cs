using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class UsrMst : MdlBase
    {
        private int _Id;
        public int Id
        {
            get => _Id;
            set => Set(ref _Id, value);
        }

        private string _UsrId;
        public string UsrId
        {
            get => _UsrId;
            set => Set(ref _UsrId, value);
        }

        private string _UsrNm;
        public string UsrNm
        {
            get => _UsrNm;
            set => Set(ref _UsrNm, value);
        }

        private string _Pwd;
        public string Pwd
        {
            get => _Pwd;
            set => Set(ref _Pwd, value);
        }

        private string _Cls;
        public string Cls
        {
            get => _Cls;
            set => Set(ref _Cls, value);
        }

    }
    public interface IUsrRepo
    {
        UsrMst GetById(int uid);
        UsrMst GetByUsrId(string uid);
        UsrMst CheckSignIn(string id, string pwd);
        List<UsrMst> GetAll();
        void Add(UsrMst usr);
        void Update(UsrMst usr);
        void Delete(int uid);
    }
    public class UsrRepo : IUsrRepo
    {
        public void Add(UsrMst usr)
        {
            string sql = @"
insert into USRMST
      (UsrId, UsrNm, Pwd, Cls,
       CId, CDt, MId, MDt)
select @UsrId, @UsrNm, @Pwd, @Cls,
       @CId, getdate(), @MId, getdate()
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, usr);
            }
        }

        public UsrMst CheckSignIn(string id, string pwd)
        {
            string sql = @"
select a.Id, a.UsrId, a.UsrNm, a.Pwd, a.Cls,
       a.CId, a.CDt, a.MId, a.MDt
  from USRMST a
 where 1=1
   and a.UsrId = @UsrId
   and a.Pwd = @Pwd
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<UsrMst>(sql, new { UsrId = id, Pwd = pwd }).FirstOrDefault();
                return result;
            }
        }

        public void Delete(int uid)
        {
            string sql = @"
delete
  from USRMST
 where 1=1
   and Id = @id
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { id = uid });
            }
        }

        public List<UsrMst> GetAll()
        {
            string sql = @"
select a.Id, a.UsrId, a.UsrNm, a.Pwd, a.Cls,
       a.CId, a.CDt, a.MId, a.MDt
  from USRMST a
";
            using (var db = new GaiaHelper())
            {
                return db.Query<UsrMst>(sql).ToList();
            }
        }

        public UsrMst GetById(int uid)
        {
            string sql = @"
select a.Id, a.UsrId, a.UsrNm, a.Pwd, a.Cls,
       a.CId, a.CDt, a.MId, a.MDt
  from USRMST a
 where 1=1
   and a.Id = @Id
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<UsrMst>(sql, new { Id = uid }).FirstOrDefault();
                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {uid} was not found.");
                }
                return result;
            }
        }

        public UsrMst GetByUsrId(string uid)
        {
            string sql = @"
select a.Id, a.UsrId, a.UsrNm, a.Pwd, a.Cls,
       a.CId, a.CDt, a.MId, a.MDt
  from USRMST a
 where 1=1
   and a.UsrId = @UId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<UsrMst>(sql, new { UsrId = uid }).FirstOrDefault();
                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {uid} was not found.");
                }
                return result;
            }
        }

        public void Update(UsrMst usr)
        {
            string sql = @"
update a
   set Id = @Id,
       UsrId= @UsrId,
       UsrNm= @UsrNm,
       Pwd= @Pwd,
       Cls= @Cls,
       MId= @MId,
       MDt= getdate()
  from USRMST a
 where 1=1
   and Id = @Id
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, usr);
            }
        }
    }

}
