using System.IdentityModel.Tokens.Jwt;

using Auth.Domain.Entities;
using Auth.Domain.Models;

namespace Auth.Application.Interfaces.Services;

public interface IJwtService
{
    public TokenPair GenerateTokenPair(User user);
}