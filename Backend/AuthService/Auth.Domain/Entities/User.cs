using System.ComponentModel.DataAnnotations;
using Auth.Domain.Entities.Abstractions;

namespace Auth.Domain.Entities;

public class User : Entity, IAuditableEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    [EmailAddress] public string Mail { get; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

    private User()
    {
    }

    public User(string username, string password, string mail)
    {
        Username = username;
        Password = password;
        Mail = mail;
    }
}