using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ""; //datasource is difrent for diffrent user. dont upload the string to github
            sqlConnectionStringBuilder.InitialCatalog = "Chinook";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            return sqlConnectionStringBuilder.ConnectionString;
        }
    }
}
