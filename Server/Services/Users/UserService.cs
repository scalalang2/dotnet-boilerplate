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

    public User? GetUser(int id)
    {
        var query = from u in _ctx.Users
            where u.UserID == id
            select u;
        
        return query.FirstOrDefault();
    }

    public bool Exists(int id)
    {
        return _ctx.Users.Find(id) != null;
    }
}