using AutoMapper;
using Data.Repositories.UserRepositories;
using Dtos.UserDtos;
using Entities;
using MediatR;

namespace CQRS.UserCommands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RegisterUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerUserUnmapped = _mapper.Map<User>(request);

            registerUserUnmapped.Role = "User";

            var registerUser = await _userRepository.RegisterUserAsync(registerUserUnmapped);

            var registerUserMapped = _mapper.Map<RegisterUserDto>(registerUser);     

            return registerUserMapped;
        }
    }
}
