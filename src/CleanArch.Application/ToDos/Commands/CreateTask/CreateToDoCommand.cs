using CleanArch.Domain.ToDos;
using CleanArch.Domain.ToDos.Enums;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.ToDos.Commands.CreateTask;

public record CreateToDoCommand(
    string Title,
    string Description,
    DateTime DueDate,
    ToDoPriority Priority,
    Guid UserId) : IRequest<ErrorOr<ToDo>>;