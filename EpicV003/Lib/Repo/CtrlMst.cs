namespace EpicV003.Lib.Repo
{
    public class CtrlMst : MdlBase
    {
        private int _CtrlId;
        public int CtrlId
        {
            get => _CtrlId;
            set => Set(ref _CtrlId, value);
        }

        private string _CtrlNm;
        public string CtrlNm
        {
            get => _CtrlNm;
            set => Set(ref _CtrlNm, value);
        }

        private string _CtrlGrpCd;
        public string CtrlGrpCd
        {
            get => _CtrlGrpCd;
            set => Set(ref _CtrlGrpCd, value);
        }

        private string _CtrlRegNm;
        public string CtrlRegNm
        {
            get => _CtrlRegNm;
            set => Set(ref _CtrlRegNm, value);
        }

        private bool _ContainYn;
        public bool ContainYn
        {
            get => _ContainYn;
            set => Set(ref _ContainYn, value);
        }

        private bool _CustomYn;
        public bool CustomYn
        {
            get => _CustomYn;
            set => Set(ref _CustomYn, value);
        }

        private bool _UseYn;
        public bool UseYn
        {
            get => _UseYn;
            set => Set(ref _UseYn, value);
        }

        private string _Rnd;
        public string Rnd
        {
            get => _Rnd;
            set => Set(ref _Rnd, value);
        }

        private string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }

        private int _PId;
        public int PId
        {
            get => _PId;
            set => Set(ref _PId, value);
        }
    }
    public interface ICtrlMstRepo
    {
        Dictionary<string, string> GetBindPropertyMapping();
        bool ChkByCtrlNm(string ctrlNm);
        CtrlMst GetByCtrlNm(string ctrlNm);
        List<CtrlMst> GetAll();
        List<CtrlMst> GetUCCtrl();
        void Add(CtrlMst uctrl);
        void Update(CtrlMst uctrl);
        void Delete(int Id);

    }
    public class  CtrlMstRepo : ICtrlMstRepo
    {
        public bool ChkByCtrlNm(string ctrlNm)
        {
            string sql = @"
select a.CtrlId, a.CtrlNm, a.CtrlGrpCd, a.CtrlRegNm, a.ContainYn, a.UseYn,
       a.CustomYn, a.Rnd, a.Memo, a.PId, a.CId,
       a.CDt, a.MId, a.MDt
  from CTRLMST a
 where 1=1
   and a.CtrlNm = @CtrlNm
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<CtrlMst>(sql, new { CtrlNm = ctrlNm }).FirstOrDefault();
                return result == null;
            }
        }

        public CtrlMst GetByCtrlNm(string ctrlNm)
        {
            string sql = @"
select a.CtrlId, a.CtrlNm, a.CtrlGrpCd, a.CtrlRegNm, a.ContainYn, a.UseYn,
       a.CustomYn, a.Rnd, a.Memo, a.PId, a.CId,
       a.CDt, a.MId, a.MDt
  from CTRLMST a
 where 1=1
   and a.CtrlNm = @CtrlNm
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<CtrlMst>(sql, new { CtrlNm = ctrlNm }).FirstOrDefault();
                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {ctrlNm} was not found.");
                }
                result.ChangedFlag = MdlState.None;  // 객체 상태를 None으로 설정

                return result;
            }
        }
        public List<CtrlMst> GetAll()
        {
            string sql = @"
select a.CtrlId, a.CtrlNm, a.CtrlGrpCd, a.CtrlRegNm, a.ContainYn, a.UseYn,
       a.CustomYn, a.Rnd, a.Memo, a.PId, a.CId,
       a.CDt, a.MId, a.MDt
  from CTRLMST a
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<CtrlMst>(sql).ToList();

                foreach (var item in result)
                {
                    item.ChangedFlag = MdlState.None;  // 객체 상태를 None으로 설정
                }

                return result;
            }

        }

        public void Add(CtrlMst uctrl)
        {
            string sql = @"
insert into CTRLMST
      (CtrlNm, CtrlGrpCd, CtrlRegNm, ContainYn, UseYn,
       CustomYn, Rnd, Memo, PId, CId,
       CDt, MId, MDt)
select @CtrlNm, @CtrlGrpCd, @CtrlRegNm, @ContainYn, @UseYn,
       @CustomYn, @Rnd, @Memo, @PId, @CId,
       getdate(), @MId, getdate()
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, uctrl);
            }
        }

        public void Update(CtrlMst uctrl)
        {
            string sql = @"
update a
   set CtrlNm= @CtrlNm,
       CtrlGrpCd= @CtrlGrpCd,
       CtrlRegNm= @CtrlRegNm,
       ContainYn= @ContainYn,
       CustomYn= @CustomYn,
       UseYn= @UseYn,
       Rnd= @Rnd,
       Memo= @Memo,
       PId= @PId,
       MId= @MId,
       MDt= getdate()
  from CTRLMST a
 where 1=1
   and CtrlId = @CtrlId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, uctrl);
            }
        }

        public void Delete(int Id)
        {
            string sql = @"
delete
  from CTRLMST
 where 1=1
   and CtrlId = @CtrlId
";
            using (var db = new GaiaHelper())
            {
                db.OpenExecute(sql, new { CtrlId = Id });
            }
        }

        public List<CtrlMst> GetUCCtrl()
        {
            string sql = @"
select a.CtrlId, a.CtrlNm, a.CtrlGrpCd, a.CtrlRegNm, a.ContainYn, a.UseYn,
       a.CustomYn, a.Rnd, a.Memo, a.PId, a.CId,
       a.CDt, a.MId, a.MDt
  from CTRLMST a
 where 1=1
   and a.UseYn = '1'
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<CtrlMst>(sql).ToList();

                foreach (var item in result)
                {
                    item.ChangedFlag = MdlState.None;  // 객체 상태를 None으로 설정
                }

                return result;
            }
        }

        public Dictionary<string, string> GetBindEventMapping()
        {
            string sql = @"
select a.CtrlNm, a.Event
  from CTRLMST
 where a.CtrlGrpCd = 'Bind'
";
            using (var db = new GaiaHelper())
            {
                return db.QueryDictionary(sql).ToDictionary();
            }
        }

        public Dictionary<string, string> GetBindPropertyMapping()
        {
            string sql = @"
select a.CtrlNm, a.Binding
  from CTRLMST
 where a.CtrlGrpCd = 'Bind'
";
            using (var db = new GaiaHelper())
            {
                return db.QueryDictionary(sql).ToDictionary();
            }
        }
    }
}


