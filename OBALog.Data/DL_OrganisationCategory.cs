using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace OBALog.Data
{
    public class DL_OrganisationCategory
    {
        public int insert(OBALog.Model.ML_OrganisationCategory category)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@OrganisationCategory", category.Category);
            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO category (Category) VALUES (@Category); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_OrganisationCategory category)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Category", category.Category);
            para[1] = new MySqlParameter("@Key", category.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE category SET `Category` = @Category WHERE `Key` = @Key", para);
            return true;
        }

        public DataTable select(OBALog.Model.ML_OrganisationCategory category)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Category", category.Category);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, Category FROM category WHERE Category = COALESCE(@Category, Category)", para);
        }

        public int selectUsage(OBALog.Model.ML_OrganisationCategory category)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", category.Key);

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM category cn JOIN city c ON cn.`Key` = c.Category JOIN address a ON c.`Key` = a.CategoryKey WHERE cn.Category = @Category", para));
        }

        public bool delete(OBALog.Model.ML_OrganisationCategory category)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", category.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM category WHERE `Key` = @Key;", para);
            return true;
        }
    }
}
