using Auth.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Application.Features.Auth.Commands.ResetPassword;

public record ResetPasswordCommand : IRequest<Result>
{
    [FromRoute]public Guid UserId { get; init; }
    [FromBody]public required string NewPassword { get; init; }
}