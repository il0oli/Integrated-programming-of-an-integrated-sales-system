/*using WebApi_Project.interfaces;
using WebApi_Project.Models.ClassModels;
using WebApi_Project.Models;
using Microsoft.EntityFrameworkCore;
*/

using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi_Project.Models; // تأكد من استخدام فضاء الأسماء الصحيح لـ ApplicationDbContext
using WebApi_Project.Models.ClassModels; // تأكد من استخدام فضاء الأسماء الصحيح لـ Customer
using WebApi_Project.Interfaces;

namespace WebApi_Project.Services
{
    public class CustomerService : ModelService<Customer>
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        // الحصول على جميع العملاء
        public async Task<IEnumerable<Customer>> GetAllItemsAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        // الحصول على عميل بمعرفه
        public async Task<Customer> GetItemByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }

        // إضافة عميل جديد
        public async Task<Customer> CreateItemAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        // تحديث بيانات عميل
        public async Task UpdateItemAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // حذف عميل
        public async Task DeleteItemAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
