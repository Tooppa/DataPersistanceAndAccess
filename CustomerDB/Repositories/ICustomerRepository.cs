using CustomerDB.Models;
using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Customer GetByName(string FirstName, string LastName);
        public IEnumerable<Customer> GetPage(int limit, int offset);
        public IEnumerable<CustomerCountry> GetNumberOfCustomersPerCountry();
        public IEnumerable<CustomerSpender> GetCustomerSpending();
        public IEnumerable<CustomerGenre> GetCustomerGenre(int id);
        public string SafeGetString(SqlDataReader reader, int colIndex);
    }
}
