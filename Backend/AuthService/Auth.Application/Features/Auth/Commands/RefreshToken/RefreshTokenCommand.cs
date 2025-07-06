using Auth.Application.Wrappers;
using Auth.Domain.Models;
using MediatR;

namespace Auth.Application.Features.Auth.Commands.RefreshToken;

public record RefreshTokenCommand : IRequest<Result<TokenPair>>
{
    public required string RefreshToken;
}