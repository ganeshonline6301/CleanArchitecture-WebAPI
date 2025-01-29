namespace CleanArch.Api.Common.Contracts.Todos;

public record CreateTodoRequest(
    string Title,
    string Description,
    DateTime DueDate,
    TodoPriority Priority);