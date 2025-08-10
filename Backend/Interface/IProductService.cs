using Backend.DTO;
using Backend.Entity;

namespace Backend.Interface
{
  public interface IProductService
  {
    Task<Product> AddProduct(CreateProductDTO product);
    Task<List<Product>> AllProduct();
    Task<Product> GetProductById(Guid Id);
    Task<Product> UpdateProduct(Guid Id, Product product);
    Task<bool> DeleteProduct(Guid Id);
    Task<List<Product>> SearchProductsAsync(
          string? term = null,
          decimal? minPrice = null,
          decimal? maxPrice = null,
          string? sortBy = "Name",
          bool desc = false,
          int page = 1,
          int pageSize = 20,
          CancellationToken ct = default);
  }
}
