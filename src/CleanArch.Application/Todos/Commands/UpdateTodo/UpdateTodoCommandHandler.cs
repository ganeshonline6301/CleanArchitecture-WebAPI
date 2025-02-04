using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Todos;
using CleanArch.Domain.Todos.Enums;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandHandler(IRepository<Todo> toDoRepository) : IRequestHandler<UpdateTodoCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
    {
        var result = await toDoRepository.GetByIdAsync(command.Id);

        if (result is null)
        {
            return Error.NotFound(description:"Task not found");
        }

        var todo = new Todo(
            id: command.Id,
            title: command.Title,
            description: command.Description,
            priority: (TodoPriority)command.Priority,
            status: (TodoStatus)command.status,
            dueDate: command.DueDate,
            userId: result.UserId
        );
        
       var updateToDoResult = result.UpdateDetails(
           newTitle: command.Title, 
           newDescription: command.Description,
           newStatus: (TodoStatus?)command.status,
           newPriority: (TodoPriority?)command.Priority,
           newDueDate: command.DueDate);

       if (updateToDoResult.IsError)
       {
           return updateToDoResult.Errors;
       }

       await toDoRepository.UpdateAsync(todo);
       
       return Result.Updated;
    }
}