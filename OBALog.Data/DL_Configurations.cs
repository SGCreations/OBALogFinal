using MySql.Data.MySqlClient;
using System.Data;

namespace OBALog.Data
{
    public class DL_Configurations
    {
        public bool update(OBALog.Model.ML_Configurations config)
        {
            MySqlParameter[] para = new MySqlParameter[4];
            para[0] = new MySqlParameter("@ConfigurationName", config.ConfigurationName);
            para[1] = new MySqlParameter("@ConfigurationValue", config.ConfigurationValue);
            para[2] = new MySqlParameter("@Description", config.Description);
            para[3] = new MySqlParameter("@UserKey", config.UserKey);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE configurations SET ConfigurationValue = @ConfigurationValue ,Description = @Description ,UserKey = @UserKey ,UpdatedDate = NOW() WHERE ConfigurationName = @ConfigurationName", para);
            return true;
        }

        public DataTable select()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT cnf.`Key`, cnf.ConfigurationName, cnf.ConfigurationValue, cnf.Description, cnf.UserKey, u.LoginId, u.`Name`, cnf.UpdatedDate FROM stc_oba.configurations cnf LEFT OUTER JOIN `user` u ON cnf.UserKey = u.`Key`");
        }

    }
}
