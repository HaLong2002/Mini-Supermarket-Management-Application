public class PromotionDTO
{
        public int PromotionID { get; set; }          
        public int? ProductID { get; set; }           
        public string PromotionName { get; set; }     
        public int Point { get; set; }               
        public decimal DiscountPercent { get; set; }  
        public DateTime StartDate { get; set; }       
        public DateTime EndDate { get; set; }        
        public bool IsActive { get; set; }
        public string Status { get; set; }
}
