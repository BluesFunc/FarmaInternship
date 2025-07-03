using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR((configuration =>
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())));
        return serviceCollection;
    }
}