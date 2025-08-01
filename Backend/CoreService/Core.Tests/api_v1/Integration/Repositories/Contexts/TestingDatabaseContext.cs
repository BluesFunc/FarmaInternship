using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Commerce;
using Microsoft.EntityFrameworkCore;

namespace Core.Tests.api_v1.Integration.Repositories.Contexts;

public class TestingDatabaseContext(DbContextOptions<TestingDatabaseContext> options) : DbContext(options) 
{
    private DbSet<Medicine> Medicines { get; set; }
    
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