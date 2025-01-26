using CleanArch.Domain.ToDos;
using MediatR;
using ErrorOr;

namespace CleanArch.Application.ToDos.Queries.GetToDo;

public record GetToDoQuery(
    Guid Id) : IRequest<ErrorOr<ToDo>>;