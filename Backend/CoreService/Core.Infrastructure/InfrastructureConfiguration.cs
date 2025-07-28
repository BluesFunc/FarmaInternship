using System.Reflection;
using Core.Infrastructure.Injections;
using Mapster;
using Mapster.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        TypeAdapterConfig.GlobalSettings.ScanInheritedTypes(Assembly.GetExecutingAssembly());
        serviceCollection.InjectDatabase();
        serviceCollection.InjectGrcp();
        serviceCollection.InjectBroker();
        return serviceCollection;
    }
}