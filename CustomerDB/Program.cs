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
            //TestInsert(repository);
            //TestEditCustomer(repository);
            //TestCustomersPerCountry(repository);
            //TestCustomerSpending(repository);
            TestCustomerGenre(repository);
        }
        private static void TestCustomerGenre(ICustomerRepository repository)
        {
            IEnumerable<CustomerGenre> genres = repository.GetCustomerGenre(12);
            foreach (CustomerGenre genre in genres)
                Console.WriteLine(genre.ToString());
        }

        private static void TestCustomerSpending(ICustomerRepository repository)
        {
            IEnumerable<CustomerSpender> customers = repository.GetCustomerSpending();
            foreach (CustomerSpender customer in customers)
                Console.WriteLine(customer.ToString());
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
      
        static void TestInsert(ICustomerRepository repository)
        {
            Customer newCustomer = new Customer()
            {
                FirstName = "Bruce",
                LastName = "Wayne",
                Country = "USA",
                PostalCode = "53540",
                Phone = "1800-BATMAN",
                Email = "bruce.wayne@waynecorp.com"
            };

            if (repository.Create(newCustomer))
            {
                Console.WriteLine("Insert successful.");
            } else
            {
                Console.WriteLine("Insert unsuccessful");
            }
            Customer customerFromDb = repository.GetByName("Bruce", "Wayne");
            Console.WriteLine(customerFromDb.ToString());
        }
      
        static void TestCustomersPerCountry(ICustomerRepository repository)
        {
            IEnumerable<CustomerCountry> customersPerCountry = repository.GetNumberOfCustomersPerCountry();
            foreach (CustomerCountry item in customersPerCountry)
                Console.WriteLine(item.ToString());
        }
    }

}