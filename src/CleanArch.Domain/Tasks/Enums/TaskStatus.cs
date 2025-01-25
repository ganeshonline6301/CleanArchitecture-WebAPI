using Ardalis.SmartEnum;

namespace CleanArch.Domain.Tasks.Enums;

public class TaskStatus : SmartEnum<TaskStatus>
{
    public TaskStatus(string name, int value) : base(name, value)
    {
    }
    
    public static readonly TaskStatus Completed = new(nameof(Completed), 1);
    public static readonly TaskStatus InProgress = new(nameof(InProgress), 2);
    public static readonly TaskStatus NotStarted = new(nameof(NotStarted), 3);
    
}