using Auth.Application;
using Auth.Infrastructure;
using Auth.Infrastructure.Configurations.AuthConfigurations;
using Auth.Infrastructure.Contexts;
using AuthApi.Extensions;
using Hangfire;
using MassTransit;
using MassTransit.MultiBus;
using Serilog;

namespace AuthApi;

public static class HostingExtension
{
    public static void AddExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureApplication()
            .ConfigureHangfire(builder.Configuration)
            .AddOpenApiAuth()
            .ConfigureInfrastructure()
            .AddMassTransit(
                x => x.UsingRabbitMq()
            )
            .AddControllers();
    }

    public static async Task UseExtensionsAsync(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
            await app.ApplyMigrations();
        }

        app.UseHangfireDashboard();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.MapHangfireDashboard();
    }
}