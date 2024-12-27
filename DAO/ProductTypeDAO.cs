using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.DAO
{
    public class ProductTypeDAO
    {
        private string connectionString;

        public ProductTypeDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Method to get all product types from the database
        public List<ProductTypeDTO> GetAllProductTypes()
        {
            var productTypes = new List<ProductTypeDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM ProductTypes";
                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productType = new ProductTypeDTO
                        {
                            ProductTypeID = (int)reader["ProductTypeID"],
                            CategoryID = (int)reader["CategoryID"],
                            ProductTypeName = reader["ProductTypeName"].ToString()
                        };
                        productTypes.Add(productType);
                    }
                }
            }

            return productTypes;
        }

        public List<ProductTypeDTO> GetProductTypesByCategoryId(int categoryId)
        {
            var productTypes = new List<ProductTypeDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Modify the query to filter by CategoryID
                string sql = "SELECT * FROM ProductTypes WHERE CategoryID = @CategoryID";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Add the CategoryID as a parameter to prevent SQL injection
                    command.Parameters.AddWithValue("@CategoryID", categoryId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productType = new ProductTypeDTO
                            {
                                ProductTypeID = (int)reader["ProductTypeID"],
                                CategoryID = (int)reader["CategoryID"],
                                ProductTypeName = reader["ProductTypeName"].ToString()
                            };
                            productTypes.Add(productType);
                        }
                    }
                }
            }
            return productTypes;
        }


        // Method to add a new product type to the database
        public void AddProductType(ProductTypeDTO productType)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO ProductTypes (ProductTypeName, CategoryID) VALUES (@ProductTypeName, @CategoryID)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductTypeName", productType.ProductTypeName);
                    command.Parameters.AddWithValue("@CategoryID", productType.CategoryID);
                    command.ExecuteNonQuery();
                }
            }
        }


        public bool UpdateProductType(int typeId, string typeName, int categoryId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductTypes SET ProductTypeName = @ProductTypeName, CategoryID = @CategoryID WHERE ProductTypeID = @ProductTypeID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductTypeName", typeName);
                    cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                    cmd.Parameters.AddWithValue("@ProductTypeID", typeId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteProductType(int productTypeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Tìm productTypeID có tên là "Khác" trong bảng ProductTypes cái mà cũng nằm trong bảng ProductCategories cũng có tên là "Khác"
                int otherProductTypeId;
                string getOtherProductTypeIdQuery = @"
                    SELECT pt.ProductTypeID 
                    FROM ProductTypes pt
                    INNER JOIN Categories pc ON pt.CategoryID = pc.CategoryID
                    WHERE pt.ProductTypeName = N'Khác' AND pc.CategoryName = N'Khác'";

                using (SqlCommand getOtherCmd = new SqlCommand(getOtherProductTypeIdQuery, conn))
                {
                    object result = getOtherCmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy loại sản phẩm 'Khác' có danh mục 'Khác'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    otherProductTypeId = (int)result;
                }

                // Kiểm tra có phụ thuộc với productType muốn xóa không
                string checkQuery = "SELECT COUNT(*) FROM Products WHERE ProductTypeID = @ProductTypeID";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@ProductTypeID", productTypeId);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        DialogResult dialogResult = MessageBox.Show(
                            "Không thể xóa bởi vì có sản phẩm phụ thuộc vào loại sản phẩm: " + productTypeId + ".\n\n" +
                            "Chọn Yes để thay thế Loại sản phẩm trong Sản phẩm thành Khác và xóa loại sản phẩm này.\n\n" +
                            "Chọn No để hủy thao tác xóa.",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.No)
                        {
                            return false;
                        }

                        // Cập nhật các loại sản phẩm của sản phẩm phụ thuộc => thành Loại sản phẩm "Khác"
                        string updateQuery = "UPDATE Products SET ProductTypeID = @OtherProductTypeID WHERE ProductTypeID = @ProductTypeID";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@OtherProductTypeID", otherProductTypeId);
                            updateCmd.Parameters.AddWithValue("@ProductTypeID", productTypeId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }

                // Xóa loại sản phẩm
                string deleteQuery = "DELETE FROM ProductTypes WHERE ProductTypeID = @ProductTypeID";
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@ProductTypeID", productTypeId);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


    }
}
