namespace Dtos.RentalDtos
{
    public class DeleteRentalDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public int InvoiceId { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
    }
}
