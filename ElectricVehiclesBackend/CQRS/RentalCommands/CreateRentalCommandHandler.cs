using AutoMapper;
using Data.Repositories.RentalRepositories;
using Dtos.RentalDtos;
using Entities;
using MediatR;

namespace CQRS.RentalCommands
{
    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, CreateRentalDto>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public CreateRentalCommandHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<CreateRentalDto> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            var rentalUnmapped = _mapper.Map<Rental>(request);

            var rental = await _rentalRepository.AddRental(rentalUnmapped);

            var rentalMapped = _mapper.Map<CreateRentalDto>(rental);

            return rentalMapped;
        }
    }
}
