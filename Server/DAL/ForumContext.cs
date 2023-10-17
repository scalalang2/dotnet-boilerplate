using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.DAL;

public class ForumContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    
    public ForumContext(DbContextOptions<ForumContext> options) : base(options)
    {
        
    }
}