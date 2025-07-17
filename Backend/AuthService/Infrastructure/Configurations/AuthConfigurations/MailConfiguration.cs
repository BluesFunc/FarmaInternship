using Application.Interfaces.Services;
using Auth.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Configurations.AuthConfigurations;

public static class MailConfiguration
{
    public static IServiceCollection AddMail(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IEmailService, EmailSender>();
        return serviceCollection;
    }
}