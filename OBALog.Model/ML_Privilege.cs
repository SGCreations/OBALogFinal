
namespace OBALog.Model
{
    public class ML_Privilege
    {
        public int UserAccessTypeKey { get; set; }
        public string Privilege { get; set; }
        public string Description { get; set; }
        public int PrivilegeKey { get; set; }
        public bool Allowed { get; set; }

    }
}
