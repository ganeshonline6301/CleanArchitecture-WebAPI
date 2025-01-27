using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.User;
using MediatR;
using ErrorOr;

namespace CleanArch.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User(
            name: command.Name,
            email: command.Email
        );

        await userRepository.AddUsersync(user);

        return user;
    }
}