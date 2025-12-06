using Dtos.UserDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.UserCommands
{
    public class DeleteUserCommand : IRequest<DeleteUserDto>
    {
        public int Id { get; set; }
    }
}
