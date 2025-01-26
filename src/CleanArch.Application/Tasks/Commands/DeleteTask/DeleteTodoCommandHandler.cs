using CleanArch.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Tasks.Commands.DeleteTask;

public class DeleteTodoCommandHandler(IToDoRepository toDoRepository) : IRequestHandler<DeleteToDoCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteToDoCommand command, CancellationToken cancellationToken)
    {
        var result = await toDoRepository.GetTaskById(command.Id);

        if (result is null)
        {
            return Error.NotFound(description: "Task not found");
        }
        
        await toDoRepository.DeleteTaskAsync(command.Id);

        return Result.Deleted;
    }
}