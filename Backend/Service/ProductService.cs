using Backend.DTO;
using Backend.Entity;
using Backend.Helpers;
using Backend.Interface;

namespace Backend.Service
{
  public class ProductService : IProductService
  {
    private IproductRepository _iproduct;
    private readonly IPhotoService _PhotoService;
    public ProductService(IproductRepository iproduct, IPhotoService photoService)
    {
      _iproduct = iproduct;
      _PhotoService = photoService;
    }

    public async Task<Product> AddProduct(CreateProductDTO productrequest)
    {
      var uploadResult = await _PhotoService.AddPhotosAsync(productrequest.Images);
      var photos = new List<ProductImage>();

      foreach (var result in uploadResult)
      {
        if (result.Error != null) throw new Exception(result.Error.Message);

        photos.Add(new ProductImage
        {
          Url = result.SecureUrl.AbsoluteUri,
          PublicId = result.PublicId
        });
      }

      Product addProduct = new Product
      {
        Name = productrequest.Name,
        Price = productrequest.Price,
        Description = productrequest.Description,
        ImageUrl = photos
      };

      return await _iproduct.AddProductAsync(addProduct);
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
      return await _iproduct.SearchProductsAsync(
        term, minPrice, maxPrice, sortBy, desc, page, pageSize, ct);
    }
  }
}
