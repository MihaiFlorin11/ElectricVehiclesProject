using AutoMapper;
using Data.Repositories.RentalRepositories;
using Dtos.RentalDtos;
using Entities;
using MediatR;

namespace CQRS.RentalCommands
{
    public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand, UpdateRentalDto>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public UpdateRentalCommandHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<UpdateRentalDto> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
        {
            var rentalUnmapped = _mapper.Map<Rental>(request);

            var rental = await _rentalRepository.UpdateRental(rentalUnmapped);

            var rentalMapped = _mapper.Map<UpdateRentalDto>(rental);

            return rentalMapped;
        }
    }
}
