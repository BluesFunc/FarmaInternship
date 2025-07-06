using System.ComponentModel.DataAnnotations;
using Auth.Application.Wrappers;
using Auth.Domain.Models;
using MediatR;

namespace Auth.Application.Features.Auth.Commands.LoginUser;

public record LoginUserCommand : IRequest<Result<TokenPair>>
{ 
    [EmailAddress]
    public required string Mail { get; init; }
    public required string Password { get; init; }
}