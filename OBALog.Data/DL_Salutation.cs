using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace OBALog.Data
{
    public class DL_Salutation
    {
        public int insert(OBALog.Model.ML_Salutation salutation)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Salutation", salutation.Salutation);
            para[1] = new MySqlParameter("@UserKey", salutation.UserKey);
            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO salutation (Salutation, UserKey) VALUES (@Salutation, @UserKey); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_Salutation salutation)
        {
            MySqlParameter[] para = new MySqlParameter[3];
            para[0] = new MySqlParameter("@Salutation", salutation.Salutation);
            para[1] = new MySqlParameter("@UserKey", salutation.UserKey);
            para[2] = new MySqlParameter("@Key", salutation.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE salutation SET `Salutation` = @Salutation, `UserKey` = @UserKey WHERE `Key` = @Key", para);
            return true;
        }

        public DataTable select(OBALog.Model.ML_Salutation salutation)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Salutation", salutation.Salutation);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, Salutation, UserKey FROM salutation WHERE Salutation = COALESCE(@Salutation, Salutation)", para);
        }

        public int selectUsage(OBALog.Model.ML_Salutation salutation)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", salutation.Key);

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM member WHERE SalutationKey = @Key", para));
        }

        public bool delete(OBALog.Model.ML_Salutation salutation)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", salutation.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM salutation WHERE `Key` = @Key;", para);
            return true;
        }
    }
}
