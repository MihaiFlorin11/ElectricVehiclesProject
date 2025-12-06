using AutoMapper;
using Data.Repositories.InvoiceRepositories;
using Data.Repositories.RentalRepositories;
using Data.Repositories.UserRepositories;
using Data.Repositories.VehicleRepositories;
using Data.Repositories.VehicleTypeRepositories;
using Dtos.RentalDtos;
using MediatR;

namespace CQRS.RentalQueries
{
    public class GetRentalsQueryHandler : IRequestHandler<GetRentalsQuery, IEnumerable<ViewRentalDto>>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetRentalsQueryHandler(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IUserRepository userRepository, IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository ?? throw new ArgumentNullException(nameof(rentalRepository));
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _vehicleTypeRepository = vehicleTypeRepository ?? throw new ArgumentNullException(nameof(vehicleTypeRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ViewRentalDto>> Handle(GetRentalsQuery request, CancellationToken cancellationToken)
        {
            List<ViewRentalDto> viewRentalDtos = new List<ViewRentalDto>();

            var rentals = await _rentalRepository.GetRentalsAsync();

            for (var i = 1; i <= rentals.Count(); i++)
            {
                var rental = await _rentalRepository.GetRentalByIdAsync(i);

                var vehicle = await _vehicleRepository.GetVehicleByIdAsync(rental.VehicleId);

                var vehicleType = await _vehicleTypeRepository.GetVehicleTypeByIdAsync(vehicle.VehicleTypeId);

                var user = await _userRepository.GetUserByIdAsync(rental.UserId);

                var invoice = await _invoiceRepository.GetInvoiceByIdAsync(rental.InvoiceId);

                var rentalMapped = _mapper.Map<ViewRentalDto>(rental);

                rentalMapped.VehicleType = vehicleType.Type;

                rentalMapped.Username = user.Username;

                rentalMapped.PaidInvoice = invoice.Paid;

                viewRentalDtos.Add(rentalMapped);
            }

            return viewRentalDtos;
        }
    }
}
