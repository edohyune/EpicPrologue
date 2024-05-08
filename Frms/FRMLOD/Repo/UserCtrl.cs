using Lib;
using System.Collections.Generic;
using System.Linq;

namespace Frms.Repo
{
    public class UserCtrl : MdlBase
    {
        int _Id;
        public int Id
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
        string _Ty;
        public string Ty
        {
            get => _Ty;
            set => Set(ref _Ty, value);
        }

        bool _CtrlYn;
        public bool CtrlYn
        {
            get => _CtrlYn;
            set => Set(ref _CtrlYn, value);
        }

        bool _WrkSetYn;
        public bool WrkSetYn
        {
            get => _WrkSetYn;
            set => Set(ref _WrkSetYn, value);
        }

        bool _ContainerYn;
        public bool ContainerYn
        {
            get => _ContainerYn;
            set => Set(ref _ContainerYn, value);
        }

        bool _FrmWrkYn;
        public bool FrmWrkYn
        {
            get => _FrmWrkYn;
            set => Set(ref _FrmWrkYn, value);
        }

        bool _CustomYn;
        public bool CustomYn
        {
            get => _CustomYn;
            set => Set(ref _CustomYn, value);
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
    public interface IUserCtrlRepo
    {
        UserCtrl GetById(int Id);
        List<UserCtrl> GetAll();
        void Add(UserCtrl userCtrl);
        void Update(UserCtrl userCtrl);
        void Delete(int Id);
    }
    public class UserCtrlRepo : IUserCtrlRepo
    {
        public void Add(UserCtrl userCtrl)
        {
            string sql = @"
insert into UserCtrl
      (Nm, Ty, CtrlYn, WrkSetYn,
       ContainerYn, FrmWrkYn, CustomYn, Versn, Memo,
       PId)
select @Nm, @Ty, @CtrlYn, @WrkSetYn,
       @ContainerYn, @FrmWrkYn, @CustomYn, @Versn, @Memo,
       @PId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, userCtrl);
            }
        }
        public void Update(UserCtrl userCtrl)
        {
            string sql = @"
update a
   set Nm= @Nm,
       Ty= @Ty,
       CtrlYn= @CtrlYn,
       WrkSetYn= @WrkSetYn,
       ContainerYn= @ContainerYn,
       FrmWrkYn= @FrmWrkYn,
       CustomYn= @CustomYn,
       Versn= @Versn,
       Memo= @Memo,
       PId= @PId
  from UserCtrl a
 where 1=1
   and Id = @Id
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, userCtrl);
            }
        }

        public void Delete(int Id)
        {
            string sql = @"
delete
  from USERCTRL
 where 1=1
   and Id = @Id
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { Id = Id });
            }
        }

        public List<UserCtrl> GetAll()
        {
            string sql = @"
select a.Id, a.Nm, a.Ty, a.CtrlYn, a.WrkSetYn,
       a.ContainerYn, a.FrmWrkYn, a.CustomYn, a.Versn, a.Memo,
       a.PId
  from USERCTRL a
 where 1=1
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<UserCtrl>(sql).ToList();
                return result;
            }
        }

        public UserCtrl GetById(int Id)
        {
            string sql = @"
select a.Id, a.Nm, a.Ty, a.CtrlYn, a.WrkSetYn,
       a.ContainerYn, a.FrmWrkYn, a.CustomYn, a.Versn, a.Memo,
       a.PId
  from USERCTRL a
 where 1=1
   and a.Id = @Id
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<UserCtrl>(sql, new { Id = Id }).FirstOrDefault();
                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {Id} was not found.");
                }
                return result;
            }
        }

        //        public string FindWorkSetType(dynamic name)
        //        {
        //            string sql = @"
        //select distinct a.Cls
        //  from USERCTRL a
        // where 1=1
        //   and a.Nm = @nm
        //";
        //            using (var db = new GaiaHelper())
        //            {
        //                var result = db.OpenQuery(sql, new { nm = name});
        //                if (result == null)
        //                {
        //                    return "ETC";
        //                }
        //                else
        //                {
        //                    return result;
        //                }
        //            }
        //        }
        public bool CheckWorkSetType(dynamic name)
        {
            string sql = @"
select cnt = count(*)
  from USERCTRL a
 where 1=1
   and a.Nm = @nm
";
            using (var db = new GaiaHelper())
            {
                //db.OpenQuery(sql, new { name = name }) string 결과를 int로 변환
                var result = db.OpenQuery(sql, new { nm = name });

                if (result == null)
                {
                    return false;
                }
                else
                {
                    //return의 string 결과를 int로 변환
                    return int.TryParse(result, out int cnt);
                }
            }


        }
    }
}
