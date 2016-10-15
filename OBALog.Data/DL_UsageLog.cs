using MySql.Data.MySqlClient;
using OBALog.Model;

namespace OBALog.Data
{
    public class DL_UsageLog
    {
        public int insert(ML_UsageLog UsageLog)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@UserKey", UsageLog.UserKey);
            para[1] = new MySqlParameter("@From", UsageLog.From);

            return (int)MySQLHelper.ExecuteScalar(DBConnection.connectionString, System.Data.CommandType.Text, "INSERT INTO usagelog (`UserKey`, `From`) VALUES (@UserKey , @From); SELECT @@identity", para);
        }

        public System.Data.DataTable selectByUser(ML_UsageLog UsageLog, int RowCount)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@UserKey", UsageLog.UserKey);
            para[1] = new MySqlParameter("@RowCount", RowCount);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT `Key`, UserKey, `From`, `To` FROM stc_oba.usagelog WHERE UserKey = @UserKey LIMIT @RowCount", para);
        }

        public System.Data.DataTable selectAll()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT `Key`, UserKey, `From`, `To` FROM stc_oba.usagelog");
        }

        public bool update(ML_UsageLog UsageLog)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Key", UsageLog.Key);
            para[1] = new MySqlParameter("@To", UsageLog.To);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, System.Data.CommandType.Text, "UPDATE stc_oba.usagelog SET`To` = @To WHERE `Key` = @Key", para);
            return true;
        }

        public bool delete(ML_UsageLog UsageLog)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", UsageLog.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, System.Data.CommandType.Text, "DELETE FROM stc_oba.usagelog WHERE `Key` = @Key", para);
            return true;
        }
    }
}
