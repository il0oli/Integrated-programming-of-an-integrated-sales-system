using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using WebApi_Project.Models;
using WebApi_Project.Models.ClassModels;


namespace WebApi_Project.Controllers.sub_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ApplicationDbContext _context; 

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET:api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDTO = new Product
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                Unit = product.Unit,
                Price = product.Price
            };

            return productDTO;
        }


        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();  
            return CreatedAtAction("GetProduct", new {id = product.ProductID}, product);
        }

    

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product productDTO)
        {
            if (id != productDTO.ProductID)
            {
                return BadRequest();
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            // تحديث قيم الحقول المسموح بها فقط
            product.ProductName = productDTO.ProductName;
            product.Unit = productDTO.Unit;
            product.Price = productDTO.Price;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.ProductID == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            
            var product = await _context.Products.FindAsync(id);

          
            if (product == null)
            {
                return NotFound();
            }

            // حذف  من قاعدة البيانات
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            // أرجع استجابة  تفيد بنجاح العملية
            return NoContent(); // يمكن أيضاً استخدام Ok() إذا أردت إرجاع رد إيجابي محدد
        }


    }
}
