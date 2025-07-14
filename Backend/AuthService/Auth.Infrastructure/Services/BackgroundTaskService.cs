using Auth.Application.Interfaces.Services;
using Hangfire;

namespace Auth.Infrastructure.Services;

public class BackgroundTaskService(IBackgroundJobClient backgroundJobClient) : IBackgroundTaskService
{
    public void SendEmail(string toMail, string subject, string messageBody, Guid requestId)
    {
        backgroundJobClient.Enqueue<IEmailService>(service =>
            service.SendEmail(toMail, subject, messageBody));
    }
}