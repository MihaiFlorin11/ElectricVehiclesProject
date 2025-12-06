using AutoMapper;
using Data.Repositories.RentalRepositories;
using Dtos.RentalDtos;
using MediatR;

namespace CQRS.RentalQueries
{
    public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, ViewRentalIdsDto>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetRentalByIdQueryHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<ViewRentalIdsDto> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            var rental = await _rentalRepository.GetRentalByIdAsync(request.Id);

            var rentalMapped = _mapper.Map<ViewRentalIdsDto>(rental);

            return rentalMapped;
        }
    }
}
