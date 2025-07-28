using Application.Wrappers;
using Domain.Models;
using MediatR;

namespace Application.Features.Auth.Commands.RefreshToken;

public record RefreshTokenCommand : IRequest<Result<TokenPair>>
{
}