using Auth.Application.Interfaces.Services;
using Auth.Domain.Entities;
using Auth.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenController(IJwtService service, IPasswordService passwordService) : ControllerBase
{
 
}