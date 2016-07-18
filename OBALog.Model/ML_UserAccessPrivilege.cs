
namespace OBALog.Model
{
    public class ML_UserAccessPrivilege
    {
        public int Key { get; set; }
        public int UserAccessTypeKey { get; set; }
        public int PrivilegeKey { get; set; }
        //public ML_Privilege Privilege { get; set; }
        public bool Allowed { get; set; }
    }
}
