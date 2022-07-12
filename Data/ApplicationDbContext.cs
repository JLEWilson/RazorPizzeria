using Microsoft.EntityFrameworkCore;
using RazorPizzeria.Models;

namespace RazorPizzeria.Data
{
  public class ApplicationDbContext : DbContext
  {
    public readonly IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    public DbSet<PizzaOrder> PizzaOrders { get; set; }
  }
}