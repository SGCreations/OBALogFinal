using System.Configuration;

namespace OBALog.Data
{
    public class DBConnection
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["OBALog.Properties.Settings.OBADB"].ConnectionString;
    }
}
