using Core.Application;
using Core.Infrastructure;
using Core.Infrastructure.Services.Notifications;
using Serilog;
using WebApi.Configurations;

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

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Host.UseSerilog();

        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSerilogRequestLogging();
        // app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapHub<OrderNotificationHub>("/hubs/marketplace");
        app.MapControllers();

        app.Run();
    }
}