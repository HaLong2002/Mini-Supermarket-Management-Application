public class ProductTypeDTO
{
    public int ProductTypeID { get; set; }       // Random
    public int CategoryID { get; set; }  
    public string ProductTypeName { get; set; }

    // Thuộc tính hiển thị kết hợp ID và Tên
    public string DisplayName => $"{ProductTypeID} - {ProductTypeName}";

    // Override ToString nếu cần
    public override string ToString()
    {
        return DisplayName;
    }
}
