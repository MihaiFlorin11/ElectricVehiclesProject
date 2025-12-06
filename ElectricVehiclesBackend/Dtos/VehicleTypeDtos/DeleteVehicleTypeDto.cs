using Utils.Enums;

namespace Dtos.VehicleTypeDtos
{
    public class DeleteVehicleTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
