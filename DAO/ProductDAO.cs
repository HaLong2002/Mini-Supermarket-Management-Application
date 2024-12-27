using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using SieuThiMini.DTO;

namespace SieuThiMini.DAO
{
    internal class ProductDAO
    {
        string connectionString = ClassKetnoi.ConnectionString;

        // Lấy tất cả sản phẩm
        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductDTO product = new ProductDTO
                    {
                        ProductId = reader["ProductId"] != DBNull.Value ? (int)reader["ProductId"] : 0,
                        ProductName = reader["ProductName"]?.ToString() ?? "N/A",
                        ProductTypeID = reader["ProductTypeID"] != DBNull.Value ? (int)reader["ProductTypeID"] : 0,
                        Brand = reader["Brand"]?.ToString() ?? "Unknown",
                        CountryOfOrigin = reader["CountryOfOrigin"]?.ToString() ?? "Unknown",
                        Price = reader["Price"] != DBNull.Value ? (decimal)reader["Price"] : 0,
                        StockQuantity = reader["StockQuantity"] != DBNull.Value ? (int)reader["StockQuantity"] : 0,
                        Unit = reader["Unit"]?.ToString() ?? "N/A",
                        Description = reader["Description"]?.ToString() ?? "",
                        Ingredients = reader["Ingredients"]?.ToString() ?? "",
                        Benefits = reader["Benefits"]?.ToString() ?? "",
                        Weight = reader["Weight"] != DBNull.Value ? (decimal)reader["Weight"] : 0,
                        Flavor = reader["Flavor"]?.ToString() ?? "N/A",
                        ManufactureDate = reader["ManufactureDate"] != DBNull.Value
                            ? (DateTime)reader["ManufactureDate"]
                            : DateTime.MinValue,
                        ExpirationDate = reader["ExpirationDate"] != DBNull.Value
                            ? (DateTime)reader["ExpirationDate"]
                            : DateTime.MinValue,
                        ImageUrl = reader["ImageUrl"]?.ToString() ?? "",
                        Status = reader["Status"]?.ToString() ?? "Unavailable"
                    };
                    products.Add(product);
                }


            }
            return products;
        }

        public List<ProductDTO> GetAllProductsForSale()
        {
            List<ProductDTO> products = new List<ProductDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Lấy trạng thái sản phẩm từ cơ sở dữ liệu
                    string status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : "Còn hạn lâu dài";

                    // Kiểm tra trạng thái hợp lệ, chỉ hiển thị sản phẩm nếu trạng thái là "Gần hết hạn" hoặc "Còn hạn lâu dài"
                    if (status == "Còn hạn lâu dài" || status == "Gần hết hạn")
                    {
                        ProductDTO product = new ProductDTO
                        {
                            ProductId = reader["ProductId"] != DBNull.Value ? (int)reader["ProductId"] : 0,
                            ProductName = reader["ProductName"]?.ToString() ?? "N/A",
                            ProductTypeID = reader["ProductTypeID"] != DBNull.Value ? (int)reader["ProductTypeID"] : 0,
                            Brand = reader["Brand"]?.ToString() ?? "Unknown",
                            CountryOfOrigin = reader["CountryOfOrigin"]?.ToString() ?? "Unknown",
                            Price = reader["Price"] != DBNull.Value ? (decimal)reader["Price"] : 0,
                            StockQuantity = reader["StockQuantity"] != DBNull.Value ? (int)reader["StockQuantity"] : 0,
                            Unit = reader["Unit"]?.ToString() ?? "N/A",
                            Description = reader["Description"]?.ToString() ?? "",
                            Ingredients = reader["Ingredients"]?.ToString() ?? "",
                            Benefits = reader["Benefits"]?.ToString() ?? "",
                            Weight = reader["Weight"] != DBNull.Value ? (decimal)reader["Weight"] : 0,
                            Flavor = reader["Flavor"]?.ToString() ?? "N/A",
                            ManufactureDate = reader["ManufactureDate"] != DBNull.Value
                                ? (DateTime)reader["ManufactureDate"]
                                : DateTime.MinValue,
                            ExpirationDate = reader["ExpirationDate"] != DBNull.Value
                                ? (DateTime)reader["ExpirationDate"]
                                : DateTime.MinValue,
                            ImageUrl = reader["ImageUrl"]?.ToString() ?? "",
                            Status = status
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }





        public void UpdateProductStatus(int productId, string status)
        {
            // Cập nhật trạng thái của sản phẩm trong cơ sở dữ liệu
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Products SET Status = @status WHERE ProductId = @productId", connection);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@productId", productId);
                command.ExecuteNonQuery();
            }
        }

        // Thêm sản phẩm
        public void AddProduct(ProductDTO product)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName, ProductTypeID, Brand, CountryOfOrigin, Price, StockQuantity, Unit, Description, Ingredients, Benefits, Weight, Flavor, ManufactureDate, ExpirationDate, ImageUrl, Status) VALUES (@ProductName, @ProductTypeID, @Brand, @CountryOfOrigin, @Price, @StockQuantity, @Unit, @Description, @Ingredients, @Benefits, @Weight, @Flavor, @ManufactureDate, @ExpirationDate, @ImageUrl, @Status)", conn);

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductTypeID", product.ProductTypeID);
                cmd.Parameters.AddWithValue("@Brand", product.Brand);
                cmd.Parameters.AddWithValue("@CountryOfOrigin", product.CountryOfOrigin);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("@Unit", product.Unit);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Ingredients", product.Ingredients);
                cmd.Parameters.AddWithValue("@Benefits", product.Benefits);
                cmd.Parameters.AddWithValue("@Weight", product.Weight);
                cmd.Parameters.AddWithValue("@Flavor", product.Flavor);
                cmd.Parameters.AddWithValue("@ManufactureDate", product.ManufactureDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate);
                cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                cmd.Parameters.AddWithValue("@Status", product.Status);

                cmd.ExecuteNonQuery();
            }
        }

        // Cập nhật sản phẩm
        public void UpdateProduct(ProductDTO product)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Products SET ProductName = @ProductName, ProductTypeID = @ProductTypeID, Brand = @Brand, CountryOfOrigin = @CountryOfOrigin, Price = @Price, StockQuantity = @StockQuantity, Unit = @Unit, Description = @Description, Ingredients = @Ingredients, Benefits = @Benefits, Weight = @Weight, Flavor = @Flavor, ManufactureDate = @ManufactureDate, ExpirationDate = @ExpirationDate, ImageUrl = @ImageUrl, Status = @Status WHERE ProductId = @ProductId", conn);

                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductTypeID", product.ProductTypeID); // string
                cmd.Parameters.AddWithValue("@Brand", product.Brand);
                cmd.Parameters.AddWithValue("@CountryOfOrigin", product.CountryOfOrigin);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                cmd.Parameters.AddWithValue("@Unit", product.Unit);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Ingredients", product.Ingredients);
                cmd.Parameters.AddWithValue("@Benefits", product.Benefits);
                cmd.Parameters.AddWithValue("@Weight", product.Weight);
                cmd.Parameters.AddWithValue("@Flavor", product.Flavor);
                cmd.Parameters.AddWithValue("@ManufactureDate", product.ManufactureDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", product.ExpirationDate);
                cmd.Parameters.AddWithValue("@ImageUrl", product.ImageUrl);
                cmd.Parameters.AddWithValue("@Status", product.Status);

                cmd.ExecuteNonQuery();
            }
        }

        // Xóa sản phẩm
        public void DeleteProduct(int productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Xóa các bản ghi liên quan trong bảng InvoiceDetails
                SqlCommand deleteInvoiceDetailsCmd = new SqlCommand(
                    "DELETE FROM InvoiceDetails WHERE ProductID = @ProductId", conn);
                deleteInvoiceDetailsCmd.Parameters.AddWithValue("@ProductId", productId);
                deleteInvoiceDetailsCmd.ExecuteNonQuery();

                // Xóa các bản ghi liên quan trong bảng Promotions
                SqlCommand deletePromotionsCmd = new SqlCommand(
                    "DELETE FROM Promotions WHERE ProductID = @ProductId", conn);
                deletePromotionsCmd.Parameters.AddWithValue("@ProductId", productId);
                deletePromotionsCmd.ExecuteNonQuery();

                // Xóa sản phẩm trong bảng Products
                SqlCommand deleteProductCmd = new SqlCommand(
                    "DELETE FROM Products WHERE ProductID = @ProductId", conn);
                deleteProductCmd.Parameters.AddWithValue("@ProductId", productId);
                deleteProductCmd.ExecuteNonQuery();
            }
        }


        // Tìm kiếm sản phẩm theo tên
        public List<ProductDTO> SearchProducts(string productName)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductName LIKE @ProductName", conn);
                cmd.Parameters.AddWithValue("@ProductName", "%" + productName + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductDTO product = new ProductDTO
                    {
                        ProductId = (int)reader["ProductId"],
                        ProductName = reader["ProductName"].ToString(),
                        ProductTypeID = (int)reader["ProductTypeID"], // string
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
                        Status = reader["Status"].ToString()
                    };
                    products.Add(product);
                }
            }
            return products;
        }
        // Tìm kiếm sản phẩm theo ProductId
        public ProductDTO GetProductById(int productId)
        {
            ProductDTO product = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductId = @ProductId", conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    product = new ProductDTO
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
                        Status = reader["Status"].ToString()
                    };
                }
            }
            return product;
        }
        // Phương thức lấy danh sách các quốc gia không trùng lặp
        public List<string> GetUniqueCountries()
        {
            List<string> countries = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT CountryOfOrigin FROM Products";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(reader["CountryOfOrigin"].ToString());
                }
            }
            return countries;
        }

        // Phương thức lấy danh sách thương hiệu không trùng lặp
        public List<string> GetUniqueBrands()
        {
            List<string> brands = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Brand FROM Products";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    brands.Add(reader["Brand"].ToString());
                }
            }
            return brands;
        }

        public List<ProductTypeDTO> GetUniqueProductTypes()
        {
            List<ProductTypeDTO> productTypes = new List<ProductTypeDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT ProductTypeID, ProductTypeName FROM ProductTypes";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductTypeDTO productType = new ProductTypeDTO
                    {
                        ProductTypeID = (int)reader["ProductTypeID"],
                        ProductTypeName = reader["ProductTypeName"].ToString()
                    };
                    productTypes.Add(productType);
                }
            }
            return productTypes;
        }

        public List<ProductDTO> AdvancedSearch(List<string> conditions)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Tạo câu lệnh SQL động dựa trên điều kiện
                string query = "SELECT * FROM Products";
                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProductDTO product = new ProductDTO
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
                        Status = reader["Status"].ToString()

                    };
                    products.Add(product);
                }
            }
            return products;
        }

        public bool CheckProductExists(int productId)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM Products WHERE ProductId = @ProductId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                exists = (int)command.ExecuteScalar() > 0;
            }

            return exists;
        }

        public List<ProductDTO> GetProductsNearExpiration()
        {
            List<ProductDTO> products = new List<ProductDTO>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // SQL query to retrieve products that will expire in the next 30 days
                string query = @"
                    SELECT * 
                    FROM Products
                    WHERE ExpirationDate BETWEEN GETDATE() AND DATEADD(DAY, 30, GETDATE())
                    ORDER BY ExpirationDate ASC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductDTO product = new ProductDTO
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
                                Status = reader["Status"].ToString()
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }


    }
}
