using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DAL;

namespace Server.Controllers;

[Route("users")]
public class UserController : ControllerBase {
    private readonly ForumContext _ctx;
    
    public UserController(ForumContext ctx) {
        _ctx = ctx;
    }
    
    [HttpGet]
    public ActionResult ListUsers()
    {
        var listofUsers = _ctx.Users.ToList();
        return Ok(listofUsers);
    }
}