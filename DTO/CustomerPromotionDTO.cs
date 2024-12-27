public class CustomerPromotionDTO
{
    public int CustomerId { get; set; }         
    public int PromotionID { get; set; }       
    public DateTime ReceivedDate { get; set; }
    public bool IsUsed { get; set; }
}
