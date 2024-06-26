namespace EpicV003.Lib.Repo
{
    public class FrmCtrl : Lib.MdlBase
    {
        private string _FrwId;
        public string FrwId
        {
            get => _FrwId;
            set => Set(ref _FrwId, value);
        }

        private string _FrmId;
        public string FrmId
        {
            get => _FrmId;
            set => Set(ref _FrmId, value);
        }

        private string _CtrlNm;
        public string CtrlNm
        {
            get => _CtrlNm;
            set => Set(ref _CtrlNm, value);
        }

        private string _ToolNm;
        public string ToolNm
        {
            get => _ToolNm;
            set => Set(ref _ToolNm, value);
        }

        private int _CtrlW;
        public int CtrlW
        {
            get => _CtrlW;
            set => Set(ref _CtrlW, value);
        }

        private int _CtrlH;
        public int CtrlH
        {
            get => _CtrlH;
            set => Set(ref _CtrlH, value);
        }
        private int _CtrlX;
        public int CtrlX
        {
            get => _CtrlX;
            set => Set(ref _CtrlX, value);
        }
        private int _CtrlY;
        public int CtrlY
        {
            get => _CtrlY;
            set => Set(ref _CtrlY, value);
        }
        private string _TitleText;
        public string TitleText
        {
            get => _TitleText;
            set => Set(ref _TitleText, value);
        }

        private int _TitleWidth;
        public int TitleWidth
        {
            get => _TitleWidth;
            set => Set(ref _TitleWidth, value);
        }

        private string _TitleAlign;
        public string TitleAlign
        {
            get => _TitleAlign;
            set => Set(ref _TitleAlign, value);
        }

        private string _DefaultText;
        public string DefaultText
        {
            get => _DefaultText;
            set => Set(ref _DefaultText, value);
        }

        private string _TextAlign;
        public string TextAlign
        {
            get => _TextAlign;
            set => Set(ref _TextAlign, value);
        }

        private bool _ShowYn;
        public bool ShowYn
        {
            get => _ShowYn;
            set => Set(ref _ShowYn, value);
        }

        private bool _EditYn;
        public bool EditYn
        {
            get => _EditYn;
            set => Set(ref _EditYn, value);
        }
    }
    public interface IFrmCtrlRepo
    {
        List<FrmCtrl> GetByFrwFrm(string frwId, string frmId);
        void Add(FrmCtrl frmCtrl);
        void Update(FrmCtrl frmCtrl);
        void Delete(string frwId, string frmid, string ctrlnm);

    }
    public class FrmCtrlRepo : IFrmCtrlRepo
    {
        public void Add(FrmCtrl frmCtrl)
        {
            string sql = @"
insert into FRMCTRL
      (FrwId, FrmId, CtrlNm, ToolNm, CtrlW,
       CtrlH, CtrlX, CtrlY, TitleText, TitleWidth,
       TitleAlign, DefaultText, TextAlign, ShowYn, EditYn,
       CId, CDt, MId, MDt)
select @FrwId, @FrmId, @CtrlNm, @ToolNm, @CtrlW,
       @CtrlH, @CtrlX, @CtrlY, @TitleText, @TitleWidth,
       @TitleAlign, @DefaultText, @TextAlign, @ShowYn, @EditYn,
       @CId, getdate(), @MId, getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, frmCtrl);
            }
        }

        public void Delete(string frwId, string frmId, string ctrlnm)
        {
            string sql = @"
delete
  from FRMCTRL
 where 1=1
   and FrwId = @FrwId
   and FrmId = @FrmId 
   and CtrlNm = @CtrlNm
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, new { FrwId = frwId, FrmId = frmId, CtrlNm = ctrlnm });
            }
        }

        public List<FrmCtrl> GetByFrwFrm(string frwId, string frmId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.CtrlNm, a.ToolNm, a.CtrlW,
       a.CtrlH, a.CtrlX, a.CtrlY, a.TitleText, a.TitleWidth,
       a.TitleAlign, a.DefaultText, a.TextAlign, a.ShowYn, a.EditYn,
       a.CId, a.CDt, a.MId, a.MDt
  from FRMCTRL a
 where 1 = 1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<FrmCtrl>(sql, new { FrwId = frwId, FrmId = frmId }).ToList();

                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {frmId} was not found.");
                }
                else
                {
                    foreach (var item in result)
                    {
                        item.ChangedFlag = MdlState.None;
                    }
                    return result;
                }
            }
        }

        public void Update(FrmCtrl frmCtrl)
        {
            string sql = @"
update a
   set FrwId= @FrwId,
       FrmId= @FrmId,
       CtrlNm= @CtrlNm,
       ToolNm= @ToolNm,
       CtrlW= @CtrlW,
       CtrlH= @CtrlH,
       CtrlX= @CtrlX,
       CtrlY= @CtrlY,
       TitleText= @TitleText,
       TitleWidth= @TitleWidth,
       TitleAlign= @TitleAlign,
       DefaultText= @DefaultText,
       TextAlign= @TextAlign,
       ShowYn= @ShowYn,
       EditYn= @EditYn,
       MId= @MId,
       MDt= getdate()
  from FRMCTRL a
 where 1=1
   and FrwId= @FrwId
   and FrmId= @FrmId
   and CtrlNm= @CtrlNm
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, frmCtrl);
            }
        }
    }
}
