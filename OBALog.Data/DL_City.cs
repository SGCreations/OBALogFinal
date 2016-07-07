using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace OBALog.Data
{
    public class DL_City
    {
        public int insert(OBALog.Model.ML_City city)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@City", city.City);
            para[1] = new MySqlParameter("@CountryKey", city.CountryKey);

            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO city (City,CountryKey) VALUES (@City,@CountryKey); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_City city)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@City", city.City);
            para[1] = new MySqlParameter("@Key", city.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE city SET `City` = @City WHERE `Key` = @Key", para);
            return true;
        }


        public DataTable selectByCountry(OBALog.Model.ML_City city)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@CountryKey", city.CountryKey);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT c.`Key` AS CountryKey, c.Country, ct.`Key` AS CityKey, ct.City FROM city ct JOIN country c ON ct.CountryKey = c.`Key` WHERE ct.CountryKey = COALESCE(@CountryKey, ct.CountryKey)", para);
        }

        public int selectUsage(OBALog.Model.ML_City city)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", city.Key);

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM address a JOIN city c ON a.CityKey = c.`KEY` WHERE c.`Key` = @Key", para));
        }

        public bool delete(OBALog.Model.ML_City city)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", city.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM city WHERE `Key` = @Key;", para);
            return true;
        }

        public bool deleteByCountry(Model.ML_City city)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@CountryKey", city.CountryKey);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM city WHERE `CountryKey` = @CountryKey;", para);
            return true;
        }

        public DataTable select(Model.ML_City city)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@City", city.City);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT c.`KEY` AS CountryKey, c.country, ct.`KEY` AS CityKey, ct.city FROM stc_oba.city ct JOIN country c ON ct.CountryKey = c.`KEY` WHERE city = COALESCE(@City, city)", para);
        }
    }
}
