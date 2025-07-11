using Auth.Application.Interfaces.Services;
using Auth.Infrastructure.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace Auth.Infrastructure.Services;

public class EmailSender : IEmailService
{
    public EmailSender(IOptions<EmailOptions> options)
    {
        Options = options.Value;
    }

    public EmailOptions Options { get; init; } 
    
    public void SendEmail(string toMail, string subject, string messageBody)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(Options.HostUsername));
        email.To.Add(MailboxAddress.Parse(toMail));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html){Text = messageBody};

        using (var client = new SmtpClient())
        {
            client.Connect(Options.HostAddress, Options.HostPort);
            client.Authenticate(Options.HostUsername, Options.HostPassword);
            client.Send(email);
            client.Disconnect(true);
        }
     
        
    }
}