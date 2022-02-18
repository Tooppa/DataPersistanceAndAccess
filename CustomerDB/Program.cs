﻿using CustomerDB.Models;
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
    }

}