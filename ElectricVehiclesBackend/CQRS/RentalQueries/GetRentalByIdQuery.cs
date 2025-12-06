using Dtos.RentalDtos;
using MediatR;

namespace CQRS.RentalQueries
{
    public class GetRentalByIdQuery : IRequest<ViewRentalIdsDto>
    {
        public int Id { get; set; }
    }
}
