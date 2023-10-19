using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Users;

namespace Server.Controllers;

public class CommonController : ControllerBase
{
    private readonly IUserService _userService;
    public CommonController(IUserService userService)
    {
        _userService = userService;
    }
    
    protected string? GetUsername()
    {
        var principal = HttpContext.User;
        var username = principal.Claims.SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
        return username;
    }

    protected User? GetUser()
    {
        var username = GetUsername();
        if (username == null) return null;
        return _userService.GetUser(username);
    }
}