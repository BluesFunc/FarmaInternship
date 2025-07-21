namespace Application.Interfaces.Services;

public interface IEmailService
{
    public void SendEmail(string toMail, string subject, string messageBody);
}