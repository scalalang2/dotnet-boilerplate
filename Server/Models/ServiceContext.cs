using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.DAL;

public class ServiceContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Board> Boards { get; set; }
    
    public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
    {
        
    }
}