using Backend.Entity;

namespace Backend.Interface
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<List<Product>> AllProduct();
    }
}
