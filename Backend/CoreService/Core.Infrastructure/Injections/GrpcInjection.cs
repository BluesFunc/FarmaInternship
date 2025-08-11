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
        var serverUri =
            new Uri(Environment.GetEnvironmentVariable("GRPC_URL") ?? throw new InvalidOperationException());

        serviceCollection.AddGrpcClient<UserStatisticService.UserStatisticServiceClient>(options =>
            options.Address = serverUri);

        serviceCollection.AddGrpcClient<ProductStatisticService.ProductStatisticServiceClient>(options =>
            options.Address = serverUri);

        serviceCollection.AddScoped<IUserAnalyticService, UserAnalyticService>();
        serviceCollection.AddScoped<IProductAnalyticService, ProductAnalyticsService>();

        return serviceCollection;
    }
}