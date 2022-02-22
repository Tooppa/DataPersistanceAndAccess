using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public class ConnectionStringHelper
    {
        /// <summary>
        /// Gets the string required for the connection to the database
        /// </summary>
        /// <returns>
        /// String from SqlConnectionStringBuilder with right information
        /// </returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            // search local machine for SQL Express Server instance
            sqlConnectionStringBuilder.DataSource = ".\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "Chinook";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            // otherwise connection fails due to untrusted SSL certificate chain
            sqlConnectionStringBuilder.TrustServerCertificate = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
    }
}
