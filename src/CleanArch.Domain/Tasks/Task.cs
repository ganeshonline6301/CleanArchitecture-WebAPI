using CleanArch.Domain.Common;
using CleanArch.Domain.Tasks.Enums;
using ErrorOr;
using TaskStatus = CleanArch.Domain.Tasks.Enums.TaskStatus;

namespace CleanArch.Domain.Tasks;

public class Task : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TaskPriority Priority { get; private set; }
    public TaskStatus Status { get; private set; }
    public DateTime DueDate { get; private set; }
    public Guid UserId { get; private set; }

    public Task(string title, string description, TaskPriority priority, DateTime dueDate, Guid userId, Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Title = title;
        Description = description;
        Priority = priority;
        Status = TaskStatus.NotStarted;
        DueDate = dueDate; 
        UserId = userId;
    }

    private Task()
    {
        
    }

    public ErrorOr<Success> StartTask()
    {
        if (Status != TaskStatus.NotStarted)
        {
            return TaskErrors.TaskAlreadyStarted;
        }
        Status = TaskStatus.InProgress;
        return Result.Success;
    }

    public ErrorOr<Success> CompleteTask()
    {
        if (Status == TaskStatus.Completed)
        {
            return TaskErrors.TaskAlreadyCompleted;
        }
        if (Status != TaskStatus.InProgress)
        {
            return TaskErrors.TaskNotInProgress;
        }
        Status = TaskStatus.Completed;
        return Result.Success;
    }
    
    public ErrorOr<Success> ReopenTask()
    {
        if (Status != TaskStatus.Completed)
        {
            return TaskErrors.TaskNotCompleted;
        }
        Status = TaskStatus.InProgress;
        return Result.Success;
    }
    
    public ErrorOr<Success> ExtendDueDate(DateTime newDueDate)
    {
        if (newDueDate <= DueDate)
        {
            return TaskErrors.InvalidDueDate;
        }
        DueDate = newDueDate;
        return Result.Success;
    }

    public ErrorOr<Success> UpdatePriority(TaskPriority newPriority)
    {
        if (Priority == newPriority)
        {
            return TaskErrors.SamePriority;
        }
        Priority = newPriority;
        return Result.Success;
    }
}