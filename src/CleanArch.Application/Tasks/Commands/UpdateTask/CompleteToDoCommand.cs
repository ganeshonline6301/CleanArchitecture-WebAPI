using ErrorOr;
using MediatR;

namespace CleanArch.Application.Tasks.Commands.UpdateTask;

public record CompleteToDoCommand(
    Guid Id,
    int status) : IRequest<ErrorOr<Updated>>;