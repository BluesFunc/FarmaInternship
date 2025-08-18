using Core.Application;
using Core.Infrastructure;
using Core.Infrastructure.Services.Notifications;
using Serilog;
using WebApi.Configurations;
using WebApi.Extensions;

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


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp",
                policy =>
                {
                    policy.WithOrigins(Environment.GetEnvironmentVariable("CLIENT_URL")
                                       ?? throw new InvalidOperationException())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });

        builder.Services.AddOpenApiAuth();

        builder.Host.UseSerilog();

        var app = builder.Build();


        app.UseSwagger();
        app.UseSwaggerUI();


        app.UseSerilogRequestLogging();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHub<OrderNotificationHub>("/hubs/marketplace");
        app.MapControllers();
        app.UseCors("AllowAngularApp");

        app.Run();
    }
}