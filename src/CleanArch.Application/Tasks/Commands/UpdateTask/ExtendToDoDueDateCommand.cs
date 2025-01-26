using ErrorOr;
using MediatR;

namespace CleanArch.Application.Tasks.Commands.UpdateTask;

public record ExtendToDoDueDateCommand(
    Guid Id,
    DateTime DueDate): IRequest<ErrorOr<Updated>>;