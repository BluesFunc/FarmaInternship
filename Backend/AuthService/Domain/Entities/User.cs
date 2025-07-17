using System.ComponentModel.DataAnnotations;
using Domain.Entities.Abstractions;
using Domain.Entities.Enums;

namespace Domain.Entities;

public class User : Entity, IAuditableEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    [EmailAddress] public string Mail { get; }
    public string RefreshToken { get; set; }
    public UserRole UserRole { get; set; } = UserRole.Customer;
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    private User()
    {
    }

    public User(string mail, UserRole role)
    {
        Mail = mail;
    }

    public void Deconstruct(out string mail, out string username, out string password)
    {
        mail = Mail;
        username = Username;
        password = Password;
    }
}