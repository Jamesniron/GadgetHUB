using Backend.DTO;
using Backend.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _user;
    public UserController(IUserService user)
    {
      _user = user;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAccount(UserDTO userDto)
    {
      return Ok(await _user.CreateUserAccount(userDto));
    }

    [HttpPost("login")]
    public async Task<IActionResult> UserLogn(string email, string password)
    {
      return Ok(await _user.LoginUser(email, password));
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUserById(Guid Id)
    {
      return Ok(await _user.GetUserById(Id));
    }
  }
}
