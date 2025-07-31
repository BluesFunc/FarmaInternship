using Core.Application.Interfaces.Statistics.Services;
using Core.Infrastructure.Services.Statistics.Base;
using Core.Infrastructure.Services.Statistics.Products;
using Core.Infrastructure.Services.Statistics.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infrastructure.Injections;

public static class GrpcInjection
{
    public static IServiceCollection InjectGrcp(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddGrpcClient<UserStatisticService.UserStatisticServiceClient>(options =>
            options.Address = new Uri("https://localhost:7215"));
        serviceCollection.AddGrpcClient<ProductStatisticService.ProductStatisticServiceClient>(options =>
            options.Address = new Uri("https://localhost:7215"));
        serviceCollection.AddScoped<IUserAnalyticService, UserAnalyticService>();
        serviceCollection.AddScoped<IProductAnalyticService, ProductAnalyticsService>();
        return serviceCollection;
    }
}