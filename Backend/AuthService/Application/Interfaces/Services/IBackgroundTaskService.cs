namespace Application.Interfaces.Services;

public interface IBackgroundTaskService
{
    public void SendEmail(string toMail, string subject, string messageBody, Guid requestId);
}