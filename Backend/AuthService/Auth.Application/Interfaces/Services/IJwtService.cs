using System.IdentityModel.Tokens.Jwt;

using Auth.Domain.Entities;
using Auth.Domain.Models;

namespace Auth.Application.Interfaces.Services;

public interface IJwtService 
{
    public TokenPair GenerateTokenPair(User user);
    public bool CanDecodeToken(string encodedToken);
    public bool IsTokenExpired(string encodedToken);

    public JwtSecurityToken? ParseToken(string token);

    
}