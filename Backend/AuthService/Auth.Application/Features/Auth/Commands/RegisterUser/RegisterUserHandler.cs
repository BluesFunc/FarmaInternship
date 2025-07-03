using System.IdentityModel.Tokens.Jwt;
using Auth.Application.Interfaces.Services;
using Auth.Application.Wrappers;
using Auth.Application.Wrappers.Enums;
using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Auth.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Auth.Application.Features.Auth.Commands.RegisterUser;

public class RegisterUserHandler(
    IUserRepository repository,
    // ILogger logger,
    IPasswordService passwordService,
    IJwtService jwtService) : IRequestHandler<RegisterUserCommand, Result<TokenPair>>
{
    public async Task<Result<TokenPair>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var emailAlreadyInUse = await repository.EntityExistAsync(x => x.Mail == request.Mail, cancellationToken);
        if (emailAlreadyInUse)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.EntityConflict, "Email already in use");
        }

        var user = new User(request.Mail) { Username = request.Username };
        user.Password = passwordService.HashPassword(user, request.Password);

        var entity = repository.AddEntity(user);

        var claims = new Dictionary<string, object>()
        {
            { "user_mail", entity.Mail },
            { "user_id", entity.Id }
        };

        var tokens = jwtService.GenerateTokenPair(claims);
        user.RefreshToken = tokens.RefreshToken;

        await repository.SaveChangesAsync(cancellationToken);
        return Result<TokenPair>.Succeed(tokens);
    }
}