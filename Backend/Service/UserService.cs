using Backend.DTO;
using Backend.Entity;
using Backend.Interface;

namespace Backend.Service
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _iuserRepo;
    public UserService(IUserRepository userRepository)
    {
      _iuserRepo = userRepository;
    }

    public async Task<User> CreateUserAccount(UserDTO user)
    {
      var Mapuser = new User()
      {
        Name = user.Name,
        Email = user.Email,
        Password = user.Password
      };
      var adduser = await _iuserRepo.CreateUserAccount(Mapuser);
      return adduser;
    }

    public async Task<User> GetUserById(Guid Id)
    {
      return await _iuserRepo.GetUserById(Id);
    }

    public async Task<User> LoginUser(string email, string password)
    {
      return await _iuserRepo.LoginUser(email, password);
    }
  }
}
