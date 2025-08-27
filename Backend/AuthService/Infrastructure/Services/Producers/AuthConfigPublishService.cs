using Application.Messages;
using Auth.Infrastructure.Options;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace Auth.Infrastructure.Services.Producers;

public class AuthConfigPublishService(IPublishEndpoint publishEndpoint) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var message = new AuthConfigMessage
        {
            Audience = AuthOptions.Audience,
            SecretKeyData = AuthOptions.SecurityKey.Key,
            SecurityAlgorithm = AuthOptions.SecurityAlgorithm
        };
        await publishEndpoint.Publish(message, cancellationToken);
    }


    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}