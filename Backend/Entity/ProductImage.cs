namespace Backend.Entity
{
  public class ProductImage
  {
    public Guid Id { get; set; }
    public required string Url { get; set; }
    public string? PublicId { get; set; }

    public Guid ProductId { get; set; }
    public Product product { get; set; }
  }
}
