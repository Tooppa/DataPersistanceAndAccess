using CustomerDB.Models;

namespace CustomerDB.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        public List<Customer> GetPage(int limit, int offset);
    }
}
