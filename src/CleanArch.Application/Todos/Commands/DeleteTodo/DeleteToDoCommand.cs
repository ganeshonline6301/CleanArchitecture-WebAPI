using ErrorOr;
using MediatR;

namespace CleanArch.Application.Todos.Commands.DeleteTodo;

public record DeleteToDoCommand(
    Guid Id) : IRequest<ErrorOr<Deleted>>;