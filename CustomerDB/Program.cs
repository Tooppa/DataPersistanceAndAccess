using CustomerDB.Repositories;

namespace CustomerDB 
{
    public class Program
    {
        public static void Main()
        {
            CustomerRepository repo = new CustomerRepository();
            repo.GetAll();
        }
    }
}