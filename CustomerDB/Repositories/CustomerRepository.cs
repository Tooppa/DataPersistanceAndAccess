using CustomerDB.Models;
using Microsoft.Data.SqlClient;

namespace CustomerDB.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool Create(Customer entity)
        {
            bool success = false;
            // sql statement
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email)" +
                " VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            try
            {
                // get connection string
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // open connection to database
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // safely add values to prevent sql injections
                        cmd.Parameters.AddWithValue("@FirstName", entity.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                        cmd.Parameters.AddWithValue("@Country", entity.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                        cmd.Parameters.AddWithValue("@Email", entity.Email);
                        // execute statament
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                    // close the connection
                    conn.Close();
                }
            } catch (SqlException ex)
            {
                // print any exceptions to console
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
            var sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerId OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY;";
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

        public IEnumerable<CustomerGenre> GetCustomerGenre(int id)
        {
            List<CustomerGenre> result = new List<CustomerGenre>();
            var sql = "SELECT TOP 1 WITH TIES Genre.Name AS Genre, COUNT(Genre.Name) AS Tracks FROM Customer " +
            "LEFT JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId " +
            "LEFT JOIN InvoiceLine ON Invoice.InvoiceId = InvoiceLine.InvoiceId " +
            "LEFT JOIN Track ON InvoiceLine.TrackId = Track.TrackId " +
            "LEFT JOIN Genre ON Track.GenreId = Genre.GenreId " +
            "WHERE Customer.CustomerId = @CustomerId " +
            "AND Invoice.CustomerId IS NOT NULL " +
            "GROUP BY Genre.Name " +
            "ORDER BY Tracks DESC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new CustomerGenre()
                                {
                                    Genre = SafeGetString(reader, 0),
                                    Number = reader.GetInt32(1),
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
