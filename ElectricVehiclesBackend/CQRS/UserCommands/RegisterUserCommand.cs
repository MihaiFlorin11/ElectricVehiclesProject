using Dtos.UserDtos;
using MediatR;
using Utils.Enums;

namespace CQRS.UserCommands
{
    public class RegisterUserCommand : IRequest<RegisterUserDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }     
        public UserRole Role { get; set; }
    }
}
