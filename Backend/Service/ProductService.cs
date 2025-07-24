using Backend.Entity;
using Backend.Interface;

namespace Backend.Service
{
  public class ProductService : IProductService
  {
    private IproductRepository _iproduct;
    public ProductService(IproductRepository iproduct)
    {
      _iproduct = iproduct;
    }

    public async Task<Product> AddProduct(Product product)
    {
      return await _iproduct.AddProductAsync(product);
    }

    public async Task<List<Product>> AllProduct()
    {
      return await _iproduct.AllProductAsync();
    }

    public async Task<Product> GetProductById(Guid Id)
    {
      return await _iproduct.ProductById(Id);
    }
    public async Task<Product> UpdateProduct(Guid Id, Product product)
    {
      return await _iproduct.UpdateProductAsync(Id, product);
    }

    public async Task<bool> DeleteProduct(Guid Id)
    {
      return await _iproduct.DeleteProduct(Id);
    }
  }
}
