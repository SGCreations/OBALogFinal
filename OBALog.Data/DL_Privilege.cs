
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace OBALog.Data
{
    public class DL_Privilege
    {
        public bool setPrivilege(OBALog.Model.ML_Privilege privilege)
        {
            MySqlParameter[] para = new MySqlParameter[3];
            para[0] = new MySqlParameter("@UserAccesstypeKey", privilege.UserAccessTypeKey);
            para[1] = new MySqlParameter("@PrivilegeKey", privilege.PrivilegeKey);
            para[2] = new MySqlParameter("@Allowed", privilege.Allowed);

            int count = Convert.ToInt32(MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(`Key`) AS Count FROM stc_oba.useraccessprivilege WHERE UserAccesstypeKey = @UserAccesstypeKey AND PrivilegeKey = @PrivilegeKey;", para).Rows[0]["Count"].ToString());

            if (count == 0)
            {
                MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO useraccessprivilege ( UserAccessTypeKey ,PrivilegeKey ,Allowed ) VALUES ( @UserAccessTypeKey ,@PrivilegeKey ,@Allowed )", para);
            }
            else
            {
                MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE useraccessprivilege SET Allowed = @Allowed WHERE UserAccessTypeKey = @UserAccessTypeKey AND PrivilegeKey = @PrivilegeKey;", para);
            }

            return true;
        }

        public DataTable selectByUAT(int UserAccessTypeKey)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@UserAccessTypeKey", UserAccessTypeKey);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT * FROM useraccessprivilege u LEFT JOIN privilege p ON u.PrivilegeKey = p.`KEY` WHERE u.UserAccesstypeKey = COALESCE(@UserAccessTypeKey, UserAccesstypeKey) ORDER BY p.Privilege ASC", para);
        }

        public DataTable selectFilters()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT DISTINCT SUBSTRING_INDEX(p.Privilege, '.', 1) AS Privilege FROM privilege p ORDER BY p.privilege");
        }
    }
}
