using ErrorOr;
using MediatR;

namespace CleanArch.Application.Tasks.Commands.UpdateTask;

public record UpdateToDoCommand(
    Guid Id, 
    string Title,
    string Description,
    int status,
    int Priority,
    DateTime DueDate) : IRequest<ErrorOr<Updated>>;