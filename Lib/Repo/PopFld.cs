using DevExpress.Pdf.Native.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class PopFld : MdlBase
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

        private string _PopId;
        public string PopId
        {
            get => _PopId;
            set => Set(ref _PopId, value);
        }

        private string _FldNm;
        public string FldNm
        {
            get => _FldNm;
            set => Set(ref _FldNm, value);
        }

        private string _CtrlCls;
        public string CtrlCls
        {
            get => _CtrlCls;
            set => Set(ref _CtrlCls, value);
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

        private long _Id;
        public long Id
        {
            get => _Id;
            set => Set(ref _Id, value);
        }

        private string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }
    }
    public interface IPopFldRepo
    {
        //PopFld GetPopFld(string frwId, string frmId, string popId, string fldNm);
        List<PopFld> GetPopColumnProperties(string frwId, string frmId, string popId);
        void Add(PopFld popFld);
        void Update(PopFld popFld);
        void Delete(PopFld popFld);
    }
    public class PopFldRepo : IPopFldRepo
    {
//        public PopFld GetPopFld(string frwId, string frmId, string popId, string fldNm)
//        {
//            string sql = @"
//select a.FrwId, a.FrmId, a.PopId, a.FldNm,
//       a.FldTy, a.FldX, a.FldY, a.FldWidth,
//       a.FldTitleWidth, a.FldTitle, a.TitleAlign, a.Popup, a.DefaultText,
//       a.TextAlign, a.FixYn, a.GroupYn, a.ShowYn, a.NeedYn,
//       a.EditYn, a.Band1, a.Band2, a.FuncStr, a.FormatStr,
//       a.ColorFont, a.ColorBg, a.ToolNm, a.Seq, a.Id,
//       a.Memo, a.CId, a.CDt, a.MId, a.MDt
//  from POPFLD a
// where 1=1
//   and a.FrwId = @FrwId
//   and a.FrmId = @FrmId
//   and a.PopId = @PopId
//   and a.FldNm = @FldNm
//";
//            using (var db = new GaiaHelper())
//            {
//                var result = db.Query<PopFld>(sql, new { FrwId = frwId, FrmId = frmId, PopId = popId, FldNm = fldNm }).SingleOrDefault();

//                if (result == null)
//                {
//                    return null;
//                }
//                else
//                {
//                    result.ChangedFlag = MdlState.None;
//                    return result;
//                }
//            }
//        }

        public List<PopFld> GetPopColumnProperties(string frwId, string frmId, string popId)
        {
            string sql = @"
select a.FrwId, a.FrmId, a.PopId, a.FldNm,
       a.FldTy, a.FldX, a.FldY, a.FldWidth,
       a.FldTitleWidth, a.FldTitle, a.TitleAlign, a.Popup, a.DefaultText,
       a.TextAlign, a.FixYn, a.GroupYn, a.ShowYn, a.NeedYn,
       a.EditYn, a.Band1, a.Band2, a.FuncStr, a.FormatStr,
       a.ColorFont, a.ColorBg, a.ToolNm, a.Seq, a.Id,
       a.Memo, a.CId, a.CDt, a.MId, a.MDt
  from POPFLD a
 where 1=1
   and a.FrwId = @FrwId
   and a.FrmId = @FrmId
   and a.PopId = @PopId
";
            using (var db = new GaiaHelper())
            {
                var result = db.Query<PopFld>(sql, new { FrwId = frwId, FrmId = frmId, PopId = popId });

                if (result == null)
                {
                    return null;
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

        public void Add(PopFld popFld)
        {
            string sql = @"
";
        }
        public void Update(PopFld popFld)
        {
            string sql = @"
";
        }
        public void Delete(PopFld popFld)
        {
            string sql = @"
";
        }
    }
}
