using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class CreateVehicleCommand : IRequest<ViewVehicleDto>
    {
        public string VehicleType { get; set; }
        public string RegisterDate { get; set; }
    }
}
