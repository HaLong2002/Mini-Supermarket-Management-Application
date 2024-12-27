using SieuThiMini.DAO;

public class CustomerBUS
{
    private CustomerDAO customerDAO;
   // private PromotionDAO promotionDAO;

    public CustomerBUS()
    {
        customerDAO = new CustomerDAO();
      //  promotionDAO = new PromotionDAO();

    }

    public List<CustomerDTO> GetAllCustomers()
    {
        return customerDAO.GetAllCustomers();
    }
    public void AddCustomer(CustomerDTO newCustomer)
    {
        customerDAO.AddCustomer(newCustomer);
    }
    public bool IsPhoneExists(string phone)
    { 
        return customerDAO.IsPhoneExists(phone);
    }
    public void UpdateCustomer(CustomerDTO updatedCustomer)
    {
        customerDAO.UpdateCustomer(updatedCustomer);
    }
    public void DeleteCustomer(int customerId)
    {
        customerDAO.DeleteCustomer(customerId);
    }
    public CustomerDTO GetCustomerById(int customerId)
    {
        return customerDAO.GetCustomerById(customerId);
    }
    public List<CustomerDTO> SearchCustomers(string keyword)
    {
        return customerDAO.SearchCustomers(keyword);
    }
    public List<CustomerDTO> GetCustomersMaxPoint()
    {
           return customerDAO.GetCustomersMaxPoint();
    }
    public List<CustomerDTO> GetCustomersMinPoint()
    {
        return customerDAO.GetCustomersMinPoint();
    }
    ////////////////////////////////////////////////////////////////////////////////
    public List<InvoiceDTO> GetAllInvoices()
    {
        return customerDAO.GetAllInvoices();
    }
    public List<InvoiceDTO> GetInvoicesByCustomerID(int customerID)
    {
        return customerDAO.GetInvoicesByCustomerID(customerID);
    }
    public List<InvoiceDetailDTO> GetAllInvoiceDetails()
    {
        return customerDAO.GetAllInvoiceDetails();
    }
    public List<InvoiceDetailDTO> GetInvoiceDetailsByInvoiceID(int invoiceID)
    {
        return customerDAO.GetInvoiceDetailsByInvoiceID(invoiceID);
    }
    public List<InvoiceDTO> GetInvoicesByDateRange(DateTime startDate, DateTime endDate)
    {
        return customerDAO.GetInvoicesByDateRange(startDate, endDate);
    }
    public List<PromotionDTO> GetAllPromotions()
    {
        return customerDAO.GetAllPromotions();
    }

}
