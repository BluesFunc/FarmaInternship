using Domain.Entities;

namespace Auth.Infrastructure.Repositories.Dapper.Queries;

public static class UserQueries
{
    private static string _userTableName = $"[{nameof(User).ToLower()}]";

    public static string GetAll =>
        $"SELECT * FROM {_userTableName}";

    public static string UserById =>
        $"SELECT * FROM {_userTableName} WHERE [Id] = @Id";

    public static string AddUser =>
        $"""
         INSERT INTO {_userTableName} ([Id],[Username], [Mail], [Password], [UserRole], [RefreshToken])
         VALUES (@Id, @Username, @Mail, @Password, @UserRole, @RefreshToken );
         """;

    public static string UpdateUser =>
        $"""
         UPDATE {_userTableName}
         SET [Username] = @Username,
             [Password] = @Password,
             [UserRole] = @UserRole,
             [RefreshToken] = @RefreshToken
         WHERE [Id] = @Id
         """;

    public static string DeleteUser =>
        $"DELETE FROM {_userTableName} WHERE [Id] = @Id";

    public static string SelectFilteredUser(string condition)
    {
        return $"SELECT * FROM {_userTableName} WHERE {condition}";
    }
}