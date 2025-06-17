using Core.Domain.EntitiesConstraints.Trading;
using FluentValidation;

namespace Core.Application.Features.Trading.CartItems.Commands.UpdateCartItem;

public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemCommand>
{
    public UpdateCartItemValidator()
    {
        RuleFor(command => command.Quantity)
            .GreaterThan(CartItemConstraint.QuantityGreaterThan)
            .LessThan(CartItemConstraint.QuantityLessThan);
    }
}