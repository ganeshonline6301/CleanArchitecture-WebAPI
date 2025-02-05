using CleanArch.Api.Common.Contracts.Users;
using CleanArch.Application.Users.Commands.CreateUser;
using CleanArch.Application.Users.Queries;
using CleanArch.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ISender mediator) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var command = new CreateUserCommand(
                Name: request.Name,
                Email: request.Email);
            
            var createuserResult = await mediator.Send(command);
            
            return createuserResult.Match(
                user => CreatedAtAction(
                    nameof(GetUser),
                    new { userId = user.Id},
                    new UserResponse(
                        user.Name,
                        user.Email,
                        user.Id)),
                error => Problem());
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var query = new GetUserQuery(userId);
            
            var getUserResult = await mediator.Send(query);
            
            return getUserResult.Match(
                user => Ok(new UserResponse(
                    user.Name,
                    user.Email,
                    user.Id)),
                error => Problem());
        }
    }
}
