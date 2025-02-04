using FluentValidation;

namespace CleanArch.Application.Todos.Commands.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(x => x.Title)
            .MinimumLength(3)
            .MaximumLength(100);
    }
}