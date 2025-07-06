using System.ComponentModel.DataAnnotations;
using Auth.Application.Wrappers;
using Auth.Domain.Entities.Enums;
using Auth.Domain.Models;
using MediatR;

namespace Auth.Application.Features.Auth.Commands.RegisterUser;

public record RegisterUserCommand : IRequest<Result<TokenPair>>
{
    public required string Username { get; init; }
    public required string Password { get; init; }

    public UserRole Role { get; init; } = UserRole.Customer;
    
    [EmailAddress]
    public required string Mail { get; init; }
}