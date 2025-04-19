using Microsoft.EntityFrameworkCore;
using WebApi_Project.Interfaces;
using WebApi_Project.Models;
using WebApi_Project.Models.ClassModels;

namespace WebApi_Project.Services
{
    public class ProductService : ModelService<Product>
    {
        private ApplicationDbContext _context;

       public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        // الحصول على جميع العناصر
        public async Task<IEnumerable<Product>> GetAllItemsAsync()
        {
            return await _context.Products.ToListAsync();   
        }


        // الحصول على عميل واحد
        public async Task<Product> GetItemByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        // اضافة 
        public async Task<Product> CreateItemAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product; 
        }

        // تحديث بيانات عنصر واحد
        public async Task UpdateItemAsync(Product product)
        {
           _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // حذف 
        public async Task DeleteItemAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();  
            }
            
        }

      


       
    }
}
