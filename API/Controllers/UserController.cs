using Application.Commands.Users.DeleteUser;
using Application.Commands.Users.RegisterUser;
using Application.Commands.Users.UpdateUser;
using Application.Dtos;
using Application.Queries.GettAllUser;
using Application.Queries.UserLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]

    public class UserController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto newUser)
        {
            return Ok(await _mediator.Send(new RegisterUserCommand(newUser)));
        }

        [HttpGet]
        [Route("logIn")]
        public async Task<IActionResult> LogIn([FromBody] UserDto UserLogIn)
        {
            return Ok(await _mediator.Send(new LogInQuerys(UserLogIn)));
        }

        [HttpGet]
        [Route("getAllUser")]
        public async Task<IActionResult> GettAllUser()
        {
            return Ok( await _mediator.Send(new GetAllUserQuery()));
        }

        [HttpPut]
        [Route("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto updatedUser, Guid userId)
        {
            return Ok(await _mediator.Send(new UpdateUserCommand(updatedUser, userId)));
        }

        [HttpDelete]
        [Route("deleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] Guid userId)
        {
            return Ok(await _mediator.Send(new DeleteUserCommand( userId)));
        }
    }
}
