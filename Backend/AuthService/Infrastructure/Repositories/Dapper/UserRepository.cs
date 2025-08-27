using System.Data;
using System.Linq.Expressions;
using Auth.Infrastructure.Repositories.Dapper.Queries;
using Dapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace Auth.Infrastructure.Repositories.Dapper;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public User AddEntity(User entity)
    {
        using var connection = CreateConnection();
        connection.Execute(UserQueries.AddUser, entity);
        return entity;
    }

    public User UpdateEntity(User entity)
    {
        using var connection = CreateConnection();
        connection.Execute(UserQueries.UpdateUser, entity);
        return entity;
    }

    public async Task<User?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<User>(
            new CommandDefinition(UserQueries.UserById, new { Id = id }, cancellationToken: cancellationToken)
        );
    }

    public void RemoveEntity(User entity)
    {
        using var connection = CreateConnection();
        connection.Execute(UserQueries.DeleteUser, new { entity.Id });
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }

    public async Task<bool> IsExistAsync(Expression<Func<User, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        var visitor = new SqlExpressionVisitor<User>();
        var condition = visitor.Translate(filter);

        Console.WriteLine(UserQueries.SelectFilteredUser(condition));
        using var connection = CreateConnection();
        var query =
            $"SELECT CASE WHEN EXISTS({UserQueries.SelectFilteredUser(condition)}) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";

        return await connection.ExecuteScalarAsync<bool>(
            new CommandDefinition(query, visitor.Parameters, cancellationToken: cancellationToken)
        );
    }

    public async Task<User?> GetEntityAsync(Expression<Func<User, bool>> filter,
        CancellationToken cancellationToken = default)
    {
        var visitor = new SqlExpressionVisitor<User>();
        var condition = visitor.Translate(filter);

        using var connection = CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<User>(
            new CommandDefinition(UserQueries.SelectFilteredUser(condition), visitor.Parameters,
                cancellationToken: cancellationToken)
        );
    }
}