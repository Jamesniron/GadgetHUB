using Backend.Dbcontext;
using Backend.Entity;
using Backend.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
  public class CartRepository : ICardRepository
  {
    private readonly AppSetting _setting;
    public CartRepository(AppSetting setting)
    {
      _setting = setting;
    }
    public async Task AddToCartAsync(Card card)
    {
      var checkUser = await _setting.User.FindAsync(card.UserId);
      //if (checkUser.role != Role.user)
      //{
      //  throw new Exception("Only users can add products to the cart");
      //}
      if (checkUser == null)
      {
        throw new Exception("User not found");
      }
      var checkProduct = await _setting.Product.FindAsync(card.ProductId);
      if (checkProduct == null)
      {
        throw new Exception("Product not found");
      }
      await _setting.Cart.AddAsync(card);
      await _setting.SaveChangesAsync();
    }

    public async Task<List<Product>> GetCartByUserIdAsync(Guid userId)
    {
      var checkcard = await _setting.Cart
         .Include(c => c.Product)
         .Where(c => c.UserId == userId)
         .ToListAsync();
      if (checkcard == null || !checkcard.Any())
      {
        return new List<Product>();
      }
      return checkcard.Select(c => c.Product).ToList();
    }

    public async Task<bool> RemoveCardAsync(Guid cardId)
    {
      var card = await _setting.Cart.FindAsync(cardId);
      if (card == null) return false;
      _setting.Cart.Remove(card);
      int result = await _setting.SaveChangesAsync();
      return result > 0;
    }
  }
}
