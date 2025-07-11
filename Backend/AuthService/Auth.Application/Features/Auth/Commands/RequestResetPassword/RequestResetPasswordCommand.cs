using System.ComponentModel.DataAnnotations;
using Auth.Application.Wrappers;
using MediatR;

namespace Auth.Application.Features.Auth.Commands.RequestResetPassword;

public record RequestResetPasswordCommand : IRequest<Result>
{
    [EmailAddress]
    public required string Mail { get; init; }
}