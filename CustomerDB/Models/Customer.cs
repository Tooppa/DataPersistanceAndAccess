namespace CustomerDB.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        /// <summary>
        /// Converts the database element to string
        /// </summary>
        /// <returns>
        /// String containing infromation from the element
        /// </returns>
        public override string? ToString()
        {
            return CustomerId + " - " + FirstName + " " + LastName + " - " + Country + " - " + PostalCode + " - " + Phone + " - " + Email;
        }
    }
}
