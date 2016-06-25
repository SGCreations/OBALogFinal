using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Data
{
    public class DL_Profession
    {
        public int insert(OBALog.Model.ML_Profession profession)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Profession", profession.Profession);
            para[1] = new MySqlParameter("@UserKey", profession.UserKey);
            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO profession (Profession, UserKey) VALUES (@Profession, @UserKey); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_Profession profession)
        {
            MySqlParameter[] para = new MySqlParameter[3];
            para[0] = new MySqlParameter("@Profession", profession.Profession);
            para[1] = new MySqlParameter("@UserKey", profession.UserKey);
            para[2] = new MySqlParameter("@Key", profession.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE profession SET `Profession` = @Profession, `UserKey` = @UserKey WHERE `Key` = @Key", para);
            return true;
        }

        public DataTable select(OBALog.Model.ML_Profession profession)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Profession", profession.Profession);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, Profession, UserKey FROM profession WHERE Profession = COALESCE(@Profession, Profession)", para);
        }

        public int selectUsage(OBALog.Model.ML_Profession profession)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", profession.Key);

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM member WHERE ProfessionKey = @Key", para));
        }

        public bool delete(OBALog.Model.ML_Profession profession)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", profession.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM profession WHERE `Key` = @Key;", para);
            return true;
        }
    }
}
