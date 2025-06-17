using FluentValidation;

namespace Core.Application.Features.Trading.CartItems.Commands.CreateCartItem;

public class CreateCartItemValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemValidator()
    {
        RuleFor(command => command.Quantity)
            .GreaterThan(0)
            .LessThan(50);
    }
}