using Core.Domain.Enums.Commerce;
using Core.Domain.Models.QueryParams.Abstractions;

namespace Core.Domain.Models.QueryParams.Commerce;

public record MedicineQueryParams : PaginationQueryParams
{
    public string? Name { get; init; }
    public MedicineType? Type { get; init; }
    public string? ManufacturerOrigin { get; init; }
    public string? ManufacturerName { get; init; }
}