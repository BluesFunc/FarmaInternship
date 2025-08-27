using Hangfire;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Configurations.AuthConfigurations;

public static class HangfireConfigurations
{
    public static IServiceCollection ConfigureHangfire(this IServiceCollection serviceCollection)
    {
        var connectionString = Environment.GetEnvironmentVariable("HANGFIRE_CONNECTION");

        EnsureDatabaseExists(connectionString);

        serviceCollection.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connectionString));


        serviceCollection.AddHangfireServer();
        return serviceCollection;

        void EnsureDatabaseExists(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = builder.InitialCatalog;

            builder.InitialCatalog = "master"; // Подключаемся к master, чтобы создать БД

            using var connection = new SqlConnection(builder.ToString());
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = $"IF DB_ID('{databaseName}') IS NULL CREATE DATABASE [{databaseName}]";
            command.ExecuteNonQuery();
        }
    }
}