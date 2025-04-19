using Microsoft.EntityFrameworkCore;
using WebApi_Project.Interfaces;
using WebApi_Project.Models;
using WebApi_Project.Models.ClassModels;

namespace WebApi_Project.Services
{
    public class EmployeeService : ModelService<Employee>
    {
        private ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Employee>> GetAllItemsAsync()
        {
          
           return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> CreateItemAsync(Employee employee)
        {
             _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteItemAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
               await _context.SaveChangesAsync();
            }
        }

      

        public async Task<Employee> GetItemByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public async Task UpdateItemAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
