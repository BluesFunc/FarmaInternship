using System.IdentityModel.Tokens.Jwt;
using Auth.Application.Interfaces.Services;
using Auth.Domain.Entities;
using Auth.Infrastructure.Configurations;
using Auth.Infrastructure.Configurations.AuthConfigurations;
using Auth.Infrastructure.Contexts;
using Auth.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure;

public static class InfrastructureConfigurations
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDatabase();
        serviceCollection.AddAuth();
        serviceCollection.AddScoped<JwtSecurityTokenHandler>();
        serviceCollection.AddScoped<IPasswordService, PasswordService>();
        serviceCollection.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        serviceCollection.AddScoped<IJwtService, JwtService>();
        return serviceCollection;
    }
}