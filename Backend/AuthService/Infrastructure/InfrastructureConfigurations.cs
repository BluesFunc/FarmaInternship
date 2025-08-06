using System.IdentityModel.Tokens.Jwt;
using Application.Interfaces.Services;
using Auth.Infrastructure.Configurations;
using Auth.Infrastructure.Configurations.AuthConfigurations;
using Auth.Infrastructure.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure;

public static class InfrastructureConfigurations
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMail();
        serviceCollection.AddDatabase();
        serviceCollection.AddAuth();
        serviceCollection.ConfigureRabbit();
        serviceCollection.AddTransient<IBackgroundTaskService, BackgroundTaskService>();
        serviceCollection.AddScoped<JwtSecurityTokenHandler>();
        serviceCollection.AddScoped<IPasswordService, PasswordService>();
        serviceCollection.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        serviceCollection.AddScoped<IJwtService, JwtService>();
        return serviceCollection;
    }
}