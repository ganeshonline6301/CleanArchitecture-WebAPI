using CleanArch.Api.Common.Contracts.Todos;
using Microsoft.OpenApi.Extensions;

namespace CleanArch.Api.Common.Extensions;

public static class TodoExtensions
{
    internal static TodoPriority ToDto(this Domain.Todos.Enums.TodoPriority todoPriority)
    {
        return todoPriority.Name switch
        {
            nameof(Domain.Todos.Enums.TodoPriority.Critical) => TodoPriority.Critical,
            nameof(Domain.Todos.Enums.TodoPriority.High) => TodoPriority.High,
            nameof(Domain.Todos.Enums.TodoPriority.Medium) => TodoPriority.Medium,
            nameof(Domain.Todos.Enums.TodoPriority.Low) => TodoPriority.Low,
            _ => throw new InvalidOperationException(),
        };
    }

    internal static Domain.Todos.Enums.TodoPriority ToDomain(this TodoPriority todoPriority)
    {
        return todoPriority.GetDisplayName() switch
        {
            nameof(TodoPriority.Critical) => Domain.Todos.Enums.TodoPriority.Critical,
            nameof(TodoPriority.High) => Domain.Todos.Enums.TodoPriority.High,
            nameof(TodoPriority.Medium) => Domain.Todos.Enums.TodoPriority.Medium,
            nameof(TodoPriority.Low) => Domain.Todos.Enums.TodoPriority.Low,
            _ => throw new InvalidOperationException(),
        };
    }
    
    internal static TodoStatus ToDto(Domain.Todos.Enums.TodoStatus todoStatus)
    {
        return todoStatus.Name switch
        {
            nameof(Domain.Todos.Enums.TodoStatus.Completed) => TodoStatus.Completed,
            nameof(Domain.Todos.Enums.TodoStatus.InProgress) => TodoStatus.InProgress,
            nameof(Domain.Todos.Enums.TodoStatus.NotStarted) => TodoStatus.NotStarted,
            _ => throw new InvalidOperationException(),
        };
    }

    internal static Domain.Todos.Enums.TodoStatus ToDomain(TodoStatus todoStatus)
    {
        return todoStatus.GetDisplayName() switch
        {
            nameof(TodoStatus.Completed) => Domain.Todos.Enums.TodoStatus.Completed,
            nameof(TodoStatus.InProgress) => Domain.Todos.Enums.TodoStatus.InProgress,
            nameof(TodoStatus.NotStarted) => Domain.Todos.Enums.TodoStatus.NotStarted,
            _ => throw new InvalidOperationException(),
        };
    }
}