using AutoMapper;
using Data.Repositories.UserRepositories;
using Dtos.UserDtos;
using Entities;
using MediatR;

namespace CQRS.UserCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userUnmapped = _mapper.Map<User>(request);

            var user = await _userRepository.UpdateUser(userUnmapped);

            var userMapped = _mapper.Map<UpdateUserDto>(user);

            return userMapped;
        }
    }
}
