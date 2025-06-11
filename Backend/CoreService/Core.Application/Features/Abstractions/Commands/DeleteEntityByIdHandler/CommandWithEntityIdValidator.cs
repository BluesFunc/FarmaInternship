using Core.Application.Wrappers;
using FluentValidation;

namespace Core.Application.Features.Abstractions.Commands.DeleteEntityByIdHandler;

public class CommandWithEntityIdValidator : AbstractValidator<CommandWithEntityId<Result>>
{
    public CommandWithEntityIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}