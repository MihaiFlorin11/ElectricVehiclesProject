using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleQueries
{
    public class GetVehiclesQuery : IRequest<IEnumerable<ViewVehicleDto>>
    {

    }
}
