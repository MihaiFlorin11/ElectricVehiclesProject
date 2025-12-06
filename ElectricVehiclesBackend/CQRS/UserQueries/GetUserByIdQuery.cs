using Dtos.UserDtos;
using MediatR;

namespace CQRS.UserQueries
{
    public class GetUserByIdQuery : IRequest<ViewUserDto>
    {
        public int Id { get; set; }
    }
}
