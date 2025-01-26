using CleanArch.Domain.ToDos;

namespace CleanArch.Application.Common.Interfaces;

public interface IToDoRepository
{
    Task AddTaskAsync(ToDo toDo);
    Task UpdateTaskAsync(ToDo toDo);
    Task DeleteTaskAsync(Guid id);
    Task<ToDo> GetTaskById(Guid id);
}