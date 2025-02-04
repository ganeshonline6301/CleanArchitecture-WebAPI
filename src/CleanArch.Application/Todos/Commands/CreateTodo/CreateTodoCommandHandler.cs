using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Todos;
using CleanArch.Domain.Todos.Enums;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Todos.Commands.CreateTodo;

public class CreateTodoCommandHandler(IRepository<Todo> toDoRepository) : IRequestHandler<CreateTodoCommand, ErrorOr<Todo>>
{
    public async Task<ErrorOr<Todo>> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        var task = new Todo(
            title: command.Title,
            description: command.Description,
            status: TodoStatus.NotStarted, 
            priority: TodoPriority.Low,
            dueDate: command.DueDate,
            userId: command.UserId);
        
        await toDoRepository.AddAsync(task);
        return task;
    }
}