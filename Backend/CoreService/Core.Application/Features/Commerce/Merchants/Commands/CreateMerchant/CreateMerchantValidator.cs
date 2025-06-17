using Core.Domain.EntitiesConstraints.Commerce;
using FluentValidation;

namespace Core.Application.Features.Commerce.Merchants.Commands.CreateMerchant;

public class CreateMerchantValidator : AbstractValidator<CreateMerchantCommand>
{
    public CreateMerchantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(MerchantConstraint.MinNameLength)
            .MaximumLength(MerchantConstraint.MaxNameLength);

        RuleFor(x => x.Description);
    }
}