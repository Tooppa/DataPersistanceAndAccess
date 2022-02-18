using CustomerDB.Models;
using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public List<Customer> GetPage(int limit, int offset);
        public string SafeGetString(SqlDataReader reader, int colIndex);
    }
}
