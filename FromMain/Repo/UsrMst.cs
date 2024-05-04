using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class UsrMst : MdlBase
    {
        string _UsrId;
        public string UsrId
        {
            get => _UsrId;
            set => Set(ref _UsrId, value);
        }
        string _UsrNm;
        public string UsrNm
        {
            get => _UsrNm;
            set => Set(ref _UsrNm, value);
        }
        string _Pwd;
        public string Pwd
        {
            get => _Pwd;
            set => Set(ref _Pwd, value);
        }
        string _Cls;
        public string Cls
        {
            get => _Cls;
            set => Set(ref _Cls, value);
        }
    }
    public interface IUsrRepo
    {
        UsrMst GetById(string uid);
        UsrMst CheckSignIn(string id, string pwd);
        List<UsrMst> GetAll();
        void Add(UsrMst usr);
        void Update(UsrMst usr);
        void Delete(string uid);
    }
    public class UsrRepo : IUsrRepo
    {
        public void Add(UsrMst usr)
        {
            string sql = @"
insert into USRMST
       (UsrId, UsrNm, Pwd, Cls)
select @UsrId, @UsrNm, @Pwd, @Cls
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, usr);
            }
        }

        public UsrMst CheckSignIn(string id, string pwd)
        {
            string sql = @"
select a.UsrId, a.UsrNm, a.Pwd, a.Cls
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

        public void Delete(string uid)
        {
            string sql = @"
delete
  from USRMST
 where 1=1
   and UsrId = @UsrId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { UsrId = uid });
            }
        }

        public List<UsrMst> GetAll()
        {
            string sql = @"
select a.UsrId, a.UsrNm, a.Pwd, a.Cls
  from USRMST a
";
            using (var db = new GaiaHelper())
            {
                return db.Query<UsrMst>(sql).ToList();
            }
        }

        public UsrMst GetById(string uid)
        {
            string sql = @"
select a.UsrId, a.UsrNm, a.Pwd, a.Cls
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
   set UsrId= @UsrId,
       UsrNm= @UsrNm,
       Pwd= @Pwd,
       Cls= @Cls
  from USRMST a
 where 1=1
   and UsrId = @UsrId_old
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, usr);
            }
        }
    }

}
