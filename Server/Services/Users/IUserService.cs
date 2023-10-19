using ErrorOr;
using Server.Models;

namespace Server.Services.Users;

public interface IUserService
{
    /// <summary>
    /// Register new user
    /// </summary>
    /// <param name="user">Provides username and password</param>
    /// <returns>inserted id</returns>
    public int CreateUser(User user);
    
    /// <summary>
    /// Validate user credentials
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>true if given user is valid</returns>
    public bool ValidateUser(string username, string password);
    
    /// <summary>
    /// Find user by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns><see cref="User" /> is returned</returns>
    public User? GetUser(int id);
    
    /// <summary>
    /// Find user by username
    /// </summary>
    /// <param name="username"><see cref="User" /> is returned</param>
    /// <returns></returns>
    public User? GetUser(string username);
    
    public bool Exists(string username);
}