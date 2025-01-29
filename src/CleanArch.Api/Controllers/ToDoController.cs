using CleanArch.Api.Common.Contracts.Todos;
using CleanArch.Api.Common.Extensions;
using CleanArch.Application.ToDos.Commands.CreateTask;
using CleanArch.Application.ToDos.Commands.DeleteTask;
using CleanArch.Application.ToDos.Queries.GetToDo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(ISender mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody]CreateTodoRequest request, Guid userId)
        {

            var command = new CreateToDoCommand(
                Title: request.Title,
                Description: request.Description,
                DueDate: request.DueDate,
                Priority: request.Priority.ToDomain(),
                UserId: userId);

            var createTodoResult = await mediator.Send(command);

            return createTodoResult.Match(
                todo => CreatedAtAction(
                    nameof(GetTodo),
                    new { todoId = todo.Id},
                    new TodoResponse(
                        todo.Id,
                        todo.Title,
                        todo.Description,
                        todo.UserId)),
                error => Problem());
            
            return Ok();
        }

        [HttpGet("{todoId:guid}")]
        public async Task<IActionResult> GetTodo(Guid todoId)
        {
            var query = new GetToDoQuery(todoId);

            var getTodoResult = await mediator.Send(query);

            return getTodoResult.Match(
                todo => Ok(new TodoResponse(
                    todo.Id,
                    todo.Title,
                    todo.Description,
                    todo.UserId)),
                error => Problem());
        }

        [HttpDelete("{todoId:guid}")]
        public async Task<IActionResult> DeleteTodo(Guid todoId)
        {
            var command = new DeleteToDoCommand(todoId);

            var deleteTodoResult = await mediator.Send(command);
            
            return deleteTodoResult.Match<IActionResult>(
                _ => NoContent(),
                error => Problem());
        }
    }
}
