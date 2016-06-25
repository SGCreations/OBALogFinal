using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Data
{
    public class DL_User
    {
        public int Insert(OBALog.Model.ML_User UsageLog)
        {
            return 0;

        }

        public System.Data.DataTable SelectAll()
        {
            return new System.Data.DataTable();

        }

        public System.Data.DataSet CheckLogin(OBALog.Model.ML_User UsageLog)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@LoginId", UsageLog.LoginId);
            para[1] = new MySqlParameter("@Password", DataHelper.CreateSHA1(UsageLog.Password));

            var a = DataHelper.CreateSHA1(UsageLog.Password);

            return MySQLHelper.ExecuteDataSet(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT usr.`Key`, usr.`LoginId`, usr.`Name`, usr.`NIC`, usr.`UserAccessTypeKey`, u.AccessTypeName FROM `user` usr JOIN useraccesstype u ON usr.UserAccessTypeKey = u.`Key` AND usr.Deleted = FALSE WHERE usr.`LoginId` = @LoginId AND usr.`Password` = @Password AND usr.`Deleted` = FALSE; SELECT p.`Key`, p.privilege, up.Allowed FROM stc_oba.useraccessprivilege up JOIN `user` u ON up.`UserAccessTypeKey` = u.`UserAccessTypeKey` AND u.LoginId = @LoginId AND u.`LoginId` = LoginId AND u.`Deleted` = FALSE JOIN privilege p ON p.`Key` = up.`PrivilegeKey`", para);
        }

        public bool Update(OBALog.Model.ML_User UsageLog)
        {
            return true;

        }

        public bool Delete(OBALog.Model.ML_User UsageLog)
        {
            return true;
        }
    }
}
