using Contracts.Boards;
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
        return Ok(_boardService.List(pagingOptions));
    }
    
    [Authorize]
    public IActionResult Create(CreateBoardRequest request)
    {
        var user = GetUser();
        _boardService.Create(new Board()
        {
            Title = request.Title,
            Content = request.Content,
            PublishedOn = DateTime.UtcNow,
            UserID = user.UserID,
        });
        return Ok(new { message = "New article published" });
    }

    [HttpGet("{id:int}")]
    public IActionResult FindById(int id)
    {
        return Ok(_boardService.FindById(id));
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateBoardRequest request)
    {
        var user = GetUser();
        var board = _boardService.FindById(id);
        if (board == null)
        {
            return NotFound();
        }

        if (user.UserID != board.UserID)
        {
            return Unauthorized();
        }
        
        _boardService.Update(new Board()
        {
            BoardID = id,
            Title = request.Title,
            Content = request.Content,
        });
        
        return Ok();
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var user = GetUser();
        var board = _boardService.FindById(id);
        if (board == null)
        {
            return NotFound();
        }
        
        if (user.UserID != board.UserID)
        {
            return Unauthorized();
        }
        
        _boardService.Delete(id);
        return Ok();
    }
}