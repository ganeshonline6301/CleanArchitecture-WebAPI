using CleanArch.Domain.ToDos;

namespace CleanArch.Application.Common.Interfaces;

public interface IToDoRepository : IRepository<ToDo>
{
    Task CompleteTaskAsync(Guid id);
}