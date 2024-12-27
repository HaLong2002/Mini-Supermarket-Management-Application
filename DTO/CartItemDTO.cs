public class CartItemDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductTypeID { get; set; }
    public string Brand { get; set; }
    public string CountryOfOrigin { get; set; }
    public decimal Price { get; set; }
    public string Unit { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public string Benefits { get; set; }
    public decimal Weight { get; set; }
    public string Flavor { get; set; }
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string ImageUrl { get; set; }
    public string Status { get; set; }
    public int Quantity { get; set; }
    public decimal DiscountedPrice { get; set; }
    public int PromotionId { get; set; }
    public string ImgUrl { get; set; } // Added ImgUrl property to store the image URL

}