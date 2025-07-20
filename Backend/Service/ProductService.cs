using Backend.Entity;
using Backend.Interface;

namespace Backend.Service
{
    public class ProductService :IProductService
    {
        private IproductRepository _iproduct;
        public ProductService(IproductRepository iproduct)
        {
            _iproduct = iproduct;  
        }

        public async Task<Product> AddProduct(Product product)
        {
           return  await _iproduct.AddProductAsync(product);
        }

        public async Task<List<Product>> AllProduct()
        {
            return await _iproduct.AllProductAsync();
        }
    }
}
