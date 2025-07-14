using Auth.Application.Interfaces.Services;
using Auth.Application.Wrappers;
using Auth.Application.Wrappers.Enums;
using Auth.Domain.Interfaces;
using Auth.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Auth.Application.Features.Auth.Commands.LoginUser;

public class LoginUserHandler(IUserRepository repository, IJwtService jwtService, IPasswordService passwordService)
    : IRequestHandler<LoginUserCommand, Result<TokenPair>>
{
    public async Task<Result<TokenPair>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetEntityAsync(x => x.Mail == request.Mail, cancellationToken);
       
        if (user is not null && 
            passwordService.VerifyHashedPassword(user, user.Password, request.Password) ==
            PasswordVerificationResult.Failed)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.EntityConflict, "Wrong email or password");
        }

        var tokenPair = jwtService.GenerateTokenPair(user);

        user.RefreshToken = tokenPair.RefreshToken;
        repository.UpdateEntity(user);
        await repository.SaveChangesAsync(cancellationToken);
        
        return Result<TokenPair>.Succeed(tokenPair);
    }
}