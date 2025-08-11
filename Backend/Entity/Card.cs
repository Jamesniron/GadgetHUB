namespace Backend.Entity
{
  public class Card
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    //for fk
    public User User { get; set; }
    public Product Product { get; set; }
  }
}
