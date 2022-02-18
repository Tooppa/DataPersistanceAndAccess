using CustomerDB.Models;
using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool Create(Customer entity)
        {
            bool success = false;
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email)" +
                " VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                        cmd.Parameters.AddWithValue("@Country", entity.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                        cmd.Parameters.AddWithValue("@Email", entity.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                    conn.Close();
                }
            } catch (SqlException ex)
            {
                // LOG
                Console.WriteLine(ex.Message);
            }
            return success;
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
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                // LOG
                Console.WriteLine(ex.Message);
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
                                customer = new Customer()
                                {
                                    CustomerId = reader.GetInt32(0),
                                    FirstName = SafeGetString(reader, 1),
                                    LastName = SafeGetString(reader, 2),
                                    Country = SafeGetString(reader, 3),
                                    PostalCode = SafeGetString(reader, 4),
                                    Phone = SafeGetString(reader, 5),
                                    Email = SafeGetString(reader, 6),
                                };
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
                                customer = new Customer()
                                {
                                    CustomerId = reader.GetInt32(0),
                                    FirstName = SafeGetString(reader, 1),
                                    LastName = SafeGetString(reader, 2),
                                    Country = SafeGetString(reader, 3),
                                    PostalCode = SafeGetString(reader, 4),
                                    Phone = SafeGetString(reader, 5),
                                    Email = SafeGetString(reader, 6),
                                };
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

        public IEnumerable<Customer> GetPage(int limit, int offset)
        {
            List<Customer> result = new List<Customer>();
            var sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET @Limit ROWS FETCH NEXT @Offset ROWS ONLY;";
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Limit", limit);
                        cmd.Parameters.AddWithValue("@Offset", offset);
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
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                // LOG
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public bool Update(Customer entity)
        {       
            bool result = false;
            string sql = "UPDATE Customer SET FirstName = @FirstName," + 
                " LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email WHERE CustomerID = @CustomerID";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", entity.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                        cmd.Parameters.AddWithValue("@Country", entity.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                        cmd.Parameters.AddWithValue("@Email", entity.Email);
                        result = cmd.ExecuteNonQuery() > 0;                    }
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                // LOG
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
        public IEnumerable<CustomerSpender> GetCustomerSpending()
        {

            List<CustomerSpender> result = new List<CustomerSpender>();
            var sql = "SELECT SUM(Invoice.Total) AS Total, Customer.CustomerID FROM Customer" +
                " LEFT JOIN Invoice ON Invoice.CustomerID = Customer.CustomerID" +
                " WHERE Invoice.CustomerID IS NOT NULL" +
                " GROUP BY Customer.CustomerID" +
                " ORDER BY Total DESC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new CustomerSpender()
                                {
                                    Spending = reader.GetDecimal(0),
                                    Customer = GetById(reader.GetInt32(1))

                                });
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
            return result;
        }

        public IEnumerable<CustomerCountry> GetNumberOfCustomersPerCountry()
        {

            List<CustomerCountry> result = new List<CustomerCountry>();
            var sql = "SELECT Country, COUNT(*) AS Customers FROM Customer" +
                " GROUP BY Country" +
                " ORDER BY Customers DESC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new CustomerCountry()
                                {
                                    Country = SafeGetString(reader, 0),
                                    NumberOfCustomers = reader.GetInt32(1)
                                });
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
            return result;
        }
    }
}
