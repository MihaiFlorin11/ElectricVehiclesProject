using Dtos.VehicleTypeDtos;
using MediatR;

namespace CQRS.VehicleTypeQueries
{
    public class GetVehicleTypesQuery : IRequest<IEnumerable<ViewVehicleTypeDto>>
    {
        
    }
}
