using AutoMapper;
using Data.Repositories.UserRepositories;
using Dtos.UserDtos;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.UserCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DeleteUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.DeleteUser(request.Id);

            var userMapped = _mapper.Map<DeleteUserDto>(user);

            return userMapped;


        }
    }
}
