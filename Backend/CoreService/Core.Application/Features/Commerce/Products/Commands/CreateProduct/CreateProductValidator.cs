using FluentValidation;

namespace Core.Application.Features.Commerce.Products.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
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