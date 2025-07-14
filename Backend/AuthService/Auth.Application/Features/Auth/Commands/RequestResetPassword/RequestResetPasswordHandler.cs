using System.Text;
using Auth.Application.Interfaces.Services;
using Auth.Application.Wrappers;
using Auth.Application.Wrappers.Enums;
using Auth.Domain.Interfaces;
using MediatR;

namespace Auth.Application.Features.Auth.Commands.RequestResetPassword;

public class RequestResetPasswordHandler(
    IUserRepository repository,
    IBackgroundTaskService backgroundTaskService) : IRequestHandler<RequestResetPasswordCommand, Result>
{
    public async Task<Result> Handle(RequestResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetEntityAsync(user => user.Mail == request.Mail, cancellationToken);

        if (user is null)
        {
            return Result.Failed(ErrorStatusCode.EntityConflict);
        }

        var messageBody = new StringBuilder();

        messageBody.Append("<h1>Hello, there is your's reset url</h1>");
        messageBody.Append($"<a href='https://localhost:5001/Auth/ResetPassword/{user.Id}'>Link</a>");

       backgroundTaskService.SendEmail(request.Mail, "Password reset", messageBody.ToString(), user.Id);

        return Result.Succeed();
    }
}