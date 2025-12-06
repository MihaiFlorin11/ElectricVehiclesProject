using AutoMapper;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.VehicleTypeDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.VehicleTypeQueries
{
    public class GetVehicleTypeByIdQueryHandler : IRequestHandler<GetVehicleTypeByIdQuery, ViewVehicleTypeDto>
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public GetVehicleTypeByIdQueryHandler(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ViewVehicleTypeDto> Handle(GetVehicleTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(request.Id);

            var vehicleTypeMapped = _mapper.Map<ViewVehicleTypeDto>(vehicleType);

            return vehicleTypeMapped;
        }
    }
}
