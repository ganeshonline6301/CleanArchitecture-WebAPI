using CleanArch.Domain.ToDos;
using CleanArch.Domain.ToDos.Enums;
using TestCommon.TestConstants;

namespace TestCommon.Todos;

public static class TodoFactory
{
    public static ToDo CreateTodo(
        ToDoPriority? priority = null,
        ToDoStatus? status = null,
        Guid? userId = null,
        Guid? id = null)
    {
        return new ToDo(
            title: Constants.Todos.Title,
            description: Constants.Todos.Description,
            dueDate: Constants.Todos.DueDate,
            priority: priority ?? Constants.Todos.DefaultPriority,
            status: status ?? Constants.Todos.DefaultStatus,
            userId: userId ?? Constants.Todos.UserId,
            id: id ?? Constants.Todos.Id);
    }
}