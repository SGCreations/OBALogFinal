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
            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO organisationcategory (Category) VALUES (@OrganisationCategory); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_OrganisationCategory category)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Category", category.Category);
            para[1] = new MySqlParameter("@Key", category.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE organisationcategory SET `Category` = @Category WHERE `Key` = @Key", para);
            return true;
        }

        public DataTable select(OBALog.Model.ML_OrganisationCategory category)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Category", category.Category);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, Category FROM organisationcategory WHERE Category = COALESCE(@Category, Category)", para);
        }

        public int selectUsage(OBALog.Model.ML_OrganisationCategory category)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", category.Key);

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM organisationcategory o JOIN organisationsubcategory o1 ON o.`KEY` = o1.CategoryKey JOIN organisation o2 ON o1.`Key` = o2.SubCategoryKey WHERE o.`KEY` = @Key", para));
        }

        public bool delete(OBALog.Model.ML_OrganisationCategory category)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", category.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM organisationcategory WHERE `Key` = @Key;", para);
            return true;
        }
    }
}
