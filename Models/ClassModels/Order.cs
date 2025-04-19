namespace WebApi_Project.Models.ClassModels
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
       
        public decimal Total { get; set; }
    }
}