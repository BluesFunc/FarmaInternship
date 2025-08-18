namespace Application.Messages;

public record AuthConfigMessage
{
    public required string Audience { get; init; }
    public required byte[] SecretKeyData { get; init; }
    public required string SecurityAlgorithm { get; init; }
}