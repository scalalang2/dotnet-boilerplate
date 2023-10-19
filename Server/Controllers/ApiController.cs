using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class ApiController : ControllerBase
{
    protected string? GetUsername()
    {
        var principal = HttpContext.User;
        var username = principal.Claims.SingleOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
        return username;
    }
}