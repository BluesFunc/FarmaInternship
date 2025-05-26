using Core.Domain.Entities.Commerce;
using Mapster;

namespace Core.Application.DTOs.Commerce;

public class ProductCategoryDto : IMapFrom<ProductCategory>
{
    public string Name { get; set; } = null!;
}