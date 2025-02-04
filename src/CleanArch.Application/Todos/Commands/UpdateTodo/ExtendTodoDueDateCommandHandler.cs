using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Todos;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.ToDos.Commands.UpdateTask;

public class ExtendTodoDueDateCommandHandler(IRepository<Todo> toDoRepository) : IRequestHandler<ExtendTodoDueDateCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(ExtendTodoDueDateCommand command, CancellationToken cancellationToken)
    {
        var result = await toDoRepository.GetByIdAsync(command.Id);

        if (result is null)
        {
            return Error.NotFound(description:"Task not found");
        }
        
        var extendDueDateResult = result.ExtendDueDate(command.DueDate);

        if (extendDueDateResult.IsError)
        {
            return extendDueDateResult.Errors;
        }

        var todo = new Todo(
            id: command.Id,
            title: result.Title,
            description: result.Description,
            status: result.Status,
            priority: result.Priority,
            dueDate: command.DueDate,
            userId: result.UserId
            );

        await toDoRepository.UpdateAsync(todo);

        return Result.Updated;
    }
}