using Analytics.BLL.Services;
using Microsoft.AspNetCore.Builder;

namespace Analytics.BLL.Configurations;

public static class GrpcConfiguration
{
    public static WebApplication MapGrcpServices(this WebApplication webApplication)
    {
        webApplication.MapGrpcService<UserAnalyticsService>();
        webApplication.MapGrpcService<ProductAnalyticsService>();
        return webApplication;
    }
}