namespace Entities
{
    public class Rental
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string StartDateTime { get; set; }

        public string EndDateTime { get; set; }
        
    }
}
