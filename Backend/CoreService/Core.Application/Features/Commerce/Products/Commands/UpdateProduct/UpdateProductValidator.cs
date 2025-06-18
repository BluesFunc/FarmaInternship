using Core.Domain.EntitiesConstraints.Commerce;
using FluentValidation;

namespace Core.Application.Features.Commerce.Products.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(ProductConstraint.MinNameLength)
            .MaximumLength(ProductConstraint.MaxNameLength);

        RuleFor(x => x.MerchantId)
            .NotEmpty();

        RuleFor(x => x.MedicineId)
            .NotEmpty();

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(ProductConstraint.PriceGreaterThan);

        RuleFor(x => x.StockQuantity)
            .NotEmpty()
            .GreaterThanOrEqualTo(ProductConstraint.QuantityGreaterThanOrEqualTo);
    }
}