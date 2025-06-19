using Core.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Injections;

public static class DatabaseInjection
{

    private const string DatabaseEnvironmentName = "CONNECTION_STRING";
    public static IServiceCollection InjectDatabase(this IServiceCollection service)
    {
        service.AddDbContext<DbContext, ApplicationDbContext>(option =>
        {
            option.UseNpgsql(Environment.GetEnvironmentVariable(DatabaseEnvironmentName));
        });

        return service;
    }
}