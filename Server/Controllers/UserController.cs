using Contracts;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Users;

namespace Server.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    
    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost("register")]
    public ActionResult Register(RegisterUserRequest request)
    {
        var user = new User
        {
            Username = request.Username,
            Password = request.Password,
        };
        var result = _userService.CreateUser(user);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public ActionResult GetUser(int id)
    {
        var user = _userService.GetUser(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}