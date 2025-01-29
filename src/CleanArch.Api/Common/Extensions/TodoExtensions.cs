using CleanArch.Api.Common.Contracts.Todos;
using Microsoft.OpenApi.Extensions;
using DomainTodoPriority = CleanArch.Domain.ToDos.Enums.ToDoPriority;
using DomainTodoStatus = CleanArch.Domain.ToDos.Enums.ToDoStatus;

namespace CleanArch.Api.Common.Extensions;

public static class TodoExtensions
{
    internal static TodoPriority ToDto(this DomainTodoPriority toDoPriority)
    {
        return toDoPriority.Name switch
        {
            nameof(DomainTodoPriority.Critical) => TodoPriority.Critical,
            nameof(DomainTodoPriority.High) => TodoPriority.High,
            nameof(DomainTodoPriority.Medium) => TodoPriority.Medium,
            nameof(DomainTodoPriority.Low) => TodoPriority.Low,
            _ => throw new InvalidOperationException(),
        };
    }

    internal static DomainTodoPriority ToDomain(this TodoPriority todoPriority)
    {
        return todoPriority.GetDisplayName() switch
        {
            nameof(TodoPriority.Critical) => DomainTodoPriority.Critical,
            nameof(TodoPriority.High) => DomainTodoPriority.High,
            nameof(TodoPriority.Medium) => DomainTodoPriority.Medium,
            nameof(TodoPriority.Low) => DomainTodoPriority.Low,
            _ => throw new InvalidOperationException(),
        };
    }
    
    internal static TodoStatus ToDto(DomainTodoStatus toDoStatus)
    {
        return toDoStatus.Name switch
        {
            nameof(DomainTodoStatus.Completed) => TodoStatus.Completed,
            nameof(DomainTodoStatus.InProgress) => TodoStatus.InProgress,
            nameof(DomainTodoStatus.NotStarted) => TodoStatus.NotStarted,
            _ => throw new InvalidOperationException(),
        };
    }

    internal static DomainTodoStatus ToDomain(TodoStatus todoStatus)
    {
        return todoStatus.GetDisplayName() switch
        {
            nameof(TodoStatus.Completed) => DomainTodoStatus.Completed,
            nameof(TodoStatus.InProgress) => DomainTodoStatus.InProgress,
            nameof(TodoStatus.NotStarted) => DomainTodoStatus.NotStarted,
            _ => throw new InvalidOperationException(),
        };
    }
}