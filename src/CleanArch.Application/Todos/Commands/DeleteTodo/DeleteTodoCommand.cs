using ErrorOr;
using MediatR;

namespace CleanArch.Application.Todos.Commands.DeleteTodo;

public record DeleteTodoCommand(
    Guid Id) : IRequest<ErrorOr<Deleted>>;