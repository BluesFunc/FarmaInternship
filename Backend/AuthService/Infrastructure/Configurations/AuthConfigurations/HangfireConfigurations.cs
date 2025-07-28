using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Configurations.AuthConfigurations;

public static class HangfireConfigurations
{
    public static IServiceCollection ConfigureHangfire(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(Environment.GetEnvironmentVariable("HANGFIRE_CONNECTION"))
        );


        serviceCollection.AddHangfireServer();
        return serviceCollection;
    }
}