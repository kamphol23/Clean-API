using Application.Commands.Users.RegisterNewUser;
using Application.Dtos;
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
    }
}
