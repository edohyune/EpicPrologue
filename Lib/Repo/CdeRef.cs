using DevExpress.Pdf.Native.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repo
{
    public class CdeRef : MdlBase
    {
        private string _FrwId;
        public string FrwId
        {
            get => _FrwId;
            set => Set(ref _FrwId, value);
        }

        private string _Cd;
        public string Cd
        {
            get => _Cd;
            set => Set(ref _Cd, value);
        }

        private string _RefNo;
        public string RefNo
        {
            get => _RefNo;
            set => Set(ref _RefNo, value);
        }

        private string _FldTy;
        public string FldTy
        {
            get => _FldTy;
            set => Set(ref _FldTy, value);
        }

        private string _FldTitle;
        public string FldTitle
        {
            get => _FldTitle;
            set => Set(ref _FldTitle, value);
        }

        private string _Popup;
        public string Popup
        {
            get => _Popup;
            set => Set(ref _Popup, value);
        }

        private string _Memo;
        public string Memo
        {
            get => _Memo;
            set => Set(ref _Memo, value);
        }
    }
}
