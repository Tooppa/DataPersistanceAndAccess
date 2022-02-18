using CustomerDB.Models;
using CustomerDB.Repositories;

using CustomerDB.Repositories;

namespace CustomerDB 
{
    public class Program
    {
        public static void Main()
        {
            ICustomerRepository repository = new CustomerRepository();
            //TestSelectById(repository);
            //TestSelectByName(repository);
        }

        static void TestSelectById(ICustomerRepository repository)
        {
            Customer customer = repository.GetById(34);
            Console.WriteLine(customer.ToString());
        }

        static void TestSelectByName(ICustomerRepository repository)
        {
            Customer customer = repository.GetByName("Jack", "Smith");
            Console.WriteLine(customer.ToString());
            CustomerRepository repo = new CustomerRepository();
            repo.GetAll();
        }
    }
}