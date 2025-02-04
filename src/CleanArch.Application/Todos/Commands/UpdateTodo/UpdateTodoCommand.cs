using ErrorOr;
using MediatR;

namespace CleanArch.Application.Todos.Commands.UpdateTodo;

public record UpdateTodoCommand(
    Guid Id, 
    string Title,
    string Description,
    int status,
    int Priority,
    DateTime DueDate) : IRequest<ErrorOr<Updated>>;