using System.ComponentModel.DataAnnotations;
using Core.Domain.Entities.Abstractions;
using Core.Domain.Entities.Trading;

namespace Core.Domain.Entities;

public class User : AuditableEntity
{
    [EmailAddress] public string Email { get; private set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public string? PhotoUrl { get; set; }
    public ICollection<Order> Orders { get; private set; }
    public ICollection<Cart> Carts { get; private set; }
    public User(string email, string username, string hashedPassword)
    {
        Email = email;
        Username = username;
        HashedPassword = hashedPassword;
    }
}