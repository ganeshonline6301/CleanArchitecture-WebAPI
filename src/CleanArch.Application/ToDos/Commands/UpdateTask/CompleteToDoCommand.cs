using ErrorOr;
using MediatR;

namespace CleanArch.Application.ToDos.Commands.UpdateTask;

public record CompleteToDoCommand(
    Guid Id,
    int status) : IRequest<ErrorOr<Updated>>;