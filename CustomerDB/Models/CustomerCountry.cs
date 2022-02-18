using System;

namespace CustomerDB.Models
{
    public class CustomerCountry
    {
        public string? Country { get; set; }
        public int NumberOfCustomers { get; set; }

        public override string? ToString()
        {
            return Country + ": " + NumberOfCustomers;
        }
    }
}
