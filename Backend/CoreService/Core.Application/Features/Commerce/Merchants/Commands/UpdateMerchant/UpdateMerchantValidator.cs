using Core.Domain.EntitiesConstraints.Commerce;
using FluentValidation;

namespace Core.Application.Features.Commerce.Merchants.Commands.UpdateMerchant;

public class UpdateMerchantValidator : AbstractValidator<UpdateMerchantCommand>
{
    public UpdateMerchantValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(MerchantConstraint.MinNameLength)
            .MaximumLength(MerchantConstraint.MaxNameLength);
    }
}