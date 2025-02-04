using CleanArch.Application.Common.Interfaces;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Todos.Commands.UpdateTodo;

public class CompleteTodoCommandHandler(ITodoRepository todoRepository) : IRequestHandler<CompleteTodoCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(CompleteTodoCommand command, CancellationToken cancellationToken)
    {
        var result = await todoRepository.GetByIdAsync(command.Id);

        if (result is null)
        {
            return Error.NotFound(description: "Task not found");    
        }

        var completeToDoResult = result.CompleteTask();
        if (completeToDoResult.IsError)
        {
            return completeToDoResult.Errors;
        }

        await todoRepository.CompleteTaskAsync(command.Id);
        
        return Result.Updated;
    }
}