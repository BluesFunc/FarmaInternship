using System.ComponentModel.DataAnnotations;
using Application.Wrappers;
using Domain.Models;
using MediatR;

namespace Application.Features.Auth.Commands.LoginUser;

public record LoginUserCommand : IRequest<Result<TokenPair>>
{
    [EmailAddress] public required string Mail { get; init; }
    public required string Password { get; init; }
}