using CleanArch.Domain.Users;
using MediatR;
using ErrorOr;

namespace CleanArch.Application.Users.Commands.CreateUser;

public record CreateUserCommand(
    string Name, string Email) : IRequest<ErrorOr<User>>;