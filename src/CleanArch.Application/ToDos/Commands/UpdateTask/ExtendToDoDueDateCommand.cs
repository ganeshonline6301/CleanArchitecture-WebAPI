using ErrorOr;
using MediatR;

namespace CleanArch.Application.ToDos.Commands.UpdateTask;

public record ExtendToDoDueDateCommand(
    Guid Id,
    DateTime DueDate): IRequest<ErrorOr<Updated>>;