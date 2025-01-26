using Ardalis.SmartEnum;

namespace CleanArch.Domain.ToDos.Enums;

public class ToDoStatus : SmartEnum<ToDoStatus>
{
    public ToDoStatus(string name, int value) : base(name, value)
    {
    }
    
    public static readonly ToDoStatus Completed = new(nameof(Completed), 1);
    public static readonly ToDoStatus InProgress = new(nameof(InProgress), 2);
    public static readonly ToDoStatus NotStarted = new(nameof(NotStarted), 3);
    
}