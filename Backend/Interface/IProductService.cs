using Backend.Entity;

namespace Backend.Interface
{
  public interface IProductService
  {
    Task<Product> AddProduct(Product product);
    Task<List<Product>> AllProduct();
    Task<Product> GetProductById(Guid Id);
    Task<Product> UpdateProduct(Guid Id, Product product);
    Task<bool> DeleteProduct(Guid Id);
  }
}
