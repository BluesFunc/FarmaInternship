using FluentValidation;

namespace Core.Application.Features.Commerce.Merchants.Commands.CreateMerchant;

public class CreateMerchantValidator : AbstractValidator<CreateMerchantCommand>
{
    public CreateMerchantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(100);
        RuleFor(x => x.Description);
    }
}