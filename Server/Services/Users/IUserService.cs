using ErrorOr;
using Server.Models;

namespace Server.Services.Users;

public interface IUserService
{
    public int CreateUser(User user);
    public bool ValidateUser(string username, string password);
    public User? GetUser(int id);
    public bool Exists(int id);
    public bool Exists(string username);
}