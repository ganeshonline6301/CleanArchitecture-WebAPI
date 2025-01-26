using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.ToDos;
using CleanArch.Domain.ToDos.Enums;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.ToDos.Commands.CreateTask;

public class CreateToDoCommandHandler(IToDoRepository toDoRepository) : IRequestHandler<CreateToDoCommand, ErrorOr<ToDo>>
{
    public async Task<ErrorOr<ToDo>> Handle(CreateToDoCommand command, CancellationToken cancellationToken)
    {
        var task = new ToDo(
            title: command.Title,
            description: command.Description,
            status: ToDoStatus.NotStarted, 
            priority: ToDoPriority.Low,
            dueDate: command.DueDate,
            userId: command.UserId);
        
        await toDoRepository.AddTaskAsync(task);
        return task;
    }
}