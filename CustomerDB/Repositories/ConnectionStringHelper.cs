using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "";
            sqlConnectionStringBuilder.InitialCatalog = "";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
    }
}
