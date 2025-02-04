using CleanArch.Domain.ToDos.Enums;

namespace TestCommon.TestConstants;

public static partial class Constants
{
    public static class Todos
    {
        public static readonly Guid Id = Guid.NewGuid();
        public const string Title = "Learn C#";
        public const string Description = "Learn C# Fundamentals from uncle bob!";
        public static readonly ToDoPriority DefaultPriority = ToDoPriority.Medium;
        public static readonly ToDoStatus DefaultStatus = ToDoStatus.NotStarted;
        public static readonly DateTime DueDate = DateTime.Now;
        public static readonly Guid UserId = Guid.NewGuid();
    }
}