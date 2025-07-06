using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Auth.Application.Interfaces.Services;
using Auth.Domain.Entities;
using Auth.Domain.Models;
using Auth.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Infrastructure.Services;

public class JwtService(JwtSecurityTokenHandler tokenHandler) : IJwtService
{
    public TokenPair GenerateTokenPair(User user)
    {
        var accessExpireAt = DateTime.UtcNow + AuthOptions.AccessTokenLifeTime;
        var encodedAccessToken = GenerateEncodedToken(accessExpireAt, user);

        var refreshExpireAt = DateTime.UtcNow + AuthOptions.RefreshTokenLifeTime;
        var encodedRefreshToken = GenerateEncodedToken(refreshExpireAt);


        var pair = new TokenPair()
        {
            AccessToken = encodedAccessToken,
            RefreshToken = encodedRefreshToken
        };
        return pair;
    }

    public bool CanDecodeToken(string encodedToken)
        => tokenHandler.CanReadToken(encodedToken);

    public bool IsTokenExpired(string encodedToken)
    {
        var token = tokenHandler.ReadJwtToken(encodedToken);
        return token.Payload.Expiration <
               (long)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;
    }

    public JwtSecurityToken? ParseToken(string token)
    {
        return CanDecodeToken(token) ? tokenHandler.ReadJwtToken(token) : null;
    }


    private string? GenerateEncodedToken(DateTime expireAt, User? user = null)
    {
        var claims =  new Dictionary<string, object>();
        
        if (user is not null)
        {
            claims.Add(ClaimsIdentity.DefaultRoleClaimType, user.UserRole.ToString());
            claims.Add(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString());
        }
        
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Audience = AuthOptions.Audience,
            SigningCredentials = new SigningCredentials(AuthOptions.SecurityKey, AuthOptions.SecurityAlgorithm),
            Claims = claims,
            Expires = expireAt
        };
        var accessSecurityToken = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
        var encodedAccessToken = tokenHandler.WriteToken(accessSecurityToken);
        return encodedAccessToken;
    }
}