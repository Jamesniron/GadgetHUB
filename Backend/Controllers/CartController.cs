using Backend.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  [Route("api/card")]
  [ApiController]
  public class CartController : ControllerBase
  {
    private readonly ICardService _cardService;
    public CartController(ICardService cardService)
    {
      _cardService = cardService;
    }
    [HttpPost]
    public async Task<IActionResult> AddToCart(Guid userId, Guid productId, int quantity)
    {
      await _cardService.AddToCartAsync(userId, productId, quantity);
      return Ok(new { message = "Product added to cart successfully." });
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCartByUserId(Guid userId)
    {
      var cartItems = await _cardService.GetCartByUserIdAsync(userId);
      if (cartItems == null || !cartItems.Any())
      {
        return NotFound(new { message = "Cart is empty." });
      }
      return Ok(cartItems);
    }

    [HttpDelete("{cardId}")]
    public async Task<IActionResult> RemoveCard(Guid cardId)
    {
      var result = await _cardService.RemoveCardAsync(cardId);
      if (!result)
      {
        return NotFound(new { message = "Card not found." });
      }
      return Ok(new { message = "Card removed successfully." });
    }
  }
}
