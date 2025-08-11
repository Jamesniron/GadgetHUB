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


    public async Task<bool> RemoveCardAsync(Guid cardId)
    {
      var card = await _setting.Cart.FindAsync(cardId);
      if (card == null) return false;
      _setting.Cart.Remove(card);
      int result = await _setting.SaveChangesAsync();
      return result > 0;
    }
    public async Task<List<CardResponse>> GetCartByUserIdAsync(Guid userId)
    {
      var checkcard = await _setting.Cart
          .Include(c => c.Product)
          //.ThenInclude(p => p.Images) 
          .Where(c => c.UserId == userId)
          .ToListAsync();

      if (!checkcard.Any())
      {
        return new List<CardResponse>
        {
            new CardResponse
            {
                Id = Guid.Empty,
                ProductId = Guid.Empty,
                Name = "No products in cart",
                Price = 0,
                Description = "Your cart is empty.",
                ImageUrl = new List<ProductImage>()
            }
        };
      }

      return checkcard.Select(c => new CardResponse
      {
        Id = c.Id,
        ProductId = c.Product.Id,
        Name = c.Product.Name,
        Price = c.Product.Price,
        Description = c.Product.Description,
        //ImageUrl = c.Product.Images // assuming navigation property is called Images
      }).ToList();
    }


    public class CardResponse
    {
      public Guid Id { get; set; }
      public Guid ProductId { get; set; }
      public string Name { get; set; }
      public int Price { get; set; }
      public string Description { get; set; }
      public ICollection<ProductImage>? ImageUrl { get; set; } = [];
    }

  }
}
