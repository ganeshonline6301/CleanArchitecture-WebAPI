using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.ToDos;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Tasks.Commands.UpdateTask;

public class ExtendToDoDueDateCommandHandler(IToDoRepository toDoRepository) : IRequestHandler<ExtendToDoDueDateCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(ExtendToDoDueDateCommand command, CancellationToken cancellationToken)
    {
        var result = await toDoRepository.GetTaskById(command.Id);

        if (result is null)
        {
            return Error.NotFound(description:"Task not found");
        }
        
        var extendDueDateResult = result.ExtendDueDate(command.DueDate);

        if (extendDueDateResult.IsError)
        {
            return extendDueDateResult.Errors;
        }

        var todo = new ToDo(
            id: command.Id,
            title: result.Title,
            description: result.Description,
            status: result.Status,
            priority: result.Priority,
            dueDate: command.DueDate,
            userId: result.UserId
            );

        await toDoRepository.UpdateTaskAsync(todo);

        return Result.Updated;
    }
}