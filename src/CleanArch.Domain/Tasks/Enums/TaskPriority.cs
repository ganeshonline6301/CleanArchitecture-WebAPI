using Ardalis.SmartEnum;

namespace CleanArch.Domain.Tasks.Enums;

public class TaskPriority : SmartEnum<TaskPriority>
{
    public TaskPriority(string name, int value) : base(name, value)
    {
    }
    
    public static readonly TaskPriority Critical = new(nameof(Critical), 1);
    public static readonly TaskPriority High = new(nameof(High), 2);
    public static readonly TaskPriority Medium = new(nameof(Medium), 3);
    public static readonly TaskPriority Low = new(nameof(Low), 4);
}