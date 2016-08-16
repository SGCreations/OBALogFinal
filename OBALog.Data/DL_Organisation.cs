using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace OBALog.Data
{
    public class DL_Organisation
    {
        public int insert(OBALog.Model.ML_Organisation organisation)
        {
            MySqlParameter[] para = new MySqlParameter[4];
            para[0] = new MySqlParameter("@Organisation", organisation.Organisation);
            para[1] = new MySqlParameter("@SubCategoryKey", organisation.SubCategoryKey);
            para[2] = new MySqlParameter("@AddressKey", organisation.AddressKey);
            para[3] = new MySqlParameter("@Website", organisation.Website);

            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO stc_oba.organisation ( Organisation ,SubCategoryKey ,AddressKey ,Website ) VALUES ( @Organisation ,@SubCategoryKey ,@AddressKey ,@Website ); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_Organisation organisation)
        {
            MySqlParameter[] para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@Key", organisation.Key);
            para[1] = new MySqlParameter("@Organisation", organisation.Organisation);
            para[2] = new MySqlParameter("@SubCategoryKey", organisation.SubCategoryKey);
            para[3] = new MySqlParameter("@AddressKey", organisation.AddressKey);
            para[4] = new MySqlParameter("@Website", organisation.Website);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE stc_oba.organisation SET Organisation = @Organisation ,SubCategoryKey = @SubCategoryKey ,AddressKey = @AddressKey ,Website = @Website WHERE `Key` = @Key", para);
            return true;
        }

        public DataTable select(OBALog.Model.ML_Organisation organisation)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Key", organisation.Key);
            para[1] = new MySqlParameter("@Organisation", organisation.Organisation);
            //SELECT org.`Key`, org.Organisation, org.SubCategoryKey, osc.SubCategory, osc.CategoryKey, oc.Category, org.AddressKey, adr.Address, adr.CityKey, ct.City, cnt.Country, ct.CountryKey, org.Website FROM organisation org LEFT OUTER JOIN organisationsubcategory osc ON org.SubCategoryKey = osc.`KEY` LEFT OUTER JOIN organisationcategory oc ON osc.CategoryKey = oc.`KEY` LEFT OUTER JOIN address adr ON org.AddressKey = adr.`KEY` LEFT OUTER JOIN city ct ON adr.CityKey = ct.`KEY` LEFT OUTER JOIN country cnt ON ct.CountryKey = cnt.`KEY` WHERE org.`KEY` = COALESCE(@Key, org.`KEY`) AND org.organisation = COALESCE(@Organisation, org.organisation) ORDER BY Organisation ASC
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT org.`Key`, org.Organisation, org.SubCategoryKey, osc.SubCategory, osc.CategoryKey, oc.Category, org.AddressKey, adr.Address, adr.CityKey, ct.City, cnt.Country, ct.CountryKey, org.Website FROM organisation org LEFT OUTER JOIN organisationsubcategory osc ON org.SubCategoryKey = osc.`KEY` LEFT OUTER JOIN organisationcategory oc ON osc.CategoryKey = oc.`KEY` LEFT OUTER JOIN address adr ON org.AddressKey = adr.`KEY` LEFT OUTER JOIN city ct ON adr.CityKey = ct.`KEY` LEFT OUTER JOIN country cnt ON ct.CountryKey = cnt.`KEY` WHERE org.`KEY` = COALESCE(@Key, org.`KEY`) OR org.organisation = COALESCE(@Organisation, org.organisation) ORDER BY Organisation ASC", para);
        }

        public DataTable selectNewRecord(OBALog.Model.ML_Organisation organisation)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Key", organisation.Key);
            para[1] = new MySqlParameter("@Organisation", organisation.Organisation);
            //SELECT org.`Key`, org.Organisation, org.SubCategoryKey, osc.SubCategory, osc.CategoryKey, oc.Category, org.AddressKey, adr.Address, adr.CityKey, ct.City, cnt.Country, ct.CountryKey, org.Website FROM organisation org LEFT OUTER JOIN organisationsubcategory osc ON org.SubCategoryKey = osc.`KEY` LEFT OUTER JOIN organisationcategory oc ON osc.CategoryKey = oc.`KEY` LEFT OUTER JOIN address adr ON org.AddressKey = adr.`KEY` LEFT OUTER JOIN city ct ON adr.CityKey = ct.`KEY` LEFT OUTER JOIN country cnt ON ct.CountryKey = cnt.`KEY` WHERE org.`KEY` = COALESCE(@Key, org.`KEY`) AND org.organisation = COALESCE(@Organisation, org.organisation) ORDER BY Organisation ASC
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT org.`Key`, org.Organisation, org.SubCategoryKey, osc.SubCategory, osc.CategoryKey, oc.Category, org.AddressKey, adr.Address, adr.CityKey, ct.City, cnt.Country, ct.CountryKey, org.Website FROM organisation org LEFT OUTER JOIN organisationsubcategory osc ON org.SubCategoryKey = osc.`KEY` LEFT OUTER JOIN organisationcategory oc ON osc.CategoryKey = oc.`KEY` LEFT OUTER JOIN address adr ON org.AddressKey = adr.`KEY` LEFT OUTER JOIN city ct ON adr.CityKey = ct.`KEY` LEFT OUTER JOIN country cnt ON ct.CountryKey = cnt.`KEY` WHERE org.`KEY` = COALESCE(@Key, org.`KEY`) AND org.organisation = COALESCE(@Organisation, org.organisation) ORDER BY Organisation ASC", para);
        }

        public int selectUsage(OBALog.Model.ML_Organisation organisation)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@OrganisationKey", organisation.Key);

            var a = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM professionaldetails p WHERE p.OrganisationKey = @OrganisationKey", para);
            return Convert.ToInt32(a);
        }

        public bool delete(OBALog.Model.ML_Organisation category)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", category.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM stc_oba.organisation WHERE `Key` = @Key;", para);
            return true;
        }
    }
}
