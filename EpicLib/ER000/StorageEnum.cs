namespace ER000.Lib
{
    public enum ModelState
    {
        None,
        Inserted,
        Updated,
        Deleted
    }
    public enum WrkSetState
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
