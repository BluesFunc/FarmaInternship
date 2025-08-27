using Auth.Infrastructure.Contexts;
using Auth.Infrastructure.Repositories.Dapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Configurations;

internal static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<DbContext, UserDbContext>(builder =>
            builder.UseSqlServer(Environment.GetEnvironmentVariable("USER_DB_CONNECTION")));
        // serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>(builder
            => new UserRepository(Environment.GetEnvironmentVariable("USER_DB_CONNECTION")));
        return serviceCollection;
    }
}