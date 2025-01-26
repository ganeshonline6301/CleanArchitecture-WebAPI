using ErrorOr;

namespace CleanArch.Domain.Tasks;

public static class TaskErrors
{
    public static readonly Error TaskAlreadyStarted = Error.Validation(
        code: "Task.TaskAlreadyInProgress",
        description: "The Task is already in progress and cannot be started again."
    );

    public static readonly Error TaskAlreadyCompleted = Error.Validation(
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

    public static readonly Error SamePriority = Error.Validation(
        code: "Task.SamePriority",
        description: "The new priority must be different from the current priority."
    );
}