using FluentValidation;

namespace Core.Application.Features.Commerce.Merchants.Commands.UpdateMerchant;

public class UpdateMerchantValidator : AbstractValidator<UpdateMerchantCommand>
{
    public UpdateMerchantValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(5)
            .MaximumLength(30);
        RuleFor(x => x.Description)
            .MinimumLength(5);
    }
}