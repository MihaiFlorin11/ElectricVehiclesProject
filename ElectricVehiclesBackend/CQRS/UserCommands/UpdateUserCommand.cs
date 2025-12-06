using Dtos.UserDtos;
using MediatR;

namespace CQRS.UserCommands
{
    public class UpdateUserCommand : IRequest<UpdateUserDto>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
