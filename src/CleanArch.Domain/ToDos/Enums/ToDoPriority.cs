using Ardalis.SmartEnum;

namespace CleanArch.Domain.ToDos.Enums;

public class ToDoPriority : SmartEnum<ToDoPriority>
{
    public ToDoPriority(string name, int value) : base(name, value)
    {
    }
    
    public static readonly ToDoPriority Critical = new(nameof(Critical), 1);
    public static readonly ToDoPriority High = new(nameof(High), 2);
    public static readonly ToDoPriority Medium = new(nameof(Medium), 3);
    public static readonly ToDoPriority Low = new(nameof(Low), 4);
}