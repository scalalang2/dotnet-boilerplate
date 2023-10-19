using System.Security.Cryptography;
using System.Text;
using Server.DAL;
using Server.Models;

namespace Server.Services.Users;

public class UserService : IUserService
{
    private readonly ServiceContext _ctx;
    
    public UserService(ServiceContext ctx)
    {
        _ctx = ctx;
    }
    
    private string GenerateHash(string toHash) {
        var crypt = SHA256.Create();
        string hash = String.Empty;
        byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(toHash));
        foreach (byte theByte in crypto)
        {
            hash += theByte.ToString("x2");
        }
        
        return hash;
    }

    public int CreateUser(User user)
    {
        var u = new User()
        {
            Username = user.Username,
            Password = GenerateHash(user.Password),
            CreatedAt = DateTime.UtcNow,
        };
        _ctx.Users.Add(u);
        _ctx.SaveChanges();
        return u.UserID;
    }

    public bool ValidateUser(string username, string password)
    {
        var query = from u in _ctx.Users
            where u.Username == username
            select u;

        var user = query.FirstOrDefault();
        if (user == null) 
        {
            return false;
        }

        if (user.Password != GenerateHash(password))
        {
            return false;
        }

        return true;
    }

    public User? GetUser(int id)
    {
        var query = from u in _ctx.Users
            where u.UserID == id
            select u;
        
        return query.FirstOrDefault();
    }

    public User? GetUser(string username)
    {
        return _ctx.Users.FirstOrDefault(u => u.Username == username);
    }

    public bool Exists(string username)
    {
        return _ctx.Users.Any(u => u.Username == username);
    }
}