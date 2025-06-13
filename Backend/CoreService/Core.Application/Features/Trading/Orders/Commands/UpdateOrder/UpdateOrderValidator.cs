using FluentValidation;

namespace Core.Application.Features.Trading.Orders.Commands.UpdateOrder;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Status)
            .IsInEnum();
    }
}