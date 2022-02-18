using CustomerDB.Models;
using CustomerDB.Repositories;

namespace CustomerDB 
{
    public class Program
    {
        public static void Main()
        {
            ICustomerRepository repository = new CustomerRepository();
            //TestSelectById(repository);
        }

        static void TestSelectById(ICustomerRepository repository)
        {
            Customer customer = repository.GetById(1);
            Console.WriteLine(customer.ToString());
        }
    }
}