/*
    #region 컨트롤 목록 RepoCtrl, ClsCtrl
    public class RepoCtrl
    {
        public static List<ClsCtrl> controls = new List<ClsCtrl>();

        public RepoCtrl()
        {
            controls = new List<ClsCtrl>();
            controls.Add(new ClsCtrl() { Ctrl_ty = "Column", Wkset_ty = "Field", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "ArchButton", Wkset_ty = "Etc", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "ArchCombo", Wkset_ty = "Field", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "ArchText", Wkset_ty = "Field", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "ArchDate", Wkset_ty = "Field", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "ArchGrid", Wkset_ty = "GridSet", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "ArchField", Wkset_ty = "FieldSet", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "ArchPanel", Wkset_ty = "Etc", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "ArchGroup", Wkset_ty = "Etc", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "ArchMemo", Wkset_ty = "Field", Wkset_id = "" });

            controls.Add(new ClsCtrl() { Ctrl_ty = "UCPanel", Wkset_ty = "Etc", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "UCButton", Wkset_ty = "Etc", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "UCCombo", Wkset_ty = "Field", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "UCText", Wkset_ty = "Field", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "UCDate", Wkset_ty = "Field", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "UCGrid", Wkset_ty = "GridSet", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "UCField", Wkset_ty = "FieldSet", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "UCGroup", Wkset_ty = "Etc", Wkset_id = "" });
            controls.Add(new ClsCtrl() { Ctrl_ty = "UCMemo", Wkset_ty = "Field", Wkset_id = "" });

            //controls.Add(new ClsCtrl() { Ctrl_ty = "SplitterPanel", Wkset_ty = "", Wkset_id = "" });
            //controls.Add(new Control() { Ctrl_ty = "", Wkset_ty = "" });
        }

        public string FindWorkSetType(dynamic name)
        {
            var str = (from a in controls
                       where a.Ctrl_ty == name.ToString()
                       select a.Wkset_ty).FirstOrDefault().ToString();
            return str;
        }
        public bool CheckWorkSetType(dynamic name)
        {
            Common.gLog = name.ToString();
            //int cnt = (from a in controls.Where(x=>x.Ctrl_ty!="UCPanel")
            int cnt = (from a in controls
                       where a.Ctrl_ty == name.ToString()
                       select a.Wkset_ty).Count();

            return (cnt == 0) ? false : true;
        }
    }
    public class ClsCtrl
    {
        public string Ctrl_ty { get; set; }
        public string Wkset_ty { get; set; }
        public string Wkset_id { get; set; }
    }
 */