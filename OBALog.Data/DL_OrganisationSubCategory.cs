using MySql.Data.MySqlClient;
using OBALog.Model;
using System;
using System.Data;

namespace OBALog.Data
{
    public class DL_OrganisationSubCategory
    {

        public int insert(ML_OrganisationSubCategory subCategory)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@SubCategory", subCategory.SubCategory);
            para[1] = new MySqlParameter("@CategoryKey", subCategory.CategoryKey);

            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO organisationsubcategory (CategoryKey, SubCategory) VALUES (@CategoryKey,@SubCategory); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public System.Data.DataTable selectByCategory(ML_OrganisationSubCategory subCategory)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@CategoryKey", subCategory.CategoryKey);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT o1.`KEY` AS CategoryKey, o1.Category, o.`KEY` AS SubCategoryKey, o.SubCategory FROM organisationsubcategory o JOIN organisationcategory o1 ON o.CategoryKey = o1.`Key` WHERE o.CategoryKey = COALESCE(@CategoryKey, o.CategoryKey)", para);
        }

        public bool delete(ML_OrganisationSubCategory subCategory)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", subCategory.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM organisationsubcategory WHERE `Key` = @Key;", para);
            return true;
        }

        public int selectUsage(ML_OrganisationSubCategory subCategory)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", subCategory.Key);

            return Convert.ToInt32(MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM organisation o JOIN organisationsubcategory o1 ON o.SubCategoryKey = o1.`Key` WHERE o1.`Key`= @Key", para));
        }

        public bool update(ML_OrganisationSubCategory subCategory)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@SubCategory", subCategory.SubCategory);
            para[1] = new MySqlParameter("@Key", subCategory.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE organisationsubcategory SET `SubCategory` = @SubCategory WHERE `Key` = @Key", para);
            return true;
        }

        public bool deleteByCategory(ML_OrganisationSubCategory subCategory)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@CategoryKey", subCategory.CategoryKey);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM organisationsubcategory WHERE `CategoryKey` = @CategoryKey;", para);
            return true;
        }

        public DataTable select(ML_OrganisationSubCategory subCategory)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@SubCategory", subCategory.SubCategory);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT o1.`KEY` AS CategoryKey, o1.Category, o.`KEY` AS SubCategoryKey, o.SubCategory FROM stc_oba.organisationsubcategory o JOIN organisationcategory o1 ON o.CategoryKey = o1.`Key` WHERE o.SubCategory = COALESCE(@SubCategory, SubCategory)", para);
        }
    }
}
