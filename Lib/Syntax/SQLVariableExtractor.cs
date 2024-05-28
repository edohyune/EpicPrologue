using System.Drawing;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;
using System.Text.RegularExpressions;
using Match = System.Text.RegularExpressions.Match;

namespace Lib.Syntax
{
    public class SQLSyntaxMatch
    {
        public Dictionary<string, string> OPatternMatch { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> DPatternMatch { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> GPatternMatch { get; set; } = new Dictionary<string, string>();
    }

    public class SQLVariableExtractor
    {
        public SQLSyntaxMatch ExtractVariables(string query)
        {
            SQLSyntaxMatch variables = new SQLSyntaxMatch();

            // ORM 변수 패턴 (@로 시작해서 공백이 나오기 전까지)
            Regex oPattern = new Regex(@"@\w+", RegexOptions.IgnoreCase);
            // DECLARE 변수 패턴 (@_로 시작해서 공백이 나오기 전까지)
            Regex dPattern = new Regex(@"@_\w+", RegexOptions.IgnoreCase);
            // 글로벌 변수 패턴 (<$로 시작해서 >까지)
            Regex gPattern = new Regex(@"<\$\w+>", RegexOptions.IgnoreCase);

            // DECLARE 변수 추출 (먼저 추출하여 ORM 변수에서 제외)
            foreach (Match match in dPattern.Matches(query))
            {
                string variableName = match.Value.ToLower();
                if (!variables.DPatternMatch.ContainsKey(variableName))
                {
                    variables.DPatternMatch[variableName] = null;
                }
            }

            // ORM 변수 추출 (DECLARE 변수 제외)
            foreach (Match match in oPattern.Matches(query))
            {
                string variableName = match.Value.ToLower();
                if (!variables.OPatternMatch.ContainsKey(variableName) && !variables.DPatternMatch.ContainsKey(variableName))
                {
                    variables.OPatternMatch[variableName] = null;
                }
            }

            // 글로벌 변수 추출
            foreach (Match match in gPattern.Matches(query))
            {
                string variableName = match.Value.ToLower();
                if (!variables.GPatternMatch.ContainsKey(variableName))
                {
                    variables.GPatternMatch[variableName] = null;
                }
            }

            return variables;
        }
    }
}


