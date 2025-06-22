using Core.Domain.EntitiesConstraints.Commerce;
using FluentValidation;

namespace Core.Application.Features.Commerce.ProductCategories.Commands.Commands.UpdateProductCategory;

public class UpdateProductCategoryValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    public UpdateProductCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(ProductCategoryConstraint.MinNameLength)
            .MaximumLength(ProductCategoryConstraint.MaxNameLength);
    }
}