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
        Password = user.Password,
        role = user.Role
      };
      var adduser = await _iuserRepo.CreateUserAccount(Mapuser);
      return adduser;
    }

    public async Task<User> GetUserById(Guid Id)
    {
      return await _iuserRepo.GetUserById(Id);
    }

    public async Task<User> LoginUser(LoginRequest login)
    {
      return await _iuserRepo.LoginUser(login);
    }

    public async Task<List<User>> GetAllUsers()
    {
      return await _iuserRepo.GetAllUser();
    }

    public async Task<bool> DeleteUser(Guid id)
    {
      return await _iuserRepo.DeleteUser(id);
    }

  }
}
