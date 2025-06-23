using Core.Domain.EntitiesConstraints.Commerce;
using FluentValidation;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.CreateProductCategory;

public class CreateProductCategoryValidator : AbstractValidator<CreateProductCategoryCommand>
{
    public CreateProductCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(ProductCategoryConstraint.MinNameLength)
            .MaximumLength(ProductCategoryConstraint.MaxNameLength);
    }
}