using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(ISender mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateTodo()
        {
            return Ok();
        }
    }
}
