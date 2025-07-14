using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Configurations.AuthConfigurations;

public static class HangfireConfigurations
{
    public static IServiceCollection ConfigureHangfire(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"))

        );
        
        
        serviceCollection.AddHangfireServer();
        return serviceCollection;
    }
}