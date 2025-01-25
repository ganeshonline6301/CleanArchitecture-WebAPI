using CleanArch.Domain.Common;

namespace CleanArch.Domain.Tasks;

public class Task : Entity
{
    public string Title { get; }
    public string Description { get; }
    public DateTime DueDate { get; }
    public Guid UserId { get; }

    public Task(string title, string description, DateTime dueDate, Guid userId, Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Title = title;
        Description = description;
        DueDate = dueDate; 
        UserId = userId;
    }

    private Task()
    {
        
    }
}