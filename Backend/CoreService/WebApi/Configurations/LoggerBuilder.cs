using Serilog;
using Serilog.Formatting.Json;

namespace WebApi.Configurations;

public static class LoggerBuilder
{
    public static void ConfigureElk()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.DurableHttpUsingFileSizeRolledBuffers(
                Environment.GetEnvironmentVariable("LOGISTASH_URL"),
                textFormatter: new JsonFormatter()
            )
            .CreateLogger();
    }
}