using Backend.Entity;
using Backend.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        public ProductController(IProductService productService)
        {
            _product = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var data = await _product.AddProduct(product);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
          var data =  await _product.AllProduct();
            return Ok(data);
        }
    }
}
