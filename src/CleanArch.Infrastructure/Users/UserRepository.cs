using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Users;

namespace CleanArch.Infrastructure.Users;

internal class UserRepository : IUserRepository
{
    public Task<User> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}