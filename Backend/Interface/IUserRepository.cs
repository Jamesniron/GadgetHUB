using Backend.DTO;
using Backend.Entity;

namespace Backend.Interface
{
  public interface IUserRepository
  {
    Task<User> GetUserById(Guid Id);
    Task<User> LoginUser(LoginRequest login);
    Task<User> CreateUserAccount(User user);
    Task<List<User>> GetAllUser();
    Task<bool> DeleteUser(Guid Id);
  }
}
