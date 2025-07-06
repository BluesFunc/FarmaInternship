using System.IdentityModel.Tokens.Jwt;

namespace Auth.Domain.Models;

public record TokenPair
{
    public required  string AccessToken { get; init; }
    public  required string RefreshToken { get; init; }
}

