using Auth.Application;
using Auth.Infrastructure;
using Auth.Infrastructure.Contexts;
using AuthApi.Extensions;
using Serilog;

namespace AuthApi;

public static class HostingExtension
{
    public static void AddExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureApplication()
            .AddOpenApiAuth()
            .ConfigureInfrastructure()
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


        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}