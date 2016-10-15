
namespace OBALog.Business
{
    public class BL_UserAccessType
    {
        public int insert(OBALog.Model.ML_UserAccessType uat)
        {
            return new OBALog.Data.DL_UserAccessType().insert(uat);
        }

        public bool update(OBALog.Model.ML_UserAccessType uat)
        {
            return new OBALog.Data.DL_UserAccessType().update(uat);
        }

        public System.Data.DataTable select(OBALog.Model.ML_UserAccessType uat)
        {
            return new OBALog.Data.DL_UserAccessType().select(uat);
        }
        public System.Data.DataTable selectUserPrivilege(OBALog.Model.ML_UserAccessType uat)
        {
            return new OBALog.Data.DL_UserAccessType().selectUserPrivilege(uat);
        }
        public int selectUsage(OBALog.Model.ML_UserAccessType uat)
        {
            return new OBALog.Data.DL_UserAccessType().selectUsage(uat);
        }

        public bool delete(OBALog.Model.ML_UserAccessType uat)
        {
            return new OBALog.Data.DL_UserAccessType().delete(uat);
        }

        public System.Data.DataTable selectAll(Model.ML_UserAccessType uat)
        {
            return new OBALog.Data.DL_UserAccessType().selectAll(uat);
        }

    }
}
