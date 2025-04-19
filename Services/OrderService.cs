
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi_Project.Models; // تأكد من استخدام فضاء الأسماء الصحيح لـ ApplicationDbContext
using WebApi_Project.Models.ClassModels; // تأكد من استخدام فضاء الأسماء الصحيح لـ Customer
using WebApi_Project.Interfaces;




namespace WebApi_Project.Services


{
    public class OrderService : ModelService<Order>
    {
        private ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllItemsAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetItemByIdAsync(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            return Order;
        }

        public async Task<Order> CreateItemAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task UpdateItemAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }

        }


    }
}
