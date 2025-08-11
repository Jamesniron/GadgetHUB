using Backend.Entity;

namespace Backend.Interface
{
  public interface ICardRepository
  {
    Task<List<Product>> GetCartByUserIdAsync(Guid userId);
    Task<bool> RemoveCardAsync(Guid cardId);
    Task AddToCartAsync(Card card);
  }
}
