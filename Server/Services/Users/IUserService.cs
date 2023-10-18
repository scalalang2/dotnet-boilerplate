using ErrorOr;
using Server.Models;

namespace Server.Services.Users;

public interface IUserService
{
    public int CreateUser(User user);
    public User? GetUser(int id);
    public bool Exists(int id);
}