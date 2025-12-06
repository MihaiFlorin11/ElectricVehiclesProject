using AutoMapper;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.VehicleTypeDtos;
using Entities;
using MediatR;

namespace CQRS.VehicleTypeCommands
{
    public class DeleteVehicleTypeCommandHandler : IRequestHandler<DeleteVehicleTypeCommand, DeleteVehicleTypeDto>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;
        public DeleteVehicleTypeCommandHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DeleteVehicleTypeDto> Handle(DeleteVehicleTypeCommand request, CancellationToken cancellationToken)
        {
            var vehicleType = await _vehicleTypeRepository.DeleteVehicleType(request.Id);

            var vehicleTypeMapped = _mapper.Map<DeleteVehicleTypeDto>(vehicleType);

            return vehicleTypeMapped;
        }
    }
}
