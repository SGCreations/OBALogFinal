
namespace OBALog.Business
{
    public class BL_User
    {
        public int insert(OBALog.Model.ML_User user)
        {
            return new OBALog.Data.DL_User().insert(user);
        }

        public bool update(OBALog.Model.ML_User user)
        {
            return new OBALog.Data.DL_User().update(user);
        }
        public bool resetPassword(OBALog.Model.ML_User user)
        {
            return new OBALog.Data.DL_User().resetPassword(user);
        }
        public bool delete(OBALog.Model.ML_User user)
        {
            return new OBALog.Data.DL_User().delete(user);
        }

        public System.Data.DataTable selectAll(OBALog.Model.ML_User user)
        {
            return new OBALog.Data.DL_User().selectAll(user);
        }

        public System.Data.DataTable selectUsage(OBALog.Model.ML_User user)
        {
            return new OBALog.Data.DL_User().selectUsage(user);
        }

        public System.Data.DataSet checkLogin(OBALog.Model.ML_User user)
        {
            return new OBALog.Data.DL_User().checkLogin(user);
        }
    }
}