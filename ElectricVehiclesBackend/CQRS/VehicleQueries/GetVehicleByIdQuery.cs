using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleQueries
{
    public class GetVehicleByIdQuery : IRequest<ViewVehicleDto>
    {
        public int Id { get; set; }
    }
}
