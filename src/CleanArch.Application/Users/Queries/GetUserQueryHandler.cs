using CleanArch.Domain.Users;
using MediatR;
using ErrorOr;

namespace CleanArch.Application.Users.Queries;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ErrorOr<User>>
{
    public Task<ErrorOr<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}