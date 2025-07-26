using Backend.Dbcontext;
using Backend.Entity;
using Backend.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly AppSetting _DbContext;
    public UserRepository(AppSetting appSetting)
    {
      _DbContext = appSetting;
    }

    //Create Account
    public async Task<User> CreateUserAccount(User user)
    {
      var Adduser = await _DbContext.User.AddAsync(user);
      await _DbContext.SaveChangesAsync();
      return user;
    }

    //Login 
    public async Task<User> LoginUser(string email, string password)
    {
      var findUser = await _DbContext.User
        .FirstOrDefaultAsync(u => u.Email == email);

      if (findUser == null)
        throw new Exception("User not found");

      if (findUser.Password != password)
        throw new Exception("Wrong password for the given email");

      return findUser;

    }

    //Get by id
    public async Task<User> GetUserById(Guid Id)
    {
      var getUser = await _DbContext.User.FindAsync(Id);
      if (getUser == null) throw new Exception("user not found");
      return getUser;
    }
  }
}
