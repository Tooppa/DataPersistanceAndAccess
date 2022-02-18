using CustomerDB.Models;
using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> result = new List<Customer>();
            var sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new Customer()
                                {
                                    CustomerId = reader.GetInt32(0),
                                    FirstName = SafeGetString(reader, 1),
                                    LastName = SafeGetString(reader, 2),
                                    Country = SafeGetString(reader,3),
                                    PostalCode = SafeGetString(reader, 4),
                                    Phone = SafeGetString(reader, 5),
                                    Email = SafeGetString(reader, 6),
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            return result;
        }

        public Customer GetById(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                " WHERE CustomerId = @CustomerId;";

            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = reader.GetString(4);
                                customer.Phone = reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                    conn.Close();
                }

            } catch (SqlException ex)
            {
                // LOG
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public Customer GetByName(string FirstName, string LastName)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                " WHERE FirstName LIKE '%' + @FirstName + '%' AND LastName LIKE '%' + @LastName + '%';";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", FirstName);
                        cmd.Parameters.AddWithValue("@LastName", LastName);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = reader.GetString(4);
                                customer.Phone = reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                // LOG
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        public List<Customer> GetPage(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }
        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
    }
}
