using Core.Application.Interfaces;
using Core.Domain.Entities.Trading;
using Core.Infrastructure.Services.Statistics;
using Core.Infrastructure.Services.Statistics.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Injections;

public static class GrpcInjection
{
    public static IServiceCollection InjectGrcp(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddGrpcClient<OrderStatistic.OrderStatisticClient>(options => 
            options.Address = new Uri("https://localhost:7215"));
        serviceCollection.AddScoped<IStatisticService<Order>, OrdersStatisticService >();
        return serviceCollection;
    }
}