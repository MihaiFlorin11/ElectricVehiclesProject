using AutoMapper;
using Data.Repositories.UserRepositories;
using Dtos.UserDtos;
using MediatR;

namespace CQRS.UserQueries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<ViewUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ViewUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersAsync();

            var usersMapped = _mapper.Map<IEnumerable<ViewUserDto>>(users);

            return usersMapped;
        }
    }
}
