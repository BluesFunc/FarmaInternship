using System.ComponentModel.DataAnnotations;
using Application.Wrappers;
using Domain.Entities.Enums;
using Domain.Models;
using MediatR;

namespace Application.Features.Auth.Commands.RegisterUser;

public record RegisterUserCommand : IRequest<Result<TokenPair>>
{
    public required string Username { get; init; }
    public required string Password { get; init; }

    public UserRole Role { get; init; } = UserRole.Customer;

    [EmailAddress] public required string Mail { get; init; }
}