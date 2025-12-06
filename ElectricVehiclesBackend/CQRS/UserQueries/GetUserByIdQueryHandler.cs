using AutoMapper;
using Data.Repositories.UserRepositories;
using Dtos.UserDtos;
using MediatR;

namespace CQRS.UserQueries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ViewUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ViewUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);

            var userMapped = _mapper.Map<ViewUserDto>(user);

            return userMapped;

        }
    }
}
