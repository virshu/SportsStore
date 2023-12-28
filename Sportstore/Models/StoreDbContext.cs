using Microsoft.EntityFrameworkCore;

namespace Sportstore.Models;

public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
}