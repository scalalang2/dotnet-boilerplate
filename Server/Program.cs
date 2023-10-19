using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Server.DAL;
using Server.Services.Boards;
using Server.Services.Users;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
        };
    });
    builder.Services.AddAuthorization();
    builder.Services.AddControllers();
    
    // Dependency Injection
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IBoardService, BoardService>();
    builder.Services.AddDbContext<ServiceContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
}

var app = builder.Build();
{
    app.MapGet("/", () => "Hello World!");
    app.MapControllers();
    app.UseAuthentication();
    app.UseAuthorization();
    app.Run();
}