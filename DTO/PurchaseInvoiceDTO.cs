public class PurchaseInvoiceDTO
{
    public int PurchaseInvoiceID { get; set; }
    public int SupplierID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal TotalAmount { get; set; }
}
