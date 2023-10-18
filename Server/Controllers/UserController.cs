using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Users;

namespace Server.Controllers;

[ApiController]
[Route("users")]
[Authorize]
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
        if (_userService.Exists(request.Username))
        {
            return Conflict(new { message = "user already exists "});
        }
        
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
            return NotFound(new { message = "User not found" });
        }

        return Ok(user);
    }
}