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

        public override string? ToString()
        {
            return CustomerId + " - " + FirstName + " " + LastName + " - " + Country + " - " + PostalCode + " - " + Phone + " - " + Email;
        }
    }
}
