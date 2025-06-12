using FluentValidation;

namespace Core.Application.Features.Trading.CartItems.Commands.UpdateCartItem;

public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemCommand>
{
    public UpdateCartItemValidator()
    {
        RuleFor(command => command.Quantity)
            .NotEmpty()
            .LessThan(50)
            .GreaterThan(0);
    }
}