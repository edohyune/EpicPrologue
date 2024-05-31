using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class WrkFld : MdlBase
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

        private string _WrkId;
        public string WrkId
        {
            get => _WrkId;
            set => Set(ref _WrkId, value);
        }

        private string _CtrlCls;
        public string CtrlCls
        {
            get => _CtrlCls;
            set => Set(ref _CtrlCls, value);
        }

        private string _FldNm;
        public string FldNm
        {
            get => _FldNm;
            set => Set(ref _FldNm, value);
        }

        private string _FldTy;
        public string FldTy
        {
            get => _FldTy;
            set => Set(ref _FldTy, value);
        }

        private int _FldX;
        public int FldX
        {
            get => _FldX;
            set => Set(ref _FldX, value);
        }

        private int _FldY;
        public int FldY
        {
            get => _FldY;
            set => Set(ref _FldY, value);
        }

        private int _FldWidth;
        public int FldWidth
        {
            get => _FldWidth;
            set => Set(ref _FldWidth, value);
        }

        private int _FldTitleWidth;
        public int FldTitleWidth
        {
            get => _FldTitleWidth;
            set => Set(ref _FldTitleWidth, value);
        }

        private string _FldTitle;
        public string FldTitle
        {
            get => _FldTitle;
            set => Set(ref _FldTitle, value);
        }

        private string _TitleAlign;
        public string TitleAlign
        {
            get => _TitleAlign;
            set => Set(ref _TitleAlign, value);
        }

        private string _Popup;
        public string Popup
        {
            get => _Popup;
            set => Set(ref _Popup, value);
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

        private bool _FixYn;
        public bool FixYn
        {
            get => _FixYn;
            set => Set(ref _FixYn, value);
        }

        private bool _GroupYn;
        public bool GroupYn
        {
            get => _GroupYn;
            set => Set(ref _GroupYn, value);
        }

        private bool _ShowYn;
        public bool ShowYn
        {
            get => _ShowYn;
            set => Set(ref _ShowYn, value);
        }

        private bool _NeedYn;
        public bool NeedYn
        {
            get => _NeedYn;
            set => Set(ref _NeedYn, value);
        }

        private bool _EditYn;
        public bool EditYn
        {
            get => _EditYn;
            set => Set(ref _EditYn, value);
        }

        private string _Band1;
        public string Band1
        {
            get => _Band1;
            set => Set(ref _Band1, value);
        }

        private string _Band2;
        public string Band2
        {
            get => _Band2;
            set => Set(ref _Band2, value);
        }

        private string _FuncStr;
        public string FuncStr
        {
            get => _FuncStr;
            set => Set(ref _FuncStr, value);
        }

        private string _FormatStr;
        public string FormatStr
        {
            get => _FormatStr;
            set => Set(ref _FormatStr, value);
        }

        private string _ColorFont;
        public string ColorFont
        {
            get => _ColorFont;
            set => Set(ref _ColorFont, value);
        }

        private string _ColorBg;
        public string ColorBg
        {
            get => _ColorBg;
            set => Set(ref _ColorBg, value);
        }

        private string _ToolNm;
        public string ToolNm
        {
            get => _ToolNm;
            set => Set(ref _ToolNm, value);
        }

        private int _Seq;
        public int Seq
        {
            get => _Seq;
            set => Set(ref _Seq, value);
        }

        private string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }

        private long _Id;
        public long Id
        {
            get => _Id;
            set => Set(ref _Id, value);
        }
        //----------------------------------------
        //----------------------------------------
        public override string ToString()
        {
            return $"{FldNm} / {FldTitle} / {CtrlCls} / {ToolNm}";
        }
    }
    public interface IWrkFldRepo
    {
        void Add(WrkFld wrkFld);
        void Update(WrkFld wrkFld);
        void Delete(WrkFld wrkFld);
    }
    public class WrkFldRepo : IWrkFldRepo
    {
        public WrkFld GetTabPageProperties(string frwId, string frmId, string tabPageNm)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.CtrlNm, a.WrkId, a.CtrlCls,
       a.FldNm, a.FldTy, a.FldX, a.FldY, a.FldWidth,
       a.FldTitleWidth, a.FldTitle, a.TitleAlign, a.Popup, a.DefaultText,
       a.TextAlign, a.FixYn, a.GroupYn, a.ShowYn, a.NeedYn,
       a.EditYn, a.Band1, a.Band2, a.FuncStr, a.FormatStr,
       a.ColorFont, a.ColorBg, a.ToolNm, a.Seq, a.Id,
       a.CId, a.CDt, a.MId, a.MDt
  from WRKFLD a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.FldNm = @TabPageNm
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<WrkFld>(sql, new { FrwId = frwId, FrmId = frmId, TabPageNm = tabPageNm }).SingleOrDefault();

                if (result == null)
                {
                    return null;
                    //throw new KeyNotFoundException($"A record with the code {frwId},{frmId},{tabPageNm} was not found.");
                }
                else
                {
                    result.ChangedFlag = MdlState.None;
                    return result;
                }
            }
        }

        public List<WrkFld> GetColumnProperties(string frwId, string frmId, string wrkId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.CtrlNm, a.WrkId, a.CtrlCls,
       a.FldNm, a.FldTy, a.FldX, a.FldY, a.FldWidth,
       a.FldTitleWidth, a.FldTitle, a.TitleAlign, a.Popup, a.DefaultText,
       a.TextAlign, a.FixYn, a.GroupYn, a.ShowYn, a.NeedYn,
       a.EditYn, a.Band1, a.Band2, a.FuncStr, a.FormatStr,
       a.ColorFont, a.ColorBg, a.ToolNm, a.Seq, a.Id,
       a.CId, a.CDt, a.MId, a.MDt
  from WRKFLD a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.WrkId = @WrkId
   and a.CtrlCls = 'Column'
 order by a.Seq, a.Id
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<WrkFld>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = wrkId }).ToList();

                if (result == null)
                {
                    return null;
                    //throw new KeyNotFoundException($"A record with the code {frwId},{frmId},{wrkId} was not found.");
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

        public WrkFld GetFldProperties(string frwId, string frmId, string ctrlNm)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.CtrlNm, a.WrkId, a.CtrlCls,
       a.FldNm, a.FldTy, a.FldX, a.FldY, a.FldWidth,
       a.FldTitleWidth, a.FldTitle, a.TitleAlign, a.Popup, a.DefaultText,
       a.TextAlign, a.FixYn, a.GroupYn, a.ShowYn, a.NeedYn,
       a.EditYn, a.Band1, a.Band2, a.FuncStr, a.FormatStr,
       a.ColorFont, a.ColorBg, a.ToolNm, a.Seq, a.Id,
       a.CId, a.CDt, a.MId, a.MDt
  from WRKFLD a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.CtrlNm = @CtrlNm
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<WrkFld>(sql, new { FrwId = frwId, FrmId = frmId, CtrlNm = ctrlNm }).SingleOrDefault();

                if (result == null)
                {
                    return null;
                    //throw new KeyNotFoundException($"A record with the code {frwId},{frmId},{ctrlNm} was not found.");
                }
                else
                {
                    result.ChangedFlag = MdlState.None;
                    return result;
                }
            }
        }

        public List<WrkFld> GetByFrwFrmWrk(string frwId, string frmId, string wrkId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.CtrlNm, a.WrkId, a.CtrlCls,
       a.FldNm, a.FldTy, a.FldX, a.FldY, a.FldWidth,
       a.FldTitleWidth, a.FldTitle, a.TitleAlign, a.Popup, a.DefaultText,
       a.TextAlign, a.FixYn, a.GroupYn, a.ShowYn, a.NeedYn,
       a.EditYn, a.Band1, a.Band2, a.FuncStr, a.FormatStr,
       a.ColorFont, a.ColorBg, a.ToolNm, a.Seq, a.Id,
       a.CId, a.CDt, a.MId, a.MDt
  from WRKFLD a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.WrkId = @WrkId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<WrkFld>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = wrkId }).ToList();

                if (result == null)
                {
                    return null;
                    //throw new KeyNotFoundException($"A record with the code {frwId},{frmId},{wrkId} was not found.");
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

        public void Add(WrkFld wrkFld)
        {
            string sql = @"
insert into WRKFLD
      (FrwId, FrmId, CtrlNm, WrkId, CtrlCls,
       FldNm, FldTy, FldX, FldY, FldWidth,
       FldTitleWidth, FldTitle, TitleAlign, Popup, DefaultText,
       TextAlign, FixYn, GroupYn, ShowYn, NeedYn,
       EditYn, Band1, Band2, FuncStr, FormatStr,
       ColorFont, ColorBg, ToolNm, Seq,
       CId, CDt, MId, MDt)
select @FrwId, @FrmId, @CtrlNm, @WrkId, @CtrlCls,
       @FldNm, @FldTy, @FldX, @FldY, @FldWidth,
       @FldTitleWidth, @FldTitle, @TitleAlign, @Popup, @DefaultText,
       @TextAlign, @FixYn, @GroupYn, @ShowYn, @NeedYn,
       @EditYn, @Band1, @Band2, @FuncStr, @FormatStr,
       @ColorFont, @ColorBg, @ToolNm, @Seq,
       <$gRegId>, getdate(), <$gRegId>, getdate()
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkFld);
            }
        }

        public void Update(WrkFld wrkFld)
        {
            string sql = @"
update a
   set FrwId= @FrwId,
       FrmId= @FrmId,
       CtrlNm= @CtrlNm,
       WrkId= @WrkId,
       CtrlCls= @CtrlCls,
       FldNm= @FldNm,
       FldTy= @FldTy,
       FldX= @FldX,
       FldY= @FldY,
       FldWidth= @FldWidth,
       FldTitleWidth= @FldTitleWidth,
       FldTitle= @FldTitle,
       TitleAlign= @TitleAlign,
       Popup= @Popup,
       DefaultText= @DefaultText,
       TextAlign= @TextAlign,
       FixYn= @FixYn,
       GroupYn= @GroupYn,
       ShowYn= @ShowYn,
       NeedYn= @NeedYn,
       EditYn= @EditYn,
       Band1= @Band1,
       Band2= @Band2,
       FuncStr= @FuncStr,
       FormatStr= @FormatStr,
       ColorFont= @ColorFont,
       ColorBg= @ColorBg,
       ToolNm= @ToolNm,
       Seq= @Seq,
       MId= <$gRegId>,
       MDt= getdate()
  from WRKFLD a
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkFld);
            }
        }

        public void Delete(WrkFld wrkFld)
        {
            string sql = @"
delete
  from WRKFLD
 where 1=1
   and Id = @Id
";
            using (var db = new Lib.GaiaHelper())
            {
                db.OpenExecute(sql, wrkFld);
            }
        }
    }
}
