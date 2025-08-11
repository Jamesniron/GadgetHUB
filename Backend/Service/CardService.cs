using Backend.Interface;
using static Backend.Repository.CartRepository;

namespace Backend.Service
{
  public class CardService : ICardService
  {
    private readonly ICardRepository _cardRepository;
    public CardService(ICardRepository cardRepository)
    {
      _cardRepository = cardRepository;
    }
    public async Task AddToCartAsync(Guid userId, Guid productId, int quantity)
    {
      var card = new Entity.Card
      {
        UserId = userId,
        ProductId = productId,
        Quantity = quantity
      };
      await _cardRepository.AddToCartAsync(card);
    }

    public async Task<List<CardResponse>> GetCartByUserIdAsync(Guid userId)
    {
      return await _cardRepository.GetCartByUserIdAsync(userId);
    }

    public async Task<bool> RemoveCardAsync(Guid cardId)
    {
      return await _cardRepository.RemoveCardAsync(cardId);
    }
  }
}
