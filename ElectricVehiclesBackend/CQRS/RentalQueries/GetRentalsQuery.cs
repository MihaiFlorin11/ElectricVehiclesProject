using Dtos.RentalDtos;
using MediatR;

namespace CQRS.RentalQueries
{
    public class GetRentalsQuery : IRequest<IEnumerable<ViewRentalDto>>
    {

    }
}
