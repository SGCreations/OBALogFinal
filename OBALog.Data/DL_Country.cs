using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace OBALog.Data
{
    public class DL_Country
    {
        public int insert(OBALog.Model.ML_Country country)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Country", country.Country);
            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO country (Country) VALUES (@Country); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_Country country)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Country", country.Country);
            para[1] = new MySqlParameter("@Key", country.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE country SET `Country` = @Country WHERE `Key` = @Key", para);
            return true;
        }

        public DataTable select(OBALog.Model.ML_Country country)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Country", country.Country);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, Country FROM country WHERE Country = COALESCE(@Country, Country)", para);
        }

        public int selectUsage(OBALog.Model.ML_Country country)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", country.Key);

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM address a JOIN city c ON a.CityKey = c.`KEY` JOIN country c1 ON c.CountryKey = c1.`KEY` WHERE c1.`KEY` = @Key", para));
        }

        public bool delete(OBALog.Model.ML_Country country)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", country.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM country WHERE `Key` = @Key;", para);
            return true;
        }
    }
}
