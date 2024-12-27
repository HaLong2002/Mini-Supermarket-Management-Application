using SieuThiMini.DAO;
using Microsoft.Data.SqlClient;

public class CustomerDAO
{
    string connectionString = ClassKetnoi.ConnectionString;
    public List<CustomerDTO> GetAllCustomers()
    {

        List<CustomerDTO> customersList = new List<CustomerDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Customers";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerDTO customer = new CustomerDTO
                            {
                                CustomerID = reader.GetInt32(0),
                                RewardPoint = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                Phone = reader.GetString(3), 
                                Gender = reader.GetString(4), 
                                DayOfBirth = reader.GetDateTime(5) 
                            };
                            customersList.Add(customer);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return customersList;
    }
    public void AddCustomer(CustomerDTO newCustomer)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Customers (RewardPoint, Name, Phone, Gender, DayOfBirth) " +
                               "VALUES (@RewardPoint, @Name, @Phone, @Gender, @DayOfBirth)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RewardPoint", newCustomer.RewardPoint);
                    command.Parameters.AddWithValue("@Name", newCustomer.Name);
                    command.Parameters.AddWithValue("@Phone", newCustomer.Phone);
                    command.Parameters.AddWithValue("@Gender", newCustomer.Gender);
                    command.Parameters.AddWithValue("@DayOfBirth", newCustomer.DayOfBirth);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }
    }
    public bool IsPhoneExists(string phone)
    {
        bool exists = false;

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM Customers WHERE Phone = @Phone";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Phone", phone);

                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        exists = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return exists;
    }
    public void UpdateCustomer(CustomerDTO updatedCustomer)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Customers SET RewardPoint = @RewardPoint, Name = @Name, " +
                               "Phone = @Phone, Gender = @Gender, DayOfBirth = @DayOfBirth " +
                               "WHERE CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RewardPoint", updatedCustomer.RewardPoint);
                    command.Parameters.AddWithValue("@Name", updatedCustomer.Name);
                    command.Parameters.AddWithValue("@Phone", updatedCustomer.Phone);
                    command.Parameters.AddWithValue("@Gender", updatedCustomer.Gender);
                    command.Parameters.AddWithValue("@DayOfBirth", updatedCustomer.DayOfBirth);
                    command.Parameters.AddWithValue("@CustomerID", updatedCustomer.CustomerID);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }
    }
    public void DeleteCustomer(int customerId)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Xóa khách hàng thành công!");
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy khách hàng với ID này.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }
    }
    public CustomerDTO GetCustomerById(int customerId)
    {
        CustomerDTO customer = null;

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new CustomerDTO
                            {
                                CustomerID = reader.GetInt32(0),
                                RewardPoint = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                Phone = reader.GetString(3), 
                                Gender = reader.GetString(4),
                                DayOfBirth = reader.GetDateTime(5)
                            };
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return customer; 
    }
    public List<CustomerDTO> SearchCustomers(string keyword)
    {
        List<CustomerDTO> customersList = new List<CustomerDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Customers WHERE Name LIKE @Keyword OR Phone LIKE @Keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerDTO customer = new CustomerDTO
                            {
                                CustomerID = reader.GetInt32(0),
                                RewardPoint = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Gender = reader.GetString(4),
                                DayOfBirth = reader.GetDateTime(5)
                            };
                            customersList.Add(customer);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return customersList;
    }
    public List<CustomerDTO> GetCustomersMaxPoint()
    {
        List<CustomerDTO> customersList = new List<CustomerDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Customers ORDER BY RewardPoint DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerDTO customer = new CustomerDTO
                            {
                                CustomerID = reader.GetInt32(0),
                                RewardPoint = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Gender = reader.GetString(4),
                                DayOfBirth = reader.GetDateTime(5)
                            };
                            customersList.Add(customer);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return customersList;
    }
    public List<CustomerDTO> GetCustomersMinPoint()
    {
        List<CustomerDTO> customersList = new List<CustomerDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Customers ORDER BY RewardPoint ASC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerDTO customer = new CustomerDTO
                            {
                                CustomerID = reader.GetInt32(0),
                                RewardPoint = reader.GetInt32(1),
                                Name = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Gender = reader.GetString(4),
                                DayOfBirth = reader.GetDateTime(5)
                            };
                            customersList.Add(customer);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return customersList;
    }
    ///////////////////////////////////// HOAS DDOWN////////////////////////////
    public List<InvoiceDTO> GetAllInvoices()
    {
        List<InvoiceDTO> invoicesList = new List<InvoiceDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Invoices";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InvoiceDTO invoice = new InvoiceDTO
                            {
                                InvoiceID = reader.GetInt32(0),
                                EmployeeID = reader.GetInt32(1),
                                CustomerID = reader.GetInt32(2),
                                InvoiceDate = reader.GetDateTime(3),
                                TotalAmount = reader.GetDecimal(4),
                                PointEarned = reader.GetInt32(5)
                            };
                            invoicesList.Add(invoice);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return invoicesList;
    }
    public List<InvoiceDTO> GetInvoicesByCustomerID(int customerID)
    {
        List<InvoiceDTO> invoicesList = new List<InvoiceDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Invoices WHERE CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InvoiceDTO invoice = new InvoiceDTO
                            {
                                InvoiceID = reader.GetInt32(0),
                                EmployeeID = reader.GetInt32(1),
                                CustomerID = reader.GetInt32(2),
                                InvoiceDate = reader.GetDateTime(3),
                                TotalAmount = reader.GetDecimal(4),
                                PointEarned = reader.GetInt32(5)
                            };
                            invoicesList.Add(invoice);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return invoicesList;
    }
    public List<InvoiceDetailDTO> GetAllInvoiceDetails()
    {
        List<InvoiceDetailDTO> invoiceDetailsList = new List<InvoiceDetailDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM InvoiceDetails";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InvoiceDetailDTO invoiceDetail = new InvoiceDetailDTO
                            {
                                InvoiceID = reader.GetInt32(0),
                                ProductID = reader.GetInt32(1),
                                PromotionID = reader.GetInt32(2),
                                Quantity = reader.GetInt32(3),
                                Price = reader.GetDecimal(4)
                            };
                            invoiceDetailsList.Add(invoiceDetail);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return invoiceDetailsList;
    }

    public List<InvoiceDetailDTO> GetInvoiceDetailsByInvoiceID(int invoiceID)
    {
        List<InvoiceDetailDTO> invoiceDetailsList = new List<InvoiceDetailDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM InvoiceDetails WHERE InvoiceID = @InvoiceID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceID", invoiceID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InvoiceDetailDTO invoiceDetail = new InvoiceDetailDTO
                            {
                                InvoiceID = reader.GetInt32(0),
                                ProductID = reader.GetInt32(1),
                                PromotionID = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                Quantity = reader.GetInt32(3),
                                Price = reader.GetDecimal(4)
                            };
                            invoiceDetailsList.Add(invoiceDetail);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return invoiceDetailsList;
    }
    public List<InvoiceDTO> GetInvoicesByDateRange(DateTime startDate, DateTime endDate)
    {
        List<InvoiceDTO> invoicesList = new List<InvoiceDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Invoices WHERE InvoiceDate >= @startDate AND InvoiceDate <= @endDate";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InvoiceDTO invoice = new InvoiceDTO
                            {
                                InvoiceID = reader.GetInt32(0),
                                EmployeeID = reader.GetInt32(1),
                                CustomerID = reader.GetInt32(2),
                                InvoiceDate = reader.GetDateTime(3),
                                TotalAmount = reader.GetDecimal(4),
                                PointEarned = reader.GetInt32(5)
                            };
                            invoicesList.Add(invoice);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return invoicesList;
    }
    public List<PromotionDTO> GetAllPromotions()
    {
        List<PromotionDTO> promotionList = new List<PromotionDTO>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Promotions";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PromotionDTO promotion = new PromotionDTO
                            {
                                PromotionID = reader.GetInt32(0),
                                ProductID = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                PromotionName = reader.GetString(2),
                                Point = reader.GetInt32(3),
                                DiscountPercent = reader.GetDecimal(4),
                                StartDate = reader.GetDateTime(5),
                                EndDate = reader.GetDateTime(6),
                                IsActive = reader.GetBoolean(7)
                            };
                            promotionList.Add(promotion);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
        }

        return promotionList;
    }
}
