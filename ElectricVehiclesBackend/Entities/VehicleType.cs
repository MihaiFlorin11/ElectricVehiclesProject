namespace Entities
{
    public class VehicleType
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public decimal PricePerMinute { get; set; }
       
        public Vehicle Vehicle { get; set; }
    }
}
