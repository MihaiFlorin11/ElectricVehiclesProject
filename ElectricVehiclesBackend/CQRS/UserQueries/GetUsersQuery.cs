using Dtos.UserDtos;
using MediatR;

namespace CQRS.UserQueries
{
    public class GetUsersQuery : IRequest<IEnumerable<ViewUserDto>>
    {
        
    }
}
