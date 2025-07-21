using Application.Extensions;
using Application.Interfaces.Services;
using Application.Wrappers;
using Application.Wrappers.Enums;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Auth.Commands.RefreshToken;

public class
    RefreshTokenHandler(
        IHttpContextAccessor httpContextAccessor,
        IUserRepository repository,
        IJwtService jwtService
    ) : IRequestHandler<RefreshTokenCommand, Result<TokenPair>>
{
    private readonly HttpContext
        _httpContext = httpContextAccessor.HttpContext ?? throw new InvalidOperationException();

    public async Task<Result<TokenPair>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var userId = _httpContext.GetUserIdFromClaims();

        if (userId is null)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.NotAuthorized, "User Id is missing");
        }

        var user = await repository.GetEntityByIdAsync(userId.Value, cancellationToken);
        if (user == null)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.NotFound, "User is not exists");
        }

        var token = _httpContext.GetAuthorizationToken();

        if (user.RefreshToken != token)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.NotAuthorized, "Incorrect refresh token");
        }

        var tokenPair = jwtService.GenerateTokenPair(user);
        user.RefreshToken = tokenPair.RefreshToken;
        repository.UpdateEntity(user);
        await repository.SaveChangesAsync(cancellationToken);

        return Result<TokenPair>.Succeed(tokenPair);
    }
}