using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Common
    {
        public static string gSysCd = string.Empty;  //시스템코드
        //최상위 시스템 GAIA

        //GAIA 개발자 - 모든 시스템의 프레임워크를 개발한다. 
        //프레임워크는 프로젝트별로 생성된다. 
        public static string gId = string.Empty;           //로그인 ID - varchar
        public static int? gRegId = null;           //로그인 ID - int
        public static string gNm = string.Empty;           //로그인 이름
        public static string gCls = string.Empty;          //사용자 구분

        //EMAX용 프레임워크, Lao Goverment용 프레임워크 등
        public static string gFrameWorkId = string.Empty;  //GAIA에서 생산하는 모든 프레임 워크

        //사용자의 환경설정 파일
        // 사용자 프로필 폴더의 경로를 동적으로 가져옵니다.
        public static string gUserProfilePath = string.Empty;
        public static string gIniFilePath = string.Empty;
                
        //public static string gSysNm = string.Empty;

        //public static string gEmpId = string.Empty;
        //public static string gEmpNm = string.Empty;
        //public static string gUserId = string.Empty;
        //public static string gUserNm = string.Empty;
        //public static string gCompId = string.Empty;
        //public static string gCompNm = string.Empty;
        //public static string gPlantId = string.Empty;
        //public static string gPlantNm = string.Empty;
        //public static string gDeptId = string.Empty;
        //public static string gDeptNm = string.Empty;
        //public static string codeBase = string.Empty;


        //public static string gLanguage = "English";
        //public static string gSkin = "Office 2010 Silver";
        //public static string MenuStyle = "1";                   //1:Tree Menu / 2:NavBar

        //public static string gSubId = string.Empty;
        //public static string gSubNm = string.Empty;

        //public static string gSubSysCd = string.Empty;
        //public static string gSubSysNm = string.Empty;

        //public static UserType gSignType = UserType.None;


        ////--------------------------------------
        ////Program
        ////--------------------------------------
        //public static string gSolution = string.Empty;

        //public static string gDirRoot = string.Empty;
        //public static string gDirEntry = string.Empty;
        //public static string gDirBuild = string.Empty;
        //public static string gDirWork = string.Empty;

        //public static string gSVR = string.Empty;
        //public static string gFTP = string.Empty;
        //public static string gFTPDir = string.Empty;
        //public static string gFTPCoreDir = string.Empty;
        //public static string gFTP_ID = string.Empty;
        //public static string gFTP_PWD = string.Empty;

        //public static string gThisFrm = string.Empty;
        public static string gOpenFrm = string.Empty;




        //BarItemMessage
        public static bool gTrackMsg = false;
        public static event EventHandler gMsgChanged;
        private static string _gMsg;
        public static string gMsg
        {
            get { return _gMsg; }
            set
            {
                if (value != _gMsg)
                {
                    _gMsg = value;

                    if (gMsgChanged != null)
                    {
                        gMsgChanged(value, EventArgs.Empty);
                    }

                }
            }
        }

        //FormDesigner Log
        public static bool gTrackLog = false;
        public static event EventHandler gLogChanged;
        private static string _gLog;
        public static string gLog
        {
            get { return _gLog; }
            set
            {
                if (value != _gLog)
                {
                    _gLog = value;

                    if (gLogChanged != null)
                    {
                        gLogChanged(value, EventArgs.Empty);
                    }

                }
            }
        }
    }
}
