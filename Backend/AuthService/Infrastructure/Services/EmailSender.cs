using Application.Interfaces.Services;
using Auth.Infrastructure.Options;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Auth.Infrastructure.Services;

public class EmailSender : IEmailService
{
    public void SendEmail(string toMail, string subject, string messageBody)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(EmailOptions.HostUsername));
        email.To.Add(MailboxAddress.Parse(toMail));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = messageBody };

        using (var client = new SmtpClient())
        {
            client.Connect(EmailOptions.HostAddress, EmailOptions.HostPort);
            client.Authenticate(EmailOptions.HostUsername, EmailOptions.HostPassword);
            client.Send(email);
            client.Disconnect(true);
        }
    }
}