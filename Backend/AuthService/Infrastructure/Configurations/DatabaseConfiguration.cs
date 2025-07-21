using Auth.Infrastructure.Contexts;
using Auth.Infrastructure.Repositories;
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
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        return serviceCollection;
    }
}