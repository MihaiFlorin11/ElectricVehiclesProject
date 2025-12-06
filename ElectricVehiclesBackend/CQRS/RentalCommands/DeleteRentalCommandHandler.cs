using AutoMapper;
using Data.Repositories.RentalRepositories;
using Dtos.RentalDtos;
using Entities;
using MediatR;

namespace CQRS.RentalCommands
{
    public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, DeleteRentalDto>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;
        public DeleteRentalCommandHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<DeleteRentalDto> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.DeleteRental(request.Id);

            var rentalMapped = _mapper.Map<DeleteRentalDto>(rental);

            return rentalMapped;
        }
    }
}
