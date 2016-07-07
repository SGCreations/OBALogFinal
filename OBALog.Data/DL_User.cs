﻿using MySql.Data.MySqlClient;

namespace OBALog.Data
{
    public class DL_User
    {
        public int insert(OBALog.Model.ML_User user)
        {
            var para = new MySqlParameter[7];
            para[0] = new MySqlParameter("@LoginId", user.LoginId);
            para[1] = new MySqlParameter("@Name", user.Name);
            para[2] = new MySqlParameter("@NIC", user.NIC);
            para[3] = new MySqlParameter("@Password", user.Password);
            para[4] = new MySqlParameter("@UpdatedDate", user.UpdatedDate);
            para[5] = new MySqlParameter("@UserAccessTypeKey", user.UserAccessTypeKey);
            para[6] = new MySqlParameter("@UserKey", user.UserKey);

            return (int)MySQLHelper.ExecuteScalar(DBConnection.connectionString, System.Data.CommandType.Text, "INSERT INTO stc_oba.user ( LoginId ,Password ,Name ,NIC ,UserAccessTypeKey ,UserKey ) VALUES ( @LoginId ,@Password ,@Name ,@NIC ,@UserAccessTypeKey ,@UserKey); SELECT @@identity", para);
        }

        public bool update(OBALog.Model.ML_User user)
        {
            var para = new MySqlParameter[8];
            para[0] = new MySqlParameter("@LoginId", user.LoginId);
            para[1] = new MySqlParameter("@Name", user.Name);
            para[2] = new MySqlParameter("@NIC", user.NIC);
            para[3] = new MySqlParameter("@Password", user.Password);
            para[4] = new MySqlParameter("@UpdatedDate", user.UpdatedDate);
            para[5] = new MySqlParameter("@UserAccessTypeKey", user.UserAccessTypeKey);
            para[6] = new MySqlParameter("@UserKey", user.UserKey);
            para[7] = new MySqlParameter("@Key", user.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, System.Data.CommandType.Text, "UPDATE stc_oba.user SET LoginId = @LoginId ,Password = COALESCE(@Password, Password) ,Name = @Name ,NIC = @NIC ,UserAccessTypeKey = @UserAccessTypeKey ,UserKey = @UserKey ,UpdatedDate = NOW() WHERE `Key` = @Key", para);
            return true;
        }

        public bool delete(OBALog.Model.ML_User user)
        {
            var para = new MySqlParameter[8];
            para[0] = new MySqlParameter("@LoginId", user.LoginId);
            para[1] = new MySqlParameter("@Name", user.Name);
            para[2] = new MySqlParameter("@NIC", user.NIC);
            para[3] = new MySqlParameter("@Password", user.Password);
            para[4] = new MySqlParameter("@UpdatedDate", user.UpdatedDate);
            para[5] = new MySqlParameter("@UserAccessTypeKey", user.UserAccessTypeKey);
            para[6] = new MySqlParameter("@UserKey", user.UserKey);
            para[7] = new MySqlParameter("@Key", user.Key);

            MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, System.Data.CommandType.Text, "UPDATE stc_oba.user SET `Deleted` = True WHERE `Key` = @Key", para);
            return true;
        }

        public System.Data.DataTable selectAll(OBALog.Model.ML_User user)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Key", user.Key);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT `Key`, LoginId, Name, NIC, UserAccessTypeKey, UserKey, UpdatedDate FROM stc_oba.user WHERE `Key` = COALESCE(@Key,`Key`) AND Deleted = 0", para);
        }

        public System.Data.DataTable selectUsage(OBALog.Model.ML_User user)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@Key", user.Key);
            para[1] = new MySqlParameter("@LoginId", user.LoginId);
            
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT `Key`, LoginId, Name, NIC, UserAccessTypeKey, UserKey, UpdatedDate FROM stc_oba.user WHERE `Key` = @Key OR `LoginId` = @LoginId", para);
        }

        public System.Data.DataSet checkLogin(OBALog.Model.ML_User user)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@LoginId", user.LoginId);
            para[1] = new MySqlParameter("@Password", DataHelper.CreateSHA1(user.Password));

            return MySQLHelper.ExecuteDataSet(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT usr.`Key`, usr.`LoginId`, usr.`Name`, usr.`NIC`, usr.`UserAccessTypeKey`, u.AccessTypeName FROM `user` usr JOIN useraccesstype u ON usr.UserAccessTypeKey = u.`Key` AND usr.Deleted = FALSE WHERE usr.`LoginId` = @LoginId AND usr.`Password` = @Password AND usr.`Deleted` = FALSE; SELECT p.`Key`, p.privilege, up.Allowed FROM stc_oba.useraccessprivilege up JOIN `user` u ON up.`UserAccessTypeKey` = u.`UserAccessTypeKey` AND u.LoginId = @LoginId AND u.`LoginId` = LoginId AND u.`Deleted` = FALSE JOIN privilege p ON p.`Key` = up.`PrivilegeKey`", para);
        }
    }
}