using CleanArch.Domain.Todos;
using CleanArch.Domain.Todos.Enums;
using TestCommon.TestConstants;

namespace TestCommon.Todos;

public static class TodoFactory
{
    public static Todo CreateTodo(
        TodoPriority? priority = null,
        TodoStatus? status = null,
        Guid? userId = null,
        Guid? id = null)
    {
        return new Todo(
            title: Constants.Todos.Title,
            description: Constants.Todos.Description,
            dueDate: Constants.Todos.DueDate,
            priority: priority ?? Constants.Todos.DefaultPriority,
            status: status ?? Constants.Todos.DefaultStatus,
            userId: userId ?? Constants.Todos.UserId,
            id: id ?? Constants.Todos.Id);
    }
}