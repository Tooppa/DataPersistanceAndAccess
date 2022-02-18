using CustomerDB.Models;

namespace CustomerDB.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetPage(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
