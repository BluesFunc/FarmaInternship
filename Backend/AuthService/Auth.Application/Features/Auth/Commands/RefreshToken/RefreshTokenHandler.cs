using System.Security.Claims;
using Auth.Application.Extensions;
using Auth.Application.Interfaces.Services;
using Auth.Application.Wrappers;
using Auth.Application.Wrappers.Enums;
using Auth.Domain.Interfaces;
using Auth.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Application.Features.Auth.Commands.RefreshToken;

public class
    RefreshTokenHandler(
        IHttpContextAccessor httpContextAccessor,
        IUserRepository repository,
        IJwtService jwtService
    ) : IRequestHandler<RefreshTokenCommand, Result<TokenPair>>
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;

    public async Task<Result<TokenPair>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        if (!jwtService.CanDecodeToken(request.RefreshToken))
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.EntityConflict, "Invalid refresh token");
        }

        var authorizationToken = _httpContext.GetAuthorizationToken();
        if (authorizationToken.IsNullOrEmpty())
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.NotAuthorized, "Authorization header is missing");
        }

        var token = jwtService.ParseToken(authorizationToken);
        if (token == null)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.NotAuthorized, "Invalid jwt token format");
        }

        var userId = token.Claims
            .FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
        if (jwtService.IsTokenExpired(request.RefreshToken))
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.NotAuthorized, "Refresh token is expired");
        }

        if (userId == null)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.NotAuthorized, "User is not authorized");
        }

        var user = await repository.GetEntityByIdAsync((Guid.Parse(userId)), cancellationToken);
        if (user == null)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.NotFound, "User is not exists");
        }

        if (user.RefreshToken != request.RefreshToken)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.NotAuthorized, "Incorrect refresh token");
        }

        var tokenPair = jwtService.GenerateTokenPair(user);
        user.RefreshToken = tokenPair.RefreshToken;
        return Result<TokenPair>.Succeed(tokenPair);
    }
}