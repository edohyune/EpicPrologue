namespace ER000.Lib.Repo
{
    public class B612 : MdlBase
    {
        private int _UsrRegId;
        public int UsrRegId
        {
            get => _UsrRegId;
            set => Set(ref _UsrRegId, value);
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
    public interface IB612Repo
    {
        B612 GetById(int uid);
        B612 GetByUsrId(string uid);
        B612 CheckSignIn(string id, string pwd);
        List<B612> GetAll();
        void Add(B612 usr);
        void Update(B612 usr);
        void Delete(int uid);
    }
    public class B612Repo : IB612Repo
    {
        public void Add(B612 usr)
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

        public B612 CheckSignIn(string id, string pwd)
        {
            string sql = @"
select a.UsrRegId, a.UsrId, a.UsrNm, a.Pwd, a.Cls,
       a.CId, a.CDt, a.MId, a.MDt
  from USRMST a
 where 1=1
   and a.UsrId = @UsrId
   and a.Pwd = @Pwd
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<B612>(sql, new { UsrId = id, Pwd = pwd }).FirstOrDefault();
                return result;
            }
        }

        public void Delete(int uid)
        {
            string sql = @"
delete
  from USRMST
 where 1=1
   and UsrRegId = @id
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { id = uid });
            }
        }

        public List<B612> GetAll()
        {
            string sql = @"
select a.UsrRegId, a.UsrId, a.UsrNm, a.Pwd, a.Cls,
       a.CId, a.CDt, a.MId, a.MDt
  from USRMST a
";
            using (var db = new GaiaHelper())
            {
                return db.Query<B612>(sql).ToList();
            }
        }

        public B612 GetById(int uid)
        {
            string sql = @"
select a.UsrRegId, a.UsrId, a.UsrNm, a.Pwd, a.Cls,
       a.CId, a.CDt, a.MId, a.MDt
  from USRMST a
 where 1=1
   and a.UsrRegId = @UsrRegId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<B612>(sql, new { UsrRegId = uid }).FirstOrDefault();
                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {uid} was not found.");
                }
                return result;
            }
        }

        public B612 GetByUsrId(string uid)
        {
            string sql = @"
select a.UsrRegId, a.UsrId, a.UsrNm, a.Pwd, a.Cls,
       a.CId, a.CDt, a.MId, a.MDt
  from USRMST a
 where 1=1
   and a.UsrId = @UId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<B612>(sql, new { UsrId = uid }).FirstOrDefault();
                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {uid} was not found.");
                }
                return result;
            }
        }

        public void Update(B612 usr)
        {
            string sql = @"
update a
   set UsrId= @UsrId,
       UsrNm= @UsrNm,
       Pwd= @Pwd,
       Cls= @Cls,
       MId= @MId,
       MDt= getdate()
  from USRMST a
 where 1=1
   and UsrRegId = @UsrRegId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, usr);
            }
        }
    }

}
