using FluentValidation;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.UpdateProductCategory;

public class UpdateProductCategoryValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    private UpdateProductCategoryValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(30);
    }
}