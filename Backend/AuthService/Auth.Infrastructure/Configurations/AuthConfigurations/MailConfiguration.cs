
using Auth.Application.Interfaces.Services;
using Auth.Infrastructure.Options;
using Auth.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Configurations.AuthConfigurations;

public static class MailConfiguration
{
    public static IServiceCollection AddMail(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IEmailService, EmailSender>();
        serviceCollection.Configure<EmailOptions>(options =>
        {
            options.HostAddress = "smtp.gmail.com";
            options.HostPort = 587;
            options.HostUsername = "farmacioservice@gmail.com";
            options.HostPassword = "yzzl pvgv wnbd cihn";
        });
        return serviceCollection;
    }
}