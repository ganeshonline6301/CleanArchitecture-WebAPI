using CleanArch.Domain.Todos.Enums;
using ErrorOr;

namespace CleanArch.Domain.Todos;

public partial class Todo
{
    public ErrorOr<Success> StartTask()
    {
        if (Status != TodoStatus.NotStarted)
        {
            return TodoErrors.TaskAlreadyStarted;
        }
        Status = TodoStatus.InProgress;
        return Result.Success;
    }

    public ErrorOr<Success> CompleteTask()
    {
        if (Status == TodoStatus.Completed)
        {
            return TodoErrors.TaskAlreadyCompleted;
        }
        if (Status != TodoStatus.InProgress)
        {
            return TodoErrors.TaskNotInProgress;
        }
        Status = TodoStatus.Completed;
        return Result.Success;
    }
    
    public ErrorOr<Success> ReopenTask()
    {
        if (Status != TodoStatus.Completed)
        {
            return TodoErrors.TaskNotCompleted;
        }
        Status = TodoStatus.InProgress;
        return Result.Success;
    }
    
    public ErrorOr<Success> ExtendDueDate(DateTime newDueDate)
    {
        if (newDueDate <= DueDate)
        {
            return TodoErrors.InvalidDueDate;
        }
        DueDate = newDueDate;
        return Result.Success;
    }

    public ErrorOr<Success> UpdateTitle(string newTitle)
    {
        if (string.IsNullOrEmpty(newTitle))
        {
            return TodoErrors.InvalidTitle;
        }

        if (Title == newTitle)
        {
            return TodoErrors.SameTitle;
        }
        Title = newTitle;
        return Result.Success;
    }

    public ErrorOr<Success> UpdateDescription(string newDescription)
    {
        if (string.IsNullOrEmpty(newDescription))
        {
            return TodoErrors.InvalidDescription;
        }

        if (Description == newDescription)
        {
            return TodoErrors.SameDescription;
        }
        Description = newDescription;
        return Result.Success;
    }

    public ErrorOr<Success> UpdatePriority(TodoPriority newPriority)
    {
        if (Priority == newPriority)
        {
            return TodoErrors.SamePriority;
        }
        Priority = newPriority;
        return Result.Success;
    }
    
    public ErrorOr<Success> UpdateDetails(string? newTitle = null, string? newDescription = null,TodoStatus newStatus = null, TodoPriority newPriority = null, DateTime? newDueDate = null)
    {
        var errors = new List<Error>();
        
        if (!string.IsNullOrWhiteSpace(newTitle) && Title != newTitle)
        {
            var result = UpdateTitle(newTitle);
            if (result.IsError)
            {
                errors.Add(result.FirstError);
            }
        }

        if (!string.IsNullOrWhiteSpace(newDescription) && Description != newDescription)
        {
            var result = UpdateDescription(newDescription);
            if (result.IsError)
            {
                errors.Add(result.FirstError);
            }
        }

        if (Priority != newPriority.Value)
        {
            var result = UpdatePriority(newPriority);
            if (result.IsError)
            {
                errors.Add(result.FirstError);
            }
        }

        if (newDueDate.HasValue && newDueDate > DueDate)
        {
            var result = ExtendDueDate(newDueDate.Value);
            if (result.IsError)
            {
                errors.Add(result.FirstError);
            }
        }
        
        if (errors.Any())
        {
            return errors;
        }

        return Result.Success;
    }
}