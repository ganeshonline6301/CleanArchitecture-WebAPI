using ErrorOr;

namespace CleanArch.Domain.ToDos;

public static class ToDoErrors
{
    public static readonly Error InvalidTitle = Error.Validation(
        code: "ToDo.InvalidTitle",
        description: "The title cannot be empty or null."
    );

    public static readonly Error SameTitle = Error.Conflict(
        code: "ToDo.SameTitle",
        description: "The new title is the same as the current one."
    );

    public static readonly Error InvalidDescription = Error.Validation(
        code: "ToDo.InvalidDescription",
        description: "The description cannot be empty or null."
    );

    public static readonly Error SameDescription = Error.Conflict(
        code: "ToDo.SameDescription",
        description: "The new description is the same as the current one."
    );
    
    public static readonly Error TaskAlreadyStarted = Error.Conflict(
        code: "Task.TaskAlreadyInProgress",
        description: "The Task is already in progress and cannot be started again."
    );

    public static readonly Error TaskAlreadyCompleted = Error.Conflict(
        code:"Task.TaskAlreadyCompleted",
        description:"The Task is already been completed and cannot be modified."
    );

    public static readonly Error TaskNotInProgress = Error.Validation(
        code:"Task.TaskNotInProgress",
        description:"The Task must be in progress to perform this action."
    );

    public static readonly Error TaskNotCompleted = Error.Validation(
        code: "Task.TaskNotCompleted",
        description: "Only completed tasks can be reopened."
    );

    public static readonly Error InvalidDueDate = Error.Validation(
        code: "Task.InvalidDueDate",
        description:"The new due date must be later than the current due date."
    );

    public static readonly Error SamePriority = Error.Conflict(
        code: "Task.SamePriority",
        description: "The new priority must be different from the current priority."
    );
}