using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class FrmCtrl : Lib.MdlBase
    {
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

        private string _TitleText;
        public string TitleText
        {
            get => _TitleText;
            set => Set(ref _TitleText, value);
        }

        private string _TitleAlign;
        public string TitleAlign
        {
            get => _TitleAlign;
            set => Set(ref _TitleAlign, value);
        }

        private bool _VisibleYn;
        public bool VisibleYn
        {
            get => _VisibleYn;
            set => Set(ref _VisibleYn, value);
        }

        private bool _ReadonlyYn;
        public bool ReadonlyYn
        {
            get => _ReadonlyYn;
            set => Set(ref _ReadonlyYn, value);
        }
    }
    public interface IFrmCtrlRepo
    {
        List<FrmCtrl> GetByFrm(string frmId);
        void Add(FrmCtrl frmCtrl);
        void Update(FrmCtrl frmCtrl);
        void Delete(string frmid, string ctrlnm);

    }
    public class FrmCtrlRepo : IFrmCtrlRepo
    {
        public void Add(FrmCtrl frmCtrl)
        {
            string sql = @"
insert into FRMCTRL
      (FrmId, CtrlNm, ToolNm, CtrlW, CtrlH,
       TitleText, TitleAlign, VisibleYn, ReadonlyYn, CId,
       CDt, MId, MDt)
select @FrmId, @CtrlNm, @ToolNm, @CtrlW, @CtrlH,
       @TitleText, @TitleAlign, @VisibleYn, @ReadonlyYn, @CId,
       getdate(), @MId, getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, frmCtrl);
            }
        }

        public void Delete(string frmid, string ctrlnm)
        {
            string sql = @"
delete
  from FRMCTRL
 where 1=1
   and FrmId = @FrmId 
   and CtrlNm = @CtrlNm
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, new { FrmId = frmid, CtrlNm = ctrlnm });
            }
        }

        public List<FrmCtrl> GetByFrm(string frmId)
        {
            string sql = @"
select a.FrmId, a.CtrlNm, a.ToolNm, a.CtrlW, a.CtrlH,
       a.TitleText, a.TitleAlign, a.VisibleYn, a.ReadonlyYn, a.CId,
       a.CDt, a.MId, a.MDt
  from FRMCTRL a
 where 1 = 1
   and a.FrmId = @FrmId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<FrmCtrl>(sql, new {FrmId=frmId }).ToList();

                if (result == null)
                {
                    throw new KeyNotFoundException($"A record with the code {frmId} was not found.");
                }
                else
                {
                    return result;
                }
            }
        }

        public void Update(FrmCtrl frmCtrl)
        {
            string sql = @"
update a
   set FrmId= @FrmId,
       CtrlNm= @CtrlNm,
       ToolNm= @ToolNm,
       CtrlW= @CtrlW,
       CtrlH= @CtrlH,
       TitleText= @TitleText,
       TitleAlign= @TitleAlign,
       VisibleYn= @VisibleYn,
       ReadonlyYn= @ReadonlyYn,
       CId= @CId,
       CDt= @CDt,
       MId= @MId,
       MDt= @MDt
  from FRMCTRL a
 where 1=1
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
