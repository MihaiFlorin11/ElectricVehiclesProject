using AutoMapper;
using Data.Repositories.VehicleRepositories;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleCommands
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, DeleteVehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DeleteVehicleDto> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {

            var vehicle = await _vehicleRepository.DeleteVehicle(request.Id);

            var vehicleTypeToString = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(vehicle.VehicleTypeId);

            var vehicleMapped = _mapper.Map<DeleteVehicleDto>(vehicle);

            vehicleMapped.VehicleType = vehicleTypeToString.Type;

            return vehicleMapped;
        }
    }
}
