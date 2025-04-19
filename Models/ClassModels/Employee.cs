namespace WebApi_Project.Models.ClassModels
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; } 
       
        public string Notes { get; set; }
    }
}