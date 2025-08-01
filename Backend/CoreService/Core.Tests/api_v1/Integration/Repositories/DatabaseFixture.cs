using Core.Tests.api_v1.Integration.Repositories.Contexts;
using DotNet.Testcontainers.Containers;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace Core.Tests.api_v1.Integration.Repositories;

public class DatabaseFixture : IAsyncLifetime
{
    public PostgreSqlContainer Container { get; private set; }
    public DbContextOptions<TestingDatabaseContext> DbOptions { get; private set; }
    public string ConnectionString => Container.GetConnectionString();

    public async Task InitializeAsync()
    {
        Container = new PostgreSqlBuilder()
            .WithImage("postgres:16")
            .WithUsername("test")
            .WithPassword("test")
            .WithDatabase("testdb")
            .Build();

        await Container.StartAsync();

        var options = new DbContextOptionsBuilder<TestingDatabaseContext>()
            .UseNpgsql(ConnectionString);

        
        DbOptions = options.IsConfigured ? options.Options : throw new NullReferenceException();
        await using var context = new TestingDatabaseContext(DbOptions);
        await ApplyMigrations();
    }

    private async Task ApplyMigrations()
    {
        using var ctx = new TestingDatabaseContext(DbOptions);
        await ctx.Database.EnsureCreatedAsync();
        await ctx.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        await Container.DisposeAsync();
    }
}

[CollectionDefinition("Repositories")]
public class RepositoryFixtureCollection() : ICollectionFixture<DatabaseFixture>;