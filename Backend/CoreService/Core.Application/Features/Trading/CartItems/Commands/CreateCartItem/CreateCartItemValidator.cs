using FluentValidation;

namespace Core.Application.Features.Trading.CartItems.Commands.CreateCartItem;

public class CreateCartItemValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemValidator()
    {
        RuleFor(command => command.Quantity)
            .NotEmpty()
            .LessThan(50)
            .GreaterThan(0);
    }
}