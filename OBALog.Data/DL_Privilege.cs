
using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace OBALog.Data
{
    public class DL_Privilege
    {

        public int insert(OBALog.Model.ML_Privilege privilege)
        {
            MySqlParameter[] para = new MySqlParameter[4];
            //para[0] = new MySqlParameter("@Organisation", privilege.Organisation);
            //para[1] = new MySqlParameter("@SubCategoryKey", privilege.SubCategoryKey);
            //para[2] = new MySqlParameter("@AddressKey", organisation.AddressKey);
            //para[3] = new MySqlParameter("@Website", organisation.Website);

            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO stc_oba.organisation ( Organisation ,SubCategoryKey ,AddressKey ,Website ) VALUES ( @Organisation ,@SubCategoryKey ,@AddressKey ,@Website ); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_Privilege privilege)
        {
            MySqlParameter[] para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@Key", privilege.Key);
            //para[1] = new MySqlParameter("@Organisation", privilege.Organisation);
            //para[2] = new MySqlParameter("@SubCategoryKey", privilege.SubCategoryKey);
            //para[3] = new MySqlParameter("@AddressKey", privilege.AddressKey);
            //para[4] = new MySqlParameter("@Website", privilege.Website);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE stc_oba.organisation SET Organisation = @Organisation ,SubCategoryKey = @SubCategoryKey ,AddressKey = @AddressKey ,Website = @Website WHERE `Key` = @Key", para);
            return true;
        }

        public DataTable select(OBALog.Model.ML_Privilege privilege)
        {
            MySqlParameter[] para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Key", privilege.Key);
            para[1] = new MySqlParameter("@Privilege", privilege.Privilege);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT `Key`, Privilege FROM privilege WHERE Privilege = COALESCE(@Privilege, Privilege) ORDER BY Privilege ASC", para);
        }

        public int selectUsage(OBALog.Model.ML_Privilege privilege)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@OrganisationKey", privilege.Key);

            var a = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "SELECT COUNT(*) FROM professionaldetails p WHERE p.OrganisationKey = @OrganisationKey", para);
            return Convert.ToInt32(a);
        }

        public bool delete(OBALog.Model.ML_Privilege privilege)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", privilege.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM stc_oba.organisation WHERE `Key` = @Key;", para);
            return true;
        }

        public DataTable selectByUAT(int UserAccessTypeKey)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@UserAccessTypeKey", UserAccessTypeKey);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT * FROM useraccessprivilege u LEFT JOIN privilege p ON u.PrivilegeKey = p.`KEY` WHERE u.UserAccesstypeKey = COALESCE(@UserAccessTypeKey, UserAccesstypeKey) ORDER BY p.Privilege ASC", para);
        }
    }
}
