using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.DAO
{
    public class SuppliersDAO
    {
        string connectionString = ClassKetnoi.ConnectionString;
        public List<SupplierDTO> GetSuppliersList() {
            List<SupplierDTO> suppliersList = new List<SupplierDTO>();

            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Suppliers";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SupplierDTO supplier = new SupplierDTO
                        {
                            SupplierID = (int) reader["SupplierID"],
                            SupplierName = reader["SupplierName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["Address"].ToString()
                        };
                        suppliersList.Add(supplier);
                    }
                }
            }

            return suppliersList;
        }
        public void CreateSuppilers(SupplierDTO supplier) {
            // SQL query to insert a new supplier into the database
            string query = "INSERT INTO Suppliers (SupplierName, Phone, Email, Address) " +
                           "VALUES (@SupplierName, @Phone, @Email, @Address)";

            // Create a new connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a new SQL command with the query and connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to prevent SQL injection
                command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                command.Parameters.AddWithValue("@Phone", supplier.Phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", supplier.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Address", supplier.Address ?? (object)DBNull.Value);

                // Open the connection and execute the command
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void EditSuppliers(SupplierDTO supplier) {
            // SQL query to update an existing supplier's details
            string query = "UPDATE Suppliers SET SupplierName = @SupplierName, Phone = @Phone, Email = @Email, Address = @Address " +
                           "WHERE SupplierID = @SupplierID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to the SQL query
                command.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                command.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                command.Parameters.AddWithValue("@Phone", supplier.Phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Email", supplier.Email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Address", supplier.Address ?? (object)DBNull.Value);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Supplier updated successfully!");
                }
                else
                {
                    Console.WriteLine("No supplier found with the given SupplierID.");
                }
            }
        }
        public void Delete(int supplierId) {
            // SQL query to delete a supplier by SupplierID
            string query = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add the SupplierID parameter
                command.Parameters.AddWithValue("@SupplierID", supplierId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Supplier deleted successfully!");
                }
                else
                {
                    Console.WriteLine("No supplier found with the given SupplierID.");
                }
            }
        }
    }
}
