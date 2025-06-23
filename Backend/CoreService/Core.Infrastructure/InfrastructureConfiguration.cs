using Core.Infrastructure.Injections;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.InjectDatabase();
        return serviceCollection;
    }
}