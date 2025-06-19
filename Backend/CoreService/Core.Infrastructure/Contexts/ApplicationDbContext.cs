using System.Reflection;
using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Commerce;
using Core.Domain.Entities.Trading;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Merchant> Merchants { get; private set; }
    public DbSet<Medicine> Medicines { get; private set; }
    public DbSet<ProductCategory> ProductCategories { get; private set; }
    public DbSet<Product> Products { get; private set; }
    public DbSet<Order> Orders { get; private set; }
    public DbSet<OrderItem> OrderItems { get; private set; }
    public DbSet<Cart> Carts { get; private set; }
    public DbSet<CartItem> CartItems { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedAt = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}