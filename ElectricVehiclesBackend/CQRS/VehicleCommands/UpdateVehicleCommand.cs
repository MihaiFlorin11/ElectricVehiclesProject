using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class UpdateVehicleCommand : IRequest<ViewVehicleDto>
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string RegisterDate { get; set; }
    }
}
