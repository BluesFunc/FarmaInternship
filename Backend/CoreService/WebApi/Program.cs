using Core.Application;
using Core.Infrastructure;
using Core.Infrastructure.Services.Notifications;
using Serilog;
using WebApi.Configurations;
using WebApi.Extensions;
using WebApi.Middlewares;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        LoggerBuilder.ConfigureElk();

        var builder = WebApplication.CreateBuilder(args);
        var configurationRoot = new ConfigurationBuilder().Build();


        builder.Services.ConfigureApplicationLayer();
        builder.Services.AddInfrastructure(configurationRoot);
        builder.Services.AddControllers();


        builder.Services.AddOpenApiAuth();

        builder.Host.UseSerilog();

        var app = builder.Build();


        app.UseSwagger();
        app.UseSwaggerUI();


        app.UseSerilogRequestLogging();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<ExceptionHandlerMiddleware>();
        app.MapHub<OrderNotificationHub>("/hubs/marketplace");
        app.MapControllers();
        app.UseCors("AllowAngularApp");

        app.Run();
    }
}