using CustomerDB.Models;
using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Gets the Customer by name from the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>
        /// Customer element with the right info
        /// </returns>
        public Customer GetByName(string firstName, string lastName);
        /// <summary>
        /// Gets a page from the database
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns>
        /// List of customers with the amount and spot that was specified
        /// </returns>
        public IEnumerable<Customer> GetPage(int limit, int offset);
        /// <summary>
        /// Gets a list of countries sorted by number of users
        /// </summary>
        /// <returns>
        /// List of CustomerCountry elements
        /// </returns>
        public IEnumerable<CustomerCountry> GetNumberOfCustomersPerCountry();
        /// <summary>
        /// Gets the customer that have spent the most sorted from highest to lowest
        /// </summary>
        /// <returns>
        /// List of CustomerSpender elements
        /// </returns>
        public IEnumerable<CustomerSpender> GetCustomerSpending();
        /// <summary>
        /// Get the most used genre from the specified user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// CustomerGenre element
        /// </returns>
        public IEnumerable<CustomerGenre> GetCustomerGenre(int id);
        /// <summary>
        /// Gets the string from the database safely
        /// </summary>
        /// <param name="reader">SQLDataReader object</param>
        /// <param name="colIndex">Index of the database column to be read next</param>
        /// <returns>
        /// String from the database. If the database has a null value returns an empty string
        /// </returns>
        public string SafeGetString(SqlDataReader reader, int colIndex);
    }
}
