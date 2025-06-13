using FluentValidation;

namespace Core.Application.Features.Trading.Orders.Commands.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.CartId)
            .NotEmpty();
    }
}