using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Users;
using MediatR;
using ErrorOr;

namespace CleanArch.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IRepository<User> userRepository) : IRequestHandler<CreateUserCommand, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(
            name: command.Name,
            email: command.Email
        );

        await userRepository.AddAsync(user);

        return user;
    }
}