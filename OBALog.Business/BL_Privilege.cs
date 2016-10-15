
namespace OBALog.Business
{
    public class BL_Privilege
    {
        public bool setPrivilege(OBALog.Model.ML_Privilege privilege)
        {
            return new OBALog.Data.DL_Privilege().setPrivilege(privilege);
        }

        public System.Data.DataTable selectByUAT(int UserAccessTypeKey)
        {
            return new OBALog.Data.DL_Privilege().selectByUAT(UserAccessTypeKey);

        }

        public System.Data.DataTable selectFilters()
        {
            return new OBALog.Data.DL_Privilege().selectFilters();
        }
    }
}
