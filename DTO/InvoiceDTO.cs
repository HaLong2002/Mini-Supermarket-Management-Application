public class InvoiceDTO
{
    public int InvoiceID { get; set; }
    public int CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public int PointEarned { get; set; }
}
