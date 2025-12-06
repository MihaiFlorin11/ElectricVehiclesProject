using AutoMapper;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.VehicleTypeDtos;
using MediatR;

namespace CQRS.VehicleTypeQueries
{
    public class GetVehicleTypesQueryHandler : IRequestHandler<GetVehicleTypesQuery, IEnumerable<ViewVehicleTypeDto>>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public GetVehicleTypesQueryHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ViewVehicleTypeDto>> Handle(GetVehicleTypesQuery request, CancellationToken cancellationToken)
        {
            var vehicleTypes = await _vehicleTypeRepository.GetVehicleTypesAsync();

            var vehicleTypesMapped = _mapper.Map<IEnumerable<ViewVehicleTypeDto>>(vehicleTypes);

            return vehicleTypesMapped;
        }
    }
}
