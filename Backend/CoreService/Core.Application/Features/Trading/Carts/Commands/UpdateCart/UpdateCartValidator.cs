using FluentValidation;

namespace Core.Application.Features.Trading.Carts.Commands.UpdateCart;

public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartValidator()
    {
        RuleFor(x => x)
            .NotEmpty();

        RuleFor(x => x.Status)
            .IsInEnum();
    }
}