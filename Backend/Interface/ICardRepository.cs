using Backend.Entity;
using static Backend.Repository.CartRepository;

namespace Backend.Interface
{
  public interface ICardRepository
  {
    Task<List<CardResponse>> GetCartByUserIdAsync(Guid userId);
    Task<bool> RemoveCardAsync(Guid cardId);
    Task AddToCartAsync(Card card);
  }
}
