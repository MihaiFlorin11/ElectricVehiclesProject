using Dtos.VehicleTypeDtos;
using MediatR;

namespace CQRS.VehicleTypeCommands
{
    public class DeleteVehicleTypeCommand : IRequest<DeleteVehicleTypeDto>
    {
        public int Id { get; set; }
    }
}
