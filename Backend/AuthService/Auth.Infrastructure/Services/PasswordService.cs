using Auth.Application.Interfaces.Services;
using Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Auth.Infrastructure.Services;

public class PasswordService(IPasswordHasher<User> passwordHasher) : IPasswordService
{
    
    public string HashPassword(User user, string password)
    {
        return passwordHasher.HashPassword(user, password);
    }

    public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
    {
        return passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
    }
    
}