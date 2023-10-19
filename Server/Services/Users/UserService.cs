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
    
    /// <summary>
    /// Hash the given string using SHA256.
    /// It's used to encrypt the password.
    /// </summary>
    /// <param name="toHash">normally password given to this parameter</param>
    /// <returns>generated hash value</returns>
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

    /// <summary>
    /// Returns true if the user exists and the password matches.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>true if the user is valid, otherwise false is returned</returns>
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

    public bool Exists(int id)
    {
        return _ctx.Users.Any(u => u.UserID == id);
    }

    public bool Exists(string username)
    {
        return _ctx.Users.Any(u => u.Username == username);
    }
}