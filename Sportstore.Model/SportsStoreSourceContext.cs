using Microsoft.Extensions.Configuration;

namespace Sportstore.Model;

public partial class SportsStoreSourceContext : DbContext
{
    public SportsStoreSourceContext()
    {
    }

    public SportsStoreSourceContext(DbContextOptions<SportsStoreSourceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartLine> CartLines { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        IConfiguration configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SportsStoreContext"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartLine>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(p => p.CartLines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartLines_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.CartLines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartLines_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }


}
