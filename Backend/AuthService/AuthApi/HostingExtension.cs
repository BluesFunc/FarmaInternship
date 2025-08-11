using Application;
using Auth.Infrastructure;
using Auth.Infrastructure.Configurations.AuthConfigurations;
using AuthApi.Extensions;
using Hangfire;
using Serilog;

namespace AuthApi;

public static class HostingExtension
{
    public static void AddExtensions(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureApplication()
            .ConfigureHangfire()
            .AddOpenApiAuth()
            .ConfigureInfrastructure()
            .AddControllers();
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp", policy =>
            {
                policy.WithOrigins(Environment.GetEnvironmentVariable("CLIENT_URL")) 
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); 
            });
        });
            
    }

    public static async Task UseExtensionsAsync(this WebApplication app)
    {
        app.UseCors("AllowAngularApp");
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