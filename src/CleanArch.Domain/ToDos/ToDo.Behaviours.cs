using CleanArch.Domain.ToDos.Enums;
using ErrorOr;

namespace CleanArch.Domain.ToDos;

public partial class ToDo
{
    public ErrorOr<Success> StartTask()
    {
        if (Status != ToDoStatus.NotStarted)
        {
            return ToDoErrors.TaskAlreadyStarted;
        }
        Status = ToDoStatus.InProgress;
        return Result.Success;
    }

    public ErrorOr<Success> CompleteTask()
    {
        if (Status == ToDoStatus.Completed)
        {
            return ToDoErrors.TaskAlreadyCompleted;
        }
        if (Status != ToDoStatus.InProgress)
        {
            return ToDoErrors.TaskNotInProgress;
        }
        Status = ToDoStatus.Completed;
        return Result.Success;
    }
    
    public ErrorOr<Success> ReopenTask()
    {
        if (Status != ToDoStatus.Completed)
        {
            return ToDoErrors.TaskNotCompleted;
        }
        Status = ToDoStatus.InProgress;
        return Result.Success;
    }
    
    public ErrorOr<Success> ExtendDueDate(DateTime newDueDate)
    {
        if (newDueDate <= DueDate)
        {
            return ToDoErrors.InvalidDueDate;
        }
        DueDate = newDueDate;
        return Result.Success;
    }

    public ErrorOr<Success> UpdateTitle(string newTitle)
    {
        if (string.IsNullOrEmpty(newTitle))
        {
            return ToDoErrors.InvalidTitle;
        }

        if (Title == newTitle)
        {
            return ToDoErrors.SameTitle;
        }
        Title = newTitle;
        return Result.Success;
    }

    public ErrorOr<Success> UpdateDescription(string newDescription)
    {
        if (string.IsNullOrEmpty(newDescription))
        {
            return ToDoErrors.InvalidDescription;
        }

        if (Description == newDescription)
        {
            return ToDoErrors.SameDescription;
        }
        Description = newDescription;
        return Result.Success;
    }

    public ErrorOr<Success> UpdatePriority(ToDoPriority newPriority)
    {
        if (Priority == newPriority)
        {
            return ToDoErrors.SamePriority;
        }
        Priority = newPriority;
        return Result.Success;
    }
    
    public ErrorOr<Success> UpdateDetails(string? newTitle = null, string? newDescription = null,ToDoStatus newStatus = null, ToDoPriority newPriority = null, DateTime? newDueDate = null)
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