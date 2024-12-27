using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.DAO
{
    public class ProductCategoryDAO
    {
        private string connectionString;

        public ProductCategoryDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ProductCategoryDTO> GetAllCategories()
        {
            List<ProductCategoryDTO> categories = new List<ProductCategoryDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new ProductCategoryDTO
                    {
                        CategoryID = (int)reader["CategoryID"],
                        CategoryName = reader["CategoryName"].ToString()
                    });
                }
            }

            return categories;
        }

        public void AddCategory(ProductCategoryDTO category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@CategoryName)", connection);
                command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                command.ExecuteNonQuery();
            }
        }

        public bool UpdateCategory(int categoryId, string categoryName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;  // Return true if update was successful
                }
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Step 1: Find the CategoryID where CategoryName = 'Khác'
                int otherCategoryId;
                string getOtherCategoryIdQuery = "SELECT CategoryID FROM Categories WHERE CategoryName = N'Khác'";
                using (SqlCommand getOtherCommand = new SqlCommand(getOtherCategoryIdQuery, conn))
                {
                    object result = getOtherCommand.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Không tìm thấy danh mục 'Khác'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Exit if "Khác" category is not found
                    }
                    otherCategoryId = (int)result;
                }

                // Step 2: Check for dependent records in the ProductTypes table
                string checkQuery = "SELECT COUNT(*) FROM ProductTypes WHERE CategoryID = @CategoryID";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                {
                    checkCommand.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryId;

                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        // Notify the user that dependent records exist
                        DialogResult result = MessageBox.Show(
                            "Không thể xóa bởi vì có dữ liệu trong Loại sản phẩm phụ thuộc vào ID danh mục: " + categoryId + ".\n\n" +
                            "Chọn Yes để thay thế Danh mục trong Loại sản phẩm thành Khác và sau đó xóa danh mục này.\n\n" +
                            "Chọn No để hủy thao tác xóa.",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.No)
                        {
                            return false; // Indicate that deletion was not successful
                        }

                        // Step 3: Update dependent ProductTypes records to set CategoryID to 'Khác' CategoryID
                        string updateChildQuery = "UPDATE ProductTypes SET CategoryID = @OtherCategoryID WHERE CategoryID = @CategoryID";
                        using (SqlCommand updateChildCommand = new SqlCommand(updateChildQuery, conn))
                        {
                            updateChildCommand.Parameters.Add("@OtherCategoryID", SqlDbType.Int).Value = otherCategoryId;
                            updateChildCommand.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryId;
                            updateChildCommand.ExecuteNonQuery(); // Update the dependent records
                        }
                    }
                }

                // Step 4: Delete the specified category
                string deleteQuery = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn))
                {
                    deleteCommand.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryId;
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    return rowsAffected > 0; // Return true if the category was deleted
                }
            }
        }


    }

}

