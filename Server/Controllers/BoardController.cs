using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.Boards;
using Server.Services.Users;

namespace Server.Controllers;

[ApiController]
[Route("boards")]
public class BoardController : CommonController
{
    private readonly ILogger<BoardController> _logger;
    private readonly IUserService _userService;
    private readonly IBoardService _boardService;
    
    public BoardController(
        ILogger<BoardController> logger,
        IUserService userService,
        IBoardService boardService
    ) : base(userService)
    {
        _logger = logger;
        _userService = userService;
        _boardService = boardService;
    }
    
    // define List which takes page and size as query parameters
    [HttpGet("list")]
    public IActionResult List([FromQuery] PagingOptions pagingOptions)
    {
        return Ok();
    }
    
    [Authorize]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpGet("{id:int}")]
    public IActionResult FindById(int id)
    {
        return Ok();
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public IActionResult Update(int id)
    {
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}