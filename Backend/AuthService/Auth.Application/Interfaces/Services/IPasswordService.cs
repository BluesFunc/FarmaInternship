using Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Auth.Application.Interfaces.Services;

public interface IPasswordService // userManager
{
    public string HashPassword(User user, string password);
    public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword);
}