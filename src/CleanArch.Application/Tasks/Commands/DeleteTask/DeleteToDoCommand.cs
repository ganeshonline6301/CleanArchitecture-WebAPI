using ErrorOr;
using MediatR;

namespace CleanArch.Application.Tasks.Commands.DeleteTask;

public record DeleteToDoCommand(
    Guid Id) : IRequest<ErrorOr<Deleted>>;