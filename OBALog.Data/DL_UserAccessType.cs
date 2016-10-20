
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace OBALog.Data
{
    public class DL_UserAccessType
    {

        public int insert(OBALog.Model.ML_UserAccessType uat)
        {
            MySqlParameter[] para = new MySqlParameter[3];
            para[0] = new MySqlParameter("@AccessTypeName", uat.AccessTypeName);
            para[1] = new MySqlParameter("@UserKey", uat.UserKey);
            para[2] = new MySqlParameter("@UpdatedDate", uat.UpdatedDate);

            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO useraccesstype (AccessTypeName, UserKey, UpdatedDate, Deleted) VALUES (@AccessTypeName, @UserKey, @UpdatedDate, 0); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_UserAccessType uat)
        {
            MySqlParameter[] para = new MySqlParameter[4];
            para[0] = new MySqlParameter("@AccessTypeName", uat.AccessTypeName);
            para[1] = new MySqlParameter("@UserKey", uat.UserKey);
            para[2] = new MySqlParameter("@Key", uat.Key);
            para[3] = new MySqlParameter("@UpdatedDate", uat.UpdatedDate);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE useraccesstype SET `AccessTypeName` = @AccessTypeName, `UserKey` = @UserKey, UpdatedDate = @UpdatedDate WHERE `Key` = @Key AND `Deleted`= False", para);
            return true;
        }

        public DataTable select(OBALog.Model.ML_UserAccessType uat)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@AccessTypeName", uat.AccessTypeName);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, AccessTypeName, UserKey, UpdatedDate, Deleted FROM useraccesstype WHERE AccessTypeName = COALESCE(@AccessTypeName, AccessTypeName) AND `Deleted` = False", para);
        }

        public int selectUsage(OBALog.Model.ML_UserAccessType uat)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", uat.Key);

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM member WHERE UserAccessTypeKey = @Key", para));
        }

        public DataTable selectUserPrivilege(OBALog.Model.ML_UserAccessType uat)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@UserAccessTypeKey", uat.Key);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT DISTINCT pr.`Key`, pr.Privilege, u.Allowed, p.Category, p.Priority FROM privilege pr LEFT OUTER JOIN useraccessprivilege u ON pr.`Key` = u.PrivilegeKey AND u.UserAccesstypeKey = @UserAccessTypeKey JOIN privilegeclass p ON pr.PrivilegeClassKey = p.`Key` ORDER BY p.Priority ASC, privilege ASC", para);
        }

        public bool delete(OBALog.Model.ML_UserAccessType uat)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Key", uat.Key);
            para[1] = new MySqlParameter("@UserKey", uat.UserKey);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE useraccesstype SET `Deleted` = True, UserKey = @UserKey WHERE `Key` = @Key", para);
            return true;
        }

        public DataTable selectAll(Model.ML_UserAccessType uat)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@AccessTypeName", uat.AccessTypeName);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, AccessTypeName, UserKey, UpdatedDate, Deleted FROM useraccesstype WHERE AccessTypeName = COALESCE(@AccessTypeName, AccessTypeName)", para);
        }
    }
}
