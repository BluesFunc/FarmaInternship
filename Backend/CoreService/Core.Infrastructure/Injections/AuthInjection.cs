using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core.Infrastructure.Injections;

public static class AuthInjection
{
    public static IServiceCollection InjectAuth(this IServiceCollection serviceCollection)
    {
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
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = signKey,
                    ValidateIssuerSigningKey = true
                }
            );

        serviceCollection.AddAuthorization();
        
        return serviceCollection;
    }
}