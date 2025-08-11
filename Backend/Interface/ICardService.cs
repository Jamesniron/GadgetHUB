using static Backend.Repository.CartRepository;

namespace Backend.Interface
{
  public interface ICardService
  {
    Task<bool> RemoveCardAsync(Guid cardId);
    Task<List<CardResponse>> GetCartByUserIdAsync(Guid userId);
    Task AddToCartAsync(Guid userId, Guid productId, int quantity);
  }
}
