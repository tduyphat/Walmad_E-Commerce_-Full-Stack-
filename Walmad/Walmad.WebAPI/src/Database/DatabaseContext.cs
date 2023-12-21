using Microsoft.EntityFrameworkCore;
using Npgsql;
using Walmad.Core.src.Entity;

namespace Walmad.WebAPI.src.Database;

public class DatabaseContext : DbContext // builder pattern
{
    private readonly IConfiguration _config;
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Review> Reviews { get; set; }

    static DatabaseContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DatabaseContext(DbContextOptions options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(_config.GetConnectionString("LocalDb"));
        dataSourceBuilder.MapEnum<Role>();
        dataSourceBuilder.MapEnum<OrderStatus>();
        var dataSource = dataSourceBuilder.Build();
        optionsBuilder
            .UseNpgsql(dataSource)
            .UseSnakeCaseNamingConvention()
            .AddInterceptors(new TimestampInterceptor());
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Role>();
        // modelBuilder.Entity<User>(entity => entity.Property(e => e.Role).HasColumnType("role"));
        modelBuilder.HasPostgresEnum<OrderStatus>();
        // modelBuilder.Entity<Order>(entity => entity.Property(e => e.OrderStatus).HasColumnType("order_status"));
        // modelBuilder.Entity<Category>().HasMany<Product>().WithOne().OnDelete(DeleteBehavior.Cascade);
        // modelBuilder.Entity<Product>().HasMany<ProductImage>().WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}
