using ErrorOr;
using MediatR;

namespace CleanArch.Application.ToDos.Commands.DeleteTask;

public record DeleteToDoCommand(
    Guid Id) : IRequest<ErrorOr<Deleted>>;