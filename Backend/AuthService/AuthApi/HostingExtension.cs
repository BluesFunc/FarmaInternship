using Auth.Application;
using Auth.Infrastructure;
using Auth.Infrastructure.Contexts;
using Serilog;

namespace AuthApi;

public static class HostingExtension
{
    public static void AddExtensions(this WebApplicationBuilder builder)
    {
        
        
        
        builder.Services.ConfigureApplication().
            ConfigureInfrastructure()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddControllers();

    }

    public static void UseExtensions(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
            context.Database.EnsureCreated();
        }


        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapDefaultControllerRoute();
    }
}