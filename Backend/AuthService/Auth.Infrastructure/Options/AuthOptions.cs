using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Infrastructure.Options;

public static class AuthOptions
{
    public static string Audience { get; } = "Farmacio";

    public static SymmetricSecurityKey SecurityKey { get; }
        = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
        (
            Environment.GetEnvironmentVariable("SECRET_KEY")
            ?? throw new InvalidOperationException()
        ));

    public static string SecurityAlgorithm { get; } = SecurityAlgorithms.HmacSha256;

    public static TimeSpan RefreshTokenLifeTime { get; }
        = TimeSpan.FromDays(
            int.Parse(
                Environment.GetEnvironmentVariable("REFRESH_TOKEN_LIFETIME")
                ?? throw new InvalidOperationException()
            ));

    public static TimeSpan AccessTokenLifeTime { get; }
        = TimeSpan.FromMinutes(
            int.Parse(
                Environment.GetEnvironmentVariable("ACCESS_TOKEN_LIFETIME")
                ?? throw new InvalidOperationException()
            ));
}