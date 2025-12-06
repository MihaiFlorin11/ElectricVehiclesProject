using AutoMapper;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.VehicleTypeDtos;
using Entities;
using MediatR;

namespace CQRS.VehicleTypeCommands
{
    public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommand, UpdateVehicleTypeDto>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleTypeCommandHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UpdateVehicleTypeDto> Handle(UpdateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var vehicleTypeUnamapped = _mapper.Map<VehicleType>(request);

            var vehicleType = await _vehicleTypeRepository.UpdateVehicleType(vehicleTypeUnamapped);

            var vehicleMapped = _mapper.Map<UpdateVehicleTypeDto>(vehicleType);

            return vehicleMapped;
        }
    }
}
