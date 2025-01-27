using FluentValidation;

namespace CleanArch.Application.ToDos.Commands.CreateTask;

public class CreateToDoCommandValidator : AbstractValidator<CreateToDoCommand>
{
    public CreateToDoCommandValidator()
    {
        RuleFor(x => x.Title)
            .MinimumLength(3)
            .MaximumLength(100);
    }
}