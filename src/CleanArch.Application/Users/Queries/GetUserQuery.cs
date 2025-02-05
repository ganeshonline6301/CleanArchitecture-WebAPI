using CleanArch.Domain.Users;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Users.Queries;

public record GetUserQuery(Guid UserId) : IRequest<ErrorOr<User>>;