using Auth.Infrastructure.Contexts;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Extensions;

public static class DatabaseConfigurationExtension
{
    public static async Task ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();

        await MigrateAsync(context);
    }

    public static async Task ConfigureDatabase()
    {
        using var connection = new SqlConnection(Environment.GetEnvironmentVariable("USER_DB_CONNECTION"));
        await connection.OpenAsync();

        var sql = $@"
            if not exists (select [name] from sys.tables where [name] = 'user')        
            CREATE TABLE [dbo].[user] (
            [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
            [Username] NVARCHAR(100) NOT NULL,
            [Password] NVARCHAR(256) NOT NULL,
            [UserRole] INT NOT NULL,
            [RefreshToken] NVARCHAR(500) NULL,
            [Mail] NVARCHAR(150) NOT NULL UNIQUE,
            [CreatedAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
            [UpdatedAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE()
        );";

        await connection.ExecuteAsync(sql);
    }

    private static async Task MigrateAsync(DbContext dbContext)
    {
        await dbContext.Database.MigrateAsync();
        await dbContext.Database.EnsureCreatedAsync();
    }
}