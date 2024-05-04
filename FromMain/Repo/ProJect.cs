using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;


namespace Repo
{
    public class ProJect : MdlBase
    {
        int _Id;
        public int Id
        {
            get=> _Id;
            set=>Set(ref _Id, value);
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
        string _PId;
        public string PId
        {
            get => _PId;
            set => Set(ref _PId, value);
        }
    }

    public interface IProJectRepo
    {
        ProJect GetById(int Id);
        List<ProJect> GetAll();
        void Add(ProJect ProJect);
        void Update(ProJect ProJect); 
        void Delete(int Id);
    }
    public class ProJectRepo : IProJectRepo
    {
        public void Add(ProJect proJect)
        {
            string sql = @"
insert into PRJMST
      (Nm, Memo, PId)
select @Nm, @Memo, @PId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, proJect);
            }
        }

        public void Update(ProJect ProJect)
        {
            string sql = @"
update a
   set Nm= @Nm,
       Memo= @Memo,
       PId= @PId
  from PRJMST a
 where 1=1
   and Id = @Id
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, ProJect);
            }
        }

        public void Delete(int Id)
        {
            string sql = @"
delete
  from PRJMST
 where 1=1
   and Id = @Id
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { Id = Id });
            }
        }

        public ProJect GetById(int Id)
        {
            string sql = @"
select a.Id, a.Nm, a.Memo, a.PId
  from PRJMST a
 where 1=1
   and a.Id = @Id
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<ProJect>(sql, new { Id = Id }).FirstOrDefault();
                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {Id} was not found.");
                }
                return result;
            }
        }

        public List<ProJect> GetAll()
        {
            string sql = @"
select a.Id, a.Nm, a.Memo, a.PId
  from PRJMST a
 where 1=1
";
            using (var db = new GaiaHelper())
            {
                return db.Query<ProJect>(sql).ToList();
            }
        }
    }
}
