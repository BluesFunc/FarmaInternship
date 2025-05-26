using Core.Application.Wrappers;
using FluentValidation;

namespace Core.Application.Features.Abstractions.DeleteEntityByIdHandler;

public class CommandWithEntityIdValidator : AbstractValidator<CommandWithEntityId<Result>>
{
    public CommandWithEntityIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}