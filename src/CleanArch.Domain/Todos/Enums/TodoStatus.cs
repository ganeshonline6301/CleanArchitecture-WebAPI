using Ardalis.SmartEnum;

namespace CleanArch.Domain.Todos.Enums;

public class TodoStatus : SmartEnum<TodoStatus>
{
    public TodoStatus(string name, int value) : base(name, value)
    {
    }
    
    public static readonly TodoStatus Completed = new(nameof(Completed), 1);
    public static readonly TodoStatus InProgress = new(nameof(InProgress), 2);
    public static readonly TodoStatus NotStarted = new(nameof(NotStarted), 3);
    
}