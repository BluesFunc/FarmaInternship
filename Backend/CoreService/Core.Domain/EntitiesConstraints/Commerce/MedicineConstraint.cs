namespace Core.Domain.EntitiesConstraints.Commerce;

public static class MedicineConstraint
{
    public const int MaxNameLength = 50;
    public const int MinNameLength = 5;
    public const int MaxVolume = 10000;
    public const int MinVolume = 1;
    public const int MaxManufacterNameLength = 50;
    public const int MinManufacterNameLength = 5;
    public const int MaxManufacterOriginLength = 50;
    public const int MinManufacterOriginLength = 5;
}