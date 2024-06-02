using Lib.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public static class GenFunc
    {
        public static bool IsNull(this string a) => string.IsNullOrWhiteSpace(a);
        public static string IsNull(this string a, string b) => string.IsNullOrWhiteSpace(a) ? b : a;

        public static WrkSql GetSql(string frwId, string frmId, string wrkId, string crudm)
        {
            string sql = @"
select a.Query
  from WRKSQL a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.WrkId = @WrkId
   and a.CRUDM = @CRUDM
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.Query<WrkSql>(sql, new { FrwId = frwId, FrmId = frmId, WrkId = wrkId, CRUDM = crudm }).SingleOrDefault();

                if (result == null)
                {
                    result = new WrkSql();
                    result.Query = "";
                    return result;
                }
                else
                {
                    result.ChangedFlag = MdlState.None;
                    return result;
                }
            }
        }

        public static string GetSql(object param)
        {
            string sql = @"
select a.Query
  from WRKSQL a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.WrkId = @WrkId
   and a.CRUDM = @CRUDM
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.OpenQuery(sql, param);
                if (result == null)
                {
                    return "";
                }
                else
                {
                    return result;
                }
            }
        }
        public static string GetPopSql(object param)
        {
            string sql = @"
select a.Query
  from POPSQL a
 where 1=1
   and a.FrmId = @FrmId
   and a.FrwId = @FrwId
   and a.PopId = @PopId
";
            using (var db = new Lib.GaiaHelper())
            {
                var result = db.OpenQuery(sql, param);
                if (result == null)
                {
                    //return "";
                    //                    result = @"
                    //select FldId='TEST01', FldNm='TEST11', Dt='A1', Col01='B1', Col02='C1' union
                    //select FldId='TEST02', FldNm='TEST12', Dt='A2', Col01='B2', Col02='C2' union
                    //select FldId='TEST03', FldNm='TEST13', Dt='A3', Col01='B3', Col02='C3' union
                    //select FldId='TEST04', FldNm='TEST14', Dt='A4', Col01='B4', Col02='C4' union
                    //select FldId='TEST05', FldNm='TEST15', Dt='A5', Col01='B5', Col02='C5' union
                    //select FldId='TEST06', FldNm='TEST16', Dt='A6', Col01='B6', Col02='C6' 
                    //";
                    result = @"
select FldId='TEST01' union
select FldId='TEST02' union
select FldId='TEST03' union
select FldId='TEST04' union
select FldId='TEST05' union
select FldId='TEST06' 
";
                    return result;
                }
                else
                {
                    result = @"
select FldId='TEST01' union
select FldId='TEST02' union
select FldId='TEST03' union
select FldId='TEST04' union
select FldId='TEST05' union
select FldId='TEST06' 
";
                    return result;
                }
            }
        }
        public static void SetIni(string key, string value = null)
        {
            string iniFilePath = Common.gIniFilePath;
            if (string.IsNullOrEmpty(iniFilePath))
            {
                throw new Exception("환경설정 파일이 지정되지 않았습니다.");
            }

            Dictionary<string, string> settings = new Dictionary<string, string>();
            if (File.Exists(iniFilePath))
            {
                var lines = File.ReadAllLines(iniFilePath);
                foreach (var line in lines)
                {
                    var keyValue = line.Split(new char[] { '=' }, 2);
                    if (keyValue.Length == 2)
                    {
                        settings[keyValue[0]] = keyValue[1];
                    }
                }
            }

            // 새로운 값으로 설정을 업데이트하거나 추가합니다.
            settings[key] = value;

            string directoryPath = Path.GetDirectoryName(iniFilePath);

            // 해당 폴더가 존재하지 않으면 생성합니다.
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // 설정을 파일에 다시 씁니다.
            using (var sw = new StreamWriter(iniFilePath))
            {
                foreach (var setting in settings)
                {
                    sw.WriteLine($"{setting.Key}={setting.Value}");
                }
            }
        }

        public static string GetIni(string settingName)
        {
            string iniFilePath = Common.gIniFilePath;
            // 파일이 존재하지 않으면 null을 반환
            if (!File.Exists(iniFilePath))
            {
                return null;
            }

            // 파일에서 모든 라인을 읽어온다
            var lines = File.ReadAllLines(iniFilePath);
            foreach (var line in lines)
            {
                // 라인을 '=' 기준으로 나눈다
                var keyValue = line.Split(new char[] { '=' }, 2);
                if (keyValue.Length == 2)
                {
                    // 첫 번째 파트가 설정 이름과 일치하면, 두 번째 파트(값)를 반환
                    if (string.Equals(keyValue[0].Trim(), settingName, StringComparison.OrdinalIgnoreCase))
                    {
                        return keyValue[1].Trim();
                    }
                }
            }

            // 설정 이름에 해당하는 값이 없으면 null을 반환
            return null;
        }

        //문자열 함수 
        public static string GetLastSubstring(string input, char delimiter)
        {
            string[] parts = input.Split(delimiter);
            return parts[^1]; // C# 8.0 이상에서 사용 가능한 인덱스 from end 연산자
        }

        public static DevExpress.Utils.HorzAlignment StrToAlign(string align)
        {
            DevExpress.Utils.HorzAlignment horz = new DevExpress.Utils.HorzAlignment();
            switch (align)
            {
                case "0": horz = DevExpress.Utils.HorzAlignment.Default; break;
                case "1": horz = DevExpress.Utils.HorzAlignment.Near; break;
                case "2": horz = DevExpress.Utils.HorzAlignment.Center; break;
                case "3": horz = DevExpress.Utils.HorzAlignment.Far; break;
            }
            return horz;
        }

        public static System.Drawing.Color StrToColor(string colorName)
        {
            return System.Drawing.Color.FromName(colorName);
        }

    }
}

