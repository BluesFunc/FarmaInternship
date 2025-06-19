namespace Core.Domain.EntitiesConstraints.Commerce;

public class ProductConstraint
{
    public const int MaxNameLength = 255;
    public const int MinNameLength = 5;
    public const int PriceGreaterThan = 0;
    public const int QuantityGreaterThanOrEqualTo = 0;
}