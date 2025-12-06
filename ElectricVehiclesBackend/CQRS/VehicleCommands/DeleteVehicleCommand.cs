using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class DeleteVehicleCommand : IRequest<DeleteVehicleDto>
    {
        public int Id { get; set; }
    }
}
