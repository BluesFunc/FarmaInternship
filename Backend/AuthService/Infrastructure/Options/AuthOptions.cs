using System.Text;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Bcpg;

namespace Auth.Infrastructure.Options;

public static class AuthOptions
{
    public static string Audience { get; } = "Farmacio";

    public static SymmetricSecurityKey SecurityKey { get; }
        = new(Encoding.UTF8.GetBytes
        (
            Environment.GetEnvironmentVariable("SECRET_KEY")
            ?? "af6fec8aa43fa80a22fd3471ab09c803a7b6e91fbc99a3a54ebdc09ddfa2b306"
        ));

    public static string SecurityAlgorithm { get; } = SecurityAlgorithms.HmacSha256;

    public static TimeSpan RefreshTokenLifeTime { get; }
        = TimeSpan.FromDays(
            int.Parse(
                Environment.GetEnvironmentVariable("REFRESH_TOKEN_LIFETIME")
                ?? "30"
            ));

    public static TimeSpan AccessTokenLifeTime { get; }
        = TimeSpan.FromMinutes(
            int.Parse(
                Environment.GetEnvironmentVariable("ACCESS_TOKEN_LIFETIME") ?? "15"
            ));
}