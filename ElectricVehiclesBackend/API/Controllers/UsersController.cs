using Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MediatR;
using CQRS.UserQueries;
using CQRS.UserCommands;
using Microsoft.AspNetCore.Cors;
using Entities;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ViewUserDto>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());

            return Ok(users);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ViewUserDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery()
            {
                Id = id,
            });
            

            return Ok(user);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateUserDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserDto createUserDto)
        {
            var user = await _mediator.Send(new CreateUserCommand() 
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                Role = createUserDto.Role,
            });

            return Ok(user);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateUserDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto registerUserDto)
        {
            var user = await _mediator.Send(new RegisterUserCommand()
            {
                Username = registerUserDto.Username,
                Email = registerUserDto.Email,
                Password = registerUserDto.Password,
                Role = registerUserDto.Role,
            });

            return Ok(user);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CreateUserDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDto loginUserDto)
        {
            var user = await _mediator.Send(new LoginUserCommand()
            {
                Email = loginUserDto.Email,
                Password = loginUserDto.Password,
            });

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UpdateUserDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            if (id == 0 || id != updateUserDto.Id)
            {
                return BadRequest();
            }

            var user = await _mediator.Send(new UpdateUserCommand()
            {
                Id = updateUserDto.Id,
                Username = updateUserDto.Username,
                Email = updateUserDto.Email,
                Password = updateUserDto.Password,
                Role = updateUserDto.Role.ToString(),
            });

            return Ok(user);
        }


        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(DeleteUserDto), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _mediator.Send(new DeleteUserCommand()
            {
                Id = id,
            });

            return Ok(user);
        }
    }
}
