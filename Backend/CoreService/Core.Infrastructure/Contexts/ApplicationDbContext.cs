using Core.Domain.Entities.Commerce;
using Core.Domain.Entities.Trading;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Contexts;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Merchant> Merchants { get; private set; }
    public DbSet<Medicine> Medicines { get; private set; }
    public DbSet<ProductCategory> ProductCategories { get; private set; }
    public DbSet<Product> Products { get; private set; }
    public DbSet<Order> Orders { get; private set; }
    public DbSet<OrderItem> OrderItems { get; private set; }
    public DbSet<Cart> Carts { get; private set; }
    public DbSet<CartItem> CartItems { get; private set; }
    
    
}