using Dtos.VehicleTypeDtos;
using MediatR;

namespace CQRS.VehicleTypeQueries
{
    public class GetVehicleTypeByIdQuery : IRequest<ViewVehicleTypeDto>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}