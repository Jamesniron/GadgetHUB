using Backend.Entity;

namespace Backend.Interface
{
    public interface IproductRepository
    {
        Task<Product> AddProductAsync(Product products);
        Task<List<Product>> AllProductAsync();
    }
}
