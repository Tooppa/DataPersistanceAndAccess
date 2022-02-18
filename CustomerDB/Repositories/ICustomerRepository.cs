using CustomerDB.Models;

namespace CustomerDB.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public Customer GetByName(string FirstName, string LastName);
        public List<Customer> GetPage(int limit, int offset);
    }
}
