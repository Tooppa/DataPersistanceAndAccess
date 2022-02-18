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
            //TestSelectByName(repository);
            //TestAllCustomers(repository);
            //TestAllCustomerWithOffsetAndLimit(repository);
            //TestEditCustomer(repository);
        }

        private static void TestEditCustomer(ICustomerRepository repository)
        {
            Customer customer = repository.GetById(3);
            Console.WriteLine(customer.ToString());
            customer.FirstName = "Edited";
            repository.Update(customer);
            customer = repository.GetById(3);
            Console.WriteLine(customer.ToString());
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
        static void TestAllCustomers(ICustomerRepository repository) 
        {
            IEnumerable<Customer> customers = repository.GetAll();
            foreach (Customer customer in customers)
                Console.WriteLine(customer.ToString());
        }
        static void TestAllCustomerWithOffsetAndLimit(ICustomerRepository repository)
        {
            IEnumerable<Customer> customers = repository.GetPage(10, 5);
            foreach (Customer customer in customers)
                Console.WriteLine(customer.ToString());
        }
    }

}