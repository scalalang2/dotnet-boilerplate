using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
public class UserController : CommonController
{
    private readonly ILogger<UserController> _logger;
    private readonly IConfiguration _config;
    private readonly IUserService _userService;
    private static readonly TimeSpan TokenLifeTime = TimeSpan.FromHours(8);
    
    public UserController(
        ILogger<UserController> logger,
        IConfiguration config,
        IUserService userService
    ) : base(userService) {
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
        if (_userService.ValidateUser(request.Username, request.Password))
        {
            var token = GenerateToken(request.Username);
            return Ok(new LoginUserResponse(token));
        }
        
        return Unauthorized(new { message = "username or password doesn't match"});
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

    private string GenerateToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID
            new(JwtRegisteredClaimNames.Sub, username), // Subject
            new(JwtRegisteredClaimNames.Exp,
                new DateTimeOffset(DateTime.Now.Add(TokenLifeTime)).ToUnixTimeSeconds().ToString()), // Expiration
        };
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _config["JwtSettings:Issuer"],
            Audience = _config["JwtSettings:Audience"],
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.Add(TokenLifeTime),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}