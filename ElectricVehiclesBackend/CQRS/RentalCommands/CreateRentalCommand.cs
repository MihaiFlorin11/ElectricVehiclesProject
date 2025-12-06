using Dtos.RentalDtos;
using MediatR;

namespace CQRS.RentalCommands
{
    public class CreateRentalCommand : IRequest<CreateRentalDto>
    {
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public int InvoiceId { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
    }
}
