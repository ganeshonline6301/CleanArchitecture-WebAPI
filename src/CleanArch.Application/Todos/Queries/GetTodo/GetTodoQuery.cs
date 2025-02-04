using CleanArch.Domain.Todos;
using MediatR;
using ErrorOr;

namespace CleanArch.Application.Todos.Queries.GetTodo;

public record GetTodoQuery(
    Guid Id) : IRequest<ErrorOr<Todo>>;