using MailKit.Security;

namespace Auth.Infrastructure.Options;

public static class EmailOptions
{
    public static SecureSocketOptions HostSecureSocketOptions { get; set; } = SecureSocketOptions.Auto;
    public static string HostAddress { get; set; } = Environment.GetEnvironmentVariable("MAIL_HOST_ADDRESS") ?? throw new InvalidOperationException();

    public static int HostPort { get; set; } = int.Parse(Environment.GetEnvironmentVariable("MAIL_HOST_PORT") ?? throw new InvalidOperationException());

    public static string HostUsername { get; set; } = Environment.GetEnvironmentVariable("EMAIL_USERNAME") ?? throw new InvalidOperationException();

    public static string HostPassword { get; set; } = Environment.GetEnvironmentVariable("EMAIL_PASSWORD") ?? throw new InvalidOperationException();
}