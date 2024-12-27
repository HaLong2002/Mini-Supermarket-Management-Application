using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;

namespace SieuThiMini.DAO
{
    internal class EmployeeDAO
    {
        string connectionString = ClassKetnoi.ConnectionString;


        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Chuyển đổi từng byte thành chuỗi hexa
                }
                return builder.ToString();
            }
        }


        public List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employeesList = new List<EmployeeDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Employees";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeDTO employee = new EmployeeDTO
                                {
                                    EmployeeID = reader.GetInt32(0),
                                    Email = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3),
                                    Status = reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    Img = reader.IsDBNull(6) ? null : reader.GetString(6), // Có thể null
                                    Name = reader.GetString(7),
                                    Phone = reader.IsDBNull(8) ? null : reader.GetString(8), 
                                    Gender = reader.IsDBNull(9) ? null : reader.GetString(9), 
                                    DayOfBirth = reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10) 
                                };
                                employeesList.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
            return employeesList;
        }

        public EmployeeDTO GetEmployeeById(int employeeId)
        {
            EmployeeDTO employee = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new EmployeeDTO
                                {
                                    EmployeeID = reader.GetInt32(0),
                                    Email = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3),
                                    Status = reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    Img = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    Name = reader.GetString(7),
                                    Phone = reader.IsDBNull(8) ? null : reader.GetString(8),
                                    Gender = reader.IsDBNull(9) ? null : reader.GetString(9),
                                    DayOfBirth = reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10)
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

            return employee; // Trả về nhân viên hoặc null nếu không tìm thấy
        }
        public bool CheckEmailExists(string email)
        {
            bool emailExists = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Email FROM Employees WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        object result = command.ExecuteScalar();
                        emailExists = result != null; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return emailExists; 
        }
        public void AddEmployee(EmployeeDTO newEmployee)
        {
            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        string query = "INSERT INTO Employees (Email, Password, Role, Status, CreatedAt, Img, Name, Phone, Gender, DayOfBirth) " +
            //                       "VALUES (@Email, @Password, @Role, @Status, GETDATE(), @Img, @Name, @Phone, @Gender, @DayOfBirth)";

            //        using (SqlCommand command = new SqlCommand(query, connection))
            //        {
            //            command.Parameters.AddWithValue("@Email", newEmployee.Email);
            //            command.Parameters.AddWithValue("@Password", newEmployee.Password);
            //            command.Parameters.AddWithValue("@Role", newEmployee.Role);
            //            command.Parameters.AddWithValue("@Status", newEmployee.Status);
            //            command.Parameters.AddWithValue("@Img", newEmployee.Img);
            //            command.Parameters.AddWithValue("@Name", newEmployee.Name);
            //            command.Parameters.AddWithValue("@Phone", newEmployee.Phone);
            //            command.Parameters.AddWithValue("@Gender", newEmployee.Gender);
            //            command.Parameters.AddWithValue("@DayOfBirth", newEmployee.DayOfBirth);

            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            //}
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Employees (Email, Password, Role, Status, CreatedAt, Img, Name, Phone, Gender, DayOfBirth) " +
                                   "VALUES (@Email, @Password, @Role, @Status, GETDATE(), @Img, @Name, @Phone, @Gender, @DayOfBirth)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Mã hóa mật khẩu trước khi lưu
                        string hashedPassword = HashPassword(newEmployee.Password);

                        command.Parameters.AddWithValue("@Email", newEmployee.Email);
                        command.Parameters.AddWithValue("@Password", hashedPassword); // Lưu mật khẩu đã băm
                        command.Parameters.AddWithValue("@Role", newEmployee.Role);
                        command.Parameters.AddWithValue("@Status", newEmployee.Status);
                        command.Parameters.AddWithValue("@Img", newEmployee.Img);
                        command.Parameters.AddWithValue("@Name", newEmployee.Name);
                        command.Parameters.AddWithValue("@Phone", newEmployee.Phone);
                        command.Parameters.AddWithValue("@Gender", newEmployee.Gender);
                        command.Parameters.AddWithValue("@DayOfBirth", newEmployee.DayOfBirth);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
        }
        public void UpdateEmployee(EmployeeDTO updatedEmployee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Employees SET Email = @Email, Password = @Password, Role = @Role, " +
                                   "Status = @Status, Img = @Img, Name = @Name, Phone = @Phone, " +
                                   "Gender = @Gender, DayOfBirth = @DayOfBirth WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", updatedEmployee.Email);
                        command.Parameters.AddWithValue("@Password", updatedEmployee.Password);
                        command.Parameters.AddWithValue("@Role", updatedEmployee.Role);
                        command.Parameters.AddWithValue("@Status", updatedEmployee.Status);
                        command.Parameters.AddWithValue("@Img", updatedEmployee.Img);
                        command.Parameters.AddWithValue("@Name", updatedEmployee.Name);
                        command.Parameters.AddWithValue("@Phone", updatedEmployee.Phone);
                        command.Parameters.AddWithValue("@Gender", updatedEmployee.Gender);
                        command.Parameters.AddWithValue("@DayOfBirth", updatedEmployee.DayOfBirth);
                        command.Parameters.AddWithValue("@EmployeeID", updatedEmployee.EmployeeID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Xóa nhân viên thành công!");
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy nhân viên với ID này.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
        }
        public List<EmployeeDTO> SearchEmployees(string keyword)
        {
            List<EmployeeDTO> employeesList = new List<EmployeeDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Employees WHERE Name LIKE @Keyword OR Email LIKE @Keyword OR Phone LIKE @Keyword";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeDTO employee = new EmployeeDTO
                                {
                                    EmployeeID = reader.GetInt32(0),
                                    Email = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3),
                                    Status = reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    Img = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    Name = reader.GetString(7),
                                    Phone = reader.IsDBNull(8) ? null : reader.GetString(8),
                                    Gender = reader.IsDBNull(9) ? null : reader.GetString(9),
                                    DayOfBirth = reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10)
                                };
                                employeesList.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return employeesList;
        }

        //////////////////////////////////////////          ABOUT USER ACCOUNT              //////////////////////////////////////////////////////////////////
        //public bool Login(string email, string password)
        //{
        //    // Kiểm tra thông tin đăng nhập
        //    string query = "SELECT EmployeeID FROM Employees WHERE Email = @Email AND Password = @Password";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Email", email);
        //            command.Parameters.AddWithValue("@Password", password);

        //            // Thực hiện truy vấn và lấy giá trị EmployeeID
        //            object result = command.ExecuteScalar();
        //            if (result != null)
        //            {
        //                // Đăng nhập thành công, có thể lưu EmployeeID nếu cần
        //                return true; // Đúng thông tin đăng nhập
        //            }
        //        }
        //    }
        //    return false; // Sai thông tin đăng nhập
        //}
        public int? Login(string email, string password)
        {
            int? employeeId = null;

            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        string query = "SELECT EmployeeID FROM Employees WHERE Email = @Email AND Password = @Password";
            //        using (SqlCommand command = new SqlCommand(query, connection))
            //        {
            //            command.Parameters.AddWithValue("@Email", email);
            //            command.Parameters.AddWithValue("@Password", password);
            //            object result = command.ExecuteScalar();
            //            if (result != null)
            //            {
            //                employeeId = Convert.ToInt32(result); 
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            //}

            //return employeeId; 
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Truy vấn chỉ lấy EmployeeID và Password đã băm dựa vào email
                    string query = "SELECT EmployeeID, Password FROM Employees WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHashedPassword = reader["Password"].ToString();
                                int id = Convert.ToInt32(reader["EmployeeID"]);

                                // Mã hóa mật khẩu người dùng nhập vào
                                string hashedPassword = HashPassword(password);

                                // So sánh mật khẩu đã mã hóa với mật khẩu trong cơ sở dữ liệu
                                if (hashedPassword == storedHashedPassword)
                                {
                                    employeeId = id; // Trả về EmployeeID nếu mật khẩu khớp
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return employeeId;
        }
        public string GetRoleById(int employeeId)
        {
            string role = null; 

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Role FROM Employees WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            role = result.ToString(); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return role;
        }
        public EmployeeDTO FindEmployeeById(int employeeId)
        {
            EmployeeDTO employee = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Employees WHERE EmployeeID = @EmployeeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new EmployeeDTO
                                {
                                    EmployeeID = reader.GetInt32(0),
                                    Email = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3),
                                    Status = reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    Img = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    Name = reader.GetString(7),
                                    Phone = reader.IsDBNull(8) ? null : reader.GetString(8),
                                    Gender = reader.IsDBNull(9) ? null : reader.GetString(9),
                                    DayOfBirth = reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10)
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

            return employee; 
        }
        public void ChangePassword(int employeeId, string newPassword)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string hashedPassword = HashPassword(newPassword); // Mã hóa mật khẩu mới

                    string query = "UPDATE Employees SET Password = @Password WHERE EmployeeID = @EmployeeID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeID", employeeId);
                        command.Parameters.AddWithValue("@Password", hashedPassword); // Sử dụng mật khẩu đã mã hóa
                        command.ExecuteNonQuery();
                        Console.WriteLine("Đã cập nhật mật khẩu thành công cho nhân viên có ID: " + employeeId);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public List<EmployeeDTO> GetEmployeesByGender(string gender)
        {
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Employees WHERE Gender = @Gender";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Gender", gender);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeDTO employee = new EmployeeDTO
                                {
                                    EmployeeID = reader.GetInt32(0),
                                    Email = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3),
                                    Status = reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    Img = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    Name = reader.GetString(7),
                                    Phone = reader.IsDBNull(8) ? null : reader.GetString(8),
                                    Gender = reader.IsDBNull(9) ? null : reader.GetString(9),
                                    DayOfBirth = reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10)
                                };

                                employeeList.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return employeeList;
        }
        public List<EmployeeDTO> GetEmployeesByAgeRange(int minAge, int maxAge)
        {
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT * 
                FROM Employees 
                WHERE DATEDIFF(year, DayOfBirth, GETDATE()) BETWEEN @MinAge AND @MaxAge";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MinAge", minAge);
                        command.Parameters.AddWithValue("@MaxAge", maxAge);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeDTO employee = new EmployeeDTO
                                {
                                    EmployeeID = reader.GetInt32(0),
                                    Email = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3),
                                    Status = reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    Img = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    Name = reader.GetString(7),
                                    Phone = reader.IsDBNull(8) ? null : reader.GetString(8),
                                    Gender = reader.IsDBNull(9) ? null : reader.GetString(9),
                                    DayOfBirth = reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10)
                                };


                                employeeList.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return employeeList;
        }
        public List<EmployeeDTO> GetEmployeesByStatus(string status)
        {
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Employees WHERE Status = @Status";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", status);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                EmployeeDTO employee = new EmployeeDTO
                                {
                                    EmployeeID = reader.GetInt32(0),
                                    Email = reader.GetString(1),
                                    Password = reader.GetString(2),
                                    Role = reader.GetString(3),
                                    Status = reader.GetString(4),
                                    CreatedAt = reader.GetDateTime(5),
                                    Img = reader.IsDBNull(6) ? null : reader.GetString(6),
                                    Name = reader.GetString(7),
                                    Phone = reader.IsDBNull(8) ? null : reader.GetString(8),
                                    Gender = reader.IsDBNull(9) ? null : reader.GetString(9),
                                    DayOfBirth = reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10)
                                };

                                employeeList.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi xảy ra: " + ex.Message);
            }

            return employeeList;
        }

    }
}
