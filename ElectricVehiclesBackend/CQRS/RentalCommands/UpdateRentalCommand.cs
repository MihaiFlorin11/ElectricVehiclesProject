using Dtos.RentalDtos;
using MediatR;

namespace CQRS.RentalCommands
{
    public class UpdateRentalCommand : IRequest<UpdateRentalDto>
    {
        public int Id { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
    }
}
