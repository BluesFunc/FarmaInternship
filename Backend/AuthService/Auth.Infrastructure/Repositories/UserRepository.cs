using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Auth.Infrastructure.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repositories;

public class UserRepository(DbContext context) : RepositoryBase<User>(context), IUserRepository;