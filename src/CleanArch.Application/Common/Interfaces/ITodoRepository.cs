using CleanArch.Domain.Todos;

namespace CleanArch.Application.Common.Interfaces;

public interface ITodoRepository : IRepository<Todo>
{
    Task CompleteTaskAsync(Guid id);
}