using CleanArch.Domain.Common;
using CleanArch.Domain.ToDos.Enums;

namespace CleanArch.Domain.ToDos;

public partial class ToDo : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public ToDoPriority Priority { get; private set; }
    public ToDoStatus Status { get; private set; }
    public DateTime DueDate { get; private set; }
    public Guid UserId { get; private set; }

    public ToDo(string title, string description, ToDoPriority priority, ToDoStatus status, DateTime dueDate, Guid userId, Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Title = title;
        Description = description;
        Priority = priority;
        Status = status;
        DueDate = dueDate; 
        UserId = userId;
    }

    private ToDo()
    {
        
    }
}