using Backend.Entity;
using Backend.Interface;
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
      var data = await _product.AllProduct();
      return Ok(data);
    }

    [HttpGet("Id")]
    public async Task<IActionResult> GetProductById(Guid Id)
    {
      return Ok(await _product.GetProductById(Id));
    }

    [HttpPut("Id")]
    public async Task<IActionResult> UpdateProduct(Guid Id, Product product)
    {
      return Ok(await _product.UpdateProduct(Id, product));
    }

    [HttpDelete("Id")]
    public async Task<IActionResult> DeleteProduct(Guid Id)
    {
      return Ok(await _product.DeleteProduct(Id));
    }
  }
}
