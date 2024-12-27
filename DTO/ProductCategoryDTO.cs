public class ProductCategoryDTO
{
    public int CategoryID { get; set; }       // Random
    public string CategoryName { get; set; }  // Tên loại sản phẩm

    // Override ToString to return the desired format
    public override string ToString()
    {
        return $"{CategoryID} - {CategoryName}";
    }
}
