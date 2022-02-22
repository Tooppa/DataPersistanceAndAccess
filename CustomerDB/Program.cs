using CustomerDB.Models;
using CustomerDB.Repositories;

namespace CustomerDB 
{
    public class Program
    {
        public static void Main()
        {
            // You can use these test methods to try out the different database interactions

            ICustomerRepository repository = new CustomerRepository();
            TestSelectById(repository);
            //TestSelectByName(repository);
            //TestAllCustomers(repository);
            //TestAllCustomerWithOffsetAndLimit(repository);
            //TestInsert(repository);
            //TestEditCustomer(repository);
            //TestCustomersPerCountry(repository);
            //TestCustomerSpending(repository);
            //TestCustomerGenre(repository);
        }
        /// <summary>
        /// Prints the favourite genre(s) of the given user based on their id
        /// Id is set to 12 here but it can be any int
        /// </summary>
        /// <param name="repository">Object that implements ICustomerRepository</param>
        private static void TestCustomerGenre(ICustomerRepository repository)
        {
            IEnumerable<CustomerGenre> genres = repository.GetCustomerGenre(12);
            foreach (CustomerGenre genre in genres)
                Console.WriteLine(genre.ToString());
        }

        /// <summary>
        /// Prints a list of customers based on their total amounts spent from highest to lowest
        /// </summary>
        /// <param name="repository">Object that implements ICustomerRepository</param>
        private static void TestCustomerSpending(ICustomerRepository repository)
        {
            IEnumerable<CustomerSpender> customers = repository.GetCustomerSpending();
            foreach (CustomerSpender customer in customers)
                Console.WriteLine(customer.ToString());
        }

        /// <summary>
        /// Updates a customer in the database based on the given customer object
        /// The method first prints out the original customer (id==3) and then
        /// changes their first name to edited and gets/prints the updated user again
        /// </summary>
        /// <param name="repository">Object that implements ICustomerRepository</param>
        private static void TestEditCustomer(ICustomerRepository repository)
        {
            Customer customer = repository.GetById(3);
            Console.WriteLine(customer.ToString());
            customer.FirstName = "Edited";
            repository.Update(customer);
            customer = repository.GetById(3);
            Console.WriteLine(customer.ToString());
        }

        /// <summary>
        /// Returns and prints and user from the database based on their id.
        /// Here the id is set to 34 but it can be any int
        /// </summary>
        /// <param name="repository">Object that implements ICustomerRepository</param>
        static void TestSelectById(ICustomerRepository repository)
        {
            Customer customer = repository.GetById(34);
            Console.WriteLine(customer.ToString());
        }

        /// <summary>
        /// Returns and prints and user from the database based on their first and last name.
        /// Jack and Smith are used here but you can try other customers as well
        /// </summary>
        /// <param name="repository">Object that implements ICustomerRepository</param>
        static void TestSelectByName(ICustomerRepository repository)
        {
            Customer customer = repository.GetByName("Jack", "Smith");
            Console.WriteLine(customer.ToString());
        }
        /// <summary>
        /// Returns and prints all the customers in the database
        /// </summary>
        /// <param name="repository">Object that implements ICustomerRepository</param>
        static void TestAllCustomers(ICustomerRepository repository) 
        {
            IEnumerable<Customer> customers = repository.GetAll();
            foreach (Customer customer in customers)
                Console.WriteLine(customer.ToString());
        }

        /// <summary>
        /// Returns and prints customers from the database. The limit parameter tells how many
        /// while the offset determines the point from where the list begins.
        /// Here the limit is set to 10 and the offset is 5 which means
        /// customers 6th to 15th are printed. You can change the parameters.
        /// </summary>
        /// <param name="repository">Object that implements ICustomerRepository</param>
        static void TestAllCustomerWithOffsetAndLimit(ICustomerRepository repository)
        {
            IEnumerable<Customer> customers = repository.GetPage(10, 5);
            foreach (Customer customer in customers)
                Console.WriteLine(customer.ToString());
        }

        /// <summary>
        /// Add an new customer to the database and print whether the insert was
        /// successful. Afterwards get the new customer by name and print it.
        /// The example data here can be changed.
        /// </summary>
        /// <param name="repository">Object that implements ICustomerRepository</param>
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

        /// <summary>
        /// Print a list of countries and the number of customers in each.
        /// </summary>
        /// <param name="repository">Object that implements ICustomerRepository</param>
        static void TestCustomersPerCountry(ICustomerRepository repository)
        {
            IEnumerable<CustomerCountry> customersPerCountry = repository.GetNumberOfCustomersPerCountry();
            foreach (CustomerCountry item in customersPerCountry)
                Console.WriteLine(item.ToString());
        }
    }

}