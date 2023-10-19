using ErrorOr;
using Server.Models;

namespace Server.Services.Boards;

public interface IBoardService
{
    /// <summary>
    /// Find a board by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Board? FindById(int id);

    /// <summary>
    /// List boards by page and size
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public Page<Board> List(PagingOptions options);

    /// <summary>
    /// Create a new board to the database
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public void Create(Board board);

    /// <summary>
    /// Update board by given object
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public void Update(Board board);

    /// <summary>
    /// Delete board by given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void Delete(int id);
}