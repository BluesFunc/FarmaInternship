namespace Core.Application.Dtos.Statistics.Messages;

public record OrderStatisticDto
{
    public double Var { get; init; }
    public double Mean { get; init; }
    public double Deviation { get; init; }
}