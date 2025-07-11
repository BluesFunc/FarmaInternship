using Auth.Application.Interfaces.Services;
using Auth.Application.Wrappers;
using Auth.Application.Wrappers.Enums;
using Auth.Domain.Interfaces;
using MediatR;

namespace Auth.Application.Features.Auth.Commands.ResetPassword;

public class ResetPasswordHandler(IUserRepository repository, IPasswordService passwordService) : IRequestHandler<ResetPasswordCommand, Result>
{
    public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetEntityByIdAsync(request.UserId,cancellationToken);

        if (user is null)
        {
            return Result.Failed(ErrorStatusCode.NotFound);
        }
        
        var newPassword = passwordService.HashPassword(user, request.NewPassword);

        user.Password = newPassword;
        repository.UpdateEntity(user);
        await repository.SaveChangesAsync(cancellationToken);
        return Result.Succeed();
    }
}