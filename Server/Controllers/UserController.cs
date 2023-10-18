using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Server.Models;
using Server.Services.Users;

namespace Server.Controllers;

[ApiController]
[Route("users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IConfiguration _config;
    private readonly IUserService _userService;
    
    public UserController(
        ILogger<UserController> logger,
        IConfiguration config,
        IUserService userService)
    {
        _logger = logger;
        _config = config;
        _userService = userService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
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

    [HttpPost("login")]
    [AllowAnonymous]
    public ActionResult Login(LoginUserRequest request)
    {
        return Ok();
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