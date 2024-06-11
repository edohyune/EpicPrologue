using System.Text.RegularExpressions;
using Match = System.Text.RegularExpressions.Match;

namespace ER000.Lib.Syntax
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

            //Regex oPattern = new Regex(@"@\w+", RegexOptions.IgnoreCase);
            //Regex dPattern = new Regex(@"@_\w+", RegexOptions.IgnoreCase);
            //Regex gPattern = new Regex(@"<\$\w+>", RegexOptions.IgnoreCase);

            Regex oPattern = new Regex(@"@\w+");
            Regex dPattern = new Regex(@"@_\w+");
            Regex gPattern = new Regex(@"<\$\w+>");

            foreach (Match match in dPattern.Matches(query))
            {
                string variableName = match.Value;
                //string variableName = match.Value.ToLower();
                if (!variables.DPatternMatch.ContainsKey(variableName))
                {
                    variables.DPatternMatch[variableName] = null;
                }
            }

            foreach (Match match in oPattern.Matches(query))
            {
                string variableName = match.Value;
                //string variableName = match.Value.ToLower();
                if (!variables.OPatternMatch.ContainsKey(variableName) && !variables.DPatternMatch.ContainsKey(variableName))
                {
                    variables.OPatternMatch[variableName] = null;
                }
            }

            foreach (Match match in gPattern.Matches(query))
            {
                string variableName = match.Value;
                //string variableName = match.Value.ToLower();
                if (!variables.GPatternMatch.ContainsKey(variableName))
                {
                    variables.GPatternMatch[variableName] = null;
                }
            }

            return variables;
        }
    }
}


