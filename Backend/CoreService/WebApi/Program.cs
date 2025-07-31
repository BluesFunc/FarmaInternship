using Core.Application;
using Core.Infrastructure;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.Http;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.DurableHttpUsingFileSizeRolledBuffers(
                requestUri: "http://localhost:8080",
                textFormatter: new JsonFormatter()
            )
            .CreateLogger();
            
        var builder = WebApplication.CreateBuilder(args);

      
        
        builder.Services.ConfigureApplicationLayer();
        builder.Services.AddInfrastructure();
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
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();
        
        app.Run();
    }
}