using Auth.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Extensions;

public static class DatabaseMigrationExtension
{
    public static async Task ApplyMigrations (this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
       
        await MigrateAsync(context);
    }

    private static async Task MigrateAsync(DbContext dbContext)
    {
        await dbContext.Database.MigrateAsync();
        await dbContext.Database.EnsureCreatedAsync();
    }
}