using Utils.Enums;

namespace Dtos.VehicleTypeDtos
{
    public class CreateVehicleTypeDto
    {
        public string Description { get; set; }
        public VehicleTypeRegistered Type { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
