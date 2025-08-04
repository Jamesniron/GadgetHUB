namespace Backend.Entity
{
  public class User
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public required Role role { get; set; }
  }

}
public enum Role
{
  user = 1,
  seller = 2,
  admin = 3
}