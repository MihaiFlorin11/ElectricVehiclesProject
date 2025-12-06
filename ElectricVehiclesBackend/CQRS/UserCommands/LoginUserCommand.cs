using Dtos.UserDtos;
using MediatR;

namespace CQRS.UserCommands
{
    public class LoginUserCommand : IRequest<LoginToSendUserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
