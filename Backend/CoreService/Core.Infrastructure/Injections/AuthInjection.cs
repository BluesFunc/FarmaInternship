using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Injections;

public static class AuthInjection
{
    public static IServiceCollection InjectAuth(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthentication();
        return serviceCollection;
    }
}