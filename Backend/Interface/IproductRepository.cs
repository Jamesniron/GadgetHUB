using Backend.Entity;

public interface IproductRepository
{
  Task<Product> AddProductAsync(Product products);
  Task<List<Product>> AllProductAsync();
  Task<Product> ProductById(Guid Id);
  Task<Product> UpdateProductAsync(Guid Id, Product product);
  Task<bool> DeleteProduct(Guid Id);

  // NEW: flexible search
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
