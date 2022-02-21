using System;

namespace CustomerDB.Models
{
    public class CustomerCountry
    {
        public string? Country { get; set; }
        public int NumberOfCustomers { get; set; }

        /// <summary>
        /// Converts the database element to string
        /// </summary>
        /// <returns>
        /// String containing infromation from the element
        /// </returns>
        public override string? ToString()
        {
            return Country + ": " + NumberOfCustomers;
        }
    }
}
