using Dtos.VehicleTypeDtos;
using MediatR;

namespace CQRS.VehicleTypeCommands
{
    public class CreateVehicleTypeCommand : IRequest<CreateVehicleTypeDto>
    {
        public string Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
