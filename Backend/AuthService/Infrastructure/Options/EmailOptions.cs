using MailKit.Security;

namespace Auth.Infrastructure.Options;

public static class EmailOptions
{
    public static SecureSocketOptions HostSecureSocketOptions { get; set; } = SecureSocketOptions.Auto;
    public static string HostAddress { get; set; } = Environment.GetEnvironmentVariable("MAIL_HOST_ADRESS");

    public static int HostPort { get; set; } = int.Parse(Environment.GetEnvironmentVariable("MAIL_HOST_PORT"));

    public static string HostUsername { get; set; } = Environment.GetEnvironmentVariable("EMAIL_USERNAME");

    public static string HostPassword { get; set; } = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
}