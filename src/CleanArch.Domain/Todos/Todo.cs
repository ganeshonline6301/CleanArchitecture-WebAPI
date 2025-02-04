using CleanArch.Domain.Common;
using CleanArch.Domain.Todos.Enums;

namespace CleanArch.Domain.Todos;

public partial class Todo : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TodoPriority Priority { get; private set; }
    public TodoStatus Status { get; private set; }
    public DateTime DueDate { get; private set; }
    public Guid UserId { get; private set; }

    public Todo(string title, string description, TodoPriority priority, TodoStatus status, DateTime dueDate, Guid userId, Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Title = title;
        Description = description;
        Priority = priority;
        Status = status;
        DueDate = dueDate; 
        UserId = userId;
    }

    private Todo()
    {
        
    }
}