using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Project.Interfaces;
using WebApi_Project.Services;

namespace WebApi_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        /*private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public SalesController(ICustomerService customerService)
        {
            _customerService = customerService;
        }*/

        // يمكنك الآن استخدام _customerService للوصول إلى بيانات العملاء
    }

}
