namespace Dtos.RentalDtos
{
    public class ViewRentalDto
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string Username { get; set; }
        public bool PaidInvoice { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
    }
}
