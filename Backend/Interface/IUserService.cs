using Backend.DTO;
using Backend.Entity;

namespace Backend.Interface
{
  public interface IUserService
  {
    Task<User> GetUserById(Guid Id);
    Task<User> LoginUser(string email, string password);
    Task<User> CreateUserAccount(UserDTO user);
    Task<List<User>> GetAllUsers();
    Task<bool> DeleteUser(Guid id);

  }
}
