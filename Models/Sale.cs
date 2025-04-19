namespace WebApi_Project.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CustomerName { get; set; }
    }
}
