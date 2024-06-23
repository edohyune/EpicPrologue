namespace Lib
{
    public enum RegexStr
    {
        OPattern,
        DPattern,
        GPattern,
        CPattern
    }
    public static class RegexStrs
    {
        public static readonly Dictionary<RegexStr, string> Lists = new Dictionary<RegexStr, string>
        {
            { RegexStr.OPattern, @"@\w+" },
            { RegexStr.DPattern, @"@_\w+" },
            { RegexStr.GPattern, @"<\$(\w+)>" },
            { RegexStr.CPattern, @"andif\s+(.+?)\s+endif" }
        };
    }

    public enum LookUpType
    {
        None,
        Code,
        SubCode,
        PopUp
    }
    public enum MdlState
    {
        None,
        Inserted,
        Updated,
        Deleted
    }
    public enum UserType
    {
        None = 0,
        RealUser = 1,
        DeputyUser = 2
    }
    public enum UserClass
    {
        SuperVisorOfGAIA,
        GAIADEV,
        Tourist
    }
    public enum FrmType
    {
        Development, 
        operation
    }
}
