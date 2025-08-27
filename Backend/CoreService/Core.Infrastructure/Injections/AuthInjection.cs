using System.Text;
using Core.Application.Requirements.ResourceAuth;
using Core.Application.Requirements.ResourceAuth.Cart;
using Core.Application.Requirements.ResourceAuth.Order;
using Core.Application.Requirements.ResourceAuth.Product;
using Core.Domain.Enums;
using Core.Infrastructure.Configurations;
using Core.Infrastructure.Handlers.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core.Infrastructure.Injections;

public static class AuthInjection
{
    public static IServiceCollection InjectAuthentication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddCors(options =>
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

        var audience = Environment.GetEnvironmentVariable("AUTH_AUDIENCE");
        var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
        (
            Environment.GetEnvironmentVariable("SECRET_KEY")
            ?? throw new InvalidOperationException()
        ));

        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = signKey,
                    ValidateIssuerSigningKey = true
                }
            );
        return serviceCollection;
    }

    public static IServiceCollection InjectAuthorization(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthorizationBuilder()
            .AddRoles()
            .AddPolices();


        serviceCollection.AddSingleton<IAuthorizationHandler, ProductModificationAuthorizationHandler>();
        serviceCollection.AddSingleton<IAuthorizationHandler, ViewOrderAuthorizationHandler>();
        serviceCollection.AddSingleton<IAuthorizationHandler, ViewCartAuthorizationHandler>();

        serviceCollection.AddHttpContextAccessor();
        return serviceCollection;
    }

    private static AuthorizationBuilder AddRoles(this AuthorizationBuilder builder)
    {
        builder
            .AddPolicy(AuthorizationConfigurations.AdminPolicy,
                config => { config.RequireRole(nameof(UserRole.Admin)); })
            .AddPolicy(AuthorizationConfigurations.MerchandiserPolicy,
                config => { config.RequireRole(nameof(UserRole.Merchandiser)); })
            .AddPolicy(AuthorizationConfigurations.AdminOrMerchandiserPolicy, config =>
            {
                config.RequireAssertion(context =>
                    context.User.IsInRole(nameof(UserRole.Admin))
                    || context.User.IsInRole(nameof(UserRole.Merchandiser)));
            });


        return builder;
    }

    private static AuthorizationBuilder AddPolices(this AuthorizationBuilder builder)
    {
        builder.AddPolicy(ResourcePolicies.ProductModification,
            config => { config.Requirements.Add(new ProductModificationRequirement()); });
        builder.AddPolicy(ResourcePolicies.ViewOrder,
            config => { config.Requirements.Add(new ViewOrderAuthorizationRequirement()); });
        builder.AddPolicy(ResourcePolicies.ViewCart,
            config => { config.Requirements.Add(new ViewCartAuthorizationRequirement()); });

        return builder;
    }
}