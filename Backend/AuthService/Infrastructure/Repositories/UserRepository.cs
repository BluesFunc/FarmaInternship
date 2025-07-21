using Auth.Infrastructure.Repositories.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repositories;

public class UserRepository(DbContext context) : RepositoryBase<User>(context), IUserRepository;