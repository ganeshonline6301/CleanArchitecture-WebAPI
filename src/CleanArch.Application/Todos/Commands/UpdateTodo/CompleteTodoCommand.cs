using ErrorOr;
using MediatR;

namespace CleanArch.Application.Todos.Commands.UpdateTodo;

public record CompleteTodoCommand(
    Guid Id,
    int status) : IRequest<ErrorOr<Updated>>;