using Lib.Repo;
using Lib.Syntax;
using System.Text.RegularExpressions;

namespace Lib
{
    public static class GenFunc
    {
        #region Conversion --------------------------------------------------------
        public static int ToInt(this string value, int defaultValue = 0)
        {
            return int.TryParse(value, out int result) ? result : defaultValue;
        }
        public static bool ToBool(this string value, bool defaultValue = false)
        {
            return bool.TryParse(value, out bool result) ? result : defaultValue;
        }
        public static DateTime ToDateTime(this string value, DateTime defaultValue)
        {
            return DateTime.TryParse(value, out DateTime result) ? result : defaultValue;
        }

        public static DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode StrToSelectMode(string selectMode)
        {
            DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode mode = new DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode();
            switch (selectMode)
            {
                case "RowSelect": mode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect; break;
                case "CheckBoxRowSelect": mode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect; break;
                //case "CellSelect": mode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect; break;
                default:
                    mode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect; 
                    break;
            }
            return mode;

        }
        public static DevExpress.Utils.HorzAlignment StrToAlign(string align)
        {
            DevExpress.Utils.HorzAlignment horz = new DevExpress.Utils.HorzAlignment();
            switch (align)
            {
                //case "0": horz = DevExpress.Utils.HorzAlignment.Default; break;
                case "1": horz = DevExpress.Utils.HorzAlignment.Near; break;
                case "2": horz = DevExpress.Utils.HorzAlignment.Center; break;
                case "3": horz = DevExpress.Utils.HorzAlignment.Far; break;
                //case "Default": horz = DevExpress.Utils.HorzAlignment.Default; break;
                case "Left": horz = DevExpress.Utils.HorzAlignment.Near; break;
                case "Center": horz = DevExpress.Utils.HorzAlignment.Center; break;
                case "Right": horz = DevExpress.Utils.HorzAlignment.Far; break;
                default:
                    horz = DevExpress.Utils.HorzAlignment.Default;
                    break;
            }
            return horz;
        }
        public static System.Drawing.Color StrToColor(string colorName)
        {
            return System.Drawing.Color.FromName(colorName);
        }
        #endregion
        #region Null Process ------------------------------------------------------
        public static bool IsNull(this string a) => string.IsNullOrWhiteSpace(a);
        //if(value1.IsNull()) value1 = value2;
        public static string IsNull(this string a, string b) => string.IsNullOrWhiteSpace(a) ? b : a;
        //string val = value1.IsNull("Default Value")
        #endregion
        #region Replace PattenVariable --------------------------------------------
        public static string ReplaceGPatternVariable(string input)
        {
            SQLVariableExtractor extractor = new SQLVariableExtractor();
            SQLSyntaxMatch cvariables = extractor.ExtractVariables(input);

            foreach (var variable in cvariables.GPatternMatch)
            {
                string variableName = variable.Key;

                string pattern = @"<\$(.*?)>";

                Match match = Regex.Match(variableName, pattern);

                if (match.Success)
                {
                    string variableValue = Common.GetValue(match.Groups[1].Value); // Lib.Common에서 값 가져오기
                    //input = input.Replace(variable.ToString(), variableValue);
                    input = input.Replace(variableName, $"'{variableValue}'");
                }
                else
                {
                    input = input.Replace(variableName, @"''");
                }
            }
            return input;
        }
        #endregion
        #region GetSql() GetPopUpSql()---------------------------------------------
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
                    return "";
                }
                else
                {
                    return result;
                }
            }
        }
        #endregion
        #region GetIni(), SetIni() ------------------------------------------------
        public static void SetIni(string key, string value = null)
        {
            string iniFilePath = Common.GetValue("gIniFilePath");
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
            string iniFilePath = Common.GetValue("gIniFilePath");
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
        #endregion

        //문자열 함수 
        public static string GetLastSubstring(string input, char delimiter)
        {
            string[] parts = input.Split(delimiter);
            return parts[^1]; // C# 8.0 이상에서 사용 가능한 인덱스 from end 연산자
        }
        //Form NameSpace를 가져오는 함수 
        public static string GetFormNamespace(string frwId, string frmId)
        {
            FrwFrm frwFrm = new FrwFrmRepo().GetByFrmId(frwId, frmId);
            return frwFrm.NmSpace;
        }
    }
}

