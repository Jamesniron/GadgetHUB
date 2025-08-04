namespace Backend.Entity
{
  public class Product
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public ICollection<ProductImage>? ImageUrl { get; set; } = [];

  }
}
