using Backend.Dbcontext;
using Backend.Entity;
using Backend.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
  public class ProductsRepository : IproductRepository
  {
    private readonly AppSetting _setting;
    public ProductsRepository(AppSetting appSetting)
    {
      _setting = appSetting;
    }
    // add product
    public async Task<Product> AddProductAsync(Product products)
    {
      var Product = await _setting.Product.AddAsync(products);
      var success = await _setting.SaveChangesAsync();
      //if (success > 0) return true;
      //return false;
      return products;
    }

    public async Task<List<Product>> AllProductAsync()
    {
      var products = await _setting.Product
        .Include(p => p.ImageUrl)
        .ToListAsync();
      return products;
    }

    public async Task<Product> ProductById(Guid Id)
    {
      Product? getproduct = await _setting.Product
        .Include(p => p.ImageUrl)
        .FirstOrDefaultAsync(p => p.Id == Id);
      if (getproduct == null) throw new Exception("Product not found");
      return getproduct;
    }

    public async Task<Product> UpdateProductAsync(Guid Id, Product product)
    {
      var findProduct = await ProductById(Id);
      findProduct.Name = product.Name;
      findProduct.Description = product.Description;
      findProduct.Price = product.Price;
      await _setting.SaveChangesAsync();
      return await ProductById(Id);
    }

    public async Task<bool> DeleteProduct(Guid Id)
    {
      var product = await ProductById(Id);
      _setting.Product.Remove(product);
      int result = await _setting.SaveChangesAsync();
      if (result == 1) return true;
      return false;
    }
  }
}
