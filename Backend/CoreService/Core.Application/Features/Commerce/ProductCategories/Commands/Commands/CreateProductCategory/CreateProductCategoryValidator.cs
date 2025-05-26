using FluentValidation;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.CreateProductCategory;

public class CreateProductCategoryValidator : AbstractValidator<CreateProductCategoryCommand>
{
    private CreateProductCategoryValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .MaximumLength(30);
    }
}