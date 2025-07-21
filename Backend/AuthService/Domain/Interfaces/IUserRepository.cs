using Domain.Entities;
using Domain.Interfaces.Abstractions;

namespace Domain.Interfaces;

public interface IUserRepository : IFilterRepository<User>;