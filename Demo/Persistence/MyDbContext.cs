using Demo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Demo.Persistence;

public class MyDbContext : DbContext
{
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public MyDbContext()
    {

    }
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-U61S967P\\NOSTALGIA;Database=DDDStrongTypeIdWithEFCore;User Id=sa;Password=admin@123;Application Name=Publisher;TrustServerCertificate=True")
            .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name, DbLoggerCategory.Database.Connection.Name },
                Microsoft.Extensions.Logging.LogLevel.Debug)
            .EnableSensitiveDataLogging(); ;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
    }
}
