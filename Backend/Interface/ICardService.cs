namespace Backend.Interface
{
  public interface ICardService
  {
    Task<bool> RemoveCardAsync(Guid cardId);
    Task<List<Entity.Card>> GetCartByUserIdAsync(Guid userId);
    Task AddToCartAsync(Guid userId, Guid productId, int quantity);
  }
}
