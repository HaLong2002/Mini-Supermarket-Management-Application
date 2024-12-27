using SieuThiMini.DTO;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.DAO
{
    public class SupplierProductsDAO
    {
        string connectionString = ClassKetnoi.ConnectionString;

        public List<SupplierProductsDTO> GetSupplierProductList()
        {
            List<SupplierProductsDTO> supplierProductList = new List<SupplierProductsDTO>();

            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM SupplierProducts";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SupplierProductsDTO product = new SupplierProductsDTO
                        {
                            ProductId = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = (decimal)reader["Price"] as decimal? ?? 0.0m,
                            StockQuantity = (int)reader["StockQuantity"] as int? ?? 0,
                            Unit = reader["Unit"].ToString(),
                            Status = reader["Status"].ToString(),
                            ProductTypeID = (int)reader["ProductTypeID"],
                            CountryOfOrigin = reader["CountryOfOrigin"].ToString(),
                            ImageUrl = reader["ImageUrl"].ToString(),
                            SupplierID = (int)reader["SupplierID"],
                            Brand = reader["Brand"].ToString(),
                            Benefits = reader["Benefits"].ToString(),
                            Ingredients = reader["Ingredients"].ToString(),
                            Flavor = reader["Flavor"].ToString(),
                            Weight = (decimal)reader["Weight"] as decimal? ?? 0.0m,
                            ManufactureDate = reader.GetDateTime(15),
                            ExpirationDate = reader.GetDateTime(16)

                        };
                        supplierProductList.Add(product);
                    }
                }
            }

            return supplierProductList;
        }

        public List<SupplierProductsDTO> GetAllSupplierProduct()
        {
            List<SupplierProductsDTO> supplierProductList = new List<SupplierProductsDTO>();

            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM SupplierProducts";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SupplierProductsDTO product = new SupplierProductsDTO
                        {
                            ProductId = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = (decimal)reader["Price"] as decimal? ?? 0.0m,
                            StockQuantity = (int)reader["StockQuantity"] as int? ?? 0,
                            Unit = reader["Unit"].ToString(),
                            Status = reader["Status"].ToString(),
                            ProductTypeID = (int)reader["ProductTypeID"],
                            CountryOfOrigin = reader["CountryOfOrigin"].ToString(),
                            ImageUrl = reader["ImageUrl"].ToString(),
                            SupplierID = (int)reader["SupplierID"],
                            Brand = reader["Brand"].ToString(),
                            Benefits = reader["Benefits"].ToString(),
                            Ingredients = reader["Ingredients"].ToString(),
                            Flavor = reader["Flavor"].ToString(),
                            Weight = (decimal)reader["Weight"] as decimal? ?? 0.0m,
                            // Xử lý giá trị DateTime với kiểm tra NULL
                            ManufactureDate = reader["ManufactureDate"] != DBNull.Value
                                ? reader.GetDateTime(reader.GetOrdinal("ManufactureDate"))
                                : DateTime.MinValue, // Giá trị mặc định
                            ExpirationDate = reader["ExpirationDate"] != DBNull.Value
                                ? reader.GetDateTime(reader.GetOrdinal("ExpirationDate"))
                                : DateTime.MinValue, // Giá trị mặc định

                        };
                        supplierProductList.Add(product);
                    }
                }
            }

            return supplierProductList;
        }

        public List<SupplierProductsDTO> GetSupplierProductListBySupplier(int supplierID)
        {
            List<SupplierProductsDTO> supplierProductList = new List<SupplierProductsDTO>();

            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM SupplierProducts WHERE SupplierID = @SupplierID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", supplierID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SupplierProductsDTO product = new SupplierProductsDTO
                        {
                            ProductId = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = (decimal)reader["Price"] as decimal? ?? 0.0m,
                            StockQuantity = (int)reader["StockQuantity"] as int? ?? 0,
                            Unit = reader["Unit"].ToString(),
                            Status = reader["Status"].ToString(),
                            ProductTypeID = (int)reader["ProductTypeID"],
                            CountryOfOrigin = reader["CountryOfOrigin"].ToString(),
                            ImageUrl = reader["ImageUrl"].ToString(),
                            SupplierID = (int)reader["SupplierID"],
                            Brand = reader["Brand"].ToString(),
                            Benefits = reader["Benefits"].ToString(),
                            Ingredients = reader["Ingredients"].ToString(),
                            Flavor = reader["Flavor"].ToString(),
                            Weight = (decimal)reader["Weight"] as decimal? ?? 0.0m,
                            ManufactureDate = reader.GetDateTime(15),
                            ExpirationDate = reader.GetDateTime(16)

                        };
                        supplierProductList.Add(product);
                    }
                }
            }

            return supplierProductList;
        }

        public List<SupplierProductsDTO> GetAllSupplierProductListBySupplier(int supplierID)
        {
            List<SupplierProductsDTO> supplierProductList = new List<SupplierProductsDTO>();

            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM SupplierProducts WHERE SupplierID = @SupplierID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", supplierID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SupplierProductsDTO product = new SupplierProductsDTO
                        {
                            ProductId = (int)reader["ProductID"],
                            ProductName = reader["ProductName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = (decimal)reader["Price"] as decimal? ?? 0.0m,
                            StockQuantity = (int)reader["StockQuantity"] as int? ?? 0,
                            Unit = reader["Unit"].ToString(),
                            Status = reader["Status"].ToString(),
                            ProductTypeID = (int)reader["ProductTypeID"],
                            CountryOfOrigin = reader["CountryOfOrigin"].ToString(),
                            ImageUrl = reader["ImageUrl"].ToString(),
                            SupplierID = (int)reader["SupplierID"],
                            Brand = reader["Brand"].ToString(),
                            Benefits = reader["Benefits"].ToString(),
                            Ingredients = reader["Ingredients"].ToString(),
                            Flavor = reader["Flavor"].ToString(),
                            Weight = (decimal)reader["Weight"] as decimal? ?? 0.0m,
                            ManufactureDate = reader["ManufactureDate"] != DBNull.Value
                            ? reader.GetDateTime(reader.GetOrdinal("ManufactureDate"))
                            : DateTime.MinValue, // Giá trị mặc định
                            ExpirationDate = reader["ExpirationDate"] != DBNull.Value
                            ? reader.GetDateTime(reader.GetOrdinal("ExpirationDate"))
                            : DateTime.MinValue, // Giá trị mặc định

                        };
                        supplierProductList.Add(product);
                    }
                }
            }

            return supplierProductList;
        }

        public void CreateSupplierProduct(SupplierProductsDTO product)
        {
            string query = "ALTER TABLE SupplierProducts NOCHECK CONSTRAINT FK__SupplierP__Expir__66603565; INSERT INTO SupplierProducts (ProductName, Description, Price, StockQuantity, Unit, Status, ProductTypeID, CountryOfOrigin, ImageUrl, SupplierID, Brand, Ingredients, ManufactureDate, ExpirationDate, Benefits, Flavor, Weight) " +
                   "VALUES (@ProductName, @Description, @Price, @StockQuantity, @Unit, @Status, @ProductTypeID, @CountryOfOrigin, @ImageUrl, @SupplierID, @Brand, @Ingredients, @ManufactureDate, @ExpirationDate, @Benefits, @Flavor, @Weight)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters to the SQL query
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                command.Parameters.AddWithValue("@Unit", product.Unit);
                command.Parameters.AddWithValue("@Status", product.Status);
                command.Parameters.AddWithValue("@ProductTypeID", product.ProductTypeID);
                command.Parameters.AddWithValue("@CountryOfOrigin", product.CountryOfOrigin);
                command.Parameters.AddWithValue("@ImageUrl", product.ImageUrl ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@SupplierID", product.SupplierID);
                command.Parameters.AddWithValue("@Brand", product.Brand);
                command.Parameters.AddWithValue("@Ingredients", product.Ingredients);
                command.Parameters.AddWithValue("@ManufactureDate", product.ManufactureDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Benefits", product.Benefits);
                command.Parameters.AddWithValue("@Flavor", product.Flavor);
                command.Parameters.AddWithValue("@Weight", product.Weight);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Product created successfully.");
            }
        }
        public void EditSupplierProduct(SupplierProductsDTO product) 
        {
            string query = "ALTER TABLE SupplierProducts NOCHECK CONSTRAINT FK__SupplierP__Expir__66603565; UPDATE SupplierProducts SET ProductName = @ProductName, Description = @Description, Price = @Price, " +
                       "StockQuantity = @StockQuantity, Unit = @Unit, Status = @Status, ProductTypeID = @ProductTypeID, " +
                       "CountryOfOrigin = @CountryOfOrigin, ImageUrl = @ImageUrl, Brand = @Brand, Ingredients = @Ingredients, ManufactureDate = @ManufactureDate, ExpirationDate = @ExpirationDate, Benefits = @Benefits, Weight = @Weight, Flavor = @Flavor WHERE ProductID = @ProductID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", product.ProductId);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                command.Parameters.AddWithValue("@Unit", product.Unit);
                command.Parameters.AddWithValue("@Status", product.Status);
                command.Parameters.AddWithValue("@ProductTypeID", product.ProductTypeID);
                command.Parameters.AddWithValue("@CountryOfOrigin", product.CountryOfOrigin);
                command.Parameters.AddWithValue("@ImageUrl", product.ImageUrl ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Brand", product.Brand);
                command.Parameters.AddWithValue("@Ingredients", product.Ingredients);
                command.Parameters.AddWithValue("@ManufactureDate", product.ManufactureDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Benefits", product.Benefits);
                command.Parameters.AddWithValue("@Flavor", product.Flavor);
                command.Parameters.AddWithValue("@Weight", product.Weight);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Product updated successfully.");
                else
                    Console.WriteLine("Product not found.");
            }
        }
        public void DeleteSupplierProduct(int productID)
        {
            string query = "DELETE FROM SupplierProducts WHERE ProductID = @ProductID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Product deleted successfully.");
                else
                    Console.WriteLine("Product not found.");
            }
        }

        public void DeleteSupplierProductBySupplier(int supplierID)
        {
            string query = "DELETE FROM SupplierProducts WHERE SupplierID = @SupplierID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", supplierID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Product deleted successfully.");
                else
                    Console.WriteLine("Product not found.");
            }
        }

        public SupplierProductsDTO GetProductFromSupplier(int productId)
        {
            SupplierProductsDTO product = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                sp.ProductId, 
                sp.ProductName, 
                sp.ProductTypeID, 
                sp.Brand, 
                sp.CountryOfOrigin, 
                sp.Price, 
                sp.StockQuantity, 
                sp.Unit, 
                sp.Description, 
                sp.Ingredients, 
                sp.Benefits, 
                sp.Weight, 
                sp.Flavor, 
                sp.ManufactureDate, 
                sp.ExpirationDate, 
                sp.ImageUrl, 
                sp.Status, 
                sp.SupplierID
            FROM SupplierProducts sp
            WHERE sp.ProductId = @ProductId";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product = new SupplierProductsDTO
                    {
                        ProductId = (int)reader["ProductId"],
                        ProductName = reader["ProductName"].ToString(),
                        ProductTypeID = (int)reader["ProductTypeID"],
                        Brand = reader["Brand"].ToString(),
                        CountryOfOrigin = reader["CountryOfOrigin"].ToString(),
                        Price = (decimal)reader["Price"],
                        StockQuantity = (int)reader["StockQuantity"],
                        Unit = reader["Unit"].ToString(),
                        Description = reader["Description"].ToString(),
                        Ingredients = reader["Ingredients"].ToString(),
                        Benefits = reader["Benefits"].ToString(),
                        Weight = (decimal)reader["Weight"],
                        Flavor = reader["Flavor"].ToString(),
                        ManufactureDate = (DateTime)reader["ManufactureDate"],
                        ExpirationDate = (DateTime)reader["ExpirationDate"],
                        ImageUrl = reader["ImageUrl"].ToString(),
                        Status = reader["Status"].ToString(),
                        SupplierID = (int)reader["SupplierID"]
                    };
                }
            }
            return product;
        }

    }
}
