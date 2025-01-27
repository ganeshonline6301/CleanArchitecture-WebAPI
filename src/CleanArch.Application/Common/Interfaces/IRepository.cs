namespace CleanArch.Application.Common.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task UpdateAsync(T entity);
    Task AddAsync(T entity);
    Task DeleteAsync(Guid id);
}