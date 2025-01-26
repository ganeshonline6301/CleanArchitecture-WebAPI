using CleanArch.Application.Common.Interfaces;
using CleanArch.Domain.ToDos;
using MediatR;
using ErrorOr;

namespace CleanArch.Application.ToDos.Queries.GetToDo;

public class GetToDoQueryHandler(IToDoRepository toDoRepository) : IRequestHandler<GetToDoQuery, ErrorOr<ToDo>>
{
    public async Task<ErrorOr<ToDo>> Handle(GetToDoQuery query, CancellationToken cancellationToken)
    {
        var toDo = await toDoRepository.GetTaskById(query.Id);

        return toDo is null
            ? Error.NotFound(description: "Task not found")
            : toDo; 
    }
}