using CleanArch.Domain.Todos;
using CleanArch.Domain.Todos.Enums;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Todos.Commands.CreateTodo;

public record CreateTodoCommand(
    string Title,
    string Description,
    DateTime DueDate,
    TodoPriority Priority,
    Guid UserId) : IRequest<ErrorOr<Todo>>;