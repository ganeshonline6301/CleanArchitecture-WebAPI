using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.Todos;
using MediatR;
using ErrorOr;

namespace CleanArch.Application.Todos.Queries.GetTodo;

public class GetTodoQueryHandler(IRepository<Todo> toDoRepository) : IRequestHandler<GetTodoQuery, ErrorOr<Todo>>
{
    public async Task<ErrorOr<Todo>> Handle(GetTodoQuery query, CancellationToken cancellationToken)
    {
        var toDo = await toDoRepository.GetByIdAsync(query.Id);

        return toDo is null
            ? Error.NotFound(description: "Task not found")
            : toDo; 
    }
}