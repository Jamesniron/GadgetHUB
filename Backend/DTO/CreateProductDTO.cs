namespace Backend.DTO
{
  public class CreateProductDTO
  {
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public IFormFile[] Images { get; set; } = Array.Empty<IFormFile>();
  }
}
