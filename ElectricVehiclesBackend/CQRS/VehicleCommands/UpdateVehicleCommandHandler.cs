using AutoMapper;
using Data.Repositories.VehicleRepositories;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.VehicleDtos;
using Entities;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, ViewVehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ViewVehicleDto> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicleTypeIdToAssign = await _vehicleTypeRepository.GetVehicleTypeByTypeAsync(request.VehicleType);

            var vehicleUnmapped = _mapper.Map<Vehicle>(request);

            vehicleUnmapped.VehicleTypeId = vehicleTypeIdToAssign.Id;

            var vehicle = await _vehicleRepository.UpdateVehicle(vehicleUnmapped);

            var vehicleTypeToString = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(vehicle.VehicleTypeId);

            var vehicleMapped = _mapper.Map<ViewVehicleDto>(vehicle);

            vehicleMapped.VehicleType = vehicleTypeToString.Type;

            return vehicleMapped;
        }
    }
}
