using AutoMapper;
using Data.Repositories.UserRepositories;
using Dtos.UserDtos;
using Entities;
using MediatR;

namespace CQRS.UserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userUnmapped = _mapper.Map<User>(request);

            var user = await _userRepository.AddUser(userUnmapped);

            var userMapped = _mapper.Map<CreateUserDto>(user);

            return userMapped;
        }
    }
}
