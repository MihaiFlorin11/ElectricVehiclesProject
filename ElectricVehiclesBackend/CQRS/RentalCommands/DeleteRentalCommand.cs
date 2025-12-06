using Dtos.RentalDtos;
using MediatR;

namespace CQRS.RentalCommands
{
    public class DeleteRentalCommand : IRequest<DeleteRentalDto>
    {
        public int Id { get; set; }
    }  
}
