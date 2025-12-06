using Utils.Enums;

namespace Dtos.VehicleTypeDtos
{
    public class UpdateVehicleTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public VehicleTypeRegistered Type { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
