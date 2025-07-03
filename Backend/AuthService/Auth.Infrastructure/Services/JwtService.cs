using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Auth.Application.Interfaces.Services;
using Auth.Domain.Models;
using Auth.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Infrastructure.Services;

public class JwtService(JwtSecurityTokenHandler tokenHandler) : IJwtService
{
    public TokenPair GenerateTokenPair(IDictionary<string, object> claims)
    {
        var accessExpireAt = DateTime.UtcNow + AuthOptions.AccessTokenLifeTime;
        var encodedAccessToken = GenerateEncodedToken(accessExpireAt, claims);

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


    private string? GenerateEncodedToken(DateTime expireAt, IDictionary<string, object>? claims = null)
    {
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