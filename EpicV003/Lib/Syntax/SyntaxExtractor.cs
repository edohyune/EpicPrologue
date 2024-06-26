using System.Text.RegularExpressions;
using static DevExpress.Utils.MVVM.Internal.ILReader;
using Match = System.Text.RegularExpressions.Match;

namespace EpicV003.Lib.Syntax
{
    public class SyntaxMatch
    {
        public Dictionary<string, string> OPatternMatch { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> DPatternMatch { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> GPatternMatch { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> CPatternMatch { get; set; } = new Dictionary<string, string>();
    }

    public class SyntaxExtractor
    {
        public SyntaxMatch ExtractVariables(string query)
        {
            SyntaxMatch variables = new SyntaxMatch();

            //Regex oPattern = new Regex(@"@\w+");
            //Regex dPattern = new Regex(@"@_\w+");
            //Regex gPattern = new Regex(@"<\$(\w+)>");
            //Regex cPattern = new Regex(@"andif\s+(.+?)\s+endif");

            Regex oPattern = new Regex(RegexStrs.Lists[RegexStr.OPattern]);
            Regex dPattern = new Regex(RegexStrs.Lists[RegexStr.DPattern]);
            Regex gPattern = new Regex(RegexStrs.Lists[RegexStr.GPattern]);
            Regex cPattern = new Regex(RegexStrs.Lists[RegexStr.CPattern], RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match match in dPattern.Matches(query))
            {
                string variableName = match.Value;
                if (!variables.DPatternMatch.ContainsKey(variableName))
                {
                    variables.DPatternMatch[variableName] = null;
                }
            }

            foreach (Match match in oPattern.Matches(query))
            {
                string variableName = match.Value;
                if (!variables.OPatternMatch.ContainsKey(variableName) && !variables.DPatternMatch.ContainsKey(variableName))
                {
                    variables.OPatternMatch[variableName] = null;
                }
            }

            foreach (Match match in gPattern.Matches(query))
            {
                string variableName = match.Value;
                if (!variables.GPatternMatch.ContainsKey(variableName))
                {
                    variables.GPatternMatch[variableName] = null;
                }
            }

            foreach (Match match in cPattern.Matches(query))
            {
                string variableName = match.Value;
                if (!variables.CPatternMatch.ContainsKey(variableName))
                {
                    variables.CPatternMatch[variableName] = null;
                }
            }

            return variables;
        }

        /// <summary>
        /// Extract Pattern
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="patternSelector">match=>match.OPatternMatch</param>
        /// <returns></returns>
        public static Dictionary<string, string> ExtractPattern(string text, Func<SyntaxMatch, Dictionary<string, string>> patternSelector) 
        { 
            SyntaxExtractor extractor = new SyntaxExtractor(); 
            SyntaxMatch variables = extractor.ExtractVariables(text); 
            return patternSelector(variables); 
        }

        /// <summary>
        /// Remove Pattern from text
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="patternStr">RegexStr.CPattern</param>    
        /// <returns>Modified SQL text</returns>
        public static string RemovePattern(string text, RegexStr patternStr)
        {
            string patternString = RegexStrs.Lists[patternStr];
            Regex regexPattern;// = new Regex(patternString, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (patternStr == RegexStr.CPattern)
            {
                regexPattern = new Regex(patternString, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                text = regexPattern.Replace(text, string.Empty);
            }
            if (patternStr == RegexStr.OPattern)
            {
                regexPattern = new Regex(patternString, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                text = regexPattern.Replace(text, "''");
            }
            return text;
        }
    }
}


