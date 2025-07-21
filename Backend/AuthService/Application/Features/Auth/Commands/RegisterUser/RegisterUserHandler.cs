using Application.Interfaces.Services;
using Application.Wrappers;
using Application.Wrappers.Enums;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Auth.Commands.RegisterUser;

public class RegisterUserHandler(
    IUserRepository repository,
    // ILogger logger,
    IPasswordService passwordService,
    IJwtService jwtService) : IRequestHandler<RegisterUserCommand, Result<TokenPair>>
{
    public async Task<Result<TokenPair>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var emailAlreadyInUse = await repository.IsExistAsync(x => x.Mail == request.Mail, cancellationToken);
        if (emailAlreadyInUse)
        {
            return Result<TokenPair>.Failed(ErrorStatusCode.EntityConflict, "Email already in use");
        }

        var user = new User(request.Mail, request.Role) { Username = request.Username };
        user.Password = passwordService.HashPassword(user, request.Password);

        var entity = repository.AddEntity(user);

        var tokenPair = jwtService.GenerateTokenPair(entity);
        user.RefreshToken = tokenPair.RefreshToken;
        repository.AddEntity(user);
        await repository.SaveChangesAsync(cancellationToken);

        return Result<TokenPair>.Succeed(tokenPair);
    }
}