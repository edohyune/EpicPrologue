using System.Drawing;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;
using System.Text.RegularExpressions;

namespace EpicV003.Lib.Syntax
{
    public class CS_Syntax : ISyntaxHighlightService
    {
        readonly Document document;

        Regex _keywords;
        Regex _quotedString;
        Regex _commentedString;
        public CS_Syntax(Document document)
        {
            this.document = document;

            // C# Keywords
            string[] keywords = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
                "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event",
                "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit",
                "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator",
                "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed",
                "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try",
                "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while" };
            _keywords = new Regex(@"\b(" + string.Join("|", keywords.Select(w => Regex.Escape(w))) + @")\b");

            // Strings
            _quotedString = new Regex(@"@?""([^""\\]|\\.)*""|'([^'\\]|\\.)*'");

            // Comments
            _commentedString = new Regex(@"//.*|/\*[\s\S]*?\*/");
        }
        public void Execute()
        {
            List<SyntaxHighlightToken> cSharpTokens = ParseTokens();
            document.ApplySyntaxHighlight(cSharpTokens);
        }
        public void ForceExecute()
        {
            Execute();
        }
        private List<SyntaxHighlightToken> ParseTokens()
        {
            List<SyntaxHighlightToken> tokens = new List<SyntaxHighlightToken>();

            // search for quoted strings
            DocumentRange[] ranges = document.FindAll(_quotedString).GetAsFrozen() as DocumentRange[];
            for (int i = 0; i < ranges.Length; i++)
            {
                tokens.Add(CreateToken(ranges[i].Start.ToInt(), ranges[i].End.ToInt(), Color.Red));
            }

            //Extract all keywords
            ranges = document.FindAll(_keywords).GetAsFrozen() as DocumentRange[];
            for (int j = 0; j < ranges.Length; j++)
            {
                if (!IsRangeInTokens(ranges[j], tokens))
                    tokens.Add(CreateToken(ranges[j].Start.ToInt(), ranges[j].End.ToInt(), Color.Blue));
            }

            //Find all comments
            ranges = document.FindAll(_commentedString).GetAsFrozen() as DocumentRange[];
            for (int j = 0; j < ranges.Length; j++)
            {
                if (!IsRangeInTokens(ranges[j], tokens))
                    tokens.Add(CreateToken(ranges[j].Start.ToInt(), ranges[j].End.ToInt(), Color.Green));
            }

            // order tokens by their start position
            tokens.Sort(new SyntaxHighlightTokenComparer());

            // fill in gaps in document coverage
            tokens = CombineWithPlainTextTokens(tokens);

            document.BeginUpdate();
            document.DefaultCharacterProperties.FontName = "Cascadia Code Light"; // "Courier New";
            document.DefaultCharacterProperties.FontSize = 10;
            document.EndUpdate();

            return tokens;
        }

        //Parse the remaining text into tokens:
        List<SyntaxHighlightToken> CombineWithPlainTextTokens(List<SyntaxHighlightToken> tokens)
        {
            List<SyntaxHighlightToken> result = new List<SyntaxHighlightToken>(tokens.Count * 2 + 1);
            int documentStart = document.Range.Start.ToInt();
            int documentEnd = document.Range.End.ToInt();
            if (tokens.Count == 0)
                result.Add(CreateToken(documentStart, documentEnd, Color.Black));
            else
            {
                SyntaxHighlightToken firstToken = tokens[0];
                if (documentStart < firstToken.Start)
                    result.Add(CreateToken(documentStart, firstToken.Start, Color.Black));
                result.Add(firstToken);
                for (int i = 1; i < tokens.Count; i++)
                {
                    SyntaxHighlightToken token = tokens[i];
                    SyntaxHighlightToken prevToken = tokens[i - 1];
                    if (prevToken.End != token.Start)
                        result.Add(CreateToken(prevToken.End, token.Start, Color.Black));
                    result.Add(token);
                }
                SyntaxHighlightToken lastToken = tokens[tokens.Count - 1];
                if (documentEnd > lastToken.End)
                    result.Add(CreateToken(lastToken.End, documentEnd, Color.Black));
            }
            return result;
        }

        //Create a token from the retrieved range and specify its forecolor
        SyntaxHighlightToken CreateToken(int start, int end, Color foreColor)
        {
            SyntaxHighlightProperties properties = new SyntaxHighlightProperties();
            properties.ForeColor = foreColor;
            return new SyntaxHighlightToken(start, end - start, properties);
        }

