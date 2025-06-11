using Core.Domain.Entities.Commerce;
using Mapster;

namespace Core.Application.Dtos.Commerce;

public class ProductCategoryDto : IMapFrom<ProductCategory>
{
    public string Name { get; set; } = null!;
}