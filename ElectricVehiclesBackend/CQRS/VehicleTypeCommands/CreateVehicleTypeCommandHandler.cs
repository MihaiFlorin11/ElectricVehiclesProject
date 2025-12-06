using AutoMapper;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.VehicleTypeDtos;
using Entities;
using MediatR;

namespace CQRS.VehicleTypeCommands
{
    public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommand, CreateVehicleTypeDto>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public CreateVehicleTypeCommandHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }

        public async Task<CreateVehicleTypeDto> Handle(CreateVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var vehicleTypeUnmapped = _mapper.Map<VehicleType>(request);

            var vehicleType = await _vehicleTypeRepository.AddVehicleType(vehicleTypeUnmapped);

            var vehicleTypeMapped = _mapper.Map<CreateVehicleTypeDto>(vehicleType);

            return vehicleTypeMapped;
        }
    }
}
