namespace CustomerDB.Models
{
    public class CustomerSpender
    {
        public decimal? Spending { get; set; }
        public Customer? Customer { get; set; }

        public override string? ToString()
        {
            return this.Customer?.FirstName + ' ' + this.Customer?.LastName + " Has Spent: " + Spending;
        }

    }
}
