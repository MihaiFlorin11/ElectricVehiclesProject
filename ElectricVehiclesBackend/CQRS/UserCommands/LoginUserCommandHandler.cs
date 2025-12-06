using AutoMapper;
using Data.Repositories.UserRepositories;
using Dtos.UserDtos;
using Entities;
using MediatR;

namespace CQRS.UserCommands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginToSendUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<LoginToSendUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var loginUserUnmapped = _mapper.Map<User>(request);

            var loginUser = await _userRepository.LoginUserAsync(loginUserUnmapped);

            var user = await _userRepository.GetUserByEmailAsync(loginUser.Email);

            var loginUserMapped = _mapper.Map<LoginToSendUserDto>(loginUser);

            loginUserMapped.Role = user.Role;

            return loginUserMapped;
        }
    }
}
