using Auth.Domain.Entities;
using Auth.Domain.Interfaces.Abstractions;

namespace Auth.Domain.Interfaces;

public interface IUserRepository : IFilterRepository<User>;