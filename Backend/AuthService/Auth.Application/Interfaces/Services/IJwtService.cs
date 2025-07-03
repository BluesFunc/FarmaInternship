using System.Security.Claims;
using Auth.Domain.Models;

namespace Auth.Application.Interfaces.Services;

public interface IJwtService 
{
    public TokenPair GenerateTokenPair(IDictionary<string,object> claims);
    public bool CanDecodeToken(string encodedToken);
}