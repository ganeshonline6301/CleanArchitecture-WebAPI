using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Todos;

namespace CleanArch.Infrastructure.Todos;

internal class TodoRepository : ITodoRepository
{
    public Task<Todo> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Todo entity)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Todo entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task CompleteTaskAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}