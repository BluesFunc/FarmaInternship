using System.IdentityModel.Tokens.Jwt;

namespace Auth.Domain.Models;

public record TokenPair
{
    public  string? AccessToken { get; init; }
    public  string? RefreshToken { get; init; }
}