        //Check whether tokens intersect each other
        private bool IsRangeInTokens(DocumentRange range, List<SyntaxHighlightToken> tokens)
        {
            return tokens.Any(t => IsIntersect(range, t));
        }
        bool IsIntersect(DocumentRange range, SyntaxHighlightToken token)
        {
            int start = range.Start.ToInt();
            if (start >= token.Start && start < token.End)
                return true;
            int end = range.End.ToInt() - 1;
            if (end >= token.Start && end < token.End)
                return true;
            if (start < token.Start && end >= token.End)
                return true;
            return false;
        }
    }
    public class SQL_Syntax : ISyntaxHighlightService
    {
        readonly Document document;

        Regex _keywords;
        Regex _quotedString = new Regex(@"'([^']|'')*'");
        Regex _commentedString = new Regex(@"(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/)");
        //Regex _customPattern = new Regex(@"<\$[^>]+>");  // <$로 시작해서 >로 끝나는 패턴
        Regex _customPattern = new Regex(@"@_\w+"); // @_로 시작하는 단어 패턴

        public SQL_Syntax(Document document)
        {
            this.document = document;
            string[] keywords = { "INSERT", "SELECT", "UPDATE", "DELETE", "CREATE",
                                  "TABLE", "USE", "IDENTITY", "ON", "OFF",
                                  "NOT", "NULL", "WITH", "SET", "GO",
                                  "DECLARE", "EXECUTE", "EXEC", "NVARCHAR", "FROM",
                                  "INTO", "VALUES", "WHERE", "AND" };
            _keywords = new Regex(@"\b(" + string.Join("|", keywords.Select(w => Regex.Escape(w))) + @")\b", RegexOptions.IgnoreCase);
        }
        public void ForceExecute()
        {
            Execute();
        }
        public void Execute()
        {
            List<SyntaxHighlightToken> tSqltokens = ParseTokens();
            document.ApplySyntaxHighlight(tSqltokens);
        }

        private List<SyntaxHighlightToken> ParseTokens()
        {
            List<SyntaxHighlightToken> tokens = new List<SyntaxHighlightToken>();

            // search for quoted strings
            DocumentRange[] ranges = document.FindAll(_quotedString).GetAsFrozen() as DocumentRange[];
            for (int i = 0; i < ranges.Length; i++)
            {
                tokens.Add(CreateToken(ranges[i].Start.ToInt(), ranges[i].End.ToInt(), Color.Red));
            }

            //Extract all keywords
            ranges = document.FindAll(_keywords).GetAsFrozen() as DocumentRange[];
            for (int j = 0; j < ranges.Length; j++)
            {
                if (!IsRangeInTokens(ranges[j], tokens))
                    tokens.Add(CreateToken(ranges[j].Start.ToInt(), ranges[j].End.ToInt(), Color.Blue));
            }

            //Find all comments
            ranges = document.FindAll(_commentedString).GetAsFrozen() as DocumentRange[];
            for (int j = 0; j < ranges.Length; j++)
            {
                if (!IsRangeInTokens(ranges[j], tokens))
                    tokens.Add(CreateToken(ranges[j].Start.ToInt(), ranges[j].End.ToInt(), Color.Green));
            }

            //Find all custom patterns
            ranges = document.FindAll(_customPattern).GetAsFrozen() as DocumentRange[];
            for (int j = 0; j < ranges.Length; j++)
            {
                if (!IsRangeInTokens(ranges[j], tokens))
                    tokens.Add(CreateToken(ranges[j].Start.ToInt(), ranges[j].End.ToInt(), Color.Magenta)); // 원하는 색상으로 변경
            }

            // order tokens by their start position
            tokens.Sort(new SyntaxHighlightTokenComparer());

            // fill in gaps in document coverage
            tokens = CombineWithPlainTextTokens(tokens);

            document.BeginUpdate();
            document.DefaultCharacterProperties.FontName = "Cascadia Code Light"; // "Courier New";
            document.DefaultCharacterProperties.FontSize = 10;
            document.EndUpdate();

            return tokens;
        }

        //Parse the remaining text into tokens:
        List<SyntaxHighlightToken> CombineWithPlainTextTokens(List<SyntaxHighlightToken> tokens)
        {
            List<SyntaxHighlightToken> result = new List<SyntaxHighlightToken>(tokens.Count * 2 + 1);
            int documentStart = document.Range.Start.ToInt();
            int documentEnd = document.Range.End.ToInt();
            if (tokens.Count == 0)
                result.Add(CreateToken(documentStart, documentEnd, Color.Black));
            else
            {
                SyntaxHighlightToken firstToken = tokens[0];
                if (documentStart < firstToken.Start)
                    result.Add(CreateToken(documentStart, firstToken.Start, Color.Black));
                result.Add(firstToken);
                for (int i = 1; i < tokens.Count; i++)
                {
                    SyntaxHighlightToken token = tokens[i];
                    SyntaxHighlightToken prevToken = tokens[i - 1];
                    if (prevToken.End != token.Start)
                        result.Add(CreateToken(prevToken.End, token.Start, Color.Black));
                    result.Add(token);
                }
                SyntaxHighlightToken lastToken = tokens[tokens.Count - 1];
                if (documentEnd > lastToken.End)
                    result.Add(CreateToken(lastToken.End, documentEnd, Color.Black));
            }
            return result;
        }

        //Create a token from the retrieved range and specify its forecolor
        SyntaxHighlightToken CreateToken(int start, int end, Color foreColor)
        {
            SyntaxHighlightProperties properties = new SyntaxHighlightProperties();
            properties.ForeColor = foreColor;
            return new SyntaxHighlightToken(start, end - start, properties);
        }

        //Check whether tokens intersect each other
        private bool IsRangeInTokens(DocumentRange range, List<SyntaxHighlightToken> tokens)
        {
            return tokens.Any(t => IsIntersect(range, t));
        }
        bool IsIntersect(DocumentRange range, SyntaxHighlightToken token)
        {
            int start = range.Start.ToInt();
            if (start >= token.Start && start < token.End)
                return true;
            int end = range.End.ToInt() - 1;
            if (end >= token.Start && end < token.End)
                return true;
            if (start < token.Start && end >= token.End)
                return true;
            return false;
        }
    }

    //Compare token's initial positions to sort them
    public class SyntaxHighlightTokenComparer : IComparer<SyntaxHighlightToken>
    {
        public int Compare(SyntaxHighlightToken x, SyntaxHighlightToken y)
        {
            return x.Start - y.Start;
        }
    }
}
