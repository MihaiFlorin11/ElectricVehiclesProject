using Dtos.VehicleTypeDtos;
using MediatR;

namespace CQRS.VehicleTypeCommands
{
    public class UpdateVehicleTypeCommand : IRequest<UpdateVehicleTypeDto>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
