using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class IdNm
    {
        public string Txt { get; set; }
        public object Val { get; set; }

        public override string ToString()
        {
            return Txt;
        }
    }

    public static class GenFunc
    {
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
    }
}

