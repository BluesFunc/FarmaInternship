using Domain.Entities;
using Domain.Models;

namespace Application.Interfaces.Services;

public interface IJwtService
{
    public TokenPair GenerateTokenPair(User user);
}