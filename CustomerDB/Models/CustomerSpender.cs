namespace CustomerDB.Models
{
    public class CustomerSpender
    {
        public decimal? Spending { get; set; }
        public Customer? Customer { get; set; }

        /// <summary>
        /// Converts the database element to string
        /// </summary>
        /// <returns>
        /// String containing infromation from the element
        /// </returns>
        public override string? ToString()
        {
            return this.Customer?.FirstName + ' ' + this.Customer?.LastName + " Has Spent: " + Spending;
        }

    }
}
