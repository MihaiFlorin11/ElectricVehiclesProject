namespace Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }

        public int VehicleTypeId { get; set; }
        
        public ICollection<VehicleType> VehicleTypes { get; set; }
        
        public ICollection<Rental> Rentals { get; set; }
    }
}