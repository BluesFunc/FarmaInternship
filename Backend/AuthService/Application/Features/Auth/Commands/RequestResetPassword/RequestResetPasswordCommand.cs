using System.ComponentModel.DataAnnotations;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Auth.Commands.RequestResetPassword;

public record RequestResetPasswordCommand : IRequest<Result>
{
    [EmailAddress] public required string Mail { get; init; }
}