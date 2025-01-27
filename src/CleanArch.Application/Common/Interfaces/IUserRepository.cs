using CleanArch.Domain.User;

namespace CleanArch.Application.Common.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task AddUsersync(User toDo);
    Task UpdateUserAsync(User toDo);
    Task DeleteUserAsync(Guid id);
    Task<User> GetUserByIdAsync(Guid id);
}