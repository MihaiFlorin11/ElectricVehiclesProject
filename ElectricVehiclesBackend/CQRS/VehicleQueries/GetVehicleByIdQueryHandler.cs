using AutoMapper;
using Data.Repositories.VehicleRepositories;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleQueries
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, ViewVehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ViewVehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(request.Id);

            var vehicleTypeToString = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(vehicle.VehicleTypeId);

            var vehicleTypeToAssign = await _vehicleTypeRepository.GetVehicleTypeByTypeAsync(vehicleTypeToString.Type);

            var vehicleMapped = _mapper.Map<ViewVehicleDto>(vehicle);

            vehicleMapped.VehicleType = vehicleTypeToAssign.Type;

            return vehicleMapped;
        }
    }
}
