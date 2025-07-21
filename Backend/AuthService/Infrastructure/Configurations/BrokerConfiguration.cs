using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Configurations;

public static class BrokerConfiguration
{
    public static IServiceCollection ConfigureRabbit(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransit(x
            => x.UsingRabbitMq((ctx, cfg)
                => cfg.Host("localhost", "/", h =>
                    {
                        h.Username("aleks");
                        h.Password("1234");
                    }
                )));

        return serviceCollection;
    }
}