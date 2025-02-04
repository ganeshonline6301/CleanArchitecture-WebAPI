using Ardalis.SmartEnum;

namespace CleanArch.Domain.Todos.Enums;

public class TodoPriority : SmartEnum<TodoPriority>
{
    public TodoPriority(string name, int value) : base(name, value)
    {
    }
    
    public static readonly TodoPriority Critical = new(nameof(Critical), 1);
    public static readonly TodoPriority High = new(nameof(High), 2);
    public static readonly TodoPriority Medium = new(nameof(Medium), 3);
    public static readonly TodoPriority Low = new(nameof(Low), 4);
}