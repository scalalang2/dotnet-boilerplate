using Microsoft.EntityFrameworkCore;
using Server.DAL;
using Server.Services.Users;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddDbContext<ServiceContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
}

var app = builder.Build();
{
    app.MapGet("/", () => "Hello World!");
    app.MapControllers();
    app.Run();
}