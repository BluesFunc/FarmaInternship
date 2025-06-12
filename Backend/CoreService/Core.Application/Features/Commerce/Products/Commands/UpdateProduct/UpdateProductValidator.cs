using FluentValidation;

namespace Core.Application.Features.Commerce.Products.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .MaximumLength(50)
            .MinimumLength(5);

        RuleFor(x => x.MerchantId)
            .NotEmpty();

        RuleFor(x => x.MedicineId)
            .NotEmpty();

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.StockQuantity)
            .NotEmpty()
            .GreaterThanOrEqualTo(0);
    }
}