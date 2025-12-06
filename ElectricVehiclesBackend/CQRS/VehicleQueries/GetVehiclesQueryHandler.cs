using AutoMapper;
using Data.Repositories.VehicleRepositories;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.VehicleDtos;
using MediatR;

namespace CQRS.VehicleQueries
{
    public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, IEnumerable<ViewVehicleDto>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public GetVehiclesQueryHandler(IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ViewVehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await _vehicleRepository.GetVehiclesAsync();

            var vehicleTypes = await _vehicleTypeRepository.GetVehicleTypesAsync();

            var vehicleTypesToString = from vehicle in vehicles
                                       join vehicleType in vehicleTypes on
                                       vehicle.VehicleTypeId equals vehicleType.Id
                                       select vehicleType.Type;

            var vehiclesMapped = _mapper.Map<IEnumerable<ViewVehicleDto>>(vehicles);

            var index = -1;
            foreach (var vehicleMapped in vehiclesMapped) 
            {
                index++;
                vehicleMapped.VehicleType = vehicleTypesToString.ElementAt(index);
                vehicleMapped.RegisterDate = vehicleMapped.RegisterDate.Split('T')[0];
            }

            return vehiclesMapped;
        }
    }
}
