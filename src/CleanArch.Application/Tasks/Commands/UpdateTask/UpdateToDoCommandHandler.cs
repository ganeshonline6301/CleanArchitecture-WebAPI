using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.ToDos;
using CleanArch.Domain.ToDos.Enums;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Tasks.Commands.UpdateTask;

public class UpdateToDoCommandHandler(IToDoRepository toDoRepository) : IRequestHandler<UpdateToDoCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateToDoCommand command, CancellationToken cancellationToken)
    {
        var result = await toDoRepository.GetTaskById(command.Id);

        if (result is null)
        {
            return Error.NotFound(description:"Task not found");
        }

        var todo = new ToDo(
            id: command.Id,
            title: command.Title,
            description: command.Description,
            priority: (ToDoPriority)command.Priority,
            status: (ToDoStatus)command.status,
            dueDate: command.DueDate,
            userId: result.UserId
        );
        
       var updateToDoResult = result.UpdateDetails(
           newTitle: command.Title, 
           newDescription: command.Description,
           newStatus: (ToDoStatus?)command.status,
           newPriority: (ToDoPriority?)command.Priority,
           newDueDate: command.DueDate);

       if (updateToDoResult.IsError)
       {
           return updateToDoResult.Errors;
       }

       await toDoRepository.UpdateTaskAsync(todo);
       
       return Result.Updated;
    }
}