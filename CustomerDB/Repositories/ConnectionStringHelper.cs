using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            // search local machine for SQL Express instance
            sqlConnectionStringBuilder.DataSource = ".\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "Chinook";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            // otherwise connection fails due to untrusted SSL certificate chain
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
    }
}
