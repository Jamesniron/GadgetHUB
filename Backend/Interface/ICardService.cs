namespace Backend.Interface
{
  public interface ICardService
  {
    Task<bool> RemoveCardAsync(Guid cardId);
    Task<List<Entity.Product>> GetCartByUserIdAsync(Guid userId);
    Task AddToCartAsync(Guid userId, Guid productId, int quantity);
  }
}
