using System.Reflection;
using Core.Infrastructure.Injections;
using Mapster;
using Mapster.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration config)
    {
        TypeAdapterConfig.GlobalSettings.ScanInheritedTypes(Assembly.GetExecutingAssembly());

        serviceCollection.InjectAuthentication()
            .InjectAuthorization()
            .InjectDatabase()
            .InjectGrcp()
            .InjectBroker(config)
            .InjectNotification()
            .AddMemoryCache()
            ;

        return serviceCollection;
    }
}