using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        serviceCollection.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

        return serviceCollection;
    }
}