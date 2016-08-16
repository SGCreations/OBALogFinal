using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBALog.Data
{
    public class DL_Address
    {
        public int insert(OBALog.Model.ML_Address address)
        {
            MySqlParameter[] para = new MySqlParameter[4];
            para[0] = new MySqlParameter("@Address", address.Address);
            para[1] = new MySqlParameter("@Telephone", address.Telephone);
            para[2] = new MySqlParameter("@CityKey", address.CityKey);
            para[3] = new MySqlParameter("@UserKey", address.UserKey);

            object insertedId = MySQLHelper.ExecuteScalar(DBConnection.connectionString, CommandType.Text, "INSERT INTO stc_oba.address (Address ,CityKey ,Telephone ,UserKey ,UpdatedDate ) VALUES ( @Address ,@CityKey ,@Telephone ,@UserKey ,NOW() ); SELECT LAST_INSERT_ID();", para);
            return Convert.ToInt32(insertedId);
        }

        public bool update(OBALog.Model.ML_Address address)
        {
            MySqlParameter[] para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@Address", address.Address);
            para[1] = new MySqlParameter("@Telephone", address.Telephone);
            para[2] = new MySqlParameter("@CityKey", address.CityKey);
            para[3] = new MySqlParameter("@UserKey", address.UserKey);
            para[4] = new MySqlParameter("@Key", address.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE stc_oba.address SET Address = @Address ,CityKey = @CityKey ,Telephone = @Telephone ,UserKey = @UserKey , UpdatedDate = NOW() WHERE `Key` = @Key", para);
            return true;
        }

        public bool delete(OBALog.Model.ML_Address address)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", address.Key);
            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM address WHERE `Key` = @Key;", para);
            return true;
        }


        public DataTable select(Model.ML_Address address)
        {
            MySqlParameter[] para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", address.Key);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT * FROM stc_oba.address WHERE `Key` = COALESCE(@Key, `Key`)", para);
        }

    }
}
