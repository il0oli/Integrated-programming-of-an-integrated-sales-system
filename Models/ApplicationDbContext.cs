using Microsoft.EntityFrameworkCore;
using WebApi_Project.Models.ClassModels;

namespace WebApi_Project.Models
{
    public class ApplicationDbContext : DbContext
    {
      //  internal readonly object Sales;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
