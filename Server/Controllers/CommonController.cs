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
    
    protected string GetUsername()
    {
        var principal = HttpContext.User;
        var claim = principal.Claims.SingleOrDefault(c => c.Type == "usr");
        if (claim == null)
        {
            throw new Exception("No username claim found in token. This is unexpected error");
        }
        
        return claim.Value;
    }

    protected User GetUser()
    {
        var username = GetUsername();
        var user = _userService.GetUser(username);
        if (user == null)
        {
            throw new Exception("No user found for username " + username);   
        }
        
        return user!;
    }
}