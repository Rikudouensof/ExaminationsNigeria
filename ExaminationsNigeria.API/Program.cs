using ExaminationsNigeria.Domain.Models.Database;
using ExaminationsNigeria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExaminationsNigeria.API
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
      builder.Services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(connectionString));
      builder.Services.AddDatabaseDeveloperPageExceptionFilter();

      builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
          .AddEntityFrameworkStores<ApplicationDbContext>();

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}