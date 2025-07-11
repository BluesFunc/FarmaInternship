using MailKit.Security;

namespace Auth.Infrastructure.Options;

public class EmailOptions
{
    public SecureSocketOptions HostSecureSocketOptions { get; init; }

    public EmailOptions()
    {
        HostSecureSocketOptions = SecureSocketOptions.Auto;
    }

    public string HostAddress { get; set; }

    public int HostPort { get; set; }

    public string HostUsername { get; set; }

    public string HostPassword { get; set; }
    

}