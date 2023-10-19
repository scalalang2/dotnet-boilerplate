using Server.DAL;
using Server.Models;

namespace Server.Services.Boards;

public class BoardService : IBoardService
{
    private readonly ServiceContext _ctx;
    
    public BoardService(ServiceContext ctx)
    {
        _ctx = ctx;
    }
    
    public Board? FindById(int id)
    {
        return _ctx.Boards.FirstOrDefault(b => b.BoardID == id);
    }

    public Page<Board> List(PagingOptions options)
    {
        var items = _ctx.Boards
            .OrderByDescending(b => b.PublishedOn)
            .Skip(options.Offset * options.Limit)
            .Take(options.Limit)
            .ToList();
        var totalItems = _ctx.Boards.Count();

        return new Page<Board>
        {
            Items = items,
            TotalSize = totalItems
        };
    }

    public void Create(Board board)
    {
        _ctx.Boards.Add(board);
        _ctx.SaveChanges();
    }

    public void Update(Board board)
    {
        var b = FindById(board.BoardID);
        if (b != null)
        {
            b.Title = board.Title;
            b.Content = board.Content;
            _ctx.Boards.Update(b);
            _ctx.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var board = _ctx.Boards.FirstOrDefault(b => b.BoardID == id);
        if (board != null)
        {
            _ctx.Boards.Remove(board);
            _ctx.SaveChanges();
        }
    }
}