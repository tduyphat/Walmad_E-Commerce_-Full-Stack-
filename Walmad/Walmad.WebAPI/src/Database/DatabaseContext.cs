using Microsoft.EntityFrameworkCore;
using Walmad.Core.src.Entity;

namespace Walmad.WebAPI.src.Database;

public class DatabaseContext : DbContext // builder pattern
{
    private readonly IConfiguration _config;
    public DbSet<User> Users { get; set; }

    public DatabaseContext(DbContextOptions options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_config.GetConnectionString("LocalDb"))
            .UseSnakeCaseNamingConvention();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
