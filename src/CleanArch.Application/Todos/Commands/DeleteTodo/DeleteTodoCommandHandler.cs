using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Todos;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandHandler(IRepository<Todo> toDoRepository) : IRequestHandler<DeleteToDoCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteToDoCommand command, CancellationToken cancellationToken)
    {
        var result = await toDoRepository.GetByIdAsync(command.Id);

        if (result is null)
        {
            return Error.NotFound(description: "Task not found");
        }
        
        await toDoRepository.DeleteAsync(command.Id);

        return Result.Deleted;
    }
}