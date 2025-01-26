using CleanArch.Domain.ToDos;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Tasks.Commands.CreateTask;

public record CreateToDoCommand(
    string Title,
    string Description,
    DateTime DueDate,
    int Priority,
    Guid UserId) : IRequest<ErrorOr<ToDo>>;