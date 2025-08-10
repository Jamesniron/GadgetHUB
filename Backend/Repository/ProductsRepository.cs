using Backend.Dbcontext;
using Backend.Entity;
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
      await _setting.Product.AddAsync(products);
      await _setting.SaveChangesAsync();
      return products;
    }

    public async Task<List<Product>> AllProductAsync()
    {
      var products = await _setting.Product
        .Include(p => p.ImageUrl)
        .AsNoTracking()
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
      return result == 1;
    }

    // NEW: search with term + optional filters/sort/paging
    public async Task<List<Product>> SearchProductsAsync(
      string? term = null,
      decimal? minPrice = null,
      decimal? maxPrice = null,
      string? sortBy = "Name",
      bool desc = false,
      int page = 1,
      int pageSize = 20,
      CancellationToken ct = default)
    {
      if (page < 1) page = 1;
      if (pageSize < 1) pageSize = 20;

      IQueryable<Product> query = _setting.Product
        .Include(p => p.ImageUrl)
        .AsNoTracking();

      if (!string.IsNullOrWhiteSpace(term))
      {
        string pattern = $"%{term.Trim()}%";
        query = query.Where(p =>
          EF.Functions.Like(p.Name!, pattern) ||
          EF.Functions.Like(p.Description!, pattern));
      }

      // Optional price range
      if (minPrice.HasValue)
        query = query.Where(p => p.Price >= minPrice.Value);

      if (maxPrice.HasValue)
        query = query.Where(p => p.Price <= maxPrice.Value);

      query = (sortBy?.ToLowerInvariant(), desc) switch
      {
        ("price", false) => query.OrderBy(p => p.Price),
        ("price", true) => query.OrderByDescending(p => p.Price),

        ("created", false) => query.OrderBy(p => EF.Property<DateTime>(p, "Created")),
        ("created", true) => query.OrderByDescending(p => EF.Property<DateTime>(p, "Created")),

        (_, false) => query.OrderBy(p => p.Name),
        (_, true) => query.OrderByDescending(p => p.Name), // default Name desc
      };

      // Paging
      query = query
        .Skip((page - 1) * pageSize)
        .Take(pageSize);

      return await query.ToListAsync(ct);
    }
  }
}